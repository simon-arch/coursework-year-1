using filemanager.Properties;
using System.Configuration;
using System.Globalization;
using System.Resources;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace filemanager
{
    public partial class Manager : Form
    {
        Mediator mediatorLeft = new Mediator();
        Mediator mediatorRight = new Mediator();

        DirectoryHandler directoryHandlerRightScreen = new DirectoryHandler();
        DirectoryHandler directoryHandlerLeftScreen = new DirectoryHandler();

        DisplayHandler displayHandlerRightScreen = new DisplayHandler();
        DisplayHandler displayHandlerLeftScreen = new DisplayHandler();

        FileWatcher watcherRightScreen = new FileWatcher();
        FileWatcher watcherLeftScreen = new FileWatcher();

        List<DirectoryHandler> directoryList = new List<DirectoryHandler>();
        List<DisplayHandler> displayList = new List<DisplayHandler>();
        List<FileWatcher> watcherList = new List<FileWatcher>();

        List<Mediator> mediatorList = new List<Mediator>();

        ExchangeBuffer exchangeBuffer = new ExchangeBuffer();

        Dictionary<string, ToolStripMenuItem> Controllers = new Dictionary<string, ToolStripMenuItem>();
        string[] defaultQuickBar = {
            "25, 20",
            "00, stk_Refresh, Ico_Refresh",
            "01, stk_GoUp, Ico_GoUp",
            "02, stk_separator, null",
            "03, stk_ViewDetails, Ico_ViewDetails",
            "04, stk_ViewSmallIcons, Ico_ViewSmallIcons",
            "05, stk_ViewList, Ico_ViewList",
            "06, stk_ViewTiles, Ico_ViewTiles",
            "07, stk_separator, null",
            "08, stk_InvertSelection, Ico_InvertSelection",
            "09, stk_PackZip, Ico_PackZip",
            "10, stk_UnpackAll, Ico_UnpackAll",
            "11, stk_separator, null",
            "12, stk_SearchFor, Ico_SearchFor",
            "13, stk_separator, null",
            "14, stk_DiskInfo, Ico_DiskInfo",
            "15, stk_Print, Ico_Print"
        };

        Dictionary<string, string> associated = new Dictionary<string, string>();
        static string currentIconPack = "none";
        public void InitQuickbar()
        {
            topToolStrip.Items.Clear();
            string[] lines = { "" };
            string[] prefs = { "" };
            string currPath = ConfigurationManager.AppSettings["Path_QuickBarIni"];
            try
            {
                lines = System.IO.File.ReadAllLines(currPath);
                prefs = lines[0].Split(", ");
            }
            catch
            {
                System.IO.File.Create(currPath).Close();
                System.IO.File.WriteAllLines(currPath, defaultQuickBar);
                lines = System.IO.File.ReadAllLines(currPath);
                prefs = lines[0].Split(", ");
            }

            try { topToolStrip.Size = new Size(topToolStrip.Size.Width, Int32.Parse(prefs[0])); }
            catch { topToolStrip.Size = new Size(topToolStrip.Size.Width, topToolStrip.Size.Height); }

            try { topToolStrip.ImageScalingSize = new Size(Int32.Parse(prefs[1]), Int32.Parse(prefs[1])); }
            catch { topToolStrip.ImageScalingSize = new Size(topToolStrip.ImageScalingSize.Width, topToolStrip.ImageScalingSize.Height); }

            foreach (string line in lines.Skip(1))
            {
                string[] data = line.Split(", ");
                string command = data[1];
                string icon = data[2];

                var btn = new ToolStripButton();
                if (command.StartsWith("stk_"))
                {
                    if (command == "stk_separator")
                    {
                        topToolStrip.Items.Add(new ToolStripSeparator());
                        continue;
                    }
                    else
                    {
                        btn.Click += (sender, e) =>
                        {
                            try { Controllers[command.Replace("stk_", "")].PerformClick(); }
                            catch { System.Media.SystemSounds.Hand.Play(); }
                        };
                    }
                }
                else
                {
                    btn.Click += (sender, e) =>
                    {
                        try { System.Diagnostics.Process.Start(command); }
                        catch { System.Media.SystemSounds.Hand.Play(); }
                    };
                }
                try { btn.Image = ((Icon)Resources.ResourceManager.GetObject(icon, Resources.Culture)).ToBitmap(); }
                catch { btn.Image = new Bitmap(16, 16); }
                btn.ImageScaling = ToolStripItemImageScaling.None;
                btn.ImageTransparentColor = Color.Black;
                btn.ToolTipText = Regex.Replace(command.Replace("stk_", ""), "([a-z])([A-Z])", "$1 $2"); ;
                topToolStrip.Items.Add(btn);
            }
        }

        public void InitCustomAssociations()
        {
            string jsonPath = ConfigurationManager.AppSettings["Path_CustomAssociations"];
            if (!System.IO.File.Exists(jsonPath)) System.IO.File.Create(jsonPath).Close();
            string jsonText = System.IO.File.ReadAllText(jsonPath);
            if (jsonText != string.Empty & jsonText != null)
            {
                associated = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonText);
                Controllers["Refresh"].PerformClick();
            }
        }
        public void InitCustomIcons(string packName)
        {
            if (packName == "none")
            {
                List<string> remove = fileIconList.Images.Keys.Cast<string>()
                        .Where(key => key.Contains("override_."))
                        .ToList();
                foreach (string key in remove)
                    fileIconList.Images.RemoveByKey(key);
                return;
            }

            string iconsPath = ConfigurationManager.AppSettings["Path_CustomIcons"];
            if (!Path.Exists(iconsPath)) System.IO.Directory.CreateDirectory(iconsPath);
            string target = Path.Combine(iconsPath, packName);
            if (!Path.Exists(target)) return;
            DirectoryInfo dir = new DirectoryInfo(target);
            foreach (FileInfo file in dir.GetFiles("*"))
                try { fileIconList.Images.Add($"override_.{Path.GetFileNameWithoutExtension(file.FullName)}", new Bitmap(file.FullName)); }
                catch { continue; }
            Controllers["Refresh"].PerformClick();
        }
        public void InitQuickAccess()
        {
            quickAccessList.SmallImageList = fileIconList;
            string path = ConfigurationManager.AppSettings["Path_QuickAccessIni"];
            if (!Path.Exists(path)) System.IO.File.Create(path).Close();
            string[] links = System.IO.File.ReadAllLines(path);
            foreach (string link in links)
            {
                if (!Path.Exists(link)) continue;
                ListViewItem target = new ListViewItem();
                FileAttributes attr = System.IO.File.GetAttributes(link);
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    Directory dir = new Directory(Path.GetFileName(link), link);
                    target.Text = $"[{dir.Name}]"; target.Tag = dir;
                    target.ImageKey = "directory.ico";
                }
                else
                {
                    FileInfo f = new FileInfo(link); File file = new File();
                    target.ImageKey = f.Extension;
                    if (f.Extension == ".exe")
                    {
                        string exename = f.Extension + DateTime.Now.Ticks;
                        Image icon = Icon.ExtractAssociatedIcon(f.FullName).ToBitmap();
                        fileIconList.Images.Add(exename, icon);
                        target.ImageKey = exename;
                    }
                    else if (!fileIconList.Images.ContainsKey(f.Extension))
                    {
                        Image icon = Icon.ExtractAssociatedIcon(f.FullName).ToBitmap();
                        fileIconList.Images.Add(f.Extension, icon);
                    }
                    file.Path = link;
                    file.Extension = f.Extension;
                    file.Name = Path.GetFileNameWithoutExtension(f.Name);
                    target.Text = file.Name;
                    target.Tag = file;
                }
                quickAccessList.Items.Add(target);
            }
        }
        public Manager()
        {
            InitializeComponent();
            // SYNC EVENTS
            ConfigurationManager.AppSettings.Set("Path_QuickBarIni", Path.Combine(System.IO.Directory.GetCurrentDirectory(), "quickbar.ini"));
            ConfigurationManager.AppSettings.Set("Path_QuickBarBackup", Path.Combine(System.IO.Directory.GetCurrentDirectory(), "quickbar_backup.ini"));
            ConfigurationManager.AppSettings.Set("Path_CustomIcons", Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Icons"));
            ConfigurationManager.AppSettings.Set("Path_CustomAssociations", Path.Combine(System.IO.Directory.GetCurrentDirectory(), "extensionAssociations.json"));
            ConfigurationManager.AppSettings.Set("Path_QuickAccessIni", Path.Combine(System.IO.Directory.GetCurrentDirectory(), "quickaccess.ini"));

            Controllers["InvertSelection"] = invertSelectionTool;
            Controllers["QuickAccessAdd"] = quickAccessAddTool;
            Controllers["QuickAccessRemove"] = quickAccessRemoveTool;

            Controllers["SortName"] = sortNameTool;
            Controllers["SortDate"] = sortDateTool;
            Controllers["SortSize"] = sortSizeTool;
            Controllers["SortExtension"] = sortExtensionTool;
            Controllers["SortReversed"] = reversedTool;

            Controllers["OpenConsole"] = openConsoleTool;
            Controllers["OpenPowershell"] = openPowershellTool;

            Controllers["ViewDetails"] = detailsTool;
            Controllers["ViewSmallIcons"] = smallIconsTool;
            Controllers["ViewList"] = listTool;
            Controllers["ViewTiles"] = tilesTool;

            Controllers["GoUp"] = goUpTool;
            Controllers["Print"] = printTool;
            Controllers["SearchFor"] = searchTool;

            Controllers["ShowAllFiles"] = showAllFilesTool;
            Controllers["ShowPrograms"] = showProgramsTool;
            Controllers["ShowCustom"] = showCustomTool;

            Controllers["CalculateSpace"] = calculateSpaceTool;
            Controllers["MultiRename"] = multiRenameTool;

            Controllers["SelectGroup"] = selectGroupTool;
            Controllers["UnselectGroup"] = unselectGroupTool;

            Controllers["CreateTab"] = createTabTool;
            Controllers["DeleteTab"] = deleteTabTool;

            Controllers["SelectAll"] = selectAllTool;
            Controllers["UnselectAll"] = unselectAllTool;
            Controllers["SelectExtensions"] = selectAllWithTheSameExtensionTool;
            Controllers["ClipSelected"] = copySelectedNamesToClipboardTool;
            Controllers["ClipWithPath"] = copyNamesWithPathToClipboardTool;
            Controllers["ClipWithExtensions"] = copyToClipboardWithExtensions;
            Controllers["ClipPathExtensions"] = copyToClipboardWithPathExtensions;

            Controllers["Refresh"] = refreshTool;
            Controllers["Rename"] = renameTool;
            Controllers["View"] = viewTool;
            Controllers["Edit"] = editTool;
            Controllers["Copy"] = copyTool;
            Controllers["Cut"] = cutTool;
            Controllers["Paste"] = pasteTool;
            Controllers["NewFolder"] = newFolderTool;
            Controllers["Delete"] = deleteTool;

            Controllers["CompareNames"] = compareFilenamesTool;
            Controllers["PackZip"] = packTool;
            Controllers["UnpackAll"] = unpackAllTool;

            Controllers["ChangeAttributes"] = changeAttributesTool;
            Controllers["OpenInExplorer"] = openInExplorerTool;

            Controllers["SaveSelection"] = saveSelectionTool;
            Controllers["RestoreSelection"] = restoreSelectionTool;
            Controllers["SelectionToFile"] = saveSelectionToFileTool;
            Controllers["LoadSelectionFile"] = loadSelectionFromFileTool;
            //

            // UNSYNC EVENTS
            Controllers["Exit"] = exitTool;
            Controllers["Desktop"] = desktopTool;
            Controllers["TargetTarget"] = sourceTargetEqualTool;
            Controllers["TargetSource"] = sourceTargetSwitchTool;
            Controllers["DiskInfo"] = diskInfoTool;
            Controllers["RecycleBin"] = binTool;
            Controllers["SystemProperties"] = systemPropertiesTool;

            Controllers["EditQuickBar"] = editQuickActionBarTool;
            Controllers["ReloadQuickBar"] = reloadQuickActionBarTool;

            Controllers["EditAssociations"] = editAssociationsTool;
            Controllers["ReloadAssociations"] = reloadAssociationsTool;

            Controllers["ViewCustomIcons"] = viewCustomIconsTool;
            Controllers["ReloadCustomIcons"] = reloadCustomIconsTool;

            Controllers["VerticalArrangement"] = verticalArrangementTool;
            //

            displayList.Add(displayHandlerLeftScreen);
            displayList.Add(displayHandlerRightScreen);

            directoryList.Add(directoryHandlerLeftScreen);
            directoryList.Add(directoryHandlerRightScreen);

            watcherList.Add(watcherLeftScreen);
            watcherList.Add(watcherRightScreen);

            mediatorList.Add(mediatorLeft);
            mediatorList.Add(mediatorRight);

            mediatorLeft.Display = displayHandlerLeftScreen;
            mediatorLeft.Navigator = directoryHandlerLeftScreen;
            mediatorLeft.Observer = watcherLeftScreen;

            mediatorRight.Display = displayHandlerRightScreen;
            mediatorRight.Navigator = directoryHandlerRightScreen;
            mediatorRight.Observer = watcherRightScreen;

            watcherList[0].Init(mediatorLeft, this);
            watcherList[1].Init(mediatorRight, this);

            InitializeHandlers(mediatorLeft, listView1, tabControl1);
            InitializeSharedEvents(mediatorLeft);
            InitializeUserControllerEvents(mediatorLeft);

            InitializeHandlers(mediatorRight, listView2, tabControl2);
            InitializeSharedEvents(mediatorRight);
            InitializeUserControllerEvents(mediatorRight);

            InitializeUniqueEvents();
            LoadSettings(displayList, directoryList, watcherList);

            displayList[0].Focused = true;
            quickAccessList.SmallImageList = fileIconList;
            displayList.ForEach(x => x.SortType = SortType.name);

            DoubleBuffering.SetDoubleBuffering(displayList[0].ListView, true);
            DoubleBuffering.SetDoubleBuffering(displayList[1].ListView, true);

            mediatorLeft.Refresh();
            mediatorRight.Refresh();

            InitContextEvents();
            InitQuickbar();
            InitCustomAssociations();
            InitCustomIcons(currentIconPack);
            InitQuickAccess();
        }
    }
}
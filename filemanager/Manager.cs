using filemanager.Dialogs;
using filemanager.Properties;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Text.Json;

namespace filemanager
{
    public partial class Manager : Form
    {
        DirectoryHandler directoryHandlerRightScreen = new DirectoryHandler();
        DirectoryHandler directoryHandlerLeftScreen = new DirectoryHandler();

        DisplayHandler displayHandlerRightScreen = new DisplayHandler();
        DisplayHandler displayHandlerLeftScreen = new DisplayHandler();

        FileWatcher watcherRightScreen = new FileWatcher();
        FileWatcher watcherLeftScreen = new FileWatcher();

        List<DirectoryHandler> directoryList = new List<DirectoryHandler>();
        List<DisplayHandler> displayList = new List<DisplayHandler>();
        List<FileWatcher> watcherList = new List<FileWatcher>();

        ExchangeBuffer exchangeBuffer = new ExchangeBuffer();
        LoggerHandler loggerHandler = new LoggerHandler();

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
            "08, stk_InvertSelection, Ico_Refresh",
            "09, stk_ZipAll, Ico_Refresh", //not ready
            "10, stk_UnzipAll, Ico_Refresh", //not ready
            "11, stk_separator, null",
            "12, stk_SearchFor, Ico_Refresh",
            "13, notepad.exe, Ico_Refresh",
            "14, stk_separator, null",
            "15, stk_DiskInfo, Ico_Refresh", //not ready
            "16, stk_Print, Ico_Refresh",
            "17, stk_RecycleBin, Ico_Refresh", //not ready
        };

        Dictionary<string, string> associated = new Dictionary<string, string>();
        Dictionary<string, string> icons = new Dictionary<string, string>();

        public void InitQuickbar()
        {
            topToolStrip.Items.Clear();
            string[] lines = { "" };
            string[] prefs = { "" };
            string currPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "quickbar.ini");
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
                btn.Image = ((Icon)Resources.ResourceManager.GetObject(icon, Resources.Culture)).ToBitmap();
                btn.ImageScaling = ToolStripItemImageScaling.None;
                topToolStrip.Items.Add(btn);
            }
        }

        public void InitCustomResources(string filename, int type)
        {
            string jsonPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(),
                filename);
            if (!System.IO.File.Exists(jsonPath)) System.IO.File.Create(jsonPath).Close();
            string jsonText = System.IO.File.ReadAllText(jsonPath);
            if (jsonText != string.Empty & jsonText != null)
            {
                if (type == 0) associated = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonText);
                if (type == 1) icons = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonText);
                Controllers["Refresh"].PerformClick();
            }
        }
        public Manager()
        {
            InitializeComponent();

            // SYNC EVENTS
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
            Controllers["UnelectAll"] = unselectAllTool;
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
            //

            //
            InitQuickbar();

            displayList.Add(displayHandlerLeftScreen);
            displayList.Add(displayHandlerRightScreen);

            directoryList.Add(directoryHandlerLeftScreen);
            directoryList.Add(directoryHandlerRightScreen);

            watcherList.Add(watcherLeftScreen);
            watcherList.Add(watcherRightScreen);

            watcherList[0].Init();
            watcherList[0].DisplayHandler = displayList[0];
            watcherList[0].DirectoryHandler = directoryList[0];
            watcherList[0].Form = this;
            watcherList[1].Init();
            watcherList[1].DisplayHandler = displayList[1];
            watcherList[1].DirectoryHandler = directoryList[1];
            watcherList[1].Form = this;

            InitializeHandlers(displayHandlerLeftScreen, listView1, tabControl1, driveComboBox,
            selectedFileSizeLabel, freeSpaceLabel, imagePreviewBox, fileIconList, progressBar,
            previewBoxTabControl, searchTextBox);
            InitializeSharedEvents(displayHandlerLeftScreen, directoryHandlerLeftScreen, watcherLeftScreen);

            InitializeHandlers(displayHandlerRightScreen, listView2, tabControl2, driveComboBox,
            selectedFileSizeLabel, freeSpaceLabel, imagePreviewBox, fileIconList, progressBar,
            previewBoxTabControl, searchTextBox);
            InitializeSharedEvents(displayHandlerRightScreen, directoryHandlerRightScreen, watcherRightScreen);

            LoadSettings(displayList, directoryList, watcherList);
            InitializeUniqueEvents();

            loggerHandler.rtb = logTextBox;
            displayList[0].Focused = true;
            quickAccessList.SmallImageList = fileIconList;
            displayList.ForEach(x => x.SortType = SortType.name);
            loggerHandler.Log(LogCategory.start);

            DoubleBuffering.SetDoubleBuffering(displayList[0].ListView, true);
            DoubleBuffering.SetDoubleBuffering(displayList[1].ListView, true);

            Focus(displayList[0]); displayList[0].setView(1);
            Focus(displayList[1]); displayList[1].setView(1);

            InitContextEvents();

            Refresh(displayHandlerLeftScreen, directoryHandlerLeftScreen);
            Refresh(displayHandlerRightScreen, directoryHandlerRightScreen);

            InitCustomResources("extensionAssociations.json", 0);
            InitCustomResources("customIcons.json", 1);

            foreach (KeyValuePair<string, string> data in icons)
            {
                fileIconList.Images.Add($"override_{data.Key}", new Bitmap(data.Value));
            }
            Controllers["Refresh"].PerformClick();
        }
    }
}
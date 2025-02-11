using filemanager.Properties;
using System.Configuration;
using System.Diagnostics;
using System.Media;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace filemanager;

public partial class Manager : Form
{
    private const string OverridePrefix = "override_.";
    private const string StkPrefix = "stk_";
    private const string ExeExtension = ".exe";

    private const string DefaultIconPack = "none";
    private static string currentIconPack = DefaultIconPack;

    private static readonly string[] DefaultQuickBar = {
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

    private readonly Mediator _mediatorLeft = new();
    private readonly Mediator _mediatorRight = new();

    private readonly DirectoryHandler _directoryHandlerRightScreen = new();
    private readonly DirectoryHandler _directoryHandlerLeftScreen = new();

    private readonly DisplayHandler _displayHandlerRightScreen = new();
    private readonly DisplayHandler _displayHandlerLeftScreen = new();

    private readonly FileWatcher _watcherRightScreen = new();
    private readonly FileWatcher _watcherLeftScreen = new();

    private readonly List<DirectoryHandler> _directoryList = new();
    private readonly List<DisplayHandler> _displayList = new();
    private readonly List<FileWatcher> _watcherList = new();

    private readonly List<Mediator> _mediatorList = new();

    private readonly ExchangeBuffer _exchangeBuffer = new();

    private readonly Dictionary<string, ToolStripMenuItem> _controllers = new();

    private Dictionary<string, string> _associated = new();

    public Manager()
    {
        InitializeComponent();
        // SYNC EVENTS
        ConfigurationManager.AppSettings.Set("Path_QuickBarIni", Path.Combine(System.IO.Directory.GetCurrentDirectory(), "quickbar.ini"));
        ConfigurationManager.AppSettings.Set("Path_QuickBarBackup", Path.Combine(System.IO.Directory.GetCurrentDirectory(), "quickbar_backup.ini"));
        ConfigurationManager.AppSettings.Set("Path_CustomIcons", Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Icons"));
        ConfigurationManager.AppSettings.Set("Path_CustomAssociations", Path.Combine(System.IO.Directory.GetCurrentDirectory(), "extensionAssociations.json"));
        ConfigurationManager.AppSettings.Set("Path_QuickAccessIni", Path.Combine(System.IO.Directory.GetCurrentDirectory(), "quickaccess.ini"));

        _controllers["InvertSelection"] = invertSelectionTool;
        _controllers["QuickAccessAdd"] = quickAccessAddTool;
        _controllers["QuickAccessRemove"] = quickAccessRemoveTool;

        _controllers["SortName"] = sortNameTool;
        _controllers["SortDate"] = sortDateTool;
        _controllers["SortSize"] = sortSizeTool;
        _controllers["SortExtension"] = sortExtensionTool;
        _controllers["SortReversed"] = reversedTool;

        _controllers["OpenConsole"] = openConsoleTool;
        _controllers["OpenPowershell"] = openPowershellTool;

        _controllers["ViewDetails"] = detailsTool;
        _controllers["ViewSmallIcons"] = smallIconsTool;
        _controllers["ViewList"] = listTool;
        _controllers["ViewTiles"] = tilesTool;

        _controllers["GoUp"] = goUpTool;
        _controllers["Print"] = printTool;
        _controllers["SearchFor"] = searchTool;

        _controllers["ShowAllFiles"] = showAllFilesTool;
        _controllers["ShowPrograms"] = showProgramsTool;
        _controllers["ShowCustom"] = showCustomTool;

        _controllers["CalculateSpace"] = calculateSpaceTool;
        _controllers["MultiRename"] = multiRenameTool;

        _controllers["SelectGroup"] = selectGroupTool;
        _controllers["UnselectGroup"] = unselectGroupTool;

        _controllers["CreateTab"] = createTabTool;
        _controllers["DeleteTab"] = deleteTabTool;

        _controllers["SelectAll"] = selectAllTool;
        _controllers["UnselectAll"] = unselectAllTool;
        _controllers["SelectExtensions"] = selectAllWithTheSameExtensionTool;
        _controllers["ClipSelected"] = copySelectedNamesToClipboardTool;
        _controllers["ClipWithPath"] = copyNamesWithPathToClipboardTool;
        _controllers["ClipWithExtensions"] = copyToClipboardWithExtensions;
        _controllers["ClipPathExtensions"] = copyToClipboardWithPathExtensions;

        _controllers["Refresh"] = refreshTool;
        _controllers["Rename"] = renameTool;
        _controllers["View"] = viewTool;
        _controllers["Edit"] = editTool;
        _controllers["Copy"] = copyTool;
        _controllers["Cut"] = cutTool;
        _controllers["Paste"] = pasteTool;
        _controllers["NewFolder"] = newFolderTool;
        _controllers["Delete"] = deleteTool;

        _controllers["CompareNames"] = compareFilenamesTool;
        _controllers["PackZip"] = packTool;
        _controllers["UnpackAll"] = unpackAllTool;

        _controllers["ChangeAttributes"] = changeAttributesTool;
        _controllers["OpenInExplorer"] = openInExplorerTool;

        _controllers["SaveSelection"] = saveSelectionTool;
        _controllers["RestoreSelection"] = restoreSelectionTool;
        _controllers["SelectionToFile"] = saveSelectionToFileTool;
        _controllers["LoadSelectionFile"] = loadSelectionFromFileTool;
        //

        // UNSYNC EVENTS
        _controllers["Exit"] = exitTool;
        _controllers["Desktop"] = desktopTool;
        _controllers["TargetTarget"] = sourceTargetEqualTool;
        _controllers["TargetSource"] = sourceTargetSwitchTool;
        _controllers["DiskInfo"] = diskInfoTool;
        _controllers["RecycleBin"] = binTool;
        _controllers["SystemProperties"] = systemPropertiesTool;

        _controllers["EditQuickBar"] = editQuickActionBarTool;
        _controllers["ReloadQuickBar"] = reloadQuickActionBarTool;

        _controllers["EditAssociations"] = editAssociationsTool;
        _controllers["ReloadAssociations"] = reloadAssociationsTool;

        _controllers["ViewCustomIcons"] = viewCustomIconsTool;
        _controllers["ReloadCustomIcons"] = reloadCustomIconsTool;

        _controllers["VerticalArrangement"] = verticalArrangementTool;
        //

        _displayList.Add(_displayHandlerLeftScreen);
        _displayList.Add(_displayHandlerRightScreen);

        _directoryList.Add(_directoryHandlerLeftScreen);
        _directoryList.Add(_directoryHandlerRightScreen);

        _watcherList.Add(_watcherLeftScreen);
        _watcherList.Add(_watcherRightScreen);

        _mediatorList.Add(_mediatorLeft);
        _mediatorList.Add(_mediatorRight);

        _mediatorLeft.Display = _displayHandlerLeftScreen;
        _mediatorLeft.Navigator = _directoryHandlerLeftScreen;
        _mediatorLeft.Observer = _watcherLeftScreen;

        _mediatorRight.Display = _displayHandlerRightScreen;
        _mediatorRight.Navigator = _directoryHandlerRightScreen;
        _mediatorRight.Observer = _watcherRightScreen;

        _watcherList[0].Init(_mediatorLeft, this);
        _watcherList[1].Init(_mediatorRight, this);

        InitializeHandlers(_mediatorLeft, listView1, tabControl1);
        InitializeSharedEvents(_mediatorLeft);
        InitializeUserControllerEvents(_mediatorLeft);

        InitializeHandlers(_mediatorRight, listView2, tabControl2);
        InitializeSharedEvents(_mediatorRight);
        InitializeUserControllerEvents(_mediatorRight);

        InitializeUniqueEvents();
        LoadSettings(_displayList, _directoryList, _watcherList);

        _displayList[0].Focused = true;
        quickAccessList.SmallImageList = fileIconList;
        _displayList.ForEach(x => x.SortType = SortType.name);

        DoubleBuffering.SetDoubleBuffering(_displayList[0].ListView, true);
        DoubleBuffering.SetDoubleBuffering(_displayList[1].ListView, true);

        _mediatorLeft.Refresh();
        _mediatorRight.Refresh();

        InitContextEvents();
        InitQuickBar();
        InitCustomAssociations();
        InitCustomIcons(currentIconPack);
        InitQuickAccess();
    }

    public void InitQuickBar()
    {
        topToolStrip.Items.Clear();

        var currentPath = GetConfig("Path_QuickBarIni");
        if (!System.IO.File.Exists(currentPath))
        {
            System.IO.File.Create(currentPath).Close();
            System.IO.File.WriteAllLines(currentPath, DefaultQuickBar);
        }

        var lines = System.IO.File.ReadAllLines(currentPath);

        SetQuickBarPreferences(lines.FirstOrDefault());

        foreach (var line in lines.Skip(1))
        {
            AddQuickBarButton(line);
        }
    }

    public void InitCustomAssociations()
    {
        var jsonPath = GetConfig("Path_CustomAssociations");
        CreateFileIfNotExist(jsonPath);

        var jsonText = System.IO.File.ReadAllText(jsonPath);
        if (string.IsNullOrEmpty(jsonText))
        {
            return;
        }
        _associated = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonText) ?? new();
        _controllers["Refresh"].PerformClick();
    }

    public void InitCustomIcons(string packName)
    {
        if (packName == DefaultIconPack)
        {
            RemoveOverrideIcons();
            return;
        }

        var iconsPath = GetConfig("Path_CustomIcons");
        var target = Path.Combine(iconsPath, packName);
        if (!Path.Exists(target))
        {
            return;
        }

        var directory = new DirectoryInfo(target);
        foreach (var file in directory.GetFiles("*"))
        {
            if (file.Exists)
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FullName);
                fileIconList.Images.Add($"{OverridePrefix}{fileName}", new Bitmap(file.FullName));
            }
        }

        _controllers["Refresh"].PerformClick();
    }

    public void InitQuickAccess()
    {
        quickAccessList.SmallImageList = fileIconList;

        var path = GetConfig("Path_QuickAccessIni");
        CreateFileIfNotExist(path);

        var links = System.IO.File.ReadAllLines(path);

        foreach (var link in links)
        {
            if (!Path.Exists(link))
            {
                continue;
            }

            AddQuickAccessItem(link);
        }
    }

    private void AddQuickAccessItem(string path)
    {
        var target = new ListViewItem();
        var fileInfo = new FileInfo(path);
        var isDirectory = fileInfo.Attributes.HasFlag(FileAttributes.Directory);

        if (isDirectory)
        {
            AddDirectoryItem(path, target);
        }
        else
        {
            AddFileItem(fileInfo, path, target);
        }

        quickAccessList.Items.Add(target);
    }

    private void AddDirectoryItem(string path, ListViewItem target)
    {
        var directory = new Directory(Path.GetFileName(path), path);
        target.Text = $"[{directory.Name}]";
        target.Tag = directory;
        target.ImageKey = "directory.ico";
    }

    private void AddFileItem(FileInfo fileInfo, string path, ListViewItem target)
    {
        var file = new File()
        {
            Path = path,
            Extension = fileInfo.Extension,
            Name = Path.GetFileNameWithoutExtension(fileInfo.Name),
        };

        target.Text = file.Name;
        target.Tag = file;
        target.ImageKey = file.Extension;

        AddFileIcon(fileInfo);
    }

    private void AddFileIcon(FileInfo fileInfo)
    {
        if (fileInfo.Extension == ExeExtension)
        {
            var extension = $"{fileInfo.Extension}{DateTime.Now.Ticks}";
            var icon = Icon.ExtractAssociatedIcon(fileInfo.FullName)!.ToBitmap();
            fileIconList.Images.Add(extension, icon);
        }
        else if (!fileIconList.Images.ContainsKey(fileInfo.Extension))
        {
            var icon = Icon.ExtractAssociatedIcon(fileInfo.FullName)!.ToBitmap();
            fileIconList.Images.Add(fileInfo.Extension, icon);
        }
    }

    private void RemoveOverrideIcons()
    {
        var remove = fileIconList.Images.Keys
            .Cast<string>()
            .Where(key => key.Contains(OverridePrefix))
            .ToList();

        foreach (var key in remove)
        {
            fileIconList.Images.RemoveByKey(key);
        }
    }

    private void SetQuickBarPreferences(string? preferenceLine)
    {
        if (string.IsNullOrEmpty(preferenceLine))
        {
            return;
        }
        var preferences = preferenceLine.Split(", ");

        topToolStrip.Size = new Size(
           topToolStrip.Size.Width,
           ParseOrDefault(preferences[0], topToolStrip.Size.Height));

        topToolStrip.ImageScalingSize = new Size(
            ParseOrDefault(preferences[1], topToolStrip.ImageScalingSize.Width),
            ParseOrDefault(preferences[1], topToolStrip.ImageScalingSize.Height));
    }

    private void AddQuickBarButton(string line)
    {
        var data = line.Split(", ");
        var command = data[1];
        var icon = data[2];

        if (command == "stk_separator")
        {
            topToolStrip.Items.Add(new ToolStripSeparator());
            return;
        }

        var button = new ToolStripButton()
        {
            Image = (Resources.ResourceManager.GetObject(icon, Resources.Culture) as Icon)?.ToBitmap() ?? new Bitmap(16, 16),
            ImageScaling = ToolStripItemImageScaling.None,
            ImageTransparentColor = Color.Black,
            ToolTipText = Regex.Replace(command.Replace(StkPrefix, string.Empty), "([a-z])([A-Z])", "$1 $2"),
        };

        button.Click += (s, e) => ExecuteCommand(command);
        topToolStrip.Items.Add(button);
    }

    private void ExecuteCommand(string command)
    {
        try
        {
            if (command.StartsWith(StkPrefix))
            {
                _controllers[command.Replace(StkPrefix, string.Empty)].PerformClick();
            }
            else
            {
                Process.Start(command);
            }
        }
        catch
        {
            SystemSounds.Hand.Play();
        }
    }

    private static void CreateFileIfNotExist(string path)
    {
        if (!System.IO.File.Exists(path))
        {
            System.IO.File.Create(path).Close();
        }
    }

    private static int ParseOrDefault(string value, int defaultValue) => 
        int.TryParse(value, out var result) ? result : defaultValue;

    private static string GetConfig(string key) =>
        ConfigurationManager.AppSettings[key] ?? throw new InvalidOperationException($"Missing config key: {key}");
}
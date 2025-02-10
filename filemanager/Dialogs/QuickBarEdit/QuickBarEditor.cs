using filemanager.Dialogs.QuickBarEdit.Models;
using filemanager.Dialogs.QuickBarEdit.Providers;
using filemanager.Dialogs.QuickBarEdit.Settings;
using filemanager.Properties;
using System.Configuration;
using System.Globalization;

namespace filemanager.Dialogs;

public partial class QuickBarEditor : Form
{
    private const string StkPrefix = "stk_";
    private const string ExeExtension = ".exe";

    private readonly string _rootPath;
    private readonly string _backupPath;

    private readonly Dictionary<string, ToolStripMenuItem> _stkFuncs;
    private readonly QuickBarSettingsProvider _settingsProvider;
    private readonly QuickBarResourceProvider _resourceProvider;

    public QuickBarEditor(Dictionary<string, ToolStripMenuItem> stkFuncs)
    {
        InitializeComponent();

        _rootPath = ConfigurationManager.AppSettings["Path_QuickBarIni"]!;
        _backupPath = ConfigurationManager.AppSettings["Path_QuickBarBackup"]!;

        _stkFuncs = stkFuncs;
        _settingsProvider = new QuickBarSettingsProvider(_rootPath, _backupPath);
        _resourceProvider = new QuickBarResourceProvider(Resources.ResourceManager, CultureInfo.CurrentUICulture);
        
        MaximumSize = new Size(int.MaxValue, this.Height);
        
        LoadResources();
        LoadSetting();
        AttachEventHandlers();
    }

    #region Initialization

    private void LoadResources()
    {
        imageList.Images.Clear();
        var iconResources = _resourceProvider.LoadIcons();

        foreach ( var resource in iconResources)
        {
            imageList.Images.Add(resource.Icon);
            iconSelectionList.Items.Add(new ListViewItem()
            {
                ImageIndex = resource.ImageIndex,
                Text = resource.ResourceKey,
            });
        }
    }

    private void LoadSetting()
    {
        var settings = _settingsProvider.Load();

        toolBarSizeText.Text = settings.ToolBarSize.ToString();
        imageSizeText.Text = settings.ImageSize.ToString();

        iniPathTextBox.Text = _rootPath;
        iniPathTextBox.Select(iniPathTextBox.Text.Length, 0);

        previewList.Items.AddRange(settings.Buttons.Select(button => new ListViewItem()
        {
            Text = button.Command,
            Tag = button,
            ImageIndex = iconSelectionList.FindItemWithText(button.Icon)?.Index ?? -1,
        }).ToArray());
    }

    private void AttachEventHandlers()
    {
        searchCommands.Click += (s, e) => ShowContextMenu(commandTextBox, _stkFuncs);
        addElement.Click += (s, e) => ExecuteOnSelection(iconSelectionList, AddQuickBarElement);
        insertSeparator.Click += (s, e) => InsertSeparator();
        replaceElement.Click += (s, e) => ExecuteOnSelection(previewList, ReplaceElement);
        deleteElement.Click += (s, e) => ExecuteOnSelection(previewList, DeleteElement);
        openIniPath.Click += (s, e) => ProcessCall.RunProcess("explorer.exe", _rootPath);
        okButton.Click += (s, e) => SaveAndClose();
        cancelButton.Click += (s, e) => DialogResult = DialogResult.Cancel;

        SetupCommandHandlers();

        static void ExecuteOnSelection(ListView listView, Action action)
        {
            if (listView.SelectedItems.Count != 0)
            {
                action();
            }
        }
    }

    private void SetupCommandHandlers()
    {
        previewList.SelectedIndexChanged += (s, e) =>
        {
            if (previewList.SelectedItems.Count > 0)
            {
                var button = previewList.SelectedItems[0].Tag as QuickBarButton;
                commandTextBox.Text = button?.Command;
            }
        };

        commandTextBox.TextChanged += (s, e) =>
        {
            if (commandTextBox.Text.StartsWith(StkPrefix))
                isAction.PerformClick();
            else if (commandTextBox.Text.EndsWith(ExeExtension))
                isProcess.PerformClick();
        };

        isAction.Click += (s, e) =>
        {
            if (commandTextBox.Text.EndsWith(ExeExtension))
                commandTextBox.Text = commandTextBox.Text.Replace(ExeExtension, string.Empty);

            if (!commandTextBox.Text.StartsWith(StkPrefix))
                commandTextBox.Text = $"{StkPrefix}{commandTextBox.Text}";
        };

        isProcess.Click += (s, e) =>
        {
            if (commandTextBox.Text.StartsWith(StkPrefix))
                commandTextBox.Text = commandTextBox.Text.Replace(StkPrefix, string.Empty);

            if (!commandTextBox.Text.EndsWith(ExeExtension))
                commandTextBox.Text = $"{commandTextBox.Text}{ExeExtension}";
        };
    }

    #endregion Initialization

    #region Form Events

    private void ShowContextMenu(TextBox textBox, Dictionary<string, ToolStripMenuItem> stkFuncs)
    {
        var context = new ContextMenuStrip();
        foreach (var (key, value) in stkFuncs)
        {
            var item = new ToolStripMenuItem();
            item.Text = value.ToString();
            item.Click += (sender, e) => textBox.Text = $"stk_{key}";
            context.Items.Add(item);
        }
        context.Show(Cursor.Position);
    }

    private void SaveAndClose()
    {
        if (isBackupOld.Checked)
        {
            _settingsProvider.BackupOld();
        }

        var toolBarSize = int.Parse(toolBarSizeText.Text);
        var imageSize = int.Parse(imageSizeText.Text);
        var buttons = previewList.Items
            .Cast<ListViewItem>()
            .Select(item => (QuickBarButton)item.Tag)
            .ToList();

        var settings = new QuickBarSettings(toolBarSize, imageSize, buttons);

        _settingsProvider.Save(settings);

        DialogResult = DialogResult.OK;
    }

    #endregion Form Events

    #region Element Events

    private void AddQuickBarElement()
    {
        var icon = iconSelectionList.SelectedItems[0].Text;
        var button = new QuickBarButton()
        {
            Icon = icon,
            ImageIndex = iconSelectionList.SelectedIndices[0],
            Command = commandTextBox.Text.Trim().Replace("stk_", "").Replace(".exe", "") == ""
                ? icon.Replace("Ico_", "stk_")
                : commandTextBox.Text,
        };
        var item = new ListViewItem()
        {
            ImageIndex = button.ImageIndex,
            Text = button.Command,
            Tag = button,
        };
        previewList.Items.Add(item);
    }

    private void InsertSeparator()
    {
        var button = new QuickBarButton
        {
            Command = "stk_separator",
            Icon = "null"
        };

        var item = new ListViewItem
        {
            Text = "|",
            Tag = button
        };
        previewList.Items.Add(item);
    }

    private void ReplaceElement()
    {
        var target = previewList.SelectedItems[0];

        if (target.Tag is not QuickBarButton button )
        {
            return;
        }
        
        button.Command = commandTextBox.Text;
        target.Text = button.Command;
        
        if (iconSelectionList.SelectedItems.Count > 0)
        {
            target.ImageIndex = iconSelectionList.SelectedIndices[0];
            button.Icon = iconSelectionList.SelectedItems[0].Text;
        }
        target.Tag = button;
    }

    private void DeleteElement()
    {
        previewList.Items.RemoveAt(previewList.SelectedIndices[0]);
    }

    #endregion Element Events
}

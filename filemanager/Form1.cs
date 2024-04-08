using filemanager.Resources;
using System.Text.Json;

namespace filemanager
{
    public partial class Form1 : Form
    {
        DirectoryHandler directoryHandler = new DirectoryHandler();
        DisplayHandler displayHandler = new DisplayHandler();
        ExchangeBuffer exchangeBuffer = new ExchangeBuffer();
        ProcessHandler processHandler = new ProcessHandler();

        public Form1()
        {
            InitializeComponent();
            InitializeHandlers();
            InitializeEvents();
            LoadSettings();
            Refresh();
        }
        private void Refresh()
        {
            directoryHandler.PopulateDirectory();
            displayHandler.populateList();
            displayHandler.populateDrives();
            displayHandler.getFileInfo();

            displayHandler.SelectDrive();
            displayHandler.StorageSize();
            displayHandler.Preview("clear");
        }
        private void InitializeHandlers()
        {
            displayHandler.ListView = listView1;
            displayHandler.TabControl = tabControl1;
            displayHandler.ComboBox = comboBox1;
            displayHandler.Label = label1;
            displayHandler.UsedStorage = label2;
            displayHandler.PictureBox = pictureBox1;
            displayHandler.ImageList = imageList1;
            displayHandler.ProgressBar = progressBar;
            displayHandler.PreviewBox = tabControl2;
            displayHandler.TextBox = searchTextBox;
            DoubleBuffering.SetDoubleBuffering(displayHandler.ListView, true);
            displayHandler.setView(1);
        }
        private void LoadSettings()
        {
            string json = System.IO.File.ReadAllText(
            Path.Combine(System.IO.Directory.GetCurrentDirectory(),
            @"..\..\..\Resources\appsettings.json"));
            UserSettings defaultSettings = new UserSettings();
            UserSettings userSettings;
            try
            {
                userSettings = JsonSerializer.Deserialize<UserSettings>(json);
            }
            catch (Exception ex)
            {
                userSettings = defaultSettings;
                MessageBox.Show(ex.Message, "JSON error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string startpath = userSettings.StartupFolder;
            displayHandler.ShowExtensions = userSettings.ShowExtensions;
            displayHandler.ShowHidden = userSettings.ShowHidden;
            GoTo(new RootDirectory("dir", startpath));
        }
        private void SaveSettings()
        {
            UserSettings settings = new UserSettings
            {
                StartupFolder = displayHandler.RootDirectory.Path,
                ShowExtensions = displayHandler.ShowExtensions,
                ShowHidden = displayHandler.ShowHidden,
            };

            string json = JsonSerializer.Serialize(settings);
            System.IO.File.WriteAllText(
            Path.Combine(System.IO.Directory.GetCurrentDirectory(),
            @"..\..\..\Resources\appsettings.json"), json);
        }
        private void InitializeEvents()
        {
            // FORM EVENTS
            this.FormClosed += (sender, e) => SaveSettings();
            //

            // DISPLAY HANDLER EVENTS
            displayHandler.ListView.Click += OnClick;
            displayHandler.ListView.DoubleClick += OnDoubleClick;
            displayHandler.ListView.SelectedIndexChanged += OnClick;
            displayHandler.ListView.SelectedIndexChanged += (sender, e) => { displayHandler.getFileInfo(); };

            displayHandler.TabControl.SelectedIndexChanged += (sender, e) =>
            {
                displayHandler.getFileInfo();
                displayHandler.CreateTab(true, OnClick, OnDoubleClick);
                if (System.IO.Directory.Exists(displayHandler.TabControl.SelectedTab.Tag!.ToString()!))
                {
                    directoryHandler.RootDirectory.Path = displayHandler.TabControl.SelectedTab.Tag!.ToString()!;
                    displayHandler.ListView = (ListView)displayHandler.TabControl.SelectedTab.Controls[0];
                    Refresh();
                }
                else
                {
                    displayHandler.DeleteTab();
                }
            };

            displayHandler.ComboBox.SelectionChangeCommitted += (sender, e) =>
            {
                directoryHandler.RootDirectory.Path = displayHandler.ComboBox.SelectedItem.ToString()!;
                displayHandler.TabControl.SelectedTab.Tag = directoryHandler.RootDirectory.Path;
                Refresh();
            };
            //

            // TEMP TEMP TEMP TEMP TEMP
            displayHandler.PictureBox.Click += (sender, e) =>
            {
                if (displayHandler.PictureBox.Image != null)
                {
                    processHandler.RunProcess("explorer", displayHandler.PictureBox.ImageLocation);
                }
            };
            // TEMP TEMP TEMP TEMP TEMP

            // SHOW TAB
            showHiddenFoldersTool.Click += (sender, e) => { displayHandler.ShowHidden = showHiddenFoldersTool.Checked; Refresh(); };
            showExtensionsTool.Click += (sender, e) => { displayHandler.ShowExtensions = showExtensionsTool.Checked; Refresh(); };
            //

            // TABS TAB
            createTabTool.Click += (sender, e) => { displayHandler.CreateTab(false, OnClick, OnDoubleClick); };
            deleteTabTool.Click += (sender, e) => { displayHandler.DeleteTab(); };
            //

            // MARK TAB
            selectAllTool.Click += (sender, e) => { displayHandler.SelectAll(); };
            unselectAllTool.Click += (sender, e) => { displayHandler.UnselectAll(); };
            selectAllWithTheSameExtensionTool.Click += (sender, e) => { displayHandler.SelectAllWithTheSameExtension(); };
            copySelectedNamesToClipboardTool.Click += (sender, e) => { displayHandler.CopyNamesToClipboard(false); };
            copyNamesWithPathToClipboardTool.Click += (sender, e) => { displayHandler.CopyNamesToClipboard(true); };
            //

            // TOOL STRIP
            quickRefreshTool.Click += (sender, e) => { Refresh(); };
            goUpTool.Click += (sender, e) =>
            {
                if (Path.GetPathRoot(directoryHandler.RootDirectory.Path) != directoryHandler.RootDirectory.Path)
                {
                    RootDirectory root = new RootDirectory("dir", Path.GetDirectoryName(directoryHandler.RootDirectory.Path));
                    GoTo(root);
                }
            };

            listViewSetView1.Click += (sender, e) => { displayHandler.setView(1); };
            listViewSetView2.Click += (sender, e) => { displayHandler.setView(2); };
            listViewSetView3.Click += (sender, e) => { displayHandler.setView(3); };
            listViewSetView4.Click += (sender, e) => { displayHandler.setView(4); };
            invertSelectionTool.Click += (sender, e) => { displayHandler.InvertSelection(); };
            zipTool.Click += (sender, e) => { directoryHandler.ZipArchive(displayHandler.ListView.SelectedItems); };
            unzipTool.Click += (sender, e) => { directoryHandler.UnzipArchive(displayHandler.ListView.SelectedItems); };
            diskInfoTool.Click += (sender, e) =>
            {
                DiskChart disk = new DiskChart(displayHandler.ComboBox.Text);
                DialogResult result = disk.ShowDialog();
            };
            searchTool.Click += (sender, e) =>
            {
                SearchBox searchBox = new SearchBox(directoryHandler.RootDirectory.Path);
                DialogResult result = searchBox.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string targetPath = Path.GetDirectoryName(searchBox.ReturnValue);
                    string targetName = Path.GetFileNameWithoutExtension(searchBox.ReturnValue);
                    searchBox.Dispose();
                    RootDirectory root = new RootDirectory("dir", targetPath);
                    GoTo(root);
                    ListViewItem targetItem = displayHandler.ListView.FindItemWithText(targetName);
                    targetItem.Selected = true;
                    targetItem.EnsureVisible();
                }
                else
                {
                    searchBox.Dispose();
                }
            };

            displayHandler.TextBox.TextChanged += (sender, e) =>
            {
                foreach (ListViewItem listitem in displayHandler.ListView.Items)
                {
                    if (((Element)listitem.Tag).IgnoreListing == false)
                    {
                        if (listitem != null)
                        {
                            if (listitem.Text.ToLower().Contains(displayHandler.TextBox.Text.ToLower())
                            && !displayHandler.TextBox.Text.Trim().Equals(""))
                            {
                                int n = displayHandler.ListView.Items.IndexOf(listitem);
                                displayHandler.ListView.Items.RemoveAt(n);
                                displayHandler.ListView.Items.Insert(1, listitem);
                                listitem.ForeColor = Color.Black;
                            }
                            else if (displayHandler.TextBox.Text.Trim().Equals(""))
                            {
                                listitem.ForeColor = Color.Black;
                                Refresh();
                                break;
                            }
                            else
                            {
                                listitem.ForeColor = Color.Gray;
                            }
                        }
                    }
                }
            };

            notepadTool.Click += (sender, e) => { processHandler.RunProcess("notepad", ""); };
            //

            // BOTTOM TAB
            refreshTool.Click += (sender, e) => { Refresh(); };
            renameTool.Click += (sender, e) =>
            {
                if (displayHandler.isSelected())
                {
                    DialogBox dialog = new DialogBox("Rename tool", "New name:", "Rename", "Cancel");
                    DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string newname = (dialog.ReturnValue).Trim();
                        dialog.Dispose();
                        ((Element)displayHandler.ListView.SelectedItems[0].Tag).Rename(newname);
                        Refresh();
                    }
                }
            };
            viewTool.Click += OnDoubleClick;
            editTool.Click += (sender, e) => { if (displayHandler.isSelected()) ((Element)displayHandler.ListView.SelectedItems[0].Tag).Edit(); };
            copyTool.Click += (sender, e) => { exchangeBuffer.Copy(displayHandler.ListView.SelectedItems); exchangeBuffer.Cut = false; };
            cutTool.Click += (sender, e) => { exchangeBuffer.Copy(displayHandler.ListView.SelectedItems); exchangeBuffer.Cut = true; };
            pasteTool.Click += (sender, e) => { exchangeBuffer.Paste(directoryHandler.RootDirectory.Path); Refresh(); };
            newFolderTool.Click += (sender, e) => { Directory.CreatePrompt(directoryHandler.RootDirectory.Path); Refresh(); };
            deleteTool.Click += (sender, e) => { displayHandler.DeleteSelection(); Refresh(); };
            exitTool.Click += (sender, e) => { Close(); };
            //
        }
        private void GoTo(RootDirectory root)
        {
            directoryHandler.RootDirectory = root;
            displayHandler.RootDirectory = root;
            displayHandler.TabControl.SelectedTab.Tag = root.Path;
            Refresh();
        }
        private void OnClick(object? sender, EventArgs e)
        {
            if (displayHandler.isSelected())
            {
                switch (((Element)displayHandler.ListView.SelectedItems[0].Tag).SubType)
                {
                    case "imagefile":
                        displayHandler.Preview("image");
                        displayHandler.PreviewBox.SelectedIndex = 0;
                        break;

                    case "documentfile":
                        displayHandler.Preview("document");
                        displayHandler.PreviewBox.SelectedIndex = 1;
                        break;

                    default:
                        displayHandler.Preview("clear");
                        break;
                }
            }
        }
        private void OnDoubleClick(object? sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selected = displayHandler.ListView.SelectedItems;
            if (selected.Count > 0)
            {
                if (((Element)selected[0].Tag).Type == "directory")
                {
                    RootDirectory root = new RootDirectory("dir", ((Element)(selected[0].Tag)).Path);
                    GoTo(root);
                }
                else if (((Element)selected[0].Tag).Type == "file")
                {
                    ((File)selected[0].Tag).View();
                }
            }
        }
    }
}
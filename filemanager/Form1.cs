using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace filemanager
{
    public partial class Form1 : Form
    {
        DisplayHandler displayHandler = new DisplayHandler();
        DirectoryHandler directoryHandler = new DirectoryHandler();
        FileWatcher fileWatcher = new FileWatcher();
        ExchangeBuffer exchangeBuffer = new ExchangeBuffer();
        public Form1()
        {
            InitializeComponent();
            InitializeHandlers();
            InitializeEvents();
            Refresh();
        }
        private new void Refresh()
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

            displayHandler.PreviewBox = tabControl2;

            displayHandler.setView(1);
            displayHandler.ShowExtensions = false;
            displayHandler.ShowHidden = false;

            RootDirectory root = new RootDirectory("dir", @"D:\_SAVES");

            fileWatcher.Watcher = fileSystemWatcher1;
            displayHandler.TabControl.TabPages[0].Tag = root.Path;
            directoryHandler.RootDirectory = root;
            displayHandler.RootDirectory = root;
            fileWatcher.ChangeRoot(root);

            displayHandler.getFileInfo();
        }
        private void InitializeEvents()
        {
            displayHandler.ListView.DoubleClick += OnDoubleClick;
            displayHandler.ListView.SelectedIndexChanged += OnClick;
            displayHandler.ListView.Click += OnClick;

            listViewSetView0.Click += (sender, e) => { displayHandler.setView(0); };
            listViewSetView1.Click += (sender, e) => { displayHandler.setView(1); };
            listViewSetView2.Click += (sender, e) => { displayHandler.setView(2); };
            listViewSetView3.Click += (sender, e) => { displayHandler.setView(3); };
            listViewSetView4.Click += (sender, e) => { displayHandler.setView(4); };

            selectAllTool.Click += (sender, e) => { displayHandler.SelectAll(); };
            unselectAllTool.Click += (sender, e) => { displayHandler.UnselectAll(); };
            selectAllWithTheSameExtensionTool.Click += (sender, e) => { displayHandler.SelectAllWithTheSameExtension(); };
            copySelectedNamesToClipboardTool.Click += (sender, e) => { displayHandler.CopyNamesToClipboard(false); };
            copyNamesWithPathToClipboardTool.Click += (sender, e) => { displayHandler.CopyNamesToClipboard(true); };

            newFolderTool.Click += (sender, e) => { Directory.Create(directoryHandler.RootDirectory.Path); Refresh(); };
            deleteTool.Click += (sender, e) => { displayHandler.DeleteSelection(); Refresh(); };

            displayHandler.ComboBox.SelectionChangeCommitted += (sender, e) =>
            {
                directoryHandler.RootDirectory.Path = displayHandler.ComboBox.SelectedItem.ToString()!;
                displayHandler.TabControl.SelectedTab.Tag = directoryHandler.RootDirectory.Path;
                Refresh();
            };

            //fileWatcher.Watcher.Created += (sender, e) => { Refresh(); };
            //fileWatcher.Watcher.Renamed += (sender, e) => { Refresh(); };
            //fileWatcher.Watcher.Deleted += (sender, e) => { Refresh(); };

            zipTool.Click += (sender, e) => { directoryHandler.ZipArchive(displayHandler.ListView.SelectedItems); };
            unzipTool.Click += (sender, e) => { directoryHandler.UnzipArchive(displayHandler.ListView.SelectedItems); };

            displayHandler.TabControl.SelectedIndexChanged += (sender, e) => { displayHandler.getFileInfo(); };
            exitTool.Click += (sender, e) => { Close(); };

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

                //IEnumerable<string> a = directoryHandler.SearchFor(directoryHandler.RootDirectory.Path);
            };

            deleteTabTool.Click += (sender, e) => { displayHandler.DeleteTab(); };

            displayHandler.TabControl.SelectedIndexChanged += (sender, e) =>
            {
                displayHandler.CreateTab(true, OnClick, OnDoubleClick);
                directoryHandler.RootDirectory.Path = displayHandler.TabControl.SelectedTab.Tag!.ToString()!;
                displayHandler.ListView = (ListView)displayHandler.TabControl.SelectedTab.Controls[0];
                Refresh();
            };

            goUpTool.Click += (sender, e) =>
            {
                if (Path.GetPathRoot(directoryHandler.RootDirectory.Path) != directoryHandler.RootDirectory.Path)
                {
                    RootDirectory root = new RootDirectory("dir", Path.GetDirectoryName(directoryHandler.RootDirectory.Path));
                    GoTo(root);
                }
            };
            createTabTool.Click += (sender, e) => { displayHandler.CreateTab(false, OnClick, OnDoubleClick); Refresh(); };

            pasteTool.Click += (sender, e) => { exchangeBuffer.Paste(directoryHandler.RootDirectory.Path); };
            copyTool.Click += (sender, e) => { exchangeBuffer.Copy(displayHandler.ListView.SelectedItems); };
            viewTool.Click += OnDoubleClick;
            editTool.Click += (sender, e) => { if (displayHandler.isSelected()) ((Element)displayHandler.ListView.SelectedItems[0].Tag).Edit(); };

            invertSelectionTool.Click += (sender, e) => { displayHandler.InvertSelection(); };

            refreshTool.Click += (sender, e) => { Refresh(); };
            quickRefreshTool.Click += (sender, e) => { Refresh(); };

            showExtensionsTool.Click += (sender, e) => { displayHandler.ShowExtensions = showExtensionsTool.Checked; Refresh(); };
            showHiddenFoldersTool.Click += (sender, e) => { displayHandler.ShowHidden = showHiddenFoldersTool.Checked; Refresh(); };

            notepadTool.Click += (sender, e) =>
            {
                System.Diagnostics.Process explorer = new System.Diagnostics.Process();
                explorer.StartInfo.FileName = "notepad";
                explorer.Start();
            };

            displayHandler.ListView.SelectedIndexChanged += (sender, e) => { displayHandler.getFileInfo(); };
        }
        public void GoTo(RootDirectory root)
        {
            directoryHandler.RootDirectory = root;
            displayHandler.RootDirectory = root;
            displayHandler.TabControl.SelectedTab.Tag = root.Path;
            fileWatcher.ChangeRoot(root);
            Refresh();
        }
        private void OnClick(object? sender, EventArgs e)
        {
            if (displayHandler.ListView.SelectedItems.Count > 0)
            {
                switch (displayHandler.ListView.SelectedItems[0].Tag.GetType().Name)
                {
                    case "ImageFile":
                        displayHandler.Preview("image");
                        displayHandler.PreviewBox.SelectedIndex = 0;
                        break;

                    case "DocumentFile":
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
                if (selected[0].Tag.GetType().Name.Equals("Directory"))
                {
                    RootDirectory root = new RootDirectory("dir", ((Element)(selected[0].Tag)).Path);
                    GoTo(root);
                }
                else if (selected[0].Tag.GetType().BaseType.Name.Equals("File"))
                {
                    ((File)selected[0].Tag).View();
                }
            }
        }
    }
}
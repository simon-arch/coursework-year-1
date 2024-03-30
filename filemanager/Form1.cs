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

        private void ComboBoxSelectedIndexChanged(object? sender, EventArgs e)
        {
            directoryHandler.RootDirectory.Path = comboBox1.SelectedItem.ToString()!;
            displayHandler.TabControl.SelectedTab.Tag = directoryHandler.RootDirectory.Path;
            Refresh();
        }

        private new void Refresh()
        {
            directoryHandler.PopulateDirectory();
            displayHandler.populateList();
            displayHandler.populateDrives();
            displayHandler.getFileInfo();
        }
        private void InitializeHandlers()
        {
            displayHandler.ListView = listView1;
            displayHandler.TabControl = tabControl1;
            displayHandler.ComboBox = comboBox1;
            displayHandler.Label = label1;
            displayHandler.PictureBox = pictureBox1;
            displayHandler.ImageList = imageList1;

            displayHandler.setView(1);
            displayHandler.ShowExtensions = false;
            displayHandler.ShowHidden = false;

            RootDirectory root = new RootDirectory("dir", @"D:\_SAVES");

            displayHandler.TabControl.TabPages[0].Tag = root.Path;
            directoryHandler.RootDirectory = root;
            displayHandler.RootDirectory = root;
            fileWatcher.RootDirectory = root;
            fileWatcher.Initialize();

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

            newFolderTool.Click += (sender, e) => { Directory.Create(directoryHandler.RootDirectory.Path); };
            deleteTool.Click += (sender, e) => { displayHandler.DeleteSelection(); };

            displayHandler.TabControl.SelectedIndexChanged += (sender, e) => { displayHandler.getFileInfo(); };
            displayHandler.ComboBox.SelectedIndexChanged += ComboBoxSelectedIndexChanged;

            deleteTabTool.Click += (sender, e) => { displayHandler.DeleteTab(); };

            displayHandler.TabControl.SelectedIndexChanged += (sender, e) =>
            {
                displayHandler.CreateTab(true, OnClick, OnDoubleClick);
                directoryHandler.RootDirectory.Path = displayHandler.TabControl.SelectedTab.Tag!.ToString()!;
                displayHandler.ListView = (ListView)displayHandler.TabControl.SelectedTab.Controls[0];
                Refresh();
            }; /// OPTIMIZE LATER

            createTabTool.Click += (sender, e) => { displayHandler.CreateTab(false, OnClick, OnDoubleClick); Refresh(); };

            pasteTool.Click += (sender, e) => { exchangeBuffer.Paste(directoryHandler.RootDirectory.Path); };
            copyTool.Click += (sender, e) => { exchangeBuffer.Copy(displayHandler.ListView.SelectedItems); };

            invertSelectionTool.Click += (sender, e) => { displayHandler.InvertSelection(); };

            refreshTool.Click += (sender, e) => { Refresh(); };
            quickRefreshTool.Click += (sender, e) => { Refresh(); };

            showExtensionsTool.Click += (sender, e) => { displayHandler.ShowExtensions = showExtensionsTool.Checked; Refresh(); };
            showHiddenFoldersTool.Click += (sender, e) => { displayHandler.ShowHidden = showHiddenFoldersTool.Checked; Refresh(); };

            displayHandler.ListView.SelectedIndexChanged += (sender, e) => { displayHandler.getFileInfo(); };
        }
        private void OnClick(object? sender, EventArgs e)
        {
            if (displayHandler.ListView.SelectedItems.Count > 0)
            {
                switch (displayHandler.ListView.SelectedItems[0].Tag.GetType().Name)
                {
                    case "ImageFile":
                        displayHandler.PreviewImage();
                        break;

                    default:
                        displayHandler.PictureBox.ImageLocation = null;
                        break;
                }
            }
        }
        private void OnDoubleClick(object? sender, EventArgs e)
        {
            if (displayHandler.ListView.SelectedItems.Count > 0)
            {
                if (displayHandler.ListView.SelectedItems[0].Tag.GetType().Name.Equals("Directory"))
                {
                    RootDirectory root = new RootDirectory("dir", ((Element)(displayHandler.ListView.SelectedItems[0].Tag)).Path);
                    directoryHandler.RootDirectory = root;
                    displayHandler.RootDirectory = root;
                    displayHandler.TabControl.SelectedTab.Tag = root.Path;
                    fileWatcher.setRoot(root);

                    Refresh();
                }
                else if (displayHandler.ListView.SelectedItems[0].Tag.GetType().BaseType.Name.Equals("File"))
                {
                    System.Diagnostics.Process explorer = new System.Diagnostics.Process();
                    explorer.StartInfo.FileName = "explorer";
                    explorer.StartInfo.Arguments = ((Element)(displayHandler.ListView.SelectedItems[0].Tag)).Path;
                    explorer.Start();
                }
            }
        }
    }
}
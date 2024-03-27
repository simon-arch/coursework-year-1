using System.Diagnostics;

namespace filemanager
{
    public partial class Form1 : Form
    {
        DisplayHandler displayHandler = new DisplayHandler();
        DirectoryHandler directoryHandler = new DirectoryHandler();
        FileWatcher fileWatcher = new FileWatcher();
        ExchangeBuffer exchangeBuffer = new ExchangeBuffer();
        NotificationHandler notificationHandler = new NotificationHandler();
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
            tabControl1.SelectedTab.Tag = directoryHandler.RootDirectory.Path;
            Refresh();
        }

        private new void Refresh()
        {
            directoryHandler.populateDirectory();
            displayHandler.populateList();
            displayHandler.populateDrives();
        }
        private void InitializeHandlers()
        {
            displayHandler.ListView = listView1;
            displayHandler.TabControl = tabControl1;
            displayHandler.ComboBox = comboBox1;

            displayHandler.ViewType = 3;
            displayHandler.setView(3);
            displayHandler.ShowExtensions = false;
            displayHandler.ShowHidden = false;

            RootDirectory root = new RootDirectory("dir", @"D:\_SAVES");

            tabControl1.TabPages[0].Tag = root.Path; // !temporary!

            directoryHandler.RootDirectory = root;
            displayHandler.RootDirectory = root;
            fileWatcher.RootDirectory = root;
            fileWatcher.Initialize();
        }
        private void InitializeEvents()
        {
            displayHandler.ListView.DoubleClick += OnDoubleClick;
            displayHandler.ListView.Click += OnClick;

            listViewSetView0.Click += (sender, e) => { displayHandler.setView(0); };
            listViewSetView1.Click += (sender, e) => { displayHandler.setView(1); };
            listViewSetView2.Click += (sender, e) => { displayHandler.setView(2); };
            listViewSetView3.Click += (sender, e) => { displayHandler.setView(3); };
            listViewSetView4.Click += (sender, e) => { displayHandler.setView(4); };

            displayHandler.ComboBox.SelectedIndexChanged += ComboBoxSelectedIndexChanged;

            selectionInvert.Click += InvertSelection;

            refreshTool.Click += (sender, e) => { Refresh(); };

            showExtensionsTool.Click += (sender, e) => { displayHandler.ShowExtensions = showExtensionsTool.Checked; Refresh(); };
            showHiddenFoldersTool.Click += (sender, e) => { displayHandler.ShowHidden = showHiddenFoldersTool.Checked; Refresh(); };
        }
        public void InvertSelection(object? sender, EventArgs e)
        {
            if (displayHandler.ListView.SelectedItems.Count > 0 && displayHandler.ListView.SelectedItems[0].Index != 0)
            {
                for (int i = 1; i < displayHandler.ListView.Items.Count; i++)
                {
                    displayHandler.ListView.Items[i].Selected = !displayHandler.ListView.Items[i].Selected;
                }
            }
        }

        private void OnClick(object? sender, EventArgs e)
        {
            if (displayHandler.ListView.SelectedItems.Count > 0)
            {
                if (displayHandler.ListView.SelectedItems[0].Tag.GetType().Name.Equals("ImageFile"))
                {
                    pictureBox1.ImageLocation = ((File)displayHandler.ListView.SelectedItems[0].Tag).Path;
                }
                else
                {
                    pictureBox1.ImageLocation = null;
                }
            }
            else if (displayHandler.ListView.SelectedItems.Count == 0)
            {
                pictureBox1.ImageLocation = null;
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
                else if (displayHandler.ListView.SelectedItems[0].Tag.GetType().BaseType!.Name.Equals("File"))
                {
                    Process explorer = new Process();
                    explorer.StartInfo.FileName = "explorer";
                    explorer.StartInfo.Arguments = ((Element)(displayHandler.ListView.SelectedItems[0].Tag)).Path;
                    explorer.Start();

                }
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection listitems = displayHandler.ListView.SelectedItems;
            if (listitems.Count > 0)
            {
                for (int i = 0; i < listitems.Count; i++)
                {
                    ((Element)listitems[i].Tag).delete();
                }
                Refresh();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection listitems = displayHandler.ListView.SelectedItems;
            if (listitems.Count > 0)
            {
                exchangeBuffer.Clear();
                for (int i = 0; i < listitems.Count; i++)
                {
                    exchangeBuffer.Copy((Element)listitems[i].Tag);
                }
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (exchangeBuffer.Buffer[0].Path != directoryHandler.RootDirectory.Path)
            {
                exchangeBuffer.Paste(directoryHandler.RootDirectory.Path);
            }
            else
            {
                notificationHandler.invokeError(1);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lastTab = tabControl1.TabCount - 1;
            if (tabControl1.SelectedIndex == lastTab)
            {
                TabPage newTab = new TabPage("Loading...");
                newTab.Tag = directoryHandler.RootDirectory.Path;
                ListView newListView = new ListView();
                newListView.Dock = DockStyle.Fill;
                newListView.Click += OnClick;
                newListView.DoubleClick += OnDoubleClick;
                newListView.View = (View)displayHandler.ViewType;
                newTab.Controls.Add(newListView);
                tabControl1.TabPages.Insert(lastTab, newTab);
                tabControl1.SelectedIndex = lastTab;
            }
            directoryHandler.RootDirectory.Path = tabControl1.SelectedTab.Tag!.ToString()!;
            displayHandler.ListView = (ListView)tabControl1.SelectedTab.Controls[0];


            comboBox1.SelectedIndexChanged -= ComboBoxSelectedIndexChanged; // !temporary!
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(Path.GetPathRoot(directoryHandler.RootDirectory.Path));
            comboBox1.SelectedIndexChanged += ComboBoxSelectedIndexChanged; // !temporary!

            Refresh();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > 2)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            else
            {
                notificationHandler.invokeError(2);
            }
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int lastTab = tabControl1.TabCount - 1;
            TabPage newTab = new TabPage("Loading...");
            newTab.Tag = directoryHandler.RootDirectory.Path;
            ListView newListView = new ListView();
            newListView.Dock = DockStyle.Fill;
            newListView.Click += OnClick;
            newListView.DoubleClick += OnDoubleClick;
            newListView.View = (View)displayHandler.ViewType;
            newTab.Controls.Add(newListView);
            tabControl1.TabPages.Insert(lastTab, newTab);
            tabControl1.SelectedIndex = lastTab;
            directoryHandler.RootDirectory.Path = tabControl1.SelectedTab.Tag!.ToString()!;
            displayHandler.ListView = (ListView)tabControl1.SelectedTab.Controls[0];
            Refresh();
        }
    }
}
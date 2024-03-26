using System.Diagnostics;

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

            //TabPage lv1 = new TabPage();
            //lv1.Controls.Add(listView1);
            //listView1.Dock = DockStyle.Fill;
            //tabControl1.Controls.Add(lv1);

            Refresh();
        }
        private new void Refresh()
        {
            directoryHandler.populateDirectory();
            displayHandler.populateList();
        }
        private void InitializeHandlers()
        {
            displayHandler.ListView = listView1;
            displayHandler.TabControl = tabControl1;
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

            toolStripButton2.Click += (sender, e) => { displayHandler.setView(0); };
            toolStripButton3.Click += (sender, e) => { displayHandler.setView(1); };
            toolStripButton4.Click += (sender, e) => { displayHandler.setView(2); };
            toolStripButton5.Click += (sender, e) => { displayHandler.setView(3); };
            toolStripButton6.Click += (sender, e) => { displayHandler.setView(4); };
            toolStripButton7.Click += InvertSelection;
        }
        private void InvertSelection(object? sender, EventArgs e)
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

                    tabControl1.SelectedTab.Tag = directoryHandler.RootDirectory.Path; // !temporary!

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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh();
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
        }

        private void extensionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayHandler.ShowExtensions = extensionsToolStripMenuItem.Checked;
            Refresh();
        }

        private void hiddenFoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayHandler.ShowHidden = hiddenFoldersToolStripMenuItem.Checked;
            Refresh();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lastTab = tabControl1.TabCount - 1;
            if (tabControl1.SelectedIndex == lastTab)
            {
                TabPage newTab = new TabPage("name");
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
            Refresh();
        }
    }
}
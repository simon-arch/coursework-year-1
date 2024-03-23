namespace filemanager
{
    public partial class Form1 : Form
    {
        DisplayHandler displayHandler = new DisplayHandler();
        DirectoryHandler directoryHandler = new DirectoryHandler();
        FileWatcher fileWatcher = new FileWatcher();
        public Form1()
        {
            InitializeComponent();
            InitializeHandlers();
            InitializeEvents();

            Refresh();
        }
        private void Refresh()
        {
            directoryHandler.populateDirectory();
            displayHandler.populateList();
        }
        private void InitializeHandlers()
        {
            displayHandler.ListView = listView1;
            displayHandler.setView(3);

            RootDirectory root = new RootDirectory("dir", @"D:\Games\testingFields");
            directoryHandler.RootDirectory = root;
            displayHandler.RootDirectory = root;
            fileWatcher.RootDirectory = root;
            fileWatcher.Initialize();
        }
        private void InitializeEvents()
        {
            displayHandler.ListView.DoubleClick += OnDoubleClick;
        }
        private void OnDoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (listView1.SelectedItems[0].Tag.GetType().Name.Equals("Directory"))
                {
                    RootDirectory ddir = new RootDirectory("dir", ((Element)(listView1.SelectedItems[0].Tag)).Path);
                    directoryHandler.RootDirectory = ddir;
                    displayHandler.RootDirectory = ddir;
                    fileWatcher.setRoot(ddir);
                    Refresh();
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
    }
}
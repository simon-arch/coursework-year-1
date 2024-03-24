using System.Diagnostics;
using System.IO;
using System.Linq;

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
        private void Refresh()
        {
            directoryHandler.populateDirectory();
            displayHandler.populateList();
        }
        private void InitializeHandlers()
        {
            displayHandler.ListView = listView1;
            displayHandler.setView(3);

            RootDirectory root = new RootDirectory("dir", @"D:\_SAVES\");
            directoryHandler.RootDirectory = root;
            displayHandler.RootDirectory = root;
            fileWatcher.RootDirectory = root;
            fileWatcher.Initialize();
        }
        private void InitializeEvents()
        {
            displayHandler.ListView.DoubleClick += OnDoubleClick;
            displayHandler.ListView.Click += OnClick;
        }

        private void OnClick(object sender, EventArgs e)
        {
            List<String> temporarystring = new List<String> {".jpg", ".png", ".bmp", ".jpeg", ".ico", ".gif"};
            ListView.SelectedListViewItemCollection listitems = displayHandler.ListView.SelectedItems;
            if (listitems.Count > 0)
            {
                if (temporarystring.Any(((Element)listView1.SelectedItems[0].Tag).Extension.Contains)){ // listView1.SelectedItems[0].Tag). FileType (?)  image, doc, etc.
                    pictureBox1.ImageLocation = ((Element)listitems[0].Tag).Path;
                }
                else
                {
                    pictureBox1.ImageLocation = null;
                }
            }
            else if (listitems.Count == 0)
            {
                pictureBox1.ImageLocation = null;
            }
        }

        private void OnDoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (listView1.SelectedItems[0].Tag.GetType().Name.Equals("Directory"))
                {
                    RootDirectory root = new RootDirectory("dir", ((Element)(listView1.SelectedItems[0].Tag)).Path);
                    directoryHandler.RootDirectory = root;
                    displayHandler.RootDirectory = root;
                    fileWatcher.setRoot(root);
                    Refresh();
                }
                else if (listView1.SelectedItems[0].Tag.GetType().Name.Equals("File")){
                    Process explorer = new Process();
                    explorer.StartInfo.FileName = "explorer";
                    explorer.StartInfo.Arguments = ((Element)(listView1.SelectedItems[0].Tag)).Path;
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
    }
}
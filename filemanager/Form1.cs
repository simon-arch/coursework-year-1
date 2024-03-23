using System.IO;

namespace filemanager
{
    public partial class Form1 : Form
    {
        DisplayHandler displayHandler = new DisplayHandler();
        DirectoryHandler directoryHandler = new DirectoryHandler();
        ManagerFileWatcher managerFileWatcher = new ManagerFileWatcher();
        public Form1()
        {
            InitializeComponent();


            RootDirectory ddir = new RootDirectory("dir", @"D:\Games\testingFields");

            managerFileWatcher.Directory = ddir;
            managerFileWatcher.init();

            displayHandler.ListView = listView1;
            displayHandler.RootDirectory = ddir;

            fileSystemWatcher1.Changed += OnChange;

            directoryHandler.RootDirectory = ddir;
            directoryHandler.populateDirectory();

            displayHandler.populateList();

            MessageBox.Show(
                listView1.Items[0].ToString()
                );

            displayHandler.setView(3);
            //Close();
        }

        private void OnChange(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show("test");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection listitems = listView1.SelectedItems;
            if (listitems.Count > 0)
            {
                for (int i = 0; i < listitems.Count; i++)
                {
                    ((Element)listitems[i].Tag).delete();
                }
                directoryHandler.populateDirectory();
                displayHandler.populateList();
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            directoryHandler.populateDirectory();
            displayHandler.populateList();
        }
    }
}
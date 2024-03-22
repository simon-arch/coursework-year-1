namespace filemanager
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            RootDirectory ddir = new RootDirectory("dir", @"D:\Games\testingFields");
            DirectoryHandler directoryHandler = new DirectoryHandler();
            DisplayHandler displayHandler = new DisplayHandler(listView1);

            directoryHandler.populateDirectory(ddir, 1);
            //MessageBox.Show((ddir.getDirs()[0]).ToString());

            displayHandler.populateList(ddir, 1);
            //ddir.getFiles()[0].delete();

            //MessageBox.Show((ddir.getDirs()[1].Name).ToString());
            MessageBox.Show(
                listView1.Items[0].ToString()
                );
            //ddir.getDirs()[1].delete();

            displayHandler.setView(listView1, 3);
            //Close();
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
                foreach (Element elem in listitems)
                {
                    elem.delete();
                }
            }
        }
    }

    public class DirectoryHandler
    {
        public void populateDirectory(RootDirectory dir, int mode)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(dir.Path);

            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo f in files)
            {
                dir.appendFile(new File(
                        Path.GetFileNameWithoutExtension(f.Name),
                        f.FullName.ToString(),
                        f.Length.ToString(),
                        f.Extension.ToString()
                    )
                );
            }

            DirectoryInfo[] dirs = directoryInfo.GetDirectories();
            foreach (DirectoryInfo d in dirs)
            {
                dir.appendDirectory(new Directory(
                        d.Name,
                        d.FullName
                    )
                );
            }
        }
    }

    public class DisplayHandler
    {
        protected ListView listView;
        public ListView ListView { get; set; }

        public void populateList(RootDirectory dir, int mode)
        {
            foreach (Directory d in dir.getDirs())
            {
                ListViewItem dirItem = new ListViewItem();
                dirItem.Text = d.Name;
                dirItem.Tag = d;
                this.ListView.Items.Add(dirItem);
            }

            foreach (File f in dir.getFiles())
            {
                ListViewItem fileItem = new ListViewItem();
                fileItem.Text = $"{f.Name}{f.Extension}";
                fileItem.Tag = f;
                this.ListView.Items.Add(fileItem);
            }
        }

        public DisplayHandler(ListView listView) {
            ListView = listView;
        }
        public void setView(ListView lv, int type)
        {
            lv.View = (View)type;
            // 0 - LargeIcon
            // 1 - Details
            // 2 - SmallIcon
            // 3 - List
            // 4 - Tile
        }
    }
    public class Element
    {
        public virtual void delete()
        {

        }
    }
    public class File : Element
    {
        protected string name = string.Empty;
        protected string size = string.Empty;
        protected string path = string.Empty;
        protected string extension = string.Empty;
        public string Name { get; set; }
        public string Size { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }

        public File(string name, string path, string size, string extension)
        {
            Name = name;
            Path = path;
            Size = size;
            Extension = extension;
        }
        public override void delete()
        {
            System.IO.File.Delete(this.Path);
        }
    }

    public class Directory : Element
    {
        protected string name = string.Empty;
        protected string path = string.Empty;
        public string Name { get; set; }
        public string Path { get; set; }
        public Directory(string name, string path)
        {
            Name = name;
            Path = path;
        }
        public override void delete()
        {
            System.IO.Directory.Delete(this.Path); //, true
        }
    }

    public class RootDirectory : Directory
    {
        protected List<File> ContainingFiles = new List<File>();
        protected List<Directory> ContainingDirectories = new List<Directory>();
        public void appendFile(File file)
        {
            ContainingFiles.Add(file);
        }
        public void appendDirectory(Directory dir)
        {
            ContainingDirectories.Add(dir);
        }
        public List<File> getFiles()
        {
            return ContainingFiles;
        }
        public List<Directory> getDirs()
        {
            return ContainingDirectories;
        }
        public RootDirectory(string name, string path) : base(name, path)
        {
            Name = name;
            Path = path;
        }
    }
}
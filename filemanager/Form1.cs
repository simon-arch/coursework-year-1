namespace filemanager
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Directory ddir = new Directory("dir");
            DirectoryHandler directoryHandler = new DirectoryHandler();
            directoryHandler.populateDirectory(ddir, @"D:\Drawings");
            MessageBox.Show((ddir.getFiles()[3].Name).ToString());
            Close();
        }
    }

    public class DirectoryHandler
    {
        public void populateDirectory(Directory dir, string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo f in files)
            {
                dir.appendFile(new File(
                        Path.GetFileNameWithoutExtension(f.Name),
                        f.Length.ToString(),
                        f.Extension.ToString()
                    )
                );
            }
        }
    }

    public class File
    {
        protected string name = string.Empty;
        protected string size = string.Empty;
        protected string extension = string.Empty;
        public string Name { get; set; }
        protected string Size { get; set; }
        protected string Extension { get; set; }

        public File(string name, string size, string extension)
        {
            Name = name;
            Size = size;
            Extension = extension;
        }
    }

    public class Directory
    {
        public string Name { get; set; }
        public List<File> Containing = new List<File>();

        public void appendFile(File file)
        {
            Containing.Add(file);
        }

        public List<File> getFiles()
        {
            return Containing;
        }

        public Directory(string name)
        {
            Name = name;
        }
    }
}
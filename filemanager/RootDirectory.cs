namespace filemanager
{
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
        public void clearData()
        {
            ContainingFiles.Clear();
            ContainingDirectories.Clear();
        }
        public RootDirectory(string name, string path) : base(name, path)
        {
            Name = name;
            Path = path;
        }
    }
}

namespace filemanager
{
    public class RootDirectory : Directory
    {
        protected List<File> containingFiles = new List<File>();
        protected List<Directory> containingDirectories = new List<Directory>();
        public void appendFile(File file)
        {
            containingFiles.Add(file);
        }
        public void appendDirectory(Directory dir)
        {
            containingDirectories.Add(dir);
        }
        public List<File> getFiles()
        {
            return containingFiles;
        }
        public List<Directory> getDirs()
        {
            return containingDirectories;
        }
        public void clearData()
        {
            containingFiles.Clear();
            containingDirectories.Clear();
        }
        public RootDirectory(string name, string path) : base(name, path)
        {
            Name = name;
            Path = path;
        }
    }
}

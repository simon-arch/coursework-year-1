using System.Text.RegularExpressions;

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
        public static string PadNumbers(string input)
        {
            return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
        }
        public void SortData(string type)
        {
            switch (type)
            {
                case "name": containingFiles = containingFiles.OrderBy(o => PadNumbers(o.Name)).ToList(); break;
                case "extension": containingFiles = containingFiles.OrderBy(o => o.Extension).ToList(); break;
                case "date": containingFiles = containingFiles.OrderBy(o => o.CreationDate).ToList(); break;
                case "size": containingFiles = containingFiles.OrderBy(o => o.Size).ToList(); break;
            }
        }
    }
}

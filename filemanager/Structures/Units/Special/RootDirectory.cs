using System.Text.RegularExpressions;

namespace filemanager
{
    public enum SortType
    {
        name,
        extension,
        date,
        size
    }
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
        public void SortData(SortType type, bool reverse)
        {
            if (reverse)
            {
                switch (type)
                {
                    case SortType.name: containingFiles = containingFiles.OrderByDescending(o => PadNumbers(o.Name)).ToList(); break;
                    case SortType.extension: containingFiles = containingFiles.OrderByDescending(o => o.Extension).ToList(); break;
                    case SortType.date: containingFiles = containingFiles.OrderByDescending(o => o.CreationDate).ToList(); break;
                    case SortType.size: containingFiles = containingFiles.OrderByDescending(o => o.Size).ToList(); break;
                }
            }
            else
            {
                switch (type)
                {
                    case SortType.name: containingFiles = containingFiles.OrderBy(o => PadNumbers(o.Name)).ToList(); break;
                    case SortType.extension: containingFiles = containingFiles.OrderBy(o => o.Extension).ToList(); break;
                    case SortType.date: containingFiles = containingFiles.OrderBy(o => o.CreationDate).ToList(); break;
                    case SortType.size: containingFiles = containingFiles.OrderBy(o => o.Size).ToList(); break;
                }
            }
        }
    }
}

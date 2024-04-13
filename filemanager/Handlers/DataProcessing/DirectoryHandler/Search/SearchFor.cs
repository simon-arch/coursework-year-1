namespace filemanager
{
    public partial class DirectoryHandler
    {
        public IEnumerable<string> SearchForFiles(string path, string key, bool isRecursive)
        {
            IEnumerable<string> result = System.IO.Directory.EnumerateFiles(path, $"*{key}*", new EnumerationOptions { RecurseSubdirectories = isRecursive, IgnoreInaccessible = true });
            return result;
        }
        public IEnumerable<string> SearchForDirectories(string path, string key, bool isRecursive)
        {
            IEnumerable<string> result = System.IO.Directory.EnumerateDirectories(path, $"*{key}*", new EnumerationOptions { RecurseSubdirectories = isRecursive, IgnoreInaccessible = true });
            return result;
        }
    }
}

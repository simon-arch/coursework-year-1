namespace filemanager
{
    public class FileWatcher
    {
        public FileSystemWatcher Watcher { get; set; }
        public void ChangeRoot(RootDirectory newdir)
        {
            Watcher.Path = newdir.Path;
        }
    }
}

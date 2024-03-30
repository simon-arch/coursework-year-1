namespace filemanager
{
    public class FileWatcher
    {
        public FileSystemWatcher Watcher { get; set; }
        public RootDirectory RootDirectory { get; set; }
        public FileWatcher() {
            Watcher = new FileSystemWatcher(); 
        }
        
        public void Initialize()
        {
            Watcher.Path = RootDirectory.Path;
            Watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;
            //watcher.Changed += OnChanged;
            Watcher.Created += OnCreated;
            Watcher.Deleted += OnDeleted;
            Watcher.Renamed += OnRenamed;

            Watcher.Filter = "*";
            Watcher.EnableRaisingEvents = true;
            Watcher.IncludeSubdirectories = false;
        }
        public void setRoot(RootDirectory newdir)
        {
            Watcher.Path = newdir.Path;
        }
        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            //MessageBox.Show("CHANGED");
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            //MessageBox.Show("CREATED");
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            //MessageBox.Show("DELETED");
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            //MessageBox.Show("RENAMED");
        }
    }
}

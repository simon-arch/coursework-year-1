namespace filemanager
{
    public class FileWatcher
    {
        protected FileSystemWatcher watcher = new FileSystemWatcher();
        protected RootDirectory rootDirectory;
        public FileSystemWatcher Watcher { 
            get { return watcher; }
            set { watcher = value; }
        }
        public RootDirectory RootDirectory { 
            get { return rootDirectory; }
            set { rootDirectory = value; }
        }
        
        public void Initialize()
        {
            watcher.Path = rootDirectory.Path;
            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;
            //watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;

            watcher.Filter = "*";
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = false;
        }
        public void setRoot(RootDirectory newdir)
        {
            watcher.Path = newdir.Path;
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

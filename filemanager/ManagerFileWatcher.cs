namespace filemanager
{
    public class ManagerFileWatcher
    {
        protected FileSystemWatcher watcher = new FileSystemWatcher();
        protected Directory directory;
        public FileSystemWatcher Watcher { 
            get { return watcher; }
            set { watcher = value; }
        }
        public Directory Directory { 
            get { return directory; }
            set { directory = value; }
        }
        
        public void init()
        {
            watcher.Path = @"D:/Games/testingFields"; //this.Directory.Path;
            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;
            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;

            watcher.Filter = "*";
            watcher.EnableRaisingEvents = true;
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show("CHANGED");
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show("CREATED");
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show("DELETED");
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            MessageBox.Show("RENAMED");
        }
    }
}

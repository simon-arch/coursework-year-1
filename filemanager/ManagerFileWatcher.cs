namespace filemanager
{
    public class ManagerFileWatcher
    {
        protected FileSystemWatcher watcher = new FileSystemWatcher();
        protected Directory directory;
        public FileSystemWatcher Watcher { get; set; }
        public Directory Directory { get; set; }
        
        public void init()
        {
            this.watcher.Path = @"D:/Games/testingFields"; //this.Directory.Path;
            this.watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;
            this.watcher.Changed += OnChanged;
            this.watcher.Created += OnCreated;
            this.watcher.Deleted += OnDeleted;
            this.watcher.Renamed += OnRenamed;

            this.watcher.Filter = "*";
            this.watcher.EnableRaisingEvents = true;
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

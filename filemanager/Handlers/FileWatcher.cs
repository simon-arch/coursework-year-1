namespace filemanager
{
    public class FileWatcher
    {
        public FileSystemWatcher Watcher { get; set; }
        public RootDirectory RootDirectory { get; set; }
        public void Init()
        {
            Watcher = new FileSystemWatcher();
            Watcher.Path = DriveInfo.GetDrives()[0].Name;
            Watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            Watcher.Created += OnCreated;
            Watcher.Deleted += OnDeleted;
            Watcher.Renamed += OnRenamed;

            Watcher.Filter = "*";
            Watcher.EnableRaisingEvents = true;

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

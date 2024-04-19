namespace filemanager
{
    public class FileWatcher
    {
        public DirectoryHandler DirectoryHandler { get; set; }
        public DisplayHandler DisplayHandler { get; set; }
        public FileSystemWatcher Watcher { get; set; }
        public Manager Form { get; set; }
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
            Watcher.InternalBufferSize = 1;
            Watcher.Created += (sender, e) => Form.Invoke(() => Form.Refresh(DisplayHandler, DirectoryHandler));
            Watcher.Deleted += (sender, e) => Form.Invoke(() => Form.Refresh(DisplayHandler, DirectoryHandler));
            Watcher.Renamed += (sender, e) => Form.Invoke(() => Form.Refresh(DisplayHandler, DirectoryHandler));
            Watcher.EnableRaisingEvents = true;
            Watcher.Filter = "*";
        }
    }
}

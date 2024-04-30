namespace filemanager
{
    public class FileWatcher
    {
        public FileSystemWatcher Watcher { get; set; }
        public Mediator Mediator { get; set; }
        public Manager Form { get; set; }
        public void Init(Mediator mediator, Manager form)
        {
            Mediator = mediator; Form = form;
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
            Watcher.Created += (sender, e) => Form.Invoke(() => Mediator.Refresh());
            Watcher.Deleted += (sender, e) => Form.Invoke(() => Mediator.Refresh());
            Watcher.Renamed += (sender, e) => Form.Invoke(() => Mediator.Refresh());
            Watcher.EnableRaisingEvents = true;
            Watcher.Filter = "*";
        }
    }
}

namespace filemanager
{
    public partial class Manager
    {
        public void GoTo(RootDirectory root, DisplayHandler displayHandler, DirectoryHandler directoryHandler, FileWatcher fileWatcher)
        {
            if (Path.Exists(root.Path))
            {
                //* [log] *//
                if (displayHandler.Focused) loggerHandler.Log(LogCategory.navigation, directoryHandler.RootDirectory.Path, root.Path);

                directoryHandler.RootDirectory = root;
                displayHandler.RootDirectory = root;
                displayHandler.TabControl.SelectedTab.Tag = root.Path;
                fileWatcher.Watcher.Path = root.Path;
                Refresh(displayHandler, directoryHandler);
            }
            else
            {
                NotificationHandler.invokeError(ErrorType.noPathError);
            }
        }
    }
}

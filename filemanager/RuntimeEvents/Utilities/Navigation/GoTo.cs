namespace filemanager
{
    public partial class Form1
    {
        public void GoTo(RootDirectory root, DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (Path.Exists(root.Path))
            {
                //* [log] *//
                if (displayHandler.Focused) loggerHandler.Log(Category.navigation, directoryHandler.RootDirectory.Path, root.Path);

                directoryHandler.RootDirectory = root;
                displayHandler.RootDirectory = root;
                displayHandler.TabControl.SelectedTab.Tag = root.Path;
                Refresh(displayHandler, directoryHandler);
            }
            else
            {
                NotificationHandler.invokeError(ErrorType.noPathError);
            }
        }
    }
}

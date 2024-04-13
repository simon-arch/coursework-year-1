namespace filemanager
{
    public partial class Manager
    {
        private void DoubleClick(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            ListView.SelectedListViewItemCollection selected = displayHandler.ListView.SelectedItems;
            if (selected.Count > 0)
            {
                if (selected[0].ETag().Type == "utility")
                {
                    RootDirectory root = new RootDirectory("dir", Path.GetFullPath(Path.Combine(directoryHandler.RootDirectory.Path, @"..")));
                    GoTo(root, displayHandler, directoryHandler);
                }
                else if (selected[0].ETag().Type == "directory")
                {
                    RootDirectory root = new RootDirectory("dir", selected[0].ETag().Path);
                    GoTo(root, displayHandler, directoryHandler);
                }
                else if (selected[0].ETag().Type == "file")
                {
                    ((File)selected[0].Tag).View();

                    //* [log] *//
                    if (displayHandler.Focused) loggerHandler.Log(LogCategory.interaction,
                        selected[0].ETag().Type,
                        selected[0].ETag().SubType,
                        selected[0].ETag().Name,
                        selected[0].ETag().Extension);
                }
            }
        }
    }
}

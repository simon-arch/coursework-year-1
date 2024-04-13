namespace filemanager
{
    public partial class Manager
    {
        public void AccessDoubleClick(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (displayHandler.Focused)
            {
                Element selection = quickAccessList.SelectedItems[0].ETag();
                RootDirectory root;
                switch (selection.Type)
                {
                    case "directory":

                        root = new RootDirectory("dir", selection.Path);
                        GoTo(root, displayHandler, directoryHandler);
                        break;
                    case "file":
                        root = new RootDirectory("dir", Path.GetDirectoryName(selection.Path));
                        GoTo(root, displayHandler, directoryHandler);
                        ListViewItem target = displayHandler.ListView.FindItemWithText(selection.Name);
                        target.Selected = true;
                        target.EnsureVisible();
                        break;
                }
            }
        }
    }
}

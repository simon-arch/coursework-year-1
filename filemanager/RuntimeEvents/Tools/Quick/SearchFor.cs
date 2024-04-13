namespace filemanager
{
    public partial class Manager
    {
        public void SearchFor(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (displayHandler.Focused)
            {
                SearchBox searchBox = new SearchBox(directoryHandler.RootDirectory.Path);
                DialogResult result = searchBox.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string targetPath = Path.GetDirectoryName(searchBox.ReturnValue);
                    string targetName = Path.GetFileNameWithoutExtension(searchBox.ReturnValue);
                    searchBox.Dispose();
                    RootDirectory root = new RootDirectory("dir", targetPath);
                    GoTo(root, displayHandler, directoryHandler);
                    ListViewItem targetItem = displayHandler.ListView.FindItemWithText(targetName);
                    targetItem.Selected = true;
                    targetItem.EnsureVisible();
                }
                else
                {
                    searchBox.Dispose();
                }
            }
        }
    }
}

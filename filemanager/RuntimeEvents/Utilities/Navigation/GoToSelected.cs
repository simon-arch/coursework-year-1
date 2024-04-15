namespace filemanager
{
    public partial class Manager
    {
        public void GoToSelected(DisplayHandler displayHandler, DirectoryHandler directoryHandler, FileWatcher fileWatcher)
        {
            if (!displayHandler.Focused) return;
            RootDirectory root = new RootDirectory("dir", $@"{selectPathTextBox.Text}"); // ISSUE WHEN TYPING PATH LIKE C: (NOT C:\)
            GoTo(root, displayHandler, directoryHandler, fileWatcher);
        }
    }
}

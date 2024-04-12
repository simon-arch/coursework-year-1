namespace filemanager
{
    public partial class Form1
    {
        public void GoToSelected(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (displayHandler.Focused)
            {
                RootDirectory root = new RootDirectory("dir", $@"{selectPathTextBox.Text}"); // ISSUE WHEN TYPING PATH LIKE C: (NOT C:\)
                GoTo(root, displayHandler, directoryHandler);
            }
        }
    }
}

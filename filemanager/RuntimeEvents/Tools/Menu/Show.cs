namespace filemanager
{
    public partial class Form1
    {
        public void ShowCustom(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (displayHandler.Focused)
            {
                DialogBox dialog = new DialogBox("Custom View", "Enter file types (e.g. .doc; .txt)", "OK", "Cancel");
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    List<string> listed = dialog.ReturnValue.Trim().Split(' ').ToList();
                    dialog.Dispose();
                    directoryHandler.ListedExtensions = listed;
                    Refresh(displayHandler, directoryHandler);
                    directoryHandler.DisplayMode = 2;
                }
                Refresh(displayHandler, directoryHandler);
            }
        }
        public void ShowPrograms(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (displayHandler.Focused)
            {
                directoryHandler.DisplayMode = 1;
                Refresh(displayHandler, directoryHandler);
            }
        }
        public void ShowAll(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (displayHandler.Focused)
            {
                directoryHandler.DisplayMode = 0;
                Refresh(displayHandler, directoryHandler);
            }
        }
    }
}

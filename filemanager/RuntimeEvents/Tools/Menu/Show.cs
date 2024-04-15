namespace filemanager
{
    public partial class Manager
    {
        public void ShowCustom(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (!displayHandler.Focused) return;
            DialogBox dialog = new DialogBox("Custom View", "Enter file types (e.g. .doc; .txt)", "OK", "Cancel");
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                List<string> listed = dialog.ReturnValue.Replace('.', ' ').ToLower().Trim().Split(' ').ToList();
                dialog.Dispose();
                directoryHandler.ListedExtensions = listed;
                Refresh(displayHandler, directoryHandler);
                directoryHandler.DisplayMode = 2;
            }
            Refresh(displayHandler, directoryHandler);
        }
        public void ShowPrograms(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (!displayHandler.Focused) return;
            directoryHandler.DisplayMode = 1;
            Refresh(displayHandler, directoryHandler);
        }
        public void ShowAll(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (!displayHandler.Focused) return;
            directoryHandler.DisplayMode = 0;
            Refresh(displayHandler, directoryHandler);
        }
    }
}

namespace filemanager
{
    public partial class Manager
    {
        public void Rename(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (displayHandler.isSelected())
            {
                DialogBox dialog = new DialogBox("Rename tool", "New name:", "Rename", "Cancel");
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string newname = dialog.ReturnValue.Trim();
                    dialog.Dispose();
                    displayHandler.ListView.SelectedItems[0].ETag().Rename(newname);
                    Refresh(displayHandler, directoryHandler);
                }
            }
        }
    }
}

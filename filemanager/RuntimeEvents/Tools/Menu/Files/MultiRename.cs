namespace filemanager
{
    public partial class Form1
    {
        public void MultiRename(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (displayHandler.Focused && displayHandler.isSelected())
            {
                DialogBox dialog = new DialogBox("Multi-Rename", "Enter filename", "OK", "Cancel");
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    int rep = 1;
                    foreach (ListViewItem item in displayHandler.ListView.SelectedItems)
                    {
                        string newname = dialog.ReturnValue.Trim();
                        dialog.Dispose();
                        if (item.ETag().Type != "utility")
                        {
                            item.ETag().Rename($"{newname}({rep})");
                            rep++;
                        }
                    }
                }
                Refresh(displayHandler, directoryHandler);
            }
        }
    }
}

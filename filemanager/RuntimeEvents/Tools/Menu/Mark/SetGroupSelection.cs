namespace filemanager
{
    public partial class Manager
    {
        public void SetGroupSelection(DisplayHandler displayHandler, DirectoryHandler directoryHandler, bool value)
        {
            if (!displayHandler.Focused) return;
            DialogBox dialog = new DialogBox("Group Select", "Enter file types (e.g. .doc; .txt)", "OK", "Cancel");
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                List<string> listed = dialog.ReturnValue.Replace('.', ' ').ToLower().Trim().Split(' ').ToList();
                dialog.Dispose();
                foreach (ListViewItem item in displayHandler.ListView.Items)
                {
                    if(item.ETag().Type == "file")
                    if (listed.Contains(item.ETag().Extension.Replace('.', ' ').Trim())) 
                        item.Selected = value;
                }
            }
        }
    }
}

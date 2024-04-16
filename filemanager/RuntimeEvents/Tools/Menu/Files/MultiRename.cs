using filemanager.Dialogs;

namespace filemanager
{
    public partial class Manager
    {
        public void MultiRename(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (!displayHandler.Focused) return;
            if (displayHandler.isSelected())
            {
                List<Element> data = new List<Element>();
                foreach (ListViewItem item in displayHandler.ListView.SelectedItems)
                    if (item.ETag().Type != "utility") data.Add(item.ETag());
                DialogMultiRename dialog = new DialogMultiRename(data);
                dialog.ShowDialog();
            }
        }
    }
}

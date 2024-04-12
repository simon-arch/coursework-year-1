namespace filemanager
{
    public partial class Form1
    {
        public void AccessAdd(DisplayHandler displayHandler)
        {
            if (displayHandler.Focused && displayHandler.isSelected())
            {
                foreach (ListViewItem lvi in displayHandler.ListView.SelectedItems)
                {
                    if (lvi.ETag().Type != "utility")
                    {
                        quickAccessList.Items.Add((ListViewItem)lvi.Clone());
                        quickAccessList.Items[quickAccessList.Items.Count - 1].Tag = lvi.ETag();
                    }
                }
            }
        }
    }
}

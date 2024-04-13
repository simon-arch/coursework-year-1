namespace filemanager
{
    public partial class DisplayHandler
    {
        public void SelectAllWithTheSameExtension()
        {
            ListView.SelectedListViewItemCollection listitems = ListView.SelectedItems;
            if (listitems.Count > 0)
            {
                string extens = ListView.SelectedItems[0].ETag().Extension;
                for (int i = 1; i < ListView.Items.Count; i++)
                {
                    if (ListView.Items[i].ETag().Extension == extens)
                    {
                        ListView.Items[i].Selected = true;
                    }
                }
            }
        }
    }
}

namespace filemanager
{
    public partial class DisplayHandler
    {
        public void DeleteSelection()
        {
            ListView.SelectedListViewItemCollection listitems = ListView.SelectedItems;
            if (listitems.Count > 0)
            {
                for (int i = 0; i < listitems.Count; i++)
                {
                    listitems[i].ETag().Delete();
                }
            }
        }
    }
}

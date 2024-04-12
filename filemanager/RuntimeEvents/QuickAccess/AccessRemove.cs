namespace filemanager
{
    public partial class Form1
    {
        public void AccessRemove()
        {
            if (quickAccessList.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lv in quickAccessList.SelectedItems)
                {
                    lv.Remove();
                }
            }
        }
    }
}

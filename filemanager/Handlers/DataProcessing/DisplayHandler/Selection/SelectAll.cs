namespace filemanager
{
    public partial class DisplayHandler
    {
        public void SelectAll()
        {
            for (int i = 1; i < ListView.Items.Count; i++)
            {
                ListView.Items[i].Selected = true;
            }
        }
    }
}

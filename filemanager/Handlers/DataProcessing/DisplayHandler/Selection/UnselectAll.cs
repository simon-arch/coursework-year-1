namespace filemanager
{
    public partial class DisplayHandler
    {
        public void UnselectAll()
        {
            for (int i = 1; i < ListView.Items.Count; i++)
            {
                ListView.Items[i].Selected = false;
            }
        }
    }
}

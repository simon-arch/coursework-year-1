namespace filemanager
{
    public partial class DisplayHandler
    {
        public void InvertSelection()
        {
            if (!Focused) return;
            if (ListView.SelectedItems.Count > 0 && ListView.SelectedItems[0].Index != 0)
            {
                for (int i = 1; i < ListView.Items.Count; i++)
                {
                    ListView.Items[i].Selected = !ListView.Items[i].Selected;
                }
            }
        }
    }
}

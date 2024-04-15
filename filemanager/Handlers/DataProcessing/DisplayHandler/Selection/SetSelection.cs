namespace filemanager
{
    public partial class DisplayHandler
    {
        public void SetSelection(bool value)
        {
            if (!Focused) return;
            for (int i = 1; i < ListView.Items.Count; i++)
            {
                ListView.Items[i].Selected = value;
            }
        }
    }
}

namespace filemanager
{
    public partial class Form1
    {
        public void CompareFilenames(DisplayHandler displayHandler)
        {
            if (displayHandler.Focused)
            {
                displayList.ForEach(i => i.ListView.SelectedItems.Clear());
                List<List<string>> collections = new List<List<string>>();
                foreach (DisplayHandler dh in displayList)
                {
                    List<string> list = dh.ListView.Items.Cast<ListViewItem>()
                                    .Select(item => item.Text)
                                    .ToList();
                    collections.Add(list);
                }
                List<string> duplicates = collections[0].Intersect(collections[1]).ToList();
                if (displayHandler.Focused)
                {
                    foreach (string item in duplicates)
                    {
                        foreach (DisplayHandler dh in displayList)
                        {
                            dh.ListView.FindItemWithText(item).Selected = true;
                        }
                    }
                }
            }
        }
    }
}

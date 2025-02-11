namespace filemanager
{
    public partial class Manager
    {
        private void Click(DisplayHandler displayHandler)
        {
            Focus(displayHandler);
            if (displayHandler.isSelected())
            {
                switch (displayHandler.ListView.SelectedItems[0].ETag().SubType)
                {
                    case "imagefile":
                        displayHandler.Preview("image");
                        displayHandler.PreviewBox.SelectedIndex = 0;
                        break;

                    case "documentfile":
                        displayHandler.Preview("document");
                        displayHandler.PreviewBox.SelectedIndex = 1;
                        break;

                    default:
                        displayHandler.Preview("clear");
                        break;
                }
            }
        }
        public void Focus(DisplayHandler displayHandler)
        {
            _displayList.Select(x => x.Focused = false).ToList();
            displayHandler.Focused = true;
        }
        public void CompareFilenames(Mediator mediator)
        {
            if (mediator.IsDisplayFocused())
            {
                _displayList.ForEach(i => i.ListView.SelectedItems.Clear());
                List<List<string>> collections = new List<List<string>>();
                foreach (DisplayHandler dh in _displayList)
                {
                    List<string> list = dh.ListView.Items.Cast<ListViewItem>()
                                    .Select(item => item.Text)
                                    .ToList();
                    collections.Add(list);
                }
                List<string> duplicates = collections[0].Intersect(collections[1]).ToList();
                if (mediator.IsDisplayFocused())
                {
                    foreach (string item in duplicates)
                    {
                        foreach (DisplayHandler dh in _displayList)
                        {
                            dh.ListView.FindItemWithText(item).Selected = true;
                        }
                    }
                }
            }
        }
    }
}

namespace filemanager
{
    public partial class Manager
    {
        public void AccessAdd(DisplayHandler displayHandler)
        {
            if (!displayHandler.Focused) return;
            if (displayHandler.isSelected())
            {
                string path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "quickaccess.ini");
                if (!Path.Exists(path)) System.IO.File.Create(path).Close();
                foreach (ListViewItem lvi in displayHandler.ListView.SelectedItems)
                {
                    if (lvi.ETag().Type != "utility")
                    {
                        quickAccessList.Items.Add((ListViewItem)lvi.Clone());
                        quickAccessList.Items[quickAccessList.Items.Count - 1].Tag = lvi.ETag();
                        System.IO.File.AppendAllText(path, lvi.ETag().Path + "\n");
                    }
                }
            }
        }
        public void AccessDoubleClick(Mediator mediator)
        {
            if (!mediator.Display.Focused) return;
            Element selection = quickAccessList.SelectedItems[0].ETag();
            RootDirectory root;
            switch (selection.Type)
            {
                case "directory":
                    root = new RootDirectory("dir", selection.Path);
                    mediator.GoTo(root);
                    break;
                case "file":
                    root = new RootDirectory("dir", Path.GetDirectoryName(selection.Path));
                    mediator.GoTo(root);
                    ListViewItem target = mediator.Display.ListView.Items.Cast<ListViewItem>()
                        .Single(x => x.ETag().Name == selection.Name 
                        && x.ETag().Extension == selection.Extension);
                    target.Selected = true;
                    target.EnsureVisible();
                    break;
            }
        }
        public void AccessRemove()
        {
            if (quickAccessList.SelectedItems.Count > 0)
            {
                string path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "quickaccess.ini");
                if (!Path.Exists(path)) System.IO.File.Create(path).Close();
                List<string> textlist = System.IO.File.ReadAllLines(path).ToList();
                foreach (ListViewItem lv in quickAccessList.SelectedItems)
                {
                    lv.Remove();
                    textlist.Remove(textlist.First(x => x == lv.ETag().Path));
                    System.IO.File.WriteAllLines(path, textlist);
                }
            }
        }
    }
}

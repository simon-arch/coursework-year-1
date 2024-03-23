namespace filemanager
{
    public class DisplayHandler
    {
        protected ListView listView;
        protected RootDirectory rootDirectory;
        public ListView ListView {
            get { return listView; }
            set { listView = value; }
        }
        public RootDirectory RootDirectory {
            get { return rootDirectory; }
            set { rootDirectory = value; }
        }
        public void populateList()
        {
            listView.Clear();
            foreach (Directory d in rootDirectory.getDirs())
            {
                ListViewItem dirItem = new ListViewItem();
                dirItem.Text = d.Name;
                dirItem.Tag = d;
                listView.Items.Add(dirItem);
            }

            foreach (File f in rootDirectory.getFiles())
            {
                ListViewItem fileItem = new ListViewItem();
                fileItem.Text = $"{f.Name}{f.Extension}";
                fileItem.Tag = f;
                listView.Items.Add(fileItem);
            }
        }
        public DisplayHandler() { }
        public void setView(int type)
        {
            listView.View = (View)type;
            /* 0 - LargeIcon
            1 - Details
            2 - SmallIcon
            3 - List
            4 - Tile */
        }
    }
}

namespace filemanager
{
    public class DisplayHandler
    {
        protected ListView listView;
        protected RootDirectory rootDirectory;
        public ListView ListView { get; set; }
        public RootDirectory RootDirectory { get; set; }
        public void populateList()
        {
            this.ListView.Clear();
            foreach (Directory d in this.RootDirectory.getDirs())
            {
                ListViewItem dirItem = new ListViewItem();
                dirItem.Text = d.Name;
                dirItem.Tag = d;
                this.ListView.Items.Add(dirItem);
            }

            foreach (File f in this.RootDirectory.getFiles())
            {
                ListViewItem fileItem = new ListViewItem();
                fileItem.Text = $"{f.Name}{f.Extension}";
                fileItem.Tag = f;
                this.ListView.Items.Add(fileItem);
            }
        }
        public DisplayHandler() { }
        public void setView(int type)
        {
            this.ListView.View = (View)type;
            /* 0 - LargeIcon
            1 - Details
            2 - SmallIcon
            3 - List
            4 - Tile */
        }
    }
}

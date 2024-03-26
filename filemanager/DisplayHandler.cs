namespace filemanager
{
    public class DisplayHandler
    {
        protected ListView listView = null!;
        protected TabControl tabControl = null!;
        protected RootDirectory rootDirectory = null!;
        protected bool showExtensions;
        public ListView ListView {
            get { return listView; }
            set { listView = value; }
        }
        public RootDirectory RootDirectory {
            get { return rootDirectory; }
            set { rootDirectory = value; }
        }
        public TabControl TabControl {
            get { return tabControl; }
            set { tabControl = value; }
        }
        public bool ShowExtensions {
            get { return showExtensions; }
            set { showExtensions = value; }
        }
        public void populateList()
        {
            listView.Clear();
            tabControl.Controls[tabControl.SelectedIndex].Text = Path.GetFileName(rootDirectory.Path);
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
                switch (showExtensions)
                {
                    case true: fileItem.Text = $"{f.Name}{f.Extension}"; break;
                    case false: fileItem.Text = $"{f.Name}"; break;
                }
                
                fileItem.Tag = f;
                listView.Items.Add(fileItem);
            }
        }
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

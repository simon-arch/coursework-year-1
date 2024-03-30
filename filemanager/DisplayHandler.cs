namespace filemanager
{
    public class DisplayHandler
    {
        public ListView? ListView { get; set; }
        public ImageList? ImageList { get; set; }
        public Label? Label { get; set; }
        public RootDirectory? RootDirectory { get; set; }
        public TabControl? TabControl { get; set; }
        public ComboBox? ComboBox { get; set; }
        public bool ShowExtensions { get; set; }
        public bool ShowHidden { get; set; }
        public int ViewType { get; set; }
        public void populateList()
        {
            ListView.Clear();
            ListView.SmallImageList = ImageList;
            TabControl.Controls[TabControl.SelectedIndex].Text = $"({Path.GetPathRoot(RootDirectory.Path)![0]}:) {Path.GetFileName(RootDirectory.Path)}";

            ListView.Columns.Add("Name", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("Ext", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("Size", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("Date", 100, HorizontalAlignment.Left);

            foreach (Directory d in RootDirectory.getDirs())
            {
                if((ShowHidden && d.IsHidden) || d.IsHidden == false)
                {
                    ListViewItem dirItem = new ListViewItem();
                    dirItem.Text = d.Name;
                    dirItem.SubItems.Add("");
                    dirItem.SubItems.Add("<DIR>");
                    dirItem.SubItems.Add(d.CreationDate);
                    dirItem.Tag = d;
                    dirItem.ImageIndex = d.IconIndex;
                    ListView.Items.Add(dirItem);
                }
            }

            foreach (File f in RootDirectory.getFiles())
            {
                ListViewItem fileItem = new ListViewItem();
                switch (ShowExtensions)
                {
                    case true: fileItem.Text = $"{f.Name}{f.Extension}"; break;
                    case false: fileItem.Text = $"{f.Name}"; break;
                }
                fileItem.SubItems.Add(f.Extension);
                fileItem.SubItems.Add(f.Size.ToString());
                fileItem.SubItems.Add(f.CreationDate);
                fileItem.Tag = f;
                fileItem.ImageIndex = f.IconIndex;
                ListView.Items.Add(fileItem);
            }

            //// TEMP ?????
            foreach (ColumnHeader column in ListView.Columns)
            {
                column.Width = -2;
            }
            //// TEMP ?????
        }
        public void populateDrives()
        {
            ComboBox.Items.Clear();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                ComboBox.Items.Add(drive.Name);
            }
        }
        public void setView(int view)
        {
            ViewType = view;
            ListView.View = (View)ViewType;
        }

        public void getFileInfo() // PEND REWORK
        {
            long totalSize = 0;
            long selectedSize = 0;
            int count = 0;
            int selectedCount = 0;
            foreach(File f in RootDirectory.getFiles())
            {
                totalSize += f.Size;
                count++;
            }

            if (ListView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem f in ListView.SelectedItems)
                {
                    if (f.Tag.GetType().BaseType!.Name.Equals("File"))
                    {
                        selectedSize += ((File)f.Tag).Size;
                        selectedCount++;
                    }
                }
            }

            Label.Text = $"{selectedSize/1000:n0} k / {totalSize/1000:n0} k in {selectedCount} / {count} file(s)";
        }
    }
}
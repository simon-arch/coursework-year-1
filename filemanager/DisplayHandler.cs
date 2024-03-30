using System.Windows.Forms;

namespace filemanager
{
    public class DisplayHandler
    {
        public ListView? ListView { get; set; }
        public ImageList? ImageList { get; set; }
        public Label? Label { get; set; }
        public PictureBox? PictureBox { get; set; }
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
        public void InvertSelection()
        {
            if (ListView.SelectedItems.Count > 0 && ListView.SelectedItems[0].Index != 0)
            {
                for (int i = 1; i < ListView.Items.Count; i++)
                {
                    ListView.Items[i].Selected = !ListView.Items[i].Selected;
                }
            }
        }
        public void DeleteSelection()
        {
            ListView.SelectedListViewItemCollection listitems = ListView.SelectedItems;
            if (listitems.Count > 0)
            {
                for (int i = 0; i < listitems.Count; i++)
                {
                    ((Element)listitems[i].Tag).Delete();
                }
            }
        }
        public void DeleteTab() // [ISSUE] -> deleting folder which is opened in a new tab calls error.
        {
            if (TabControl.TabPages.Count > 2)
            {
                TabControl.TabPages.Remove(TabControl.SelectedTab);
            }
            else
            {
                NotificationHandler.invokeError(2);
            }
        }
        public void SelectAll()
        {
            for (int i = 1; i < ListView.Items.Count; i++)
            {
                ListView.Items[i].Selected = true;
            }
        }
        public void UnselectAll()
        {
            for (int i = 1; i < ListView.Items.Count; i++)
            {
                ListView.Items[i].Selected = false;
            }
        }
        public void SelectAllWithTheSameExtension()
        {
            ListView.SelectedListViewItemCollection listitems = ListView.SelectedItems;
            if (listitems.Count > 0)
            {
                string extens = ((Element)(ListView.SelectedItems[0].Tag)).Extension;
                for (int i = 1; i < ListView.Items.Count; i++)
                {
                    if (((Element)(ListView.Items[i].Tag)).Extension == extens)
                    {
                        ListView.Items[i].Selected = true;
                    }
                }
            }
        }
        public void CopyNamesToClipboard(bool copyWithPath)
        {
            string copystring = string.Empty;

            foreach (ListViewItem tocopy in ListView.SelectedItems)
            {
                if (copyWithPath)
                {
                    copystring += $"{((Element)tocopy.Tag).Name}\n";
                }
                else
                {
                    copystring += $"{((Element)tocopy.Tag).Path}\n";
                }
            }
            Clipboard.SetText(copystring);
        }
        public void CreateTab(bool usePlusButton,
            Action<object, EventArgs> OnClickFunc,
            Action<object, EventArgs> OnDoubleClickFunc)
        {
            int lastTab = TabControl.TabCount - 1;

            if(usePlusButton && TabControl.SelectedIndex != lastTab)
            {
                return;
            }

            EventHandler OnClick = (obj, eventArg) => OnClickFunc(obj, eventArg);
            EventHandler OnDoubleClick = (obj, eventArg) => OnDoubleClickFunc(obj, eventArg);

            ListView newListView = new ListView();
            newListView.Dock = DockStyle.Fill;
            newListView.FullRowSelect = true;

            TabPage newTab = new TabPage("Loading...");
            newTab.Tag = RootDirectory.Path;
            newListView.View = (View)ViewType;
            newTab.Controls.Add(newListView);

            TabControl.TabPages.Insert(lastTab, newTab);
            TabControl.SelectedIndex = lastTab;

            ListView.Click += OnClick;
            ListView.DoubleClick += OnDoubleClick;
            ListView.SelectedIndexChanged += OnClick;
            ListView.SelectedIndexChanged += (sender, e) => { getFileInfo(); };

            RootDirectory.Path = TabControl.SelectedTab.Tag.ToString()!;
            ListView = (ListView)TabControl.SelectedTab.Controls[0];
        }
        public void PreviewImage()
        {
            PictureBox.ImageLocation = ((File)ListView.SelectedItems[0].Tag).Path;
        }
    }
}
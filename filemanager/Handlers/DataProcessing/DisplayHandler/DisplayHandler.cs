using System.Text.RegularExpressions;
namespace filemanager
{
    public partial class DisplayHandler : DataHandler
    {
        public bool Focused { get; set; }
        public ListView? ListView { get; set; }
        public ImageList? ImageList { get; set; }
        public Label? Label { get; set; }
        public ProgressBar? ProgressBar { get; set; }
        public Label? UsedStorage { get; set; }
        public PictureBox? PictureBox { get; set; }
        public TabControl? TabControl { get; set; }
        public TabControl? PreviewBox { get; set; }
        public ComboBox? ComboBox { get; set; }
        public TextBox TextBox { get; set; }
        public bool ShowExtensions { get; set; }
        public bool ShowHidden { get; set; }
        public int ViewType { get; set; }
        public SortType SortType { get; set; }
        public static string PadNumbers(string input)
        {
            return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
        } /// TEMP SOLUTION TEMP SOLUTION
        public void populateList()
        {
            RootDirectory.SortData(SortType);
            TabControl.Controls[TabControl.SelectedIndex].Text = $"({Path.GetPathRoot(RootDirectory.Path)[0]}:) {Path.GetFileName(Path.GetFullPath(RootDirectory.Path))}";
            ListView.Clear();
            ListView.SmallImageList = ImageList;
            ListView.Columns.Add("Name", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("Ext", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("Size", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("Date", 100, HorizontalAlignment.Left);
            ProgressBar.Value = 0; ProgressBar.Show();
            ProgressBar.Maximum = RootDirectory.getDirs().Count + RootDirectory.getFiles().Count;

            ListView.BeginUpdate();

            ListViewItem dd = new ListViewItem();
            dd.Text = $"[..]";
            dd.SubItems.Add("");
            dd.SubItems.Add("<DIR>");
            dd.SubItems.Add("");
            dd.Tag = new MovementDirectory();
            dd.ImageIndex = 1;
            ListView.Items.Add(dd);

            foreach (Directory d in RootDirectory.getDirs().Take(1).Concat(RootDirectory.getDirs().Skip(1).OrderBy(x => PadNumbers(x.Name))))
            {
                if ((ShowHidden && d.IsHidden) || d.IsHidden == false)
                {
                    ListViewItem dirItem = new ListViewItem();
                    dirItem.Text = $"[{d.Name}]";
                    dirItem.SubItems.Add("");
                    dirItem.SubItems.Add("<DIR>");
                    dirItem.SubItems.Add(d.CreationDate);
                    dirItem.Tag = d;
                    dirItem.ImageIndex = d.IconIndex;
                    ListView.Items.Add(dirItem);
                    ProgressBar.Value++;
                }
            }
            foreach (File f in RootDirectory.getFiles())
            {
                if (f.IgnoreListing == false)
                {
                    ListViewItem fileItem = new ListViewItem();
                    switch (ShowExtensions)
                    {
                        case true: fileItem.Text = $"{f.Name}{f.Extension}"; break;
                        case false: fileItem.Text = $"{f.Name}"; break;
                    }
                    fileItem.SubItems.Add(f.Extension.Replace(".", ""));
                    fileItem.SubItems.Add($"{f.Size:n0}");
                    fileItem.SubItems.Add(f.CreationDate);
                    fileItem.Tag = f;
                    fileItem.ImageIndex = f.IconIndex;
                    ListView.Items.Add(fileItem);
                }
                ProgressBar.Value++;
            }

            ListView.EndUpdate();

            foreach (ColumnHeader column in ListView.Columns)
            {
                column.Width = -2;
                ProgressBar.Hide();
            }
        }
        public void populateDrives()
        {
            ComboBox.Items.Clear();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                ComboBox.Items.Add(drive.Name);
            }
        }
        public void StorageSize()
        {
            DriveInfo drive = new DriveInfo(ComboBox.GetItemText(ComboBox.SelectedItem));
            UsedStorage.Text = $"{drive.TotalFreeSpace / 1000:n0} k of {drive.TotalSize / 1000:n0} k free";
        }
        public void SelectDrive()
        {
            ComboBox.SelectedIndex = ComboBox.Items.IndexOf(Path.GetPathRoot(RootDirectory.Path));
        }
        public void setView(int view)
        {
            if (!Focused) return;
            ViewType = view;
            ListView.View = (View)ViewType;
        }

        public void getFileInfo() // PEND REWORK
        {
            long totalSize = 0;
            long selectedSize = 0;
            int count = 0;
            int selectedCount = 0;
            int folders = 0;
            int selectedFolders = 0;

            foreach (File f in RootDirectory.getFiles())
            {
                totalSize += f.Size;
                count++;
            }
            foreach (Directory f in RootDirectory.getDirs())
            {
                folders++;
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
                    if (f.Tag.GetType().Name.Equals("Directory"))
                    {
                        selectedFolders++;
                    }
                }
            }
            Label.Text = $"{selectedSize / 1000:n0} k / {totalSize / 1000:n0} k in {selectedCount} / {count} file(s), {selectedFolders} / {folders} dir(s)";
        }
        public void DeleteTab()
        {
            if (!Focused) return;
            if (TabControl.TabPages.Count > 2)
            {
                TabControl.TabPages.Remove(TabControl.SelectedTab);
            }
            else
            {
                NotificationHandler.invokeError(ErrorType.tabDeletionError);
            }
        }
        public bool isSelected()
        {
            if (ListView.SelectedItems.Count > 0)
            {
                if (ListView.SelectedItems[0].Tag != "utility")
                {
                    return true;
                }
            }
            return false;
        }
        public void CopyNamesToClipboard(bool copyWithPath, bool copyWithExtension)
        {
            if (!Focused) return;
            string copystring = string.Empty;
            foreach (ListViewItem tocopy in ListView.SelectedItems)
            {
                if (tocopy.ETag().IgnoreListing) continue;
                if (copyWithPath) copystring += Path.Combine(Path.GetDirectoryName(tocopy.ETag().Path), tocopy.ETag().Name);
                else copystring += tocopy.ETag().Name;
                if (copyWithExtension) copystring += tocopy.ETag().Extension;
                copystring += "\n";
            }
            if (copystring == string.Empty) return;
            Clipboard.SetText(copystring);
        }
        public void CreateTab(bool usePlusButton,
            Action<DisplayHandler, DirectoryHandler> OnClickFunc,
            Action<DisplayHandler, DirectoryHandler, FileWatcher> OnDoubleClickFunc,
            DirectoryHandler directoryHandler, FileWatcher fileWatcher)
        {
            if (!Focused) return;
            int lastTab = TabControl.TabCount - 1;

            if (usePlusButton && TabControl.SelectedIndex != lastTab)
            {
                return;
            }

            ListView newListView = new ListView();
            newListView.Dock = DockStyle.Fill;
            newListView.FullRowSelect = true;
            newListView.GridLines = true;

            TabPage newTab = new TabPage("Loading...");
            newTab.Tag = RootDirectory.Path;
            newListView.View = (View)ViewType;
            newTab.Controls.Add(newListView);

            TabControl.TabPages.Insert(lastTab, newTab);
            TabControl.SelectedIndex = lastTab;

            ListView.Click += (sender, e) => { OnClickFunc(this, directoryHandler); };
            ListView.DoubleClick += (sender, e) => { OnDoubleClickFunc(this, directoryHandler, fileWatcher); };
            ListView.SelectedIndexChanged += (sender, e) => { OnClickFunc(this, directoryHandler); };
            ListView.SelectedIndexChanged += (sender, e) => { getFileInfo(); };
            DoubleBuffering.SetDoubleBuffering(ListView, true);

            RootDirectory.Path = TabControl.SelectedTab.Tag.ToString()!;
            ListView = (ListView)TabControl.SelectedTab.Controls[0];
        }
        public void Preview(string type)
        {
            switch (type)
            {
                case "image":
                    ((PictureBox)PreviewBox.TabPages[0].Controls[0]).ImageLocation = ((File)ListView.SelectedItems[0].Tag).Path;
                    break;
                case "document":
                    ((RichTextBox)PreviewBox.TabPages[1].Controls[0]).Text = System.IO.File.ReadAllText(((File)ListView.SelectedItems[0].Tag).Path);
                    break;
                case "clear":
                    ((PictureBox)PreviewBox.TabPages[0].Controls[0]).ImageLocation = null;
                    ((RichTextBox)PreviewBox.TabPages[1].Controls[0]).Text = null;
                    break;
            }
        }
    }
}
namespace filemanager
{
    public class DisplayHandler
    {
        public ListView? ListView { get; set; }
        public ImageList? ImageList { get; set; }
        public Label? Label { get; set; }
        public Label? UsedStorage { get; set; }
        public PictureBox? PictureBox { get; set; }
        public RootDirectory? RootDirectory { get; set; }
        public TabControl? TabControl { get; set; }
        public TabControl? PreviewBox { get; set; }
        public ComboBox? ComboBox { get; set; }
        public bool ShowExtensions { get; set; }
        public bool ShowHidden { get; set; }
        public int ViewType { get; set; }
        public bool isBusy { get; set; }
        public CancellationTokenSource DisposeEvent { get; set; }
        public DisplayHandler()
        {
            DisposeEvent = new CancellationTokenSource();
            isBusy = false;
        }
        public async Task populateList()
        {
            DisposeEvent.Cancel();
            CancellationTokenSource token = new CancellationTokenSource();
            DisposeEvent = token;
            await Task.Run(() => 
            {
                isBusy = true;
                SynchronizedInvoke(TabControl, delegate () {
                    TabControl.Controls[TabControl.SelectedIndex].Text = $"({Path.GetPathRoot(RootDirectory.Path)![0]}:) {Path.GetFileName(RootDirectory.Path)}";
                });
                SynchronizedInvoke(ListView, delegate () {
                    ListView.Clear();
                    ListView.SmallImageList = ImageList;
                    ListView.Columns.Add("Name", 100, HorizontalAlignment.Left);
                    ListView.Columns.Add("Ext", 100, HorizontalAlignment.Left);
                    ListView.Columns.Add("Size", 100, HorizontalAlignment.Left);
                    ListView.Columns.Add("Date", 100, HorizontalAlignment.Left);
                });

                foreach (Directory d in RootDirectory.getDirs())
                {
                    if (!token.Token.IsCancellationRequested)
                    {
                        if ((ShowHidden && d.IsHidden) || d.IsHidden == false)
                        {
                            SynchronizedInvoke(ListView, delegate () {
                                ListViewItem dirItem = new ListViewItem();
                                dirItem.Text = $"[{d.Name}]";
                                dirItem.SubItems.Add("");
                                dirItem.SubItems.Add("<DIR>");
                                dirItem.SubItems.Add(d.CreationDate);
                                dirItem.Tag = d;
                                dirItem.ImageIndex = d.IconIndex;
                                ListView.Items.Add(dirItem);
                            });
                        }
                    }
                }

                foreach (File f in RootDirectory.getFiles())
                {
                    if (!token.Token.IsCancellationRequested)
                    {
                        SynchronizedInvoke(ListView, delegate () {
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
                        });
                    }
                }

                foreach (ColumnHeader column in ListView.Columns)
                {
                    SynchronizedInvoke(ListView, delegate () {
                        column.Width = -2;
                    });
                }
                isBusy = false;
            });
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
            UsedStorage.Text = $"{drive.TotalFreeSpace/1000:n0} k of {drive.TotalSize/1000:n0} k free";
        }
        public void SelectDrive()
        {
            ComboBox.SelectedIndex = ComboBox.Items.IndexOf(Path.GetPathRoot(RootDirectory.Path));
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

            Label.Text = $"{selectedSize/1000:n0} k / {totalSize/1000:n0} k in {selectedCount} / {count} file(s), {selectedFolders} / {folders} dir(s)";
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
        public bool isSelected()
        {
            if (ListView.SelectedItems.Count > 0)
            {
                return true;
            } 
            return false;
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
        // TEMP TEMP TEMP TEMP TEMP
        static void SynchronizedInvoke(System.ComponentModel.ISynchronizeInvoke sync, Action action)
        {
            if (!sync.InvokeRequired)
            {
                action();
                return;
            }
            sync.Invoke(action, new object[] { });
        }
    }
}
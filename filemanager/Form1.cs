using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace filemanager
{
    public partial class Form1 : Form
    {
        DirectoryHandler directoryHandlerRightScreen = new DirectoryHandler();
        DirectoryHandler directoryHandlerLeftScreen = new DirectoryHandler();

        ExchangeBuffer exchangeBuffer = new ExchangeBuffer();
        ProcessHandler processHandler = new ProcessHandler();

        DisplayHandler displayHandlerRightScreen = new DisplayHandler();
        DisplayHandler displayHandlerLeftScreen = new DisplayHandler();

        List<DisplayHandler> displayList = new List<DisplayHandler>();
        List<DirectoryHandler> directoryList = new List<DirectoryHandler>();
        public Form1()
        {
            InitializeComponent();
            displayList.Add(displayHandlerLeftScreen);
            displayList.Add(displayHandlerRightScreen);

            directoryList.Add(directoryHandlerLeftScreen);
            directoryList.Add(directoryHandlerRightScreen);

            InitializeHandlers(displayHandlerLeftScreen, listView1, tabControl1, driveComboBox,
            selectedFileSizeLabel, freeSpaceLabel, imagePreviewBox, fileIconList, progressBar,
            previewBoxTabControl, searchTextBox);

            InitializeEvents(displayHandlerLeftScreen, directoryHandlerLeftScreen);
            InitializeUniqueEvents(displayHandlerLeftScreen, directoryHandlerLeftScreen);

            InitializeHandlers(displayHandlerRightScreen, listView2, tabControl2, driveComboBox,
            selectedFileSizeLabel, freeSpaceLabel, imagePreviewBox, fileIconList, progressBar,
            previewBoxTabControl, searchTextBox);

            InitializeEvents(displayHandlerRightScreen, directoryHandlerRightScreen);
            InitializeUniqueEvents(displayHandlerRightScreen, directoryHandlerRightScreen);

            LoadSettings(displayList, directoryList);
            InitializeSingletonEvents();

            displayList[0].Focused = true;

            Refresh(displayHandlerLeftScreen, directoryHandlerLeftScreen);
            Refresh(displayHandlerRightScreen, directoryHandlerRightScreen);
        }
        private void Refresh(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            directoryHandler.PopulateDirectory();
            displayHandler.populateDrives();

            displayHandler.populateList();
            displayHandler.getFileInfo();

            displayHandler.SelectDrive();
            displayHandler.StorageSize();
            displayHandler.Preview("clear");
        }
        private void InitializeSingletonEvents()
        {
            // ADD LATER MAYBE
        }
        private void InitializeUniqueEvents(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            goUpTool.Click += (sender, e) =>
            {
                if (displayHandler.Focused)
                {
                    if (Path.GetPathRoot(directoryHandler.RootDirectory.Path) != directoryHandler.RootDirectory.Path)
                    {
                        RootDirectory root = new RootDirectory("dir", Path.GetDirectoryName(directoryHandler.RootDirectory.Path));
                        GoTo(root, displayHandler, directoryHandler);
                    }
                }
            };
            listViewSetView1.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.setView(1); };
            listViewSetView2.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.setView(2); };
            listViewSetView3.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.setView(3); };
            listViewSetView4.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.setView(4); };
            invertSelectionTool.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.InvertSelection(); };
            zipTool.Click += (sender, e) => { if (displayHandler.Focused) directoryHandler.ZipArchive(displayHandler.ListView.SelectedItems); };
            unzipTool.Click += (sender, e) => { if (displayHandler.Focused) directoryHandler.UnzipArchive(displayHandler.ListView.SelectedItems); };
            diskInfoTool.Click += (sender, e) =>
            {
                if (displayHandler.Focused)
                {
                    DiskChart disk = new DiskChart(displayHandler.ComboBox.Text);
                    DialogResult result = disk.ShowDialog();
                }
            };
            searchTool.Click += (sender, e) =>
            {
                if (displayHandler.Focused)
                {
                    SearchBox searchBox = new SearchBox(directoryHandler.RootDirectory.Path);
                    DialogResult result = searchBox.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string targetPath = Path.GetDirectoryName(searchBox.ReturnValue);
                        string targetName = Path.GetFileNameWithoutExtension(searchBox.ReturnValue);
                        searchBox.Dispose();
                        RootDirectory root = new RootDirectory("dir", targetPath);
                        GoTo(root, displayHandler, directoryHandler);
                        ListViewItem targetItem = displayHandler.ListView.FindItemWithText(targetName);
                        targetItem.Selected = true;
                        targetItem.EnsureVisible();
                    }
                    else
                    {
                        searchBox.Dispose();
                    }
                }
            };
            notepadTool.Click += (sender, e) => { if (displayHandler.Focused) processHandler.RunProcess("notepad", ""); };
            goToPathButton.Click += (sender, e) =>
            {
                if (displayHandler.Focused)
                {
                    RootDirectory root = new RootDirectory("dir", $@"{pathTextBox.Text}"); // ISSUE WHEN TYPING PATH LIKE C: (NOT C:\)
                    GoTo(root, displayHandler, directoryHandler);
                }
            };
            displayHandler.ComboBox.SelectionChangeCommitted += (sender, e) =>
            {
                if (displayHandler.Focused)
                {
                    directoryHandler.RootDirectory.Path = displayHandler.ComboBox.SelectedItem.ToString();
                    displayHandler.TabControl.SelectedTab.Tag = directoryHandler.RootDirectory.Path;
                    Refresh(displayHandler, directoryHandler);
                }
            };
            printTool.Click += (sender, e) =>
            {
                if (displayHandler.Focused && displayHandler.isSelected())
                {
                    Element printfile = displayHandler.ListView.SelectedItems[0].ETag();
                    if (printfile.SubType == "documentfile")
                    {
                        using (PrintDialog printDialog = new PrintDialog())
                        {
                            if (printDialog.ShowDialog() == DialogResult.OK)
                            {
                                ((DocumentFile)printfile).PrintDocument(printfile.Path,
                                    printDialog.PrinterSettings.PrinterName);
                            }
                        }
                    }
                }
            };

            propertiesTool.Click += (sender, e) =>
            {
                if (displayHandler.Focused && displayHandler.isSelected())
                {
                    Element selected = displayHandler.ListView.SelectedItems[0].ETag();
                    if (selected.Type == "file")
                    {
                        ((File)selected).Properties();
                    }
                }
            };

            showAllFilesTool.Click += (sender, e) =>
            {
                if (displayHandler.Focused)
                {
                    directoryHandler.DisplayMode = 0;
                    Refresh(displayHandler, directoryHandler);
                }
            };

            showProgramsTool.Click += (sender, e) =>
            {
                if (displayHandler.Focused)
                {
                    directoryHandler.DisplayMode = 1;
                    Refresh(displayHandler, directoryHandler);
                }
            };

            showCustomTool.Click += (sender, e) =>
            {
                if (displayHandler.Focused)
                {
                    DialogBox dialog = new DialogBox("Custom View", "Enter file types", "OK", "Cancel");
                    DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        List<string> listed = dialog.ReturnValue.Trim().Split(' ').ToList();
                        dialog.Dispose();
                        directoryHandler.ListedExtensions = listed;
                        Refresh(displayHandler, directoryHandler);
                        directoryHandler.DisplayMode = 2;
                    }
                    Refresh(displayHandler, directoryHandler);
                }
            };

            calculateSpaceTool.Click += (sender, e) =>
            {
                if (displayHandler.Focused && displayHandler.isSelected())
                {
                    long totalSize = 0;
                    int totalFiles = 0;
                    int totalDirectories = 0;
                    foreach (ListViewItem elem in displayHandler.ListView.SelectedItems)
                    {
                        if (elem.ETag().Type == "file")
                        {
                            totalSize += ((File)elem.ETag()).GetSize();
                            totalFiles++;
                        }
                        else if (elem.ETag().Type == "directory")
                        {
                            if (((Directory)elem.ETag()).IgnoreListing == false)
                            {
                                totalSize += ((Directory)elem.ETag()).GetSize();
                                totalDirectories += 1 + System.IO.Directory.GetDirectories(((Directory)elem.ETag()).Path, "*", SearchOption.AllDirectories).Length;
                                totalFiles += System.IO.Directory.GetFiles(((Directory)elem.ETag()).Path, "*", SearchOption.AllDirectories).Length;
                            }
                        }
                    }
                    DriveInfo driveInfo = new DriveInfo(displayHandler.ComboBox.Text); // REWORK LATER / ADD RECURSIVE LAG CHECK
                    long totalSpace = driveInfo.TotalSize;
                    long usedSpace = driveInfo.TotalFreeSpace;
                    MessageBox.Show($"Total space occupied:\n {totalSize:n0} bytes in {totalFiles:n0} file(s)," +
                        $"\n in {totalDirectories} directories\n\n{driveInfo.Name} : {usedSpace / 1000:n0} k of {totalSpace / 1000:n0} k free", "File Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
        }
        private void InitializeHandlers(DisplayHandler displayHandler, ListView listView, TabControl tabControl, ComboBox comboBox, Label label1, Label label2, PictureBox pictureBox, ImageList imageList, ProgressBar progressBar, TabControl tabControl2, TextBox textBox)
        {
            displayHandler.ListView = listView;
            displayHandler.TabControl = tabControl;
            displayHandler.ComboBox = comboBox;
            displayHandler.Label = label1;
            displayHandler.UsedStorage = label2;
            displayHandler.PictureBox = pictureBox;
            displayHandler.ImageList = imageList;
            displayHandler.ProgressBar = progressBar;
            displayHandler.PreviewBox = tabControl2;
            displayHandler.TextBox = textBox;

            DoubleBuffering.SetDoubleBuffering(displayHandler.ListView, true);
            displayHandler.setView(1);
        }
        private void InitializeEvents(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            // FORM EVENTS
            this.FormClosed += (sender, e) => SaveSettings(displayList);
            //

            // MAKE DEFOCUS ON OTHER LISTS!  // THIS INDEX IN DISPLAYLIST SET FOCUSED, OTHER FALSE
            displayHandler.ListView.Click += (sender, e) =>
            {
                displayList.Select(x => x.Focused = false).ToList();
                displayHandler.Focused = true;

                displayHandler.SelectDrive();
            };
            displayHandler.TabControl.Click += (sender, e) =>
            {
                displayList.Select(x => x.Focused = false).ToList();
                displayHandler.Focused = true;

                displayHandler.SelectDrive();
            };
            // // // // // // // // // // // //

            // DISPLAY HANDLER EVENTS
            displayHandler.ListView.Click += (sender, e) => { Click(displayHandler, directoryHandler); };
            displayHandler.ListView.DoubleClick += (sender, e) => { DoubleClick(displayHandler, directoryHandler); };
            displayHandler.ListView.SelectedIndexChanged += (sender, e) => { Click(displayHandler, directoryHandler); };
            displayHandler.ListView.SelectedIndexChanged += (sender, e) => { displayHandler.getFileInfo(); };

            displayHandler.TabControl.SelectedIndexChanged += (sender, e) =>
            {
                displayHandler.getFileInfo();
                displayHandler.CreateTab(true, Click, DoubleClick, directoryHandler);
                if (System.IO.Directory.Exists(displayHandler.TabControl.SelectedTab.Tag!.ToString()!))
                {
                    directoryHandler.RootDirectory.Path = displayHandler.TabControl.SelectedTab.Tag!.ToString()!;
                    displayHandler.ListView = (ListView)displayHandler.TabControl.SelectedTab.Controls[0];
                    Refresh(displayHandler, directoryHandler);
                }
                else
                {
                    displayHandler.DeleteTab();
                }
            };


            //

            // TEMP TEMP TEMP TEMP TEMP
            displayHandler.PictureBox.Click += (sender, e) =>
            {
                if (displayHandler.PictureBox.Image != null)
                {
                    processHandler.RunProcess("explorer", displayHandler.PictureBox.ImageLocation);
                }
            };
            // TEMP TEMP TEMP TEMP TEMP

            // SHOW TAB
            showHiddenFoldersTool.Click += (sender, e) => { displayHandler.ShowHidden = showHiddenFoldersTool.Checked; Refresh(displayHandler, directoryHandler); };
            showExtensionsTool.Click += (sender, e) => { displayHandler.ShowExtensions = showExtensionsTool.Checked; Refresh(displayHandler, directoryHandler); };
            //

            // TABS TAB
            createTabTool.Click += (sender, e) => { displayHandler.CreateTab(false, Click, DoubleClick, directoryHandler); };
            deleteTabTool.Click += (sender, e) => { displayHandler.DeleteTab(); };
            //

            // MARK TAB
            selectAllTool.Click += (sender, e) => { displayHandler.SelectAll(); };
            unselectAllTool.Click += (sender, e) => { displayHandler.UnselectAll(); };
            selectAllWithTheSameExtensionTool.Click += (sender, e) => { displayHandler.SelectAllWithTheSameExtension(); };
            copySelectedNamesToClipboardTool.Click += (sender, e) => { displayHandler.CopyNamesToClipboard(false); };
            copyNamesWithPathToClipboardTool.Click += (sender, e) => { displayHandler.CopyNamesToClipboard(true); };
            //






            // TOOL STRIP
            quickRefreshTool.Click += (sender, e) => { Refresh(displayHandler, directoryHandler); };


            displayHandler.TextBox.TextChanged += (sender, e) =>
            {
                foreach (ListViewItem listitem in displayHandler.ListView.Items)
                {
                    if (((Element)listitem.Tag).IgnoreListing == false)
                    {
                        if (listitem != null)
                        {
                            if (listitem.Text.ToLower().Contains(displayHandler.TextBox.Text.ToLower())
                            && !displayHandler.TextBox.Text.Trim().Equals(""))
                            {
                                int n = displayHandler.ListView.Items.IndexOf(listitem);
                                displayHandler.ListView.Items.RemoveAt(n);
                                displayHandler.ListView.Items.Insert(1, listitem);
                                listitem.ForeColor = Color.Black;
                            }
                            else if (displayHandler.TextBox.Text.Trim().Equals(""))
                            {
                                listitem.ForeColor = Color.Black;
                                Refresh(displayHandler, directoryHandler);
                                break;
                            }
                            else
                            {
                                listitem.ForeColor = Color.Gray;
                            }
                        }
                    }
                }
            };


            //

            // BOTTOM TAB
            refreshTool.Click += (sender, e) => { Refresh(displayHandler, directoryHandler); };
            renameTool.Click += (sender, e) =>
            {
                if (displayHandler.isSelected())
                {
                    DialogBox dialog = new DialogBox("Rename tool", "New name:", "Rename", "Cancel");
                    DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string newname = (dialog.ReturnValue).Trim();
                        dialog.Dispose();
                        ((Element)displayHandler.ListView.SelectedItems[0].Tag).Rename(newname);
                        Refresh(displayHandler, directoryHandler);
                    }
                }
            };
            viewTool.Click += (sender, e) => { Click(displayHandler, directoryHandler); };
            editTool.Click += (sender, e) => { if (displayHandler.isSelected()) ((Element)displayHandler.ListView.SelectedItems[0].Tag).Edit(); };
            copyTool.Click += (sender, e) => { exchangeBuffer.Copy(displayHandler.ListView.SelectedItems); exchangeBuffer.Cut = false; };
            cutTool.Click += (sender, e) => { exchangeBuffer.Copy(displayHandler.ListView.SelectedItems); exchangeBuffer.Cut = true; };
            pasteTool.Click += (sender, e) => { exchangeBuffer.Paste(directoryHandler.RootDirectory.Path); Refresh(displayHandler, directoryHandler); };
            newFolderTool.Click += (sender, e) => { Directory.CreatePrompt(directoryHandler.RootDirectory.Path); Refresh(displayHandler, directoryHandler); };
            deleteTool.Click += (sender, e) => { displayHandler.DeleteSelection(); Refresh(displayHandler, directoryHandler); };
            exitTool.Click += (sender, e) => { Close(); };
            //
        }
        private void GoTo(RootDirectory root, DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (Path.Exists(root.Path))
            {
                directoryHandler.RootDirectory = root;
                displayHandler.RootDirectory = root;
                displayHandler.TabControl.SelectedTab.Tag = root.Path;
                Refresh(displayHandler, directoryHandler);
            }
            else
            {
                NotificationHandler.invokeError(3);
            }
        }




        //////////////////////////////////////////////////////////////////

        private void Click(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (displayHandler.isSelected())
            {
                switch (((Element)displayHandler.ListView.SelectedItems[0].Tag).SubType)
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
        private void DoubleClick(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            ListView.SelectedListViewItemCollection selected = displayHandler.ListView.SelectedItems;
            if (selected.Count > 0)
            {
                if (selected[0].ETag().Type == "directory")
                {
                    RootDirectory root = new RootDirectory("dir", selected[0].ETag().Path);
                    GoTo(root, displayHandler, directoryHandler);
                }
                else if (selected[0].ETag().Type == "file")
                {
                    if (selected[0].ETag().SubType == "shortcut")
                    {
                        string linkpath = ((ShortcutFile)selected[0].Tag).GetShortcut();
                        RootDirectory root = new RootDirectory("dir", linkpath);
                        GoTo(root, displayHandler, directoryHandler);
                    }
                    else ((File)selected[0].Tag).View();
                }
            }
        }

        ///////////////////////////////////////////////


        private void LoadSettings(List<DisplayHandler> displayList, List<DirectoryHandler> directoryList)
        {
            string json = System.IO.File.ReadAllText(
            Path.Combine(System.IO.Directory.GetCurrentDirectory(),
            @"..\..\..\Resources\appsettings.json"));
            UserSettings defaultSettings = new UserSettings();
            List<UserSettings> userSettings = new List<UserSettings>();
            try
            {
                userSettings = JsonSerializer.Deserialize<List<UserSettings>>(json);
            }
            catch (Exception ex)
            {
                userSettings.Add(defaultSettings);
                userSettings.Add(defaultSettings);
                MessageBox.Show(ex.Message, "JSON error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            for (int i = displayList.Count - 1; i >= 0; i--)
            {
                string startpath = userSettings[i].StartupFolder;
                displayList[i].ShowExtensions = userSettings[i].ShowExtensions;
                displayList[i].ShowHidden = userSettings[i].ShowHidden;
                GoTo(new RootDirectory("dir", startpath), displayList[i], directoryList[i]);
            }
        }
        private void SaveSettings(List<DisplayHandler> displayList)
        {
            List<UserSettings> viewSettings = new List<UserSettings>();
            foreach (DisplayHandler displayHandler in displayList)
            {
                UserSettings settings = new UserSettings
                {
                    StartupFolder = displayHandler.RootDirectory.Path,
                    ShowExtensions = displayHandler.ShowExtensions,
                    ShowHidden = displayHandler.ShowHidden,
                };
                viewSettings.Add(settings);
            }
            string json = JsonSerializer.Serialize(viewSettings);
            System.IO.File.WriteAllText(
            Path.Combine(System.IO.Directory.GetCurrentDirectory(),
            @"..\..\..\Resources\appsettings.json"), json);
        }
    }
}
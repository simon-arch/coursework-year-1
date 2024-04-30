using filemanager.Dialogs;

namespace filemanager
{
    public class Mediator
    {
        public DirectoryHandler Navigator { get; set; }
        public DisplayHandler Display { get; set; }
        public FileWatcher Observer { get; set; }
        public void GoUp()
        {
            if (!Display.Focused) return;
            if (Path.GetPathRoot(Navigator.RootDirectory.Path) != Navigator.RootDirectory.Path)
            {
                RootDirectory root = new RootDirectory("dir", Path.GetDirectoryName(Navigator.RootDirectory.Path));
                GoTo(root);
            }
        }
        public void GoTo(RootDirectory root)
        {
            if (Path.Exists(root.Path))
            {
                Navigator.RootDirectory = root;
                Display.RootDirectory = root;
                Display.TabControl.SelectedTab.Tag = root.Path;
                Observer.Watcher.Path = root.Path;
                Refresh();
            }
            else NotificationHandler.invokeError(ErrorType.noPathError);
        }
        public void GoToSelected(string path)
        {
            if (!Display.Focused) return;
            if (path.Length <= 2) path += @"\";
            RootDirectory root = new RootDirectory("dir", path);
            GoTo(root);
        }
        public void SearchFor()
        {
            if (!Display.ListView.Focused) return;
            SearchBox searchBox = new SearchBox(Navigator.RootDirectory.Path);
            DialogResult result = searchBox.ShowDialog();
            if (result == DialogResult.OK)
            {
                string targetPath = Path.GetDirectoryName(searchBox.ReturnValue);
                string targetName = Path.GetFileNameWithoutExtension(searchBox.ReturnValue);
                RootDirectory root = new RootDirectory("dir", targetPath);
                GoTo(root);
                ListViewItem targetItem = Display.ListView.FindItemWithText(targetName);
                if (targetItem == null) targetItem = Display.ListView.FindItemWithText("[" + targetName + "]");
                targetItem.Selected = true;
                targetItem.EnsureVisible();
            }
            else
            {
                searchBox.Dispose();
            }
        }

        public void DoubleClick(Dictionary<string, string> associated)
        {
            if (!Display.Focused) return;
            ListView.SelectedListViewItemCollection selected = Display.ListView.SelectedItems;
            if (selected.Count > 0)
            {
                if (selected[0].ETag().Type == "utility")
                {
                    RootDirectory root = new RootDirectory("dir", Path.GetFullPath(Path.Combine(Display.RootDirectory.Path, @"..")));
                    GoTo(root);
                }
                else if (selected[0].ETag().Type == "directory")
                {
                    RootDirectory root = new RootDirectory("dir", selected[0].ETag().Path);
                    GoTo(root);
                }
                else if (selected[0].ETag().Type == "file")
                {
                    ((File)selected[0].Tag).View(associated);
                }
            }
        }
        public void ShowCustom()
        {
            if (!Display.Focused) return;
            DialogBox dialog = new DialogBox("Custom View", "Enter file types (e.g. .doc; .txt)", "OK", "Cancel");
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                List<string> listed = dialog.ReturnValue.Replace('.', ' ').ToLower().Trim().Split(' ').ToList();
                dialog.Dispose();
                Navigator.ListedExtensions = listed;
                Refresh();
                Navigator.DisplayMode = 2;
            } 
            Refresh();
        }
        public void ShowPrograms()
        {
            if (!Display.Focused) return;
            Navigator.DisplayMode = 1;
            Refresh();
        }
        public void ShowAll()
        {
            if (!Display.Focused) return;
            Navigator.DisplayMode = 0;
            Refresh();
        }
        public void Refresh()
        {
            Navigator.PopulateDirectory();
            Display.populateDrives();
            Display.populateList();
            Display.getFileInfo();
            Display.SelectDrive();
            Display.StorageSize();
            Display.Preview("clear");
        }
        public void Sort(SortType sortType)
        {
            if (!Display.Focused) return;
            Display.SortType = sortType;
            Refresh();
        }
        public void SearchInList()
        {
            foreach (ListViewItem listitem in Display.ListView.Items)
            {
                if (listitem.ETag().IgnoreListing == false)
                {
                    if (listitem != null)
                    {
                        if (listitem.Text.ToLower().Contains(Display.TextBox.Text.ToLower())
                        && !Display.TextBox.Text.Trim().Equals(""))
                        {
                            int n = Display.ListView.Items.IndexOf(listitem);
                            Display.ListView.Items.RemoveAt(n);
                            Display.ListView.Items.Insert(1, listitem);
                            listitem.ForeColor = Color.Black;
                        }
                        else if (Display.TextBox.Text.Trim().Equals(""))
                        {
                            listitem.ForeColor = Color.Black;
                            Refresh();
                            break;
                        }
                        else
                        {
                            listitem.ForeColor = Color.Gray;
                        }
                    }
                }
            }
        }
        public void ChangeAttributes()
        {
            if (!Display.Focused) return;
            if (Display.isSelected())
            {
                DialogChangeAttribute dialog = new DialogChangeAttribute(
                    Display.ListView.SelectedItems.Cast<ListViewItem>()
                        .Select(item => item.ETag().Path)
                        .ToList());
                dialog.ShowDialog(); Refresh();
            }
        }
        public void ReverseSort(bool value)
        {
            if (Display.Focused) 
                Display.SortReversed = value; 
            Refresh();
        }
        public void NewFolder()
        {
            if (Display.Focused) Directory.CreatePrompt(Navigator.RootDirectory.Path);
        }
        public void Edit()
        {
            if (!Display.Focused) return;
            if (Display.isSelected()) 
                Display.ListView.SelectedItems[0].ETag().Edit();
        }
        public void ZipSelected()
        {
            if (Display.Focused) 
                Navigator.ZipArchive(Display.ListView.SelectedItems);
        }
        public void UnzipSelected()
        {
            if (Display.Focused)
                Navigator.UnzipArchive(Display.ListView.SelectedItems);
        }
    }
}

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace filemanager
{
    public class DisplayHandler
    {
        protected ListView listView = null!;
        protected ComboBox comboBox = null!;
        protected TabControl tabControl = null!;
        protected RootDirectory rootDirectory = null!;
        protected int viewType;
        protected bool showExtensions;
        protected bool showHidden;
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
        public ComboBox ComboBox {
            get { return comboBox; }
            set { comboBox = value; }
        }
        public bool ShowExtensions {
            get { return showExtensions; }
            set { showExtensions = value; }
        }        
        public bool ShowHidden {
            get { return showHidden; }
            set { showHidden = value; }
        }        
        public int ViewType {
            get { return viewType; }
            set { viewType = value; }
        }
        public void populateList()
        {
            listView.Clear();
            tabControl.Controls[tabControl.SelectedIndex].Text = $"({Path.GetPathRoot(rootDirectory.Path)![0]}:) {Path.GetFileName(rootDirectory.Path)}";

            listView.Columns.Add("Name", 100, HorizontalAlignment.Left);
            listView.Columns.Add("Ext", 100, HorizontalAlignment.Left);
            listView.Columns.Add("Size", 100, HorizontalAlignment.Left);
            listView.Columns.Add("Date", 100, HorizontalAlignment.Left);

            foreach (Directory d in rootDirectory.getDirs())
            {
                if((showHidden && d.IsHidden) || d.IsHidden == false)
                {
                    ListViewItem dirItem = new ListViewItem();
                    dirItem.Text = d.Name;
                    dirItem.SubItems.Add("");
                    dirItem.SubItems.Add("<DIR>");
                    dirItem.SubItems.Add(d.CreationDate);
                    dirItem.Tag = d;
                    listView.Items.Add(dirItem);
                }
            }
            
            foreach (File f in rootDirectory.getFiles())
            {
                ListViewItem fileItem = new ListViewItem();
                switch (showExtensions)
                {
                    case true: fileItem.Text = $"{f.Name}{f.Extension}"; break;
                    case false: fileItem.Text = $"{f.Name}"; break;
                }
                fileItem.SubItems.Add(f.Extension);
                fileItem.SubItems.Add(f.Size);
                fileItem.SubItems.Add(f.CreationDate);
                fileItem.Tag = f;
                listView.Items.Add(fileItem);
            }
        }
        public void populateDrives()
        {
            comboBox.Items.Clear();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                comboBox.Items.Add(drive.Name);
            }
        }
        public void setView(int view)
        {
            viewType = view;
            listView.View = (View)viewType;
        }
    }
}

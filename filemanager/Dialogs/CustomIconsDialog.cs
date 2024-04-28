namespace filemanager.Dialogs
{
    public partial class CustomIconsDialog : Form
    {
        public string SelectedPack { get; set; }
        public CustomIconsDialog()
        {
            InitializeComponent();

            string iconsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Icons");
            if (!Path.Exists(iconsPath)) System.IO.Directory.CreateDirectory(iconsPath);

            avaliableList.Items.Add("none");
            DirectoryInfo icons = new DirectoryInfo(iconsPath);
            foreach (DirectoryInfo dir in icons.GetDirectories())
                avaliableList.Items.Add(dir.Name);

            avaliableList.SelectedIndexChanged += (sender, e) =>
            {
                if (avaliableList.SelectedItems.Count > 0)
                {
                    previewList.Items.Clear();
                    previewImageList.Images.Clear();
                    string target = Path.Combine(iconsPath, avaliableList.SelectedItems[0].Text);
                    if (!Path.Exists(target)) return;
                    DirectoryInfo dir = new DirectoryInfo(target);
                    foreach (FileInfo file in dir.GetFiles("*"))
                    {
                        string filename = Path.GetFileNameWithoutExtension(file.FullName);
                        string key = $"override_.{filename}";
                        try { previewImageList.Images.Add(key, new Bitmap(file.FullName)); }
                        catch { continue; }
                        ListViewItem item = new ListViewItem();
                        item.Text = filename;
                        item.ImageKey = key;
                        previewList.Items.Add(item);
                    }
                }
            };
            cancelButton.Click += (sender, e) => Dispose();
            applyButton.Click += (sender, e) =>
            {
                if (avaliableList.SelectedItems.Count > 0)
                {
                    SelectedPack = avaliableList.SelectedItems[0].Text;
                    DialogResult = DialogResult.OK;
                }
            };
        }
    }
}

using System.Configuration;

namespace filemanager.Dialogs
{
    public partial class CustomIconsDialog : Form
    {
        public string SelectedPack { get; set; } = "none";
        private readonly string iconsPath = ConfigurationManager.AppSettings["Path_CustomIcons"]!;
        private readonly ListView.SelectedListViewItemCollection selectedIconPacks;

        public CustomIconsDialog()
        {
            InitializeComponent();
            if (!Path.Exists(iconsPath)) System.IO.Directory.CreateDirectory(iconsPath);
            selectedIconPacks = avaliableList.SelectedItems;

            PopulateIconPacks();
            avaliableList.SelectedIndexChanged += (s, e) => ChangeIconPack();
            applyButton.Click += (s, e) => ApplyIconPack();
            cancelButton.Click += (s, e) => Dispose();
        }

        private void PopulateIconPacks()
        {
            avaliableList.Items.Add("none");
            var iconPacks = new DirectoryInfo(iconsPath);
            foreach (var pack in iconPacks.GetDirectories())
            {
                avaliableList.Items.Add(pack.Name);
            }
        }

        private void OverrideIcons(FileInfo[] files)
        {
            foreach (var filePath in files.Select(f => f.FullName))
            {
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                var key = $"override_.{fileName}";

                try { 
                    previewImageList.Images.Add(key, new Bitmap(filePath)); 
                }
                catch { 
                    continue;
                }

                ListViewItem item = new()
                {
                    Text = fileName,
                    ImageKey = key,
                };
                previewList.Items.Add(item);
            }
        }

        private void ChangeIconPack()
        {
            if (selectedIconPacks.Count <= 0)
                return;

            previewList.Items.Clear();
            previewImageList.Images.Clear();
            var iconPack = Path.Combine(iconsPath, selectedIconPacks[0].Text);
            if (!Path.Exists(iconPack))
                return;

            var dir = new DirectoryInfo(iconPack);
            OverrideIcons(dir.GetFiles("*"));
        }

        private void ApplyIconPack()
        {
            if (selectedIconPacks.Count <= 0)
                return;

            SelectedPack = selectedIconPacks[0].Text;
            DialogResult = DialogResult.OK;
        }
    }
}

using filemanager.Properties;
using System.Collections;
using System.Globalization;
using System.Resources;

namespace filemanager.Dialogs
{
    public partial class EditQuickBar : Form
    {
        public struct QuickBarButton
        {
            public string Icon { get; set; }
            public string Command { get; set; }
        }
        public EditQuickBar(Dictionary<string, ToolStripMenuItem> stkFuncs)
        {
            InitializeComponent();
            MaximumSize = new Size(Int32.MaxValue, this.Height);

            imageList.Images.Clear();
            ResourceManager Resource = new ResourceManager(typeof(Resources));
            ResourceSet ResourceData = Resource.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            string rootPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "quickbar.ini");

            string[] lines = System.IO.File.ReadAllLines(rootPath);
            string[] prefs = lines[0].Split(", ");
            toolBarSizeText.Text = prefs[0];
            imageSizeText.Text = prefs[1];

            iniPathTextBox.Text = rootPath;
            iniPathTextBox.Select(iniPathTextBox.Text.Length, 0);

            int imgindex = 0;
            foreach (DictionaryEntry entry in ResourceData)
            {
                string resourceKey = entry.Key.ToString();
                object resource = entry.Value;
                Icon ico = (Icon)Resources.ResourceManager.GetObject(resourceKey, Resources.Culture);
                imageList.Images.Add(ico);
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = imgindex;
                lvi.Text = resourceKey;
                iconSelectionList.Items.Add(lvi);
                imgindex++;
            }

            foreach (string line in lines.Skip(1))
            {
                string[] data = line.Split(", ");
                string index = data[0];
                string command = data[1];
                string icon = data[2];

                QuickBarButton quickBtn = new QuickBarButton();
                quickBtn.Command = command;
                quickBtn.Icon = icon;

                ListViewItem lvi = new ListViewItem();
                try { lvi.ImageIndex = iconSelectionList.FindItemWithText(quickBtn.Icon).Index; }
                catch { lvi.ImageIndex = -1; }
                lvi.Text = quickBtn.Command;
                lvi.Tag = quickBtn;
                previewList.Items.Add(lvi);
            }

            searchCommands.Click += (sender, e) => CallContext(commandTextBox, stkFuncs);

            previewList.SelectedIndexChanged += (sender, e) =>
            {
                if (previewList.SelectedItems.Count > 0)
                    commandTextBox.Text = ((QuickBarButton)previewList.SelectedItems[0].Tag).Command;
            };

            addElement.Click += (sender, e) =>
            {
                if (iconSelectionList.SelectedItems.Count == 0) return;

                QuickBarButton quickBtn = new QuickBarButton();

                int iconIndex = iconSelectionList.SelectedIndices[0];
                quickBtn.Icon = iconSelectionList.SelectedItems[0].Text;

                if (commandTextBox.Text.Trim().Replace("stk_", "").Replace(".exe", "") == "") quickBtn.Command = quickBtn.Icon.Replace("Ico_", "stk_");
                else quickBtn.Command = commandTextBox.Text;

                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = iconIndex;
                lvi.Text = quickBtn.Command;
                lvi.Tag = quickBtn;
                previewList.Items.Add(lvi);
            };

            insertSeparator.Click += (sender, e) =>
            {
                QuickBarButton quickBtn = new QuickBarButton();

                quickBtn.Command = "stk_separator";
                quickBtn.Icon = "null";

                ListViewItem lvi = new ListViewItem();
                lvi.Text = "|";
                lvi.Tag = quickBtn;
                previewList.Items.Add(lvi);
            };

            replaceElement.Click += (sender, e) =>
            {
                if (previewList.SelectedItems.Count == 0) return;
                ListViewItem target = previewList.SelectedItems[0];
                QuickBarButton quickBtn = (QuickBarButton)target.Tag;
                quickBtn.Command = commandTextBox.Text;
                target.Text = quickBtn.Command;
                if (iconSelectionList.SelectedItems.Count > 0)
                {
                    target.ImageIndex = iconSelectionList.SelectedIndices[0];
                    quickBtn.Icon = iconSelectionList.SelectedItems[0].Text;
                }
                target.Tag = quickBtn;
            };

            deleteElement.Click += (sender, e) =>
            {
                if (previewList.SelectedItems.Count == 0) return;
                previewList.Items.RemoveAt(previewList.SelectedIndices[0]);
            };

            commandTextBox.TextChanged += (sender, e) =>
            {
                if (commandTextBox.Text.StartsWith("stk_")) isAction.PerformClick();
                if (commandTextBox.Text.EndsWith(".exe")) isProcess.PerformClick();
            };

            isAction.Click += (sender, e) =>
            {
                if (commandTextBox.Text.EndsWith(".exe"))
                    commandTextBox.Text = commandTextBox.Text.Replace(".exe", "");
                if (commandTextBox.Text.StartsWith("stk_")) return;
                commandTextBox.Text = $"stk_{commandTextBox.Text}";
            };

            isProcess.Click += (sender, e) =>
            {
                if (commandTextBox.Text.StartsWith("stk_"))
                    commandTextBox.Text = commandTextBox.Text.Replace("stk_", "");
                if (commandTextBox.Text.EndsWith(".exe")) return;
                commandTextBox.Text = $"{commandTextBox.Text}.exe";
            };

            openIniPath.Click += (sender, e) => { ProcessCall.RunProcess("explorer.exe", rootPath); };

            okButton.Click += (sender, e) =>
            {
                if (isBackupOld.Checked) System.IO.File.Move(rootPath, $"{Path.Combine(Path.GetDirectoryName(rootPath), "quickbar_backup.ini")}", true);
                System.IO.File.WriteAllText(rootPath, $"{toolBarSizeText.Text}, {imageSizeText.Text}\n");
                foreach (ListViewItem item in previewList.Items)
                {
                    QuickBarButton target = (QuickBarButton)item.Tag;
                    string data = $"{item.Index.ToString("00")}, {target.Command}, {target.Icon}";
                    using (StreamWriter writer = new StreamWriter(rootPath, true)) { writer.WriteLine(data); }
                }
                DialogResult = DialogResult.OK;
            };

            cancelButton.Click += (sender, e) =>
            {
                DialogResult = DialogResult.Cancel;
            };
        }
        private void CallContext(TextBox textBox, Dictionary<string, ToolStripMenuItem> stkFuncs)
        {
            ContextMenuStrip context = new ContextMenuStrip();
            foreach (KeyValuePair<string, ToolStripMenuItem> data in stkFuncs)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = $"{data.Value}";
                item.Click += (sender, e) => textBox.Text = $"stk_{data.Key}";
                context.Items.Add(item);
            }
            context.Show(Cursor.Position);
        }
    }
}

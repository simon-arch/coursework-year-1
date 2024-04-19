namespace filemanager.Dialogs
{
    public partial class DialogMultiRename : Form
    {
        public DialogMultiRename(List<Element> renameData)
        {
            InitializeComponent();
            DoubleBuffering.SetDoubleBuffering(fileView, true);

            int start = 1;
            int step = 1;
            int digits = 1;

            nameMaskAddName.Click += (sender, e) => fileNameMask.Text += "[N]";
            nameMaskAddPath.Click += (sender, e) => fileNameMask.Text += "[P]";
            nameMaskAddCounter.Click += (sender, e) => fileNameMask.Text += "[C]";
            nameMaskAddDate.Click += (sender, e) => fileNameMask.Text += "[YMD]";
            nameMaskAddTime.Click += (sender, e) => fileNameMask.Text += "[HMS]";
            nameMaskClear.Click += (sender, e) => fileNameMask.Text = string.Empty;

            extensionMaskAddExtension.Click += (sender, e) => fileExtensionMask.Text += "[E]";
            extensionMaskAddCounter.Click += (sender, e) => fileExtensionMask.Text += "[C]";
            extensionMaskClear.Click += (sender, e) => fileExtensionMask.Text = string.Empty;

            fileNameMask.TextChanged += (sender, e) => PreviewData(renameData, start, step, digits);
            fileExtensionMask.TextChanged += (sender, e) => PreviewData(renameData, start, step, digits);

            counterResetButton.Click += (sender, e) =>
            {
                numericStartAt.Value = 1;
                numericStep.Value = 1;
                comboDigits.SelectedIndex = 0;
                PreviewData(renameData, start, step, digits);
            };

            numericStartAt.ValueChanged += (sender, e) =>
            {
                start = (int)numericStartAt.Value;
                PreviewData(renameData, start, step, digits);
            };

            numericStep.ValueChanged += (sender, e) =>
            {
                step = (int)numericStep.Value;
                PreviewData(renameData, start, step, digits);
            };

            comboDigits.TextChanged += (sender, e) =>
            {
                digits = Int32.Parse(comboDigits.Text);
                PreviewData(renameData, start, step, digits);
            };

            comboLetterCase.TextChanged += (sender, e) => PreviewData(renameData, start, step, digits);
            searchForTextBox.TextChanged += (sender, e) => PreviewData(renameData, start, step, digits);
            replaceWithTextBox.TextChanged += (sender, e) => PreviewData(renameData, start, step, digits);
            respectUpperCaseCheck.CheckedChanged += (sender, e) => PreviewData(renameData, start, step, digits);
            extensionReplaceCheck.CheckedChanged += (sender, e) => PreviewData(renameData, start, step, digits);

            closeButton.Click += (sender, e) => Dispose();
            startButton.Click += (sender, e) => RunData();

            fileNameContextCall.Click += (sender, e) => CallContext(fileNameMask);
            fileExtensionContextCall.Click += (sender, e) => CallContext(fileExtensionMask);

            fileNameMask.Text += "[N]";
            fileExtensionMask.Text = "[E]";
        }
        private void CallContext(TextBox textBox)
        {
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                { "[N]",          "File name" },
                { "[E]",          "File extension" },
                { "[YMD]",        "Date" },
                { "[HMS]",        "Time" },
                { "[C]",          "Index" },
                { "[P]",          "Parent" },
                { "[A]",          "File name and extension" },
                { "[S]",          "File size" },
                { "[%USERNAME%]", "Username" },
                { "[[]",          "[" },
                { "[]]",          "]" },
                { "[X]",          Clipboard.GetText() },
            };

            ContextMenuStrip context = new ContextMenuStrip();
            foreach (KeyValuePair<string, string> data in values)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = $"{data.Key} {data.Value}";
                item.Click += (sender, e) => textBox.Text += data.Key;
                context.Items.Add(item);
            }
            context.Show(Cursor.Position);
        }
        private void PreviewData(List<Element> renameData, int index, int step, int digits)
        {
            fileView.Items.Clear();
            foreach (Element element in renameData)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = element;
                item.Text = element.Name;
                item.SubItems.Add(element.Extension);
                item.SubItems.Add(GetName(element, index, digits));
                item.SubItems.Add(element.GetSize().ToString());
                item.SubItems.Add(element.CreationDate);
                item.SubItems.Add(element.Path);
                fileView.Items.Add(item);
                index += step;
            }
        }
        private void RunData()
        {
            List<string> list = fileView.Items.Cast<ListViewItem>()
                                 .Select(item => item.SubItems[2].Text)
                                 .ToList();
            if (list.Distinct().Count() == list.Count())
            {
                foreach (ListViewItem item in fileView.Items)
                {
                    item.ETag().Rename(item.SubItems[2].Text, false, true);
                }
                MessageBox.Show("Rename successful.", "Multi-Rename", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            else
            {
                MessageBox.Show("Duplicate names are present!", "Rename Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            };
        }
        private string GetName(Element element, int index, int digits)
        {
            string targetname = fileNameMask.Text;
            string targetextension = fileExtensionMask.Text;

            Dictionary<string, string> args = new Dictionary<string, string>
            {
                { "[N]",          element.Name },
                { "[E]",          element.Extension },
                { "[YMD]",        YMD(element.CreationDate) },
                { "[HMS]",        HMS(element.CreationDate) },
                { "[C]",          string.Format("{0:" + new string('0', digits) + "}", index) },
                { "[P]",          Path.GetFileName(Path.GetDirectoryName(element.Path)) },
                { "[A]",          element.Name + element.Extension },
                { "[S]",          element.GetSize().ToString() },
                { "[%USERNAME%]", System.Security.Principal.WindowsIdentity.GetCurrent().Name },
                { "[[]",          "[" },
                { "[]]",          "]" },
                { "[X]",          Clipboard.GetText() },
            };

            foreach (KeyValuePair<string, string> replacement in args)
            {
                targetname = targetname.Replace(replacement.Key, replacement.Value);
                targetextension = targetextension.Replace(replacement.Key, replacement.Value);
            }
            if (searchForTextBox.Text.Length > 0)
            {
                StringComparison comparsion;
                if (respectUpperCaseCheck.Checked) comparsion = StringComparison.Ordinal;
                else comparsion = StringComparison.OrdinalIgnoreCase;
                targetname = targetname.Replace(searchForTextBox.Text, replaceWithTextBox.Text, comparsion);
                if (extensionReplaceCheck.Checked)
                {
                    targetextension = targetextension.Replace(searchForTextBox.Text, replaceWithTextBox.Text, comparsion);
                }
            }
            string result = targetname + targetextension;
            switch (comboLetterCase.SelectedIndex)
            {
                case 0: break;
                case 1: result = result.ToLower(); break;
                case 2: result = result.ToUpper(); break;
                case 3: result = result[0].ToString().ToUpper() + result[1..]; break;
                case 4: result = ToTitleCase.CaseString(targetname) + targetextension; break;
            }

            return result;
        }
        private string YMD(string date)
        {
            return DateTime.Parse(date).Year.ToString("0000") +
                   DateTime.Parse(date).Month.ToString("00") +
                   DateTime.Parse(date).Day.ToString("00");
        }
        private string HMS(string date)
        {
            return DateTime.Parse(date).Hour.ToString("00") +
                   DateTime.Parse(date).Minute.ToString("00") +
                   DateTime.Parse(date).Second.ToString("00");
        }
    }
}

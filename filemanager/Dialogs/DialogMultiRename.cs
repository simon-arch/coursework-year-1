namespace filemanager.Dialogs;

public partial class DialogMultiRename : Form
{
    private static readonly Dictionary<string, string> ContextLabels = new()
    {
        { "[N]", "File name" },
        { "[E]", "File extension" },
        { "[YMD]", "Date" },
        { "[HMS]", "Time" },
        { "[C]", "Index" },
        { "[P]", "Parent" },
        { "[A]", "File name and extension" },
        { "[S]", "File size" },
        { "[%USERNAME%]", "Username" },
        { "[[]", "[" },
        { "[]]", "]" },
        { "[X]", Clipboard.GetText()},
    };

    private readonly List<Element> _elements;

    private int _start = 1;
    private int _step = 1;
    private int _digits = 1;

    public DialogMultiRename(List<Element> elements)
    {
        InitializeComponent();
        DoubleBuffering.SetDoubleBuffering(fileView, true);

        _elements = elements;

        AttachEventHandlers();
        SetDefaultMasks();
    }

    private void AttachEventHandlers()
    {
        AttachNameMaskEventHandlers();
        AttachExtensionMaskEventHandler();

        fileNameMask.TextChanged += (s, e) => PreviewItems();
        fileExtensionMask.TextChanged += (s, e) => PreviewItems();

        counterResetButton.Click += (s, e) => ResetCounterValues();

        numericStartAt.ValueChanged += (s, e) => UpdateCounterValues();
        numericStep.ValueChanged += (s, e) => UpdateCounterValues();
        comboDigits.TextChanged += (s, e) => UpdateCounterValues();

        comboLetterCase.TextChanged += (s, e) => PreviewItems();
        searchForTextBox.TextChanged += (s, e) => PreviewItems();
        replaceWithTextBox.TextChanged += (s, e) => PreviewItems();
        respectUpperCaseCheck.CheckedChanged += (s, e) => PreviewItems();
        extensionReplaceCheck.CheckedChanged += (s, e) => PreviewItems();

        startButton.Click += (s, e) => ProccedRename();
        closeButton.Click += (s, e) => Dispose();

        fileNameContextCall.Click += (s, e) => CallContext(fileNameMask);
        fileExtensionContextCall.Click += (s, e) => CallContext(fileExtensionMask);
    }

    private void AttachNameMaskEventHandlers()
    {
        nameMaskAddName.Click += (s, e) => AppendToMask(fileNameMask, "[N]");
        nameMaskAddPath.Click += (s, e) => AppendToMask(fileNameMask, "[P]");
        nameMaskAddCounter.Click += (s, e) => AppendToMask(fileNameMask, "[C]");
        nameMaskAddDate.Click += (s, e) => AppendToMask(fileNameMask, "[YMD]");
        nameMaskAddTime.Click += (s, e) => AppendToMask(fileNameMask, "[HMS]");
        nameMaskClear.Click += (s, e) => fileNameMask.Clear(); 
    }

    private void AttachExtensionMaskEventHandler()
    {
        extensionMaskAddExtension.Click += (s, e) => AppendToMask(fileExtensionMask, "[E]");
        extensionMaskAddCounter.Click += (s, e) => AppendToMask(fileExtensionMask, "[C]");
        extensionMaskClear.Click += (s, e) => fileExtensionMask.Clear();
    }

    private void SetDefaultMasks()
    {
        fileNameMask.Text = "[N]";
        fileExtensionMask.Text = "[E]";
    }

    private void AppendToMask(TextBox textBox, string text) => textBox.Text += text;

    private void UpdateCounterValues()
    {
        _start = (int)numericStartAt.Value;
        _step = (int)numericStep.Value;
        _digits = int.TryParse(comboDigits.Text, out int parsed) ? parsed : 1;
        PreviewItems();
    }

    private void CallContext(TextBox textBox)
    {
        var context = new ContextMenuStrip();
        foreach (var (key, value) in ContextLabels)
        {
            var item = new ToolStripMenuItem();
            item.Text = $"{key} {value}";
            item.Click += (s, e) => textBox.Text += key;
            context.Items.Add(item);
        }
        context.Show(Cursor.Position);
    }

    private void ResetCounterValues()
    {
        numericStartAt.Value = _start = 1;
        numericStep.Value = _step = 1;
        comboDigits.SelectedIndex = 0;
        _digits = 1;
        PreviewItems();
    }

    private void PreviewItems()
    {
        fileView.Items.Clear();
        int index = _start;

        foreach (var element in _elements)
        {
            fileView.Items.Add(CreateListViewItem(element, ref index));
        }
    }

    private ListViewItem CreateListViewItem(Element element, ref int index)
    {
        var item = new ListViewItem
        {
            Tag = element,
            Text = element.Name,
            SubItems =
            {
                element.Extension,
                GetPreviewName(element, index),
                element.GetSize().ToString(),
                element.CreationDate,
                element.Path
            }
        };
        index += _step;
        return item;
    }

    private void ProccedRename()
    {
        var list = fileView.Items.Cast<ListViewItem>()
            .Select(item => item.SubItems[2].Text)
            .ToList();

        if (list.Distinct().Count() != list.Count)
        {
            MessageBox.Show("Duplicate names are present!", "Rename Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        foreach (ListViewItem item in fileView.Items)
        {
            item.ETag().Rename(item.SubItems[2].Text, false, true);
        }

        MessageBox.Show("Rename successful.", "Multi-Rename", MessageBoxButtons.OK, MessageBoxIcon.Information);
        Dispose();
    }

    private string GetPreviewName(Element element, int index)
    {
        var replacements = new Dictionary<string, string>
        {
            { "[N]", element.Name },
            { "[E]", element.Extension },
            { "[YMD]", DateTime.Parse(element.CreationDate).ToString("yyyyMMdd") },
            { "[HMS]", DateTime.Parse(element.CreationDate).ToString("HHmmss") },
            { "[C]", index.ToString($"D{_digits}") },
            { "[P]", Path.GetFileName(Path.GetDirectoryName(element.Path)) ?? string.Empty },
            { "[A]", $"{element.Name}{element.Extension}" },
            { "[S]", element.GetSize().ToString() },
            { "[%USERNAME%]", System.Security.Principal.WindowsIdentity.GetCurrent().Name },
            { "[[]", "[" },
            { "[]]", "]" },
            { "[X]", Clipboard.GetText() },
        };

        var name = ReplaceTokens(fileNameMask.Text, replacements);
        var extension = ReplaceTokens(fileExtensionMask.Text, replacements);

        name = ApplyTextReplacement(name);
        extension = extensionReplaceCheck.Checked ? ApplyTextReplacement(extension) : extension;

        return ApplyCase(name, extension);
    }

    private string ApplyTextReplacement(string text)
    {
        if (string.IsNullOrEmpty(searchForTextBox.Text))
        {
            return text;
        }

        var comparison = respectUpperCaseCheck.Checked
            ? StringComparison.Ordinal
            : StringComparison.OrdinalIgnoreCase;

        return text.Replace(searchForTextBox.Text, replaceWithTextBox.Text, comparison);
    }

    private string ReplaceTokens(string text, Dictionary<string, string> replacements)
    {
        foreach (var replacement in replacements)
        {
            text = text.Replace(replacement.Key, replacement.Value);
        }
        return text;
    }

    private string ApplyCase(string name, string extension)
    {
        var fullName = $"{name}{extension}";

        return comboLetterCase.SelectedIndex switch
        {
            1 => fullName.ToLower(),
            2 => fullName.ToUpper(),
            3 => char.ToUpper(fullName[0]) + fullName[1..],
            4 => $"{ToTitleCase.CaseString(name)}{extension}",
            _ => fullName,
        };
    }
}
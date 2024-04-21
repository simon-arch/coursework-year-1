namespace filemanager
{
    public partial class SearchBox : Form
    {
        public string ReturnValue { get; set; }
        public SearchBox(string searchInPath)
        {
            InitializeComponent();
            DoubleBuffering.SetDoubleBuffering(fileListView, true);
            searchInTextBox.Text = searchInPath;
            pathSelectButton.Click += (sender, e) =>
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    searchInPath = folderBrowserDialog1.SelectedPath;
                    searchInTextBox.Text = searchInPath;
                }
            };
            cancelButton.Click += (sender, e) => { this.DialogResult = DialogResult.Cancel; };
            searchButton.Click += async (sender, e) =>
            {
                if (searchInTextBox.Text != "" && searchForTextBox.Text != "")
                {
                    DirectoryHandler directoryHandler = new DirectoryHandler();
                    IEnumerable<string> directorySearchResult = Empty();
                    IEnumerable<string> fileSearchResult = Empty();
                    string searchTarget = searchForTextBox.Text;
                    if (searchExactCheck.Checked == false) searchTarget = $"*{searchTarget}*";

                    if (includeDirsCheck.Checked)
                        directorySearchResult = System.IO.Directory.EnumerateDirectories(searchInTextBox.Text,
                            searchTarget,
                            new EnumerationOptions
                            {
                                RecurseSubdirectories = includeSubdirs.Checked,
                                IgnoreInaccessible = true,
                                MatchCasing = (matchCaseCheck.Checked) ? MatchCasing.CaseSensitive : MatchCasing.CaseInsensitive,
                            });

                    if (includeFilesCheck.Checked)
                        fileSearchResult = System.IO.Directory.EnumerateFiles(searchInTextBox.Text,
                            searchTarget,
                            new EnumerationOptions
                            {
                                RecurseSubdirectories = includeSubdirs.Checked,
                                IgnoreInaccessible = true,
                                MatchCasing = (matchCaseCheck.Checked) ? MatchCasing.CaseSensitive : MatchCasing.CaseInsensitive,
                            });

                    fileListView.Clear();
                    fileListView.Columns.Add($"[{fileSearchResult.Count()} files and {directorySearchResult.Count()} directories found]", -2);

                    progressBar.Value = 0;
                    progressBar.Maximum = directorySearchResult.Count() + fileSearchResult.Count();

                    fileListView.BeginUpdate();
                    if (fileSearchResult.Count() > 0)
                    {
                        foreach (string result in fileSearchResult)
                        {
                            fileListView.Items.Add(result);
                            progressBar.Value++;
                        }
                    }

                    if (directorySearchResult.Count() > 0)
                    {
                        foreach (string result in directorySearchResult)
                        {
                            fileListView.Items.Add(result);
                            progressBar.Value++;
                        }
                    }
                    fileListView.Columns[0].Width = -2;
                    fileListView.EndUpdate();

                    progressBar.Value = 0;
                }
            };
            goToFileButton.Click += (sender, e) =>
            {
                if (fileListView.SelectedItems.Count > 0)
                {
                    ReturnValue = fileListView.SelectedItems[0].Text;
                    DialogResult = DialogResult.OK;
                }
            };
        }
        public static IEnumerable<string> Empty()
        {
            yield break;
        }
    }
}

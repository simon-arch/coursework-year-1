namespace filemanager
{
    public partial class SearchBox : Form
    {
        public string ReturnValue { get; set; }
        public SearchBox(string searchInPath)
        {
            InitializeComponent();
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
            searchButton.Click += (sender, e) =>
            {
                if (searchInTextBox.Text != "" && searchForTextBox.Text != "")
                {
                    DirectoryHandler directoryHandler = new DirectoryHandler();
                    IEnumerable<string> fileSearchResult = directoryHandler.SearchForFiles(searchInTextBox.Text, searchForTextBox.Text, includeSubdirs.Checked);
                    IEnumerable<string> directorySearchResult = directoryHandler.SearchForDirectories(searchInTextBox.Text, searchForTextBox.Text, includeSubdirs.Checked);
                    fileListView.Clear();
                    fileListView.Columns.Add($"[{fileSearchResult.Count()} files and {directorySearchResult.Count()} directories found]", -2);
                    if (fileSearchResult.Count() > 0)
                    {
                        foreach (string result in fileSearchResult)
                        {
                            fileListView.Items.Add(result);
                            fileListView.Columns[0].Width = -2;
                        }
                    }
                    if (directorySearchResult.Count() > 0)
                    {
                        foreach (string result in directorySearchResult)
                        {
                            fileListView.Items.Add(result);
                            fileListView.Columns[0].Width = -2;
                        }
                    }
                }
            };
            goToFileButton.Click += (sender, e) =>
            {
                if (fileListView.SelectedItems.Count > 0)
                {
                    ReturnValue = fileListView.SelectedItems[0].Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            };
        }
    }
}

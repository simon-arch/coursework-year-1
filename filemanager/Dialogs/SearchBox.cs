namespace filemanager
{
    public partial class SearchBox : Form
    {
        public string? ReturnValue { get; set; }
        private const string searchResultCountFormatting = "[{0} files and {1} directories found]";
        private IEnumerable<string> directorySearchResult = Empty();
        private IEnumerable<string> fileSearchResult = Empty();
        private enum SearchType
        {
            Files,
            Directories
        }

        public SearchBox(string searchInPath)
        {
            InitializeComponent();
            DoubleBuffering.SetDoubleBuffering(fileListView, true);
            searchInTextBox.Text = searchInPath;

            pathSelectButton.Click += (s, e) => ApplySelectedPath();
            cancelButton.Click += (s, e) => Cancel();
            searchButton.Click += (s, e) => PerformSearch();
            goToFileButton.Click += (s, e) => GoToSearchResult();
        }

        private void ApplySelectedPath()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                searchInTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Cancel()
        {
            DialogResult = DialogResult.Cancel;
        }

        private void GoToSearchResult()
        {
            if (fileListView.SelectedItems.Count > 0)
            {
                ReturnValue = fileListView.SelectedItems[0].Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void PerformSearch()
        {
            var searchPath = searchInTextBox.Text;
            var searchContent = searchForTextBox.Text;
            if (string.IsNullOrEmpty(searchPath) || string.IsNullOrEmpty(searchContent))
                return;

            if (!searchExactCheck.Checked)
                searchContent = $"*{searchContent}*";

            if (includeDirsCheck.Checked)
                directorySearchResult = GetSearchResults(searchPath, searchContent, SearchType.Directories);
            
            if (includeFilesCheck.Checked)
                fileSearchResult = GetSearchResults(searchPath, searchContent, SearchType.Files);

            PopulateSearchResultsList();
        }

        private IEnumerable<string> GetSearchResults(string searchInPath, string searchTarget, SearchType searchType)
        {
            EnumerationOptions options = new EnumerationOptions
            {
                MatchCasing = matchCaseCheck.Checked ? MatchCasing.CaseSensitive : MatchCasing.CaseInsensitive,
                RecurseSubdirectories = includeSubdirs.Checked,
                IgnoreInaccessible = true
            };

            return searchType switch
            {
                SearchType.Files => System.IO.Directory.EnumerateFiles(searchInPath, searchTarget, options),
                SearchType.Directories => System.IO.Directory.EnumerateDirectories(searchInPath, searchTarget, options),
                _ => Enumerable.Empty<string>(),
            };
        }

        private void PopulateSearchResultsList()
        {
            fileListView.Clear();
            fileListView.Columns.Add(string.Format(searchResultCountFormatting, fileSearchResult.Count(), directorySearchResult.Count()));

            int totalSearchResults = directorySearchResult.Count() + fileSearchResult.Count();
            progressBar.Value = 0;
            progressBar.Maximum = totalSearchResults;

            fileListView.BeginUpdate();

            foreach (var file in fileSearchResult)
            {
                fileListView.Items.Add(file);
                progressBar.Value++;
            }

            foreach (var directory in directorySearchResult)
            {
                fileListView.Items.Add(directory);
                progressBar.Value++;
            }

            fileListView.Columns[0].Width = -2;
            fileListView.EndUpdate();
            progressBar.Value = 0;
        }

        private static IEnumerable<string> Empty()
        {
            yield break;
        }
    }
}

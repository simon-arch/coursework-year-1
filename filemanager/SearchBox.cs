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
                DirectoryHandler directoryHandler = new DirectoryHandler();
                IEnumerable<string> searchResult = directoryHandler.SearchFor(searchInTextBox.Text, searchForTextBox.Text);
                fileListView.Items.Add($"[{searchResult.Count()} files and 0 directories found]"); // IMPLEMENT DIRECTORIES LATER
                foreach (string result in searchResult)
                {
                    fileListView.Items.Add(result);
                    fileListView.Columns[0].Width = -1;
                }
            };
            goToFileButton.Click += (sender, e) =>
            {
                if (fileListView.SelectedItems.Count > 0 && fileListView.Items[0] != fileListView.SelectedItems[0])
                {
                    ReturnValue = fileListView.SelectedItems[0].Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            };
        }
    }
}

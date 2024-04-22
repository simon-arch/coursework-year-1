namespace filemanager
{
    partial class SearchBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchBox));
            searchForTextBox = new TextBox();
            searchInTextBox = new TextBox();
            fileListView = new ListView();
            filesColumn = new ColumnHeader();
            label1 = new Label();
            label2 = new Label();
            pathSelectButton = new Button();
            label3 = new Label();
            searchButton = new Button();
            cancelButton = new Button();
            goToFileButton = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            tableLayoutPanel1 = new TableLayoutPanel();
            progressBar = new ProgressBar();
            includeSubdirs = new CheckBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            includeDirsCheck = new CheckBox();
            includeFilesCheck = new CheckBox();
            matchCaseCheck = new CheckBox();
            searchExactCheck = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // searchForTextBox
            // 
            tableLayoutPanel1.SetColumnSpan(searchForTextBox, 2);
            searchForTextBox.Dock = DockStyle.Fill;
            searchForTextBox.Location = new Point(111, 3);
            searchForTextBox.Name = "searchForTextBox";
            searchForTextBox.Size = new Size(231, 27);
            searchForTextBox.TabIndex = 0;
            // 
            // searchInTextBox
            // 
            searchInTextBox.Dock = DockStyle.Fill;
            searchInTextBox.Location = new Point(111, 39);
            searchInTextBox.Name = "searchInTextBox";
            searchInTextBox.Size = new Size(174, 27);
            searchInTextBox.TabIndex = 1;
            // 
            // fileListView
            // 
            fileListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fileListView.Columns.AddRange(new ColumnHeader[] { filesColumn });
            tableLayoutPanel1.SetColumnSpan(fileListView, 4);
            fileListView.FullRowSelect = true;
            fileListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            fileListView.Location = new Point(3, 162);
            fileListView.MultiSelect = false;
            fileListView.Name = "fileListView";
            fileListView.Size = new Size(436, 296);
            fileListView.TabIndex = 2;
            fileListView.UseCompatibleStateImageBehavior = false;
            fileListView.View = View.Details;
            // 
            // filesColumn
            // 
            filesColumn.Text = "[0 files and 0 directories found]";
            filesColumn.Width = 435;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(102, 36);
            label1.TabIndex = 3;
            label1.Text = "Search for:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 36);
            label2.Name = "label2";
            label2.Size = new Size(102, 36);
            label2.TabIndex = 4;
            label2.Text = "Search in:";
            // 
            // pathSelectButton
            // 
            pathSelectButton.Dock = DockStyle.Fill;
            pathSelectButton.Location = new Point(291, 39);
            pathSelectButton.Name = "pathSelectButton";
            pathSelectButton.Size = new Size(51, 30);
            pathSelectButton.TabIndex = 5;
            pathSelectButton.Text = ">>";
            pathSelectButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 72);
            label3.Name = "label3";
            label3.Size = new Size(102, 36);
            label3.TabIndex = 6;
            label3.Text = "Search results:";
            // 
            // searchButton
            // 
            searchButton.Dock = DockStyle.Fill;
            searchButton.Location = new Point(348, 3);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(91, 30);
            searchButton.TabIndex = 7;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Dock = DockStyle.Fill;
            cancelButton.Location = new Point(348, 39);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(91, 30);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // goToFileButton
            // 
            goToFileButton.Dock = DockStyle.Fill;
            goToFileButton.Location = new Point(348, 75);
            goToFileButton.Name = "goToFileButton";
            goToFileButton.Size = new Size(91, 30);
            goToFileButton.TabIndex = 9;
            goToFileButton.Text = "Go to file";
            goToFileButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 108F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 57F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 97F));
            tableLayoutPanel1.Controls.Add(progressBar, 0, 5);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(fileListView, 0, 4);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(searchForTextBox, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(searchButton, 3, 0);
            tableLayoutPanel1.Controls.Add(pathSelectButton, 2, 1);
            tableLayoutPanel1.Controls.Add(cancelButton, 3, 1);
            tableLayoutPanel1.Controls.Add(searchInTextBox, 1, 1);
            tableLayoutPanel1.Controls.Add(goToFileButton, 3, 2);
            tableLayoutPanel1.Controls.Add(includeSubdirs, 1, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 3);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(442, 481);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // progressBar
            // 
            tableLayoutPanel1.SetColumnSpan(progressBar, 4);
            progressBar.Dock = DockStyle.Fill;
            progressBar.Location = new Point(3, 464);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(436, 14);
            progressBar.TabIndex = 11;
            // 
            // includeSubdirs
            // 
            includeSubdirs.AutoSize = true;
            includeSubdirs.Checked = true;
            includeSubdirs.CheckState = CheckState.Checked;
            tableLayoutPanel1.SetColumnSpan(includeSubdirs, 2);
            includeSubdirs.Location = new Point(111, 75);
            includeSubdirs.Name = "includeSubdirs";
            includeSubdirs.Size = new Size(188, 24);
            includeSubdirs.TabIndex = 10;
            includeSubdirs.Text = "Search in subdirectories";
            includeSubdirs.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel1.SetColumnSpan(tableLayoutPanel2, 4);
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 173F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 157F));
            tableLayoutPanel2.Controls.Add(includeDirsCheck, 0, 0);
            tableLayoutPanel2.Controls.Add(includeFilesCheck, 0, 1);
            tableLayoutPanel2.Controls.Add(matchCaseCheck, 1, 0);
            tableLayoutPanel2.Controls.Add(searchExactCheck, 1, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 108);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 51.8518524F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 48.1481476F));
            tableLayoutPanel2.Size = new Size(442, 51);
            tableLayoutPanel2.TabIndex = 12;
            // 
            // includeDirsCheck
            // 
            includeDirsCheck.AutoSize = true;
            includeDirsCheck.Checked = true;
            includeDirsCheck.CheckState = CheckState.Checked;
            includeDirsCheck.Location = new Point(3, 0);
            includeDirsCheck.Margin = new Padding(3, 0, 0, 0);
            includeDirsCheck.Name = "includeDirsCheck";
            includeDirsCheck.Size = new Size(153, 24);
            includeDirsCheck.TabIndex = 0;
            includeDirsCheck.Text = "Include directories";
            includeDirsCheck.UseVisualStyleBackColor = true;
            // 
            // includeFilesCheck
            // 
            includeFilesCheck.AutoSize = true;
            includeFilesCheck.Checked = true;
            includeFilesCheck.CheckState = CheckState.Checked;
            includeFilesCheck.Location = new Point(3, 26);
            includeFilesCheck.Margin = new Padding(3, 0, 0, 0);
            includeFilesCheck.Name = "includeFilesCheck";
            includeFilesCheck.Size = new Size(110, 24);
            includeFilesCheck.TabIndex = 1;
            includeFilesCheck.Text = "Include files";
            includeFilesCheck.UseVisualStyleBackColor = true;
            // 
            // matchCaseCheck
            // 
            matchCaseCheck.AutoSize = true;
            matchCaseCheck.Location = new Point(173, 0);
            matchCaseCheck.Margin = new Padding(0);
            matchCaseCheck.Name = "matchCaseCheck";
            matchCaseCheck.Size = new Size(105, 24);
            matchCaseCheck.TabIndex = 2;
            matchCaseCheck.Text = "Match case";
            matchCaseCheck.UseVisualStyleBackColor = true;
            // 
            // searchExactCheck
            // 
            searchExactCheck.AutoSize = true;
            searchExactCheck.Location = new Point(173, 26);
            searchExactCheck.Margin = new Padding(0);
            searchExactCheck.Name = "searchExactCheck";
            searchExactCheck.Size = new Size(114, 24);
            searchExactCheck.TabIndex = 3;
            searchExactCheck.Text = "Search exact";
            searchExactCheck.UseVisualStyleBackColor = true;
            // 
            // SearchBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 499);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(484, 546);
            Name = "SearchBox";
            Text = "File Search";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox searchForTextBox;
        private TextBox searchInTextBox;
        private ListView fileListView;
        private Label label1;
        private Label label2;
        private Button pathSelectButton;
        private Label label3;
        private Button searchButton;
        private Button cancelButton;
        private Button goToFileButton;
        private FolderBrowserDialog folderBrowserDialog1;
        private ColumnHeader filesColumn;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox includeSubdirs;
        private ProgressBar progressBar;
        private TableLayoutPanel tableLayoutPanel2;
        private CheckBox includeDirsCheck;
        private CheckBox includeFilesCheck;
        private CheckBox matchCaseCheck;
        private CheckBox searchExactCheck;
    }
}
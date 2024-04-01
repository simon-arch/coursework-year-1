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
            Files = new ColumnHeader();
            label1 = new Label();
            label2 = new Label();
            pathSelectButton = new Button();
            label3 = new Label();
            searchButton = new Button();
            cancelButton = new Button();
            goToFileButton = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // searchForTextBox
            // 
            tableLayoutPanel1.SetColumnSpan(searchForTextBox, 2);
            searchForTextBox.Dock = DockStyle.Fill;
            searchForTextBox.Location = new Point(111, 3);
            searchForTextBox.Name = "searchForTextBox";
            searchForTextBox.Size = new Size(232, 27);
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
            fileListView.Columns.AddRange(new ColumnHeader[] { Files });
            tableLayoutPanel1.SetColumnSpan(fileListView, 4);
            fileListView.FullRowSelect = true;
            fileListView.HeaderStyle = ColumnHeaderStyle.None;
            fileListView.Location = new Point(3, 111);
            fileListView.Name = "fileListView";
            fileListView.Size = new Size(436, 270);
            fileListView.TabIndex = 2;
            fileListView.UseCompatibleStateImageBehavior = false;
            fileListView.View = View.Details;
            // 
            // Files
            // 
            Files.Text = "Files";
            Files.Width = 435;
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
            pathSelectButton.Size = new Size(52, 30);
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
            searchButton.Location = new Point(349, 3);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(90, 30);
            searchButton.TabIndex = 7;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Dock = DockStyle.Fill;
            cancelButton.Location = new Point(349, 39);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(90, 30);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // goToFileButton
            // 
            goToFileButton.Dock = DockStyle.Fill;
            goToFileButton.Location = new Point(349, 75);
            goToFileButton.Name = "goToFileButton";
            goToFileButton.Size = new Size(90, 30);
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 58F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 96F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(fileListView, 0, 3);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(searchForTextBox, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(searchButton, 3, 0);
            tableLayoutPanel1.Controls.Add(pathSelectButton, 2, 1);
            tableLayoutPanel1.Controls.Add(cancelButton, 3, 1);
            tableLayoutPanel1.Controls.Add(searchInTextBox, 1, 1);
            tableLayoutPanel1.Controls.Add(goToFileButton, 3, 2);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(442, 384);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // SearchBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 408);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SearchBox";
            Text = "File Search";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
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
        private ColumnHeader Files;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
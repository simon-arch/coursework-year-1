namespace filemanager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip = new MenuStrip();
            showTab = new ToolStripMenuItem();
            showExtensionsTool = new ToolStripMenuItem();
            showHiddenFoldersTool = new ToolStripMenuItem();
            tabsTab = new ToolStripMenuItem();
            createTabTool = new ToolStripMenuItem();
            deleteTabTool = new ToolStripMenuItem();
            markToolStripMenuItem = new ToolStripMenuItem();
            selectAllTool = new ToolStripMenuItem();
            unselectAllTool = new ToolStripMenuItem();
            selectAllWithTheSameExtensionTool = new ToolStripMenuItem();
            copySelectedNamesToClipboardTool = new ToolStripMenuItem();
            copyNamesWithPathToClipboardTool = new ToolStripMenuItem();
            fileSystemWatcher1 = new FileSystemWatcher();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            comboBox1 = new ComboBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            listView1 = new ListView();
            tabPage2 = new TabPage();
            label1 = new Label();
            label2 = new Label();
            tabControl2 = new TabControl();
            imagePreviewTab = new TabPage();
            documentPreviewTab = new TabPage();
            richTextBox1 = new RichTextBox();
            searchTextBox = new TextBox();
            toolStrip = new ToolStrip();
            quickRefreshTool = new ToolStripButton();
            goUpTool = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            listViewSetView1 = new ToolStripButton();
            listViewSetView2 = new ToolStripButton();
            listViewSetView3 = new ToolStripButton();
            listViewSetView4 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            invertSelectionTool = new ToolStripButton();
            zipTool = new ToolStripButton();
            unzipTool = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            searchTool = new ToolStripButton();
            notepadTool = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            diskInfoTool = new ToolStripButton();
            menuStrip1 = new MenuStrip();
            refreshTool = new ToolStripMenuItem();
            renameTool = new ToolStripMenuItem();
            viewTool = new ToolStripMenuItem();
            editTool = new ToolStripMenuItem();
            copyTool = new ToolStripMenuItem();
            cutTool = new ToolStripMenuItem();
            pasteTool = new ToolStripMenuItem();
            newFolderTool = new ToolStripMenuItem();
            deleteTool = new ToolStripMenuItem();
            exitTool = new ToolStripMenuItem();
            imageList1 = new ImageList(components);
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl2.SuspendLayout();
            imagePreviewTab.SuspendLayout();
            documentPreviewTab.SuspendLayout();
            toolStrip.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { showTab, tabsTab, markToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 28);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip";
            // 
            // showTab
            // 
            showTab.DropDownItems.AddRange(new ToolStripItem[] { showExtensionsTool, showHiddenFoldersTool });
            showTab.Name = "showTab";
            showTab.Size = new Size(59, 24);
            showTab.Text = "Show";
            // 
            // showExtensionsTool
            // 
            showExtensionsTool.CheckOnClick = true;
            showExtensionsTool.Name = "showExtensionsTool";
            showExtensionsTool.Size = new Size(193, 26);
            showExtensionsTool.Text = "File Extensions";
            // 
            // showHiddenFoldersTool
            // 
            showHiddenFoldersTool.CheckOnClick = true;
            showHiddenFoldersTool.Name = "showHiddenFoldersTool";
            showHiddenFoldersTool.Size = new Size(193, 26);
            showHiddenFoldersTool.Text = "Hidden Folders";
            // 
            // tabsTab
            // 
            tabsTab.DropDownItems.AddRange(new ToolStripItem[] { createTabTool, deleteTabTool });
            tabsTab.Name = "tabsTab";
            tabsTab.Size = new Size(52, 24);
            tabsTab.Text = "Tabs";
            // 
            // createTabTool
            // 
            createTabTool.Name = "createTabTool";
            createTabTool.Size = new Size(163, 26);
            createTabTool.Text = "Create Tab";
            // 
            // deleteTabTool
            // 
            deleteTabTool.Name = "deleteTabTool";
            deleteTabTool.Size = new Size(163, 26);
            deleteTabTool.Text = "Delete Tab";
            // 
            // markToolStripMenuItem
            // 
            markToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { selectAllTool, unselectAllTool, selectAllWithTheSameExtensionTool, copySelectedNamesToClipboardTool, copyNamesWithPathToClipboardTool });
            markToolStripMenuItem.Name = "markToolStripMenuItem";
            markToolStripMenuItem.Size = new Size(56, 24);
            markToolStripMenuItem.Text = "Mark";
            // 
            // selectAllTool
            // 
            selectAllTool.Image = (Image)resources.GetObject("selectAllTool.Image");
            selectAllTool.ImageScaling = ToolStripItemImageScaling.None;
            selectAllTool.ImageTransparentColor = Color.Black;
            selectAllTool.Name = "selectAllTool";
            selectAllTool.Size = new Size(325, 26);
            selectAllTool.Text = "Select all";
            // 
            // unselectAllTool
            // 
            unselectAllTool.Image = (Image)resources.GetObject("unselectAllTool.Image");
            unselectAllTool.ImageScaling = ToolStripItemImageScaling.None;
            unselectAllTool.ImageTransparentColor = Color.Black;
            unselectAllTool.Name = "unselectAllTool";
            unselectAllTool.Size = new Size(325, 26);
            unselectAllTool.Text = "Unselect all";
            // 
            // selectAllWithTheSameExtensionTool
            // 
            selectAllWithTheSameExtensionTool.Image = (Image)resources.GetObject("selectAllWithTheSameExtensionTool.Image");
            selectAllWithTheSameExtensionTool.ImageScaling = ToolStripItemImageScaling.None;
            selectAllWithTheSameExtensionTool.ImageTransparentColor = Color.Black;
            selectAllWithTheSameExtensionTool.Name = "selectAllWithTheSameExtensionTool";
            selectAllWithTheSameExtensionTool.Size = new Size(325, 26);
            selectAllWithTheSameExtensionTool.Text = "Select all with the same extension";
            // 
            // copySelectedNamesToClipboardTool
            // 
            copySelectedNamesToClipboardTool.Image = (Image)resources.GetObject("copySelectedNamesToClipboardTool.Image");
            copySelectedNamesToClipboardTool.ImageScaling = ToolStripItemImageScaling.None;
            copySelectedNamesToClipboardTool.ImageTransparentColor = Color.Black;
            copySelectedNamesToClipboardTool.Name = "copySelectedNamesToClipboardTool";
            copySelectedNamesToClipboardTool.Size = new Size(325, 26);
            copySelectedNamesToClipboardTool.Text = "Copy selected names to clipboard";
            // 
            // copyNamesWithPathToClipboardTool
            // 
            copyNamesWithPathToClipboardTool.Image = (Image)resources.GetObject("copyNamesWithPathToClipboardTool.Image");
            copyNamesWithPathToClipboardTool.ImageScaling = ToolStripItemImageScaling.None;
            copyNamesWithPathToClipboardTool.ImageTransparentColor = Color.Black;
            copyNamesWithPathToClipboardTool.Name = "copyNamesWithPathToClipboardTool";
            copyNamesWithPathToClipboardTool.Size = new Size(325, 26);
            copyNamesWithPathToClipboardTool.Text = "Copy names with path to clipboard";
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.IncludeSubdirectories = true;
            fileSystemWatcher1.Path = "D:\\Games\\testingFields";
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(223, 243);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.00000048F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.9999962F));
            tableLayoutPanel1.Controls.Add(comboBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 2);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(tabControl2, 3, 1);
            tableLayoutPanel1.Controls.Add(searchTextBox, 3, 2);
            tableLayoutPanel1.Location = new Point(25, 77);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 92.68292F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.317074F));
            tableLayoutPanel1.Size = new Size(751, 340);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // comboBox1
            // 
            comboBox1.Cursor = Cursors.Hand;
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(3, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(74, 28);
            comboBox1.TabIndex = 6;
            // 
            // tabControl1
            // 
            tableLayoutPanel1.SetColumnSpan(tabControl1, 2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.ItemSize = new Size(74, 25);
            tabControl1.Location = new Point(3, 33);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(476, 258);
            tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(listView1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(0);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(468, 225);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.Location = new Point(0, 0);
            listView1.Margin = new Padding(0);
            listView1.Name = "listView1";
            listView1.Size = new Size(468, 225);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(468, 225);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "+";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label1, 2);
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 294);
            label1.Name = "label1";
            label1.Size = new Size(476, 25);
            label1.TabIndex = 6;
            label1.Text = "totalFileSize";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(83, 0);
            label2.Name = "label2";
            label2.Size = new Size(396, 30);
            label2.TabIndex = 7;
            label2.Text = "totalFreeSpace";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabControl2
            // 
            tabControl2.Appearance = TabAppearance.FlatButtons;
            tabControl2.Controls.Add(imagePreviewTab);
            tabControl2.Controls.Add(documentPreviewTab);
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.ItemSize = new Size(0, 1);
            tabControl2.Location = new Point(511, 33);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(237, 258);
            tabControl2.SizeMode = TabSizeMode.Fixed;
            tabControl2.TabIndex = 8;
            // 
            // imagePreviewTab
            // 
            imagePreviewTab.Controls.Add(pictureBox1);
            imagePreviewTab.Location = new Point(4, 5);
            imagePreviewTab.Name = "imagePreviewTab";
            imagePreviewTab.Padding = new Padding(3);
            imagePreviewTab.Size = new Size(229, 249);
            imagePreviewTab.TabIndex = 0;
            imagePreviewTab.Text = "image";
            imagePreviewTab.UseVisualStyleBackColor = true;
            // 
            // documentPreviewTab
            // 
            documentPreviewTab.Controls.Add(richTextBox1);
            documentPreviewTab.Location = new Point(4, 5);
            documentPreviewTab.Name = "documentPreviewTab";
            documentPreviewTab.Padding = new Padding(3);
            documentPreviewTab.Size = new Size(229, 249);
            documentPreviewTab.TabIndex = 1;
            documentPreviewTab.Text = "text";
            documentPreviewTab.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(3, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(223, 243);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // searchTextBox
            // 
            searchTextBox.Dock = DockStyle.Fill;
            searchTextBox.Location = new Point(511, 297);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(237, 27);
            searchTextBox.TabIndex = 9;
            // 
            // toolStrip
            // 
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { quickRefreshTool, goUpTool, toolStripSeparator1, listViewSetView1, listViewSetView2, listViewSetView3, listViewSetView4, toolStripSeparator2, invertSelectionTool, zipTool, unzipTool, toolStripSeparator3, searchTool, notepadTool, toolStripSeparator4, diskInfoTool });
            toolStrip.Location = new Point(0, 28);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(800, 25);
            toolStrip.TabIndex = 4;
            toolStrip.Text = "toolStrip";
            // 
            // quickRefreshTool
            // 
            quickRefreshTool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            quickRefreshTool.Image = (Image)resources.GetObject("quickRefreshTool.Image");
            quickRefreshTool.ImageScaling = ToolStripItemImageScaling.None;
            quickRefreshTool.ImageTransparentColor = Color.Black;
            quickRefreshTool.Name = "quickRefreshTool";
            quickRefreshTool.Size = new Size(29, 22);
            quickRefreshTool.Text = "toolStripButton1";
            quickRefreshTool.ToolTipText = "Refresh";
            // 
            // goUpTool
            // 
            goUpTool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            goUpTool.Image = (Image)resources.GetObject("goUpTool.Image");
            goUpTool.ImageScaling = ToolStripItemImageScaling.None;
            goUpTool.ImageTransparentColor = Color.Black;
            goUpTool.Name = "goUpTool";
            goUpTool.Size = new Size(29, 22);
            goUpTool.Text = "Go Up";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // listViewSetView1
            // 
            listViewSetView1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            listViewSetView1.Image = (Image)resources.GetObject("listViewSetView1.Image");
            listViewSetView1.ImageScaling = ToolStripItemImageScaling.None;
            listViewSetView1.ImageTransparentColor = Color.Black;
            listViewSetView1.Name = "listViewSetView1";
            listViewSetView1.Size = new Size(29, 22);
            listViewSetView1.Text = "File Details View";
            // 
            // listViewSetView2
            // 
            listViewSetView2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            listViewSetView2.Image = (Image)resources.GetObject("listViewSetView2.Image");
            listViewSetView2.ImageScaling = ToolStripItemImageScaling.None;
            listViewSetView2.ImageTransparentColor = Color.Black;
            listViewSetView2.Name = "listViewSetView2";
            listViewSetView2.Size = new Size(29, 22);
            listViewSetView2.Text = "Small Icon View";
            // 
            // listViewSetView3
            // 
            listViewSetView3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            listViewSetView3.Image = (Image)resources.GetObject("listViewSetView3.Image");
            listViewSetView3.ImageScaling = ToolStripItemImageScaling.None;
            listViewSetView3.ImageTransparentColor = Color.Black;
            listViewSetView3.Name = "listViewSetView3";
            listViewSetView3.Size = new Size(29, 22);
            listViewSetView3.Text = "List View";
            // 
            // listViewSetView4
            // 
            listViewSetView4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            listViewSetView4.Image = (Image)resources.GetObject("listViewSetView4.Image");
            listViewSetView4.ImageScaling = ToolStripItemImageScaling.None;
            listViewSetView4.ImageTransparentColor = Color.Black;
            listViewSetView4.Name = "listViewSetView4";
            listViewSetView4.Size = new Size(29, 22);
            listViewSetView4.Text = "Tile View";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // invertSelectionTool
            // 
            invertSelectionTool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            invertSelectionTool.Image = (Image)resources.GetObject("invertSelectionTool.Image");
            invertSelectionTool.ImageScaling = ToolStripItemImageScaling.None;
            invertSelectionTool.ImageTransparentColor = Color.Black;
            invertSelectionTool.Name = "invertSelectionTool";
            invertSelectionTool.Size = new Size(29, 22);
            invertSelectionTool.Text = "Invert Selection";
            // 
            // zipTool
            // 
            zipTool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            zipTool.Image = (Image)resources.GetObject("zipTool.Image");
            zipTool.ImageScaling = ToolStripItemImageScaling.None;
            zipTool.ImageTransparentColor = Color.Black;
            zipTool.Name = "zipTool";
            zipTool.Size = new Size(29, 22);
            zipTool.Text = "Zip Selected Folders";
            // 
            // unzipTool
            // 
            unzipTool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            unzipTool.Image = (Image)resources.GetObject("unzipTool.Image");
            unzipTool.ImageScaling = ToolStripItemImageScaling.None;
            unzipTool.ImageTransparentColor = Color.Black;
            unzipTool.Name = "unzipTool";
            unzipTool.Size = new Size(29, 22);
            unzipTool.Text = "Unzip Selected Archives";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // searchTool
            // 
            searchTool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            searchTool.Image = (Image)resources.GetObject("searchTool.Image");
            searchTool.ImageScaling = ToolStripItemImageScaling.None;
            searchTool.ImageTransparentColor = Color.Black;
            searchTool.Name = "searchTool";
            searchTool.Size = new Size(29, 22);
            searchTool.Text = "Search For...";
            // 
            // notepadTool
            // 
            notepadTool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            notepadTool.Image = (Image)resources.GetObject("notepadTool.Image");
            notepadTool.ImageScaling = ToolStripItemImageScaling.None;
            notepadTool.ImageTransparentColor = Color.Black;
            notepadTool.Name = "notepadTool";
            notepadTool.Size = new Size(29, 22);
            notepadTool.Text = "Open Notepad";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // diskInfoTool
            // 
            diskInfoTool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            diskInfoTool.Image = (Image)resources.GetObject("diskInfoTool.Image");
            diskInfoTool.ImageScaling = ToolStripItemImageScaling.None;
            diskInfoTool.ImageTransparentColor = Color.Black;
            diskInfoTool.Name = "diskInfoTool";
            diskInfoTool.Size = new Size(29, 22);
            diskInfoTool.Text = "Show Disk Info";
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.Bottom;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { refreshTool, renameTool, viewTool, editTool, copyTool, cutTool, pasteTool, newFolderTool, deleteTool, exitTool });
            menuStrip1.Location = new Point(0, 422);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // refreshTool
            // 
            refreshTool.Name = "refreshTool";
            refreshTool.ShortcutKeys = Keys.F1;
            refreshTool.Size = new Size(91, 24);
            refreshTool.Text = "F1 Refresh";
            // 
            // renameTool
            // 
            renameTool.Name = "renameTool";
            renameTool.ShortcutKeys = Keys.F2;
            renameTool.Size = new Size(96, 24);
            renameTool.Text = "F2 Rename";
            // 
            // viewTool
            // 
            viewTool.Name = "viewTool";
            viewTool.ShortcutKeys = Keys.F3;
            viewTool.Size = new Size(74, 24);
            viewTool.Text = "F3 View";
            // 
            // editTool
            // 
            editTool.Name = "editTool";
            editTool.ShortcutKeys = Keys.F4;
            editTool.Size = new Size(68, 24);
            editTool.Text = "F4 Edit";
            // 
            // copyTool
            // 
            copyTool.Name = "copyTool";
            copyTool.ShortcutKeys = Keys.F5;
            copyTool.Size = new Size(76, 24);
            copyTool.Text = "F5 Copy";
            // 
            // cutTool
            // 
            cutTool.Name = "cutTool";
            cutTool.ShortcutKeys = Keys.F6;
            cutTool.Size = new Size(64, 24);
            cutTool.Text = "F6 Cut";
            // 
            // pasteTool
            // 
            pasteTool.Name = "pasteTool";
            pasteTool.ShortcutKeys = Keys.F7;
            pasteTool.Size = new Size(76, 24);
            pasteTool.Text = "F7 Paste";
            // 
            // newFolderTool
            // 
            newFolderTool.Name = "newFolderTool";
            newFolderTool.ShortcutKeys = Keys.F8;
            newFolderTool.Size = new Size(114, 24);
            newFolderTool.Text = "F8 NewFolder";
            // 
            // deleteTool
            // 
            deleteTool.Name = "deleteTool";
            deleteTool.ShortcutKeys = Keys.F9;
            deleteTool.Size = new Size(86, 24);
            deleteTool.Text = "F9 Delete";
            // 
            // exitTool
            // 
            exitTool.Name = "exitTool";
            exitTool.Size = new Size(47, 24);
            exitTool.Text = "Exit";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "11.ico");
            imageList1.Images.SetKeyName(1, "8.ico");
            imageList1.Images.SetKeyName(2, "2.ico");
            imageList1.Images.SetKeyName(3, "12.ico");
            imageList1.Images.SetKeyName(4, "13.ico");
            imageList1.Images.SetKeyName(5, "19.ico");
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStrip);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Name = "Form1";
            Text = "Sapphire Toolkit";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            imagePreviewTab.ResumeLayout(false);
            documentPreviewTab.ResumeLayout(false);
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip;
        private ToolStripMenuItem deleteTool;
        private FileSystemWatcher fileSystemWatcher1;
        private ToolStripMenuItem copyTool;
        private ToolStripMenuItem pasteTool;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private ToolStrip toolStrip;
        private ToolStripButton quickRefreshTool;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton listViewSetView1;
        private ToolStripButton listViewSetView2;
        private ToolStripButton listViewSetView3;
        private ToolStripButton listViewSetView4;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton invertSelectionTool;
        private TabControl tabControl1;
        private ListView listView1;
        private TabPage tabPage1;
        private ToolStripMenuItem showTab;
        private ToolStripMenuItem showExtensionsTool;
        private ToolStripMenuItem showHiddenFoldersTool;
        private TabPage tabPage2;
        private ToolStripMenuItem tabsTab;
        private ToolStripMenuItem createTabTool;
        private ToolStripMenuItem deleteTabTool;
        private ComboBox comboBox1;
        private ToolStripMenuItem markToolStripMenuItem;
        private ToolStripMenuItem selectAllTool;
        private ToolStripMenuItem unselectAllTool;
        private ToolStripMenuItem selectAllWithTheSameExtensionTool;
        private ToolStripMenuItem copySelectedNamesToClipboardTool;
        private ToolStripMenuItem copyNamesWithPathToClipboardTool;
        private ToolStripButton zipTool;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem viewTool;
        private ToolStripMenuItem editTool;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem cutTool;
        private ToolStripMenuItem newFolderTool;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem exitTool;
        private Label label1;
        private ImageList imageList1;
        private Label label2;
        private TabControl tabControl2;
        private TabPage imagePreviewTab;
        private TabPage documentPreviewTab;
        private ToolStripButton unzipTool;
        private RichTextBox richTextBox1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton searchTool;
        private ToolStripButton goUpTool;
        private ToolStripButton notepadTool;
        private ToolStripMenuItem f8PasteToolStripMenuItem;
        private ToolStripButton diskInfoTool;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem renameTool;
        private ToolStripMenuItem refreshTool;
        private TextBox searchTextBox;
    }
}
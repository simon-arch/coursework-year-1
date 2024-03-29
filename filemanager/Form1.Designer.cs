﻿namespace filemanager
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
            editTab = new ToolStripMenuItem();
            deleteTool = new ToolStripMenuItem();
            refreshTool = new ToolStripMenuItem();
            copyTool = new ToolStripMenuItem();
            pasteTool = new ToolStripMenuItem();
            showTab = new ToolStripMenuItem();
            showExtensionsTool = new ToolStripMenuItem();
            showHiddenFoldersTool = new ToolStripMenuItem();
            tabsTab = new ToolStripMenuItem();
            createTabTool = new ToolStripMenuItem();
            deleteTabTool = new ToolStripMenuItem();
            markToolStripMenuItem = new ToolStripMenuItem();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            unselectAllToolStripMenuItem = new ToolStripMenuItem();
            selectAllWithTheSameExtensionToolStripMenuItem = new ToolStripMenuItem();
            copySelectedNamesToClipboardToolStripMenuItem = new ToolStripMenuItem();
            copyNamesWithPathToClipboardToolStripMenuItem = new ToolStripMenuItem();
            fileSystemWatcher1 = new FileSystemWatcher();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            comboBox1 = new ComboBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            listView1 = new ListView();
            tabPage2 = new TabPage();
            label1 = new Label();
            toolStrip = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            listViewSetView0 = new ToolStripButton();
            listViewSetView1 = new ToolStripButton();
            listViewSetView2 = new ToolStripButton();
            listViewSetView3 = new ToolStripButton();
            listViewSetView4 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            selectionInvert = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            menuStrip1 = new MenuStrip();
            viewToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            moveToolStripMenuItem = new ToolStripMenuItem();
            newFolderToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            aToolStripMenuItem = new ToolStripMenuItem();
            imageList1 = new ImageList(components);
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            toolStrip.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { editTab, showTab, tabsTab, markToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 28);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip";
            // 
            // editTab
            // 
            editTab.DropDownItems.AddRange(new ToolStripItem[] { deleteTool, refreshTool, copyTool, pasteTool });
            editTab.Name = "editTab";
            editTab.Size = new Size(49, 24);
            editTab.Text = "Edit";
            // 
            // deleteTool
            // 
            deleteTool.Name = "deleteTool";
            deleteTool.ShortcutKeys = Keys.Delete;
            deleteTool.Size = new Size(177, 26);
            deleteTool.Text = "Delete";
            deleteTool.Click += deleteToolStripMenuItem_Click;
            // 
            // refreshTool
            // 
            refreshTool.Name = "refreshTool";
            refreshTool.ShortcutKeys = Keys.F1;
            refreshTool.Size = new Size(177, 26);
            refreshTool.Text = "Refresh";
            // 
            // copyTool
            // 
            copyTool.Name = "copyTool";
            copyTool.ShortcutKeys = Keys.Control | Keys.C;
            copyTool.Size = new Size(177, 26);
            copyTool.Text = "Copy";
            copyTool.Click += copyToolStripMenuItem_Click;
            // 
            // pasteTool
            // 
            pasteTool.Name = "pasteTool";
            pasteTool.ShortcutKeys = Keys.Control | Keys.V;
            pasteTool.Size = new Size(177, 26);
            pasteTool.Text = "Paste";
            pasteTool.Click += pasteToolStripMenuItem_Click;
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
            createTabTool.Click += addNewToolStripMenuItem_Click;
            // 
            // deleteTabTool
            // 
            deleteTabTool.Name = "deleteTabTool";
            deleteTabTool.Size = new Size(163, 26);
            deleteTabTool.Text = "Delete Tab";
            deleteTabTool.Click += deleteToolStripMenuItem1_Click;
            // 
            // markToolStripMenuItem
            // 
            markToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { selectAllToolStripMenuItem, unselectAllToolStripMenuItem, selectAllWithTheSameExtensionToolStripMenuItem, copySelectedNamesToClipboardToolStripMenuItem, copyNamesWithPathToClipboardToolStripMenuItem });
            markToolStripMenuItem.Name = "markToolStripMenuItem";
            markToolStripMenuItem.Size = new Size(56, 24);
            markToolStripMenuItem.Text = "Mark";
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.Size = new Size(325, 26);
            selectAllToolStripMenuItem.Text = "Select all";
            selectAllToolStripMenuItem.Click += selectAllToolStripMenuItem_Click;
            // 
            // unselectAllToolStripMenuItem
            // 
            unselectAllToolStripMenuItem.Name = "unselectAllToolStripMenuItem";
            unselectAllToolStripMenuItem.Size = new Size(325, 26);
            unselectAllToolStripMenuItem.Text = "Unselect all";
            unselectAllToolStripMenuItem.Click += unselectAllToolStripMenuItem_Click;
            // 
            // selectAllWithTheSameExtensionToolStripMenuItem
            // 
            selectAllWithTheSameExtensionToolStripMenuItem.Name = "selectAllWithTheSameExtensionToolStripMenuItem";
            selectAllWithTheSameExtensionToolStripMenuItem.Size = new Size(325, 26);
            selectAllWithTheSameExtensionToolStripMenuItem.Text = "Select all with the same extension";
            selectAllWithTheSameExtensionToolStripMenuItem.Click += selectAllWithTheSameExtensionToolStripMenuItem_Click;
            // 
            // copySelectedNamesToClipboardToolStripMenuItem
            // 
            copySelectedNamesToClipboardToolStripMenuItem.Name = "copySelectedNamesToClipboardToolStripMenuItem";
            copySelectedNamesToClipboardToolStripMenuItem.Size = new Size(325, 26);
            copySelectedNamesToClipboardToolStripMenuItem.Text = "Copy selected names to clipboard";
            copySelectedNamesToClipboardToolStripMenuItem.Click += copySelectedNamesToClipboardToolStripMenuItem_Click;
            // 
            // copyNamesWithPathToClipboardToolStripMenuItem
            // 
            copyNamesWithPathToClipboardToolStripMenuItem.Name = "copyNamesWithPathToClipboardToolStripMenuItem";
            copyNamesWithPathToClipboardToolStripMenuItem.Size = new Size(325, 26);
            copyNamesWithPathToClipboardToolStripMenuItem.Text = "Copy names with path to clipboard";
            copyNamesWithPathToClipboardToolStripMenuItem.Click += copyNamesWithPathToClipboardToolStripMenuItem_Click;
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
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(507, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(241, 257);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.5454559F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.63636374F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.727272F));
            tableLayoutPanel1.Controls.Add(comboBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(pictureBox1, 3, 1);
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 2);
            tableLayoutPanel1.Location = new Point(25, 77);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.2040815F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 77.55102F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.122449F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.122449F));
            tableLayoutPanel1.Size = new Size(751, 340);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(3, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(62, 28);
            comboBox1.TabIndex = 5;
            // 
            // tabControl1
            // 
            tableLayoutPanel1.SetColumnSpan(tabControl1, 2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.ItemSize = new Size(74, 25);
            tabControl1.Location = new Point(3, 37);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(471, 257);
            tabControl1.TabIndex = 5;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(listView1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(0);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(463, 224);
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
            listView1.Size = new Size(463, 224);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(463, 224);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "+";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label1, 2);
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 297);
            label1.Name = "label1";
            label1.Size = new Size(471, 20);
            label1.TabIndex = 6;
            label1.Text = "filesize";
            // 
            // toolStrip
            // 
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripSeparator1, listViewSetView0, listViewSetView1, listViewSetView2, listViewSetView3, listViewSetView4, toolStripSeparator2, selectionInvert, toolStripButton2 });
            toolStrip.Location = new Point(0, 28);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(800, 27);
            toolStrip.TabIndex = 4;
            toolStrip.Text = "toolStrip";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(29, 24);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // listViewSetView0
            // 
            listViewSetView0.DisplayStyle = ToolStripItemDisplayStyle.Image;
            listViewSetView0.Image = (Image)resources.GetObject("listViewSetView0.Image");
            listViewSetView0.ImageTransparentColor = Color.Magenta;
            listViewSetView0.Name = "listViewSetView0";
            listViewSetView0.Size = new Size(29, 24);
            listViewSetView0.Text = "toolStripButton2";
            // 
            // listViewSetView1
            // 
            listViewSetView1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            listViewSetView1.Image = (Image)resources.GetObject("listViewSetView1.Image");
            listViewSetView1.ImageTransparentColor = Color.Magenta;
            listViewSetView1.Name = "listViewSetView1";
            listViewSetView1.Size = new Size(29, 24);
            listViewSetView1.Text = "toolStripButton3";
            // 
            // listViewSetView2
            // 
            listViewSetView2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            listViewSetView2.Image = (Image)resources.GetObject("listViewSetView2.Image");
            listViewSetView2.ImageTransparentColor = Color.Magenta;
            listViewSetView2.Name = "listViewSetView2";
            listViewSetView2.Size = new Size(29, 24);
            listViewSetView2.Text = "toolStripButton4";
            // 
            // listViewSetView3
            // 
            listViewSetView3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            listViewSetView3.Image = (Image)resources.GetObject("listViewSetView3.Image");
            listViewSetView3.ImageTransparentColor = Color.Magenta;
            listViewSetView3.Name = "listViewSetView3";
            listViewSetView3.Size = new Size(29, 24);
            listViewSetView3.Text = "toolStripButton5";
            // 
            // listViewSetView4
            // 
            listViewSetView4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            listViewSetView4.Image = (Image)resources.GetObject("listViewSetView4.Image");
            listViewSetView4.ImageTransparentColor = Color.Magenta;
            listViewSetView4.Name = "listViewSetView4";
            listViewSetView4.Size = new Size(29, 24);
            listViewSetView4.Text = "toolStripButton6";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // selectionInvert
            // 
            selectionInvert.DisplayStyle = ToolStripItemDisplayStyle.Image;
            selectionInvert.Image = (Image)resources.GetObject("selectionInvert.Image");
            selectionInvert.ImageTransparentColor = Color.Magenta;
            selectionInvert.Name = "selectionInvert";
            selectionInvert.Size = new Size(29, 24);
            selectionInvert.Text = "toolStripButton7";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(29, 24);
            toolStripButton2.Text = "toolStripButton2";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.Bottom;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { viewToolStripMenuItem, editToolStripMenuItem, copyToolStripMenuItem, moveToolStripMenuItem, newFolderToolStripMenuItem, deleteToolStripMenuItem, aToolStripMenuItem });
            menuStrip1.Location = new Point(0, 422);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(55, 24);
            viewToolStripMenuItem.Text = "View";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(49, 24);
            editToolStripMenuItem.Text = "Edit";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(57, 24);
            copyToolStripMenuItem.Text = "Copy";
            // 
            // moveToolStripMenuItem
            // 
            moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            moveToolStripMenuItem.Size = new Size(60, 24);
            moveToolStripMenuItem.Text = "Move";
            // 
            // newFolderToolStripMenuItem
            // 
            newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            newFolderToolStripMenuItem.Size = new Size(95, 24);
            newFolderToolStripMenuItem.Text = "NewFolder";
            newFolderToolStripMenuItem.Click += newFolderToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(67, 24);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // aToolStripMenuItem
            // 
            aToolStripMenuItem.Name = "aToolStripMenuItem";
            aToolStripMenuItem.Size = new Size(47, 24);
            aToolStripMenuItem.Text = "Exit";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "39.ico");
            imageList1.Images.SetKeyName(1, "30.ico");
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
            MainMenuStrip = menuStrip;
            Name = "Form1";
            Text = "Sapphire";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip;
        private ToolStripMenuItem editTab;
        private ToolStripMenuItem deleteTool;
        private ToolStripMenuItem refreshTool;
        private FileSystemWatcher fileSystemWatcher1;
        private ToolStripMenuItem copyTool;
        private ToolStripMenuItem pasteTool;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private ToolStrip toolStrip;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton listViewSetView0;
        private ToolStripButton listViewSetView1;
        private ToolStripButton listViewSetView2;
        private ToolStripButton listViewSetView3;
        private ToolStripButton listViewSetView4;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton selectionInvert;
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
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem unselectAllToolStripMenuItem;
        private ToolStripMenuItem selectAllWithTheSameExtensionToolStripMenuItem;
        private ToolStripMenuItem copySelectedNamesToClipboardToolStripMenuItem;
        private ToolStripMenuItem copyNamesWithPathToClipboardToolStripMenuItem;
        private ToolStripButton toolStripButton2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem moveToolStripMenuItem;
        private ToolStripMenuItem newFolderToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem aToolStripMenuItem;
        private Label label1;
        private ImageList imageList1;
    }
}
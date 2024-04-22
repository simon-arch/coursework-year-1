namespace filemanager.Dialogs
{
    partial class EditQuickBar
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditQuickBar));
            previewList = new ListView();
            imageList = new ImageList(components);
            addElement = new Button();
            deleteElement = new Button();
            iniPathTextBox = new TextBox();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            imageSizeText = new NumericUpDown();
            toolBarSizeText = new NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            isBackupOld = new CheckBox();
            commandTextBox = new TextBox();
            openIniPath = new Button();
            label1 = new Label();
            searchCommands = new Button();
            iconSelectionList = new ListView();
            okButton = new Button();
            cancelButton = new Button();
            insertSeparator = new Button();
            isAction = new RadioButton();
            isProcess = new RadioButton();
            replaceElement = new Button();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageSizeText).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toolBarSizeText).BeginInit();
            SuspendLayout();
            // 
            // previewList
            // 
            previewList.Alignment = ListViewAlignment.Left;
            previewList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            previewList.FullRowSelect = true;
            previewList.LargeImageList = imageList;
            previewList.Location = new Point(112, 45);
            previewList.Margin = new Padding(0);
            previewList.MultiSelect = false;
            previewList.Name = "previewList";
            previewList.Size = new Size(314, 75);
            previewList.TabIndex = 1;
            previewList.TileSize = new Size(48, 48);
            previewList.UseCompatibleStateImageBehavior = false;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth24Bit;
            imageList.ImageSize = new Size(24, 24);
            imageList.TransparentColor = Color.Black;
            // 
            // addElement
            // 
            addElement.Location = new Point(9, 45);
            addElement.Name = "addElement";
            addElement.Size = new Size(47, 37);
            addElement.TabIndex = 2;
            addElement.Text = "Add";
            addElement.UseVisualStyleBackColor = true;
            // 
            // deleteElement
            // 
            deleteElement.Location = new Point(57, 45);
            deleteElement.Name = "deleteElement";
            deleteElement.Size = new Size(47, 37);
            deleteElement.TabIndex = 3;
            deleteElement.Text = "Del";
            deleteElement.UseVisualStyleBackColor = true;
            // 
            // iniPathTextBox
            // 
            iniPathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            iniPathTextBox.Location = new Point(112, 12);
            iniPathTextBox.Name = "iniPathTextBox";
            iniPathTextBox.ReadOnly = true;
            iniPathTextBox.Size = new Size(283, 27);
            iniPathTextBox.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Location = new Point(431, 12);
            groupBox1.Margin = new Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(163, 108);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Appearance";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(imageSizeText, 1, 1);
            tableLayoutPanel1.Controls.Add(toolBarSizeText, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 23);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(157, 82);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // imageSizeText
            // 
            imageSizeText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            imageSizeText.Location = new Point(81, 44);
            imageSizeText.Name = "imageSizeText";
            imageSizeText.Size = new Size(73, 27);
            imageSizeText.TabIndex = 20;
            // 
            // toolBarSizeText
            // 
            toolBarSizeText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            toolBarSizeText.Location = new Point(81, 3);
            toolBarSizeText.Name = "toolBarSizeText";
            toolBarSizeText.Size = new Size(73, 27);
            toolBarSizeText.TabIndex = 20;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(3, 51);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 12;
            label3.Text = "Icon Size:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(3, 10);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 11;
            label2.Text = "Bar Size:";
            // 
            // isBackupOld
            // 
            isBackupOld.AutoSize = true;
            isBackupOld.Checked = true;
            isBackupOld.CheckState = CheckState.Checked;
            isBackupOld.Location = new Point(294, 176);
            isBackupOld.Name = "isBackupOld";
            isBackupOld.Size = new Size(138, 24);
            isBackupOld.TabIndex = 8;
            isBackupOld.Text = "Backup Previous";
            isBackupOld.UseVisualStyleBackColor = true;
            // 
            // commandTextBox
            // 
            commandTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            commandTextBox.Location = new Point(112, 142);
            commandTextBox.Name = "commandTextBox";
            commandTextBox.Size = new Size(283, 27);
            commandTextBox.TabIndex = 9;
            // 
            // openIniPath
            // 
            openIniPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            openIniPath.Location = new Point(398, 12);
            openIniPath.Margin = new Padding(0);
            openIniPath.Name = "openIniPath";
            openIniPath.Size = new Size(28, 29);
            openIniPath.TabIndex = 11;
            openIniPath.Text = ">";
            openIniPath.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 145);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 12;
            label1.Text = "Command:";
            // 
            // searchCommands
            // 
            searchCommands.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchCommands.Location = new Point(398, 141);
            searchCommands.Margin = new Padding(0);
            searchCommands.Name = "searchCommands";
            searchCommands.Size = new Size(28, 29);
            searchCommands.TabIndex = 13;
            searchCommands.Text = "..";
            searchCommands.UseVisualStyleBackColor = true;
            // 
            // iconSelectionList
            // 
            iconSelectionList.Alignment = ListViewAlignment.Left;
            iconSelectionList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            iconSelectionList.FullRowSelect = true;
            iconSelectionList.GridLines = true;
            iconSelectionList.LargeImageList = imageList;
            iconSelectionList.Location = new Point(9, 211);
            iconSelectionList.Margin = new Padding(0);
            iconSelectionList.MultiSelect = false;
            iconSelectionList.Name = "iconSelectionList";
            iconSelectionList.Size = new Size(585, 81);
            iconSelectionList.TabIndex = 14;
            iconSelectionList.TileSize = new Size(48, 48);
            iconSelectionList.UseCompatibleStateImageBehavior = false;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            okButton.Location = new Point(436, 174);
            okButton.Name = "okButton";
            okButton.Size = new Size(78, 32);
            okButton.TabIndex = 15;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cancelButton.Location = new Point(515, 174);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(79, 32);
            cancelButton.TabIndex = 16;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // insertSeparator
            // 
            insertSeparator.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            insertSeparator.Location = new Point(436, 141);
            insertSeparator.Name = "insertSeparator";
            insertSeparator.Size = new Size(158, 29);
            insertSeparator.TabIndex = 17;
            insertSeparator.Text = "Insert Separator";
            insertSeparator.UseVisualStyleBackColor = true;
            // 
            // isAction
            // 
            isAction.AutoSize = true;
            isAction.Location = new Point(112, 175);
            isAction.Name = "isAction";
            isAction.Size = new Size(73, 24);
            isAction.TabIndex = 18;
            isAction.TabStop = true;
            isAction.Text = "Action";
            isAction.UseVisualStyleBackColor = true;
            // 
            // isProcess
            // 
            isProcess.AutoSize = true;
            isProcess.Location = new Point(191, 175);
            isProcess.Name = "isProcess";
            isProcess.Size = new Size(79, 24);
            isProcess.TabIndex = 19;
            isProcess.TabStop = true;
            isProcess.Text = "Process";
            isProcess.UseVisualStyleBackColor = true;
            // 
            // replaceElement
            // 
            replaceElement.Location = new Point(9, 85);
            replaceElement.Name = "replaceElement";
            replaceElement.Size = new Size(95, 35);
            replaceElement.TabIndex = 20;
            replaceElement.Text = "Replace";
            replaceElement.UseVisualStyleBackColor = true;
            // 
            // EditQuickBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 301);
            Controls.Add(replaceElement);
            Controls.Add(isProcess);
            Controls.Add(isAction);
            Controls.Add(insertSeparator);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(iconSelectionList);
            Controls.Add(searchCommands);
            Controls.Add(label1);
            Controls.Add(openIniPath);
            Controls.Add(commandTextBox);
            Controls.Add(isBackupOld);
            Controls.Add(groupBox1);
            Controls.Add(iniPathTextBox);
            Controls.Add(deleteElement);
            Controls.Add(addElement);
            Controls.Add(previewList);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(623, 348);
            Name = "EditQuickBar";
            Text = "Quickbar Edit";
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imageSizeText).EndInit();
            ((System.ComponentModel.ISupportInitialize)toolBarSizeText).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListView previewList;
        private Button addElement;
        private Button deleteElement;
        private TextBox iniPathTextBox;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox isBackupOld;
        private TextBox commandTextBox;
        private Button openIniPath;
        private Label label1;
        private Button searchCommands;
        private ListView iconSelectionList;
        private ImageList imageList;
        private Button okButton;
        private Button cancelButton;
        private Button insertSeparator;
        private RadioButton isAction;
        private RadioButton isProcess;
        private Label label3;
        private Label label2;
        private NumericUpDown toolBarSizeText;
        private NumericUpDown imageSizeText;
        private Button replaceElement;
    }
}
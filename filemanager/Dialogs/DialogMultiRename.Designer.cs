namespace filemanager.Dialogs
{
    partial class DialogMultiRename
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogMultiRename));
            fileView = new ListView();
            oldName = new ColumnHeader();
            extension = new ColumnHeader();
            newName = new ColumnHeader();
            size = new ColumnHeader();
            date = new ColumnHeader();
            location = new ColumnHeader();
            fileNameMask = new TextBox();
            fileExtensionMask = new TextBox();
            groupBox1 = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            nameMaskAddName = new Button();
            nameMaskAddDate = new Button();
            nameMaskAddTime = new Button();
            nameMaskAddPath = new Button();
            nameMaskAddCounter = new Button();
            tableLayoutPanel6 = new TableLayoutPanel();
            button6 = new Button();
            nameMaskClear = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            extensionMaskAddExtension = new Button();
            extensionMaskAddCounter = new Button();
            tableLayoutPanel7 = new TableLayoutPanel();
            button9 = new Button();
            extensionMaskClear = new Button();
            groupBox3 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel9 = new TableLayoutPanel();
            respectUpperCaseCheck = new CheckBox();
            label6 = new Label();
            extensionReplaceCheck = new CheckBox();
            label7 = new Label();
            searchForTextBox = new TextBox();
            replaceWithTextBox = new TextBox();
            label4 = new Label();
            label5 = new Label();
            groupBox4 = new GroupBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            numericStartAt = new NumericUpDown();
            numericStep = new NumericUpDown();
            comboDigits = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            counterResetButton = new Button();
            groupBox5 = new GroupBox();
            comboLetterCase = new ComboBox();
            closeButton = new Button();
            startButton = new Button();
            groupBox1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            groupBox4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericStartAt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericStep).BeginInit();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // fileView
            // 
            fileView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fileView.Columns.AddRange(new ColumnHeader[] { oldName, extension, newName, size, date, location });
            fileView.Location = new Point(12, 199);
            fileView.Name = "fileView";
            fileView.Size = new Size(895, 304);
            fileView.TabIndex = 0;
            fileView.UseCompatibleStateImageBehavior = false;
            fileView.View = View.Details;
            // 
            // oldName
            // 
            oldName.Text = "Old Name";
            oldName.Width = 150;
            // 
            // extension
            // 
            extension.Text = "Extension";
            extension.Width = 80;
            // 
            // newName
            // 
            newName.Text = "New Name";
            newName.Width = 150;
            // 
            // size
            // 
            size.Text = "Size";
            size.Width = 100;
            // 
            // date
            // 
            date.Text = "Date";
            date.Width = 150;
            // 
            // location
            // 
            location.Text = "Location";
            location.Width = 240;
            // 
            // fileNameMask
            // 
            tableLayoutPanel3.SetColumnSpan(fileNameMask, 3);
            fileNameMask.Dock = DockStyle.Fill;
            fileNameMask.Location = new Point(3, 3);
            fileNameMask.Name = "fileNameMask";
            fileNameMask.Size = new Size(206, 27);
            fileNameMask.TabIndex = 1;
            // 
            // fileExtensionMask
            // 
            fileExtensionMask.Dock = DockStyle.Fill;
            fileExtensionMask.Location = new Point(3, 3);
            fileExtensionMask.Name = "fileExtensionMask";
            fileExtensionMask.Size = new Size(102, 27);
            fileExtensionMask.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel3);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            tableLayoutPanel1.SetRowSpan(groupBox1, 2);
            groupBox1.Size = new Size(218, 175);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rename mask: file name";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
            tableLayoutPanel3.Controls.Add(fileNameMask, 0, 0);
            tableLayoutPanel3.Controls.Add(nameMaskAddName, 0, 1);
            tableLayoutPanel3.Controls.Add(nameMaskAddDate, 2, 1);
            tableLayoutPanel3.Controls.Add(nameMaskAddTime, 2, 2);
            tableLayoutPanel3.Controls.Add(nameMaskAddPath, 0, 2);
            tableLayoutPanel3.Controls.Add(nameMaskAddCounter, 0, 3);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel6, 2, 3);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 23);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.Size = new Size(212, 149);
            tableLayoutPanel3.TabIndex = 6;
            // 
            // nameMaskAddName
            // 
            nameMaskAddName.Dock = DockStyle.Fill;
            nameMaskAddName.Location = new Point(3, 40);
            nameMaskAddName.Name = "nameMaskAddName";
            nameMaskAddName.Size = new Size(95, 31);
            nameMaskAddName.TabIndex = 2;
            nameMaskAddName.Text = "[N] Name";
            nameMaskAddName.TextAlign = ContentAlignment.MiddleLeft;
            nameMaskAddName.UseVisualStyleBackColor = true;
            // 
            // nameMaskAddDate
            // 
            nameMaskAddDate.Dock = DockStyle.Fill;
            nameMaskAddDate.Location = new Point(112, 40);
            nameMaskAddDate.Name = "nameMaskAddDate";
            nameMaskAddDate.Size = new Size(97, 31);
            nameMaskAddDate.TabIndex = 3;
            nameMaskAddDate.Text = "[YMD] Date";
            nameMaskAddDate.TextAlign = ContentAlignment.MiddleLeft;
            nameMaskAddDate.UseVisualStyleBackColor = true;
            // 
            // nameMaskAddTime
            // 
            nameMaskAddTime.Dock = DockStyle.Fill;
            nameMaskAddTime.Location = new Point(112, 77);
            nameMaskAddTime.Name = "nameMaskAddTime";
            nameMaskAddTime.Size = new Size(97, 31);
            nameMaskAddTime.TabIndex = 4;
            nameMaskAddTime.Text = "[HMS] Time";
            nameMaskAddTime.TextAlign = ContentAlignment.MiddleLeft;
            nameMaskAddTime.UseVisualStyleBackColor = true;
            // 
            // nameMaskAddPath
            // 
            nameMaskAddPath.Dock = DockStyle.Fill;
            nameMaskAddPath.Location = new Point(3, 77);
            nameMaskAddPath.Name = "nameMaskAddPath";
            nameMaskAddPath.Size = new Size(95, 31);
            nameMaskAddPath.TabIndex = 5;
            nameMaskAddPath.Text = "[P] Parent";
            nameMaskAddPath.TextAlign = ContentAlignment.MiddleLeft;
            nameMaskAddPath.UseVisualStyleBackColor = true;
            // 
            // nameMaskAddCounter
            // 
            nameMaskAddCounter.Dock = DockStyle.Fill;
            nameMaskAddCounter.Location = new Point(3, 114);
            nameMaskAddCounter.Name = "nameMaskAddCounter";
            nameMaskAddCounter.Size = new Size(95, 32);
            nameMaskAddCounter.TabIndex = 6;
            nameMaskAddCounter.Text = "[C] Counter";
            nameMaskAddCounter.TextAlign = ContentAlignment.MiddleLeft;
            nameMaskAddCounter.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(button6, 0, 0);
            tableLayoutPanel6.Controls.Add(nameMaskClear, 1, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(112, 114);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(97, 32);
            tableLayoutPanel6.TabIndex = 7;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Fill;
            button6.Location = new Point(0, 0);
            button6.Margin = new Padding(0, 0, 2, 0);
            button6.Name = "button6";
            button6.Size = new Size(46, 32);
            button6.TabIndex = 7;
            button6.Text = "+";
            button6.UseVisualStyleBackColor = true;
            // 
            // nameMaskClear
            // 
            nameMaskClear.Dock = DockStyle.Fill;
            nameMaskClear.Location = new Point(50, 0);
            nameMaskClear.Margin = new Padding(2, 0, 0, 0);
            nameMaskClear.Name = "nameMaskClear";
            nameMaskClear.Size = new Size(47, 32);
            nameMaskClear.TabIndex = 8;
            nameMaskClear.Text = "X";
            nameMaskClear.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.4078217F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.4525146F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox2, 1, 0);
            tableLayoutPanel1.Controls.Add(groupBox3, 2, 0);
            tableLayoutPanel1.Controls.Add(groupBox4, 3, 0);
            tableLayoutPanel1.Controls.Add(groupBox5, 2, 1);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            tableLayoutPanel1.Size = new Size(895, 181);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tableLayoutPanel4);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(227, 3);
            groupBox2.Name = "groupBox2";
            tableLayoutPanel1.SetRowSpan(groupBox2, 2);
            groupBox2.Size = new Size(114, 175);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Extension";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(fileExtensionMask, 0, 0);
            tableLayoutPanel4.Controls.Add(extensionMaskAddExtension, 0, 1);
            tableLayoutPanel4.Controls.Add(extensionMaskAddCounter, 0, 2);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel7, 0, 3);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 23);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 4;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.Size = new Size(108, 149);
            tableLayoutPanel4.TabIndex = 6;
            // 
            // extensionMaskAddExtension
            // 
            extensionMaskAddExtension.Dock = DockStyle.Fill;
            extensionMaskAddExtension.Location = new Point(3, 40);
            extensionMaskAddExtension.Name = "extensionMaskAddExtension";
            extensionMaskAddExtension.Size = new Size(102, 31);
            extensionMaskAddExtension.TabIndex = 3;
            extensionMaskAddExtension.Text = "[E] Extension";
            extensionMaskAddExtension.TextAlign = ContentAlignment.MiddleLeft;
            extensionMaskAddExtension.UseVisualStyleBackColor = true;
            // 
            // extensionMaskAddCounter
            // 
            extensionMaskAddCounter.Dock = DockStyle.Fill;
            extensionMaskAddCounter.Location = new Point(3, 77);
            extensionMaskAddCounter.Name = "extensionMaskAddCounter";
            extensionMaskAddCounter.Size = new Size(102, 31);
            extensionMaskAddCounter.TabIndex = 4;
            extensionMaskAddCounter.Text = "[C] Counter";
            extensionMaskAddCounter.TextAlign = ContentAlignment.MiddleLeft;
            extensionMaskAddCounter.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Controls.Add(button9, 0, 0);
            tableLayoutPanel7.Controls.Add(extensionMaskClear, 1, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 114);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(102, 32);
            tableLayoutPanel7.TabIndex = 5;
            // 
            // button9
            // 
            button9.Dock = DockStyle.Fill;
            button9.Location = new Point(0, 0);
            button9.Margin = new Padding(0, 0, 2, 0);
            button9.Name = "button9";
            button9.Size = new Size(49, 32);
            button9.TabIndex = 5;
            button9.Text = "+";
            button9.UseVisualStyleBackColor = true;
            // 
            // extensionMaskClear
            // 
            extensionMaskClear.Dock = DockStyle.Fill;
            extensionMaskClear.Location = new Point(53, 0);
            extensionMaskClear.Margin = new Padding(2, 0, 0, 0);
            extensionMaskClear.Name = "extensionMaskClear";
            extensionMaskClear.Size = new Size(49, 32);
            extensionMaskClear.TabIndex = 6;
            extensionMaskClear.Text = "X";
            extensionMaskClear.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(tableLayoutPanel2);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(347, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(365, 117);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Search and Replace";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel9, 0, 2);
            tableLayoutPanel2.Controls.Add(searchForTextBox, 1, 0);
            tableLayoutPanel2.Controls.Add(replaceWithTextBox, 1, 1);
            tableLayoutPanel2.Controls.Add(label4, 0, 0);
            tableLayoutPanel2.Controls.Add(label5, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 23);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(359, 91);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 7;
            tableLayoutPanel2.SetColumnSpan(tableLayoutPanel9, 2);
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 34F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 26F));
            tableLayoutPanel9.Controls.Add(respectUpperCaseCheck, 0, 0);
            tableLayoutPanel9.Controls.Add(label6, 1, 0);
            tableLayoutPanel9.Controls.Add(extensionReplaceCheck, 2, 0);
            tableLayoutPanel9.Controls.Add(label7, 3, 0);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Location = new Point(0, 60);
            tableLayoutPanel9.Margin = new Padding(0);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel9.Size = new Size(359, 31);
            tableLayoutPanel9.TabIndex = 0;
            // 
            // respectUpperCaseCheck
            // 
            respectUpperCaseCheck.AutoSize = true;
            respectUpperCaseCheck.Location = new Point(11, 3);
            respectUpperCaseCheck.Margin = new Padding(11, 3, 3, 3);
            respectUpperCaseCheck.Name = "respectUpperCaseCheck";
            respectUpperCaseCheck.Size = new Size(16, 24);
            respectUpperCaseCheck.TabIndex = 0;
            respectUpperCaseCheck.Text = "respectUpperCaseCheck";
            respectUpperCaseCheck.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(30, 0);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(30, 31);
            label6.TabIndex = 3;
            label6.Text = "^";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // extensionReplaceCheck
            // 
            extensionReplaceCheck.AutoSize = true;
            extensionReplaceCheck.Location = new Point(71, 3);
            extensionReplaceCheck.Margin = new Padding(11, 3, 3, 3);
            extensionReplaceCheck.Name = "extensionReplaceCheck";
            extensionReplaceCheck.Size = new Size(16, 24);
            extensionReplaceCheck.TabIndex = 2;
            extensionReplaceCheck.Text = "extensionReplaceCheck";
            extensionReplaceCheck.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(90, 0);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Size = new Size(30, 31);
            label7.TabIndex = 4;
            label7.Text = "[E]";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // searchForTextBox
            // 
            searchForTextBox.Dock = DockStyle.Fill;
            searchForTextBox.Location = new Point(138, 3);
            searchForTextBox.Name = "searchForTextBox";
            searchForTextBox.Size = new Size(218, 27);
            searchForTextBox.TabIndex = 1;
            // 
            // replaceWithTextBox
            // 
            replaceWithTextBox.Dock = DockStyle.Fill;
            replaceWithTextBox.Location = new Point(138, 33);
            replaceWithTextBox.Name = "replaceWithTextBox";
            replaceWithTextBox.Size = new Size(218, 27);
            replaceWithTextBox.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(129, 30);
            label4.TabIndex = 3;
            label4.Text = "Search for:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 30);
            label5.Name = "label5";
            label5.Size = new Size(129, 30);
            label5.TabIndex = 4;
            label5.Text = "Replace with:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(tableLayoutPanel5);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(718, 3);
            groupBox4.Name = "groupBox4";
            tableLayoutPanel1.SetRowSpan(groupBox4, 2);
            groupBox4.Size = new Size(174, 175);
            groupBox4.TabIndex = 7;
            groupBox4.TabStop = false;
            groupBox4.Text = "Define counter [C]";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(numericStartAt, 1, 0);
            tableLayoutPanel5.Controls.Add(numericStep, 1, 1);
            tableLayoutPanel5.Controls.Add(comboDigits, 1, 2);
            tableLayoutPanel5.Controls.Add(label1, 0, 0);
            tableLayoutPanel5.Controls.Add(label2, 0, 1);
            tableLayoutPanel5.Controls.Add(label3, 0, 2);
            tableLayoutPanel5.Controls.Add(counterResetButton, 1, 3);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 23);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 4;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Size = new Size(168, 149);
            tableLayoutPanel5.TabIndex = 6;
            // 
            // numericStartAt
            // 
            numericStartAt.Dock = DockStyle.Fill;
            numericStartAt.Location = new Point(87, 3);
            numericStartAt.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericStartAt.Minimum = new decimal(new int[] { 999, 0, 0, int.MinValue });
            numericStartAt.Name = "numericStartAt";
            numericStartAt.Size = new Size(78, 27);
            numericStartAt.TabIndex = 0;
            numericStartAt.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericStep
            // 
            numericStep.Dock = DockStyle.Fill;
            numericStep.Location = new Point(87, 40);
            numericStep.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericStep.Minimum = new decimal(new int[] { 999, 0, 0, int.MinValue });
            numericStep.Name = "numericStep";
            numericStep.Size = new Size(78, 27);
            numericStep.TabIndex = 1;
            numericStep.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // comboDigits
            // 
            comboDigits.Dock = DockStyle.Fill;
            comboDigits.FormattingEnabled = true;
            comboDigits.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            comboDigits.Location = new Point(87, 77);
            comboDigits.MaxDropDownItems = 10;
            comboDigits.Name = "comboDigits";
            comboDigits.Size = new Size(78, 28);
            comboDigits.TabIndex = 2;
            comboDigits.Text = "1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 37);
            label1.TabIndex = 3;
            label1.Text = "Start at:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 37);
            label2.Name = "label2";
            label2.Size = new Size(78, 37);
            label2.TabIndex = 4;
            label2.Text = "Step by:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 74);
            label3.Name = "label3";
            label3.Size = new Size(78, 37);
            label3.TabIndex = 5;
            label3.Text = "Digits";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // counterResetButton
            // 
            counterResetButton.Dock = DockStyle.Fill;
            counterResetButton.Location = new Point(84, 113);
            counterResetButton.Margin = new Padding(0, 2, 0, 2);
            counterResetButton.Name = "counterResetButton";
            counterResetButton.Size = new Size(84, 34);
            counterResetButton.TabIndex = 6;
            counterResetButton.Text = "Reset";
            counterResetButton.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(comboLetterCase);
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Location = new Point(347, 126);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(365, 52);
            groupBox5.TabIndex = 8;
            groupBox5.TabStop = false;
            groupBox5.Text = "Upper/lowercase";
            // 
            // comboLetterCase
            // 
            comboLetterCase.Dock = DockStyle.Fill;
            comboLetterCase.FormattingEnabled = true;
            comboLetterCase.Items.AddRange(new object[] { "Unchanged", "All lowercase", "All UPPERCASE", "First letter uppercase", "First of each word uppercase" });
            comboLetterCase.Location = new Point(3, 23);
            comboLetterCase.Name = "comboLetterCase";
            comboLetterCase.Size = new Size(359, 28);
            comboLetterCase.TabIndex = 0;
            comboLetterCase.Text = "Unchanged";
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeButton.Location = new Point(813, 513);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(94, 29);
            closeButton.TabIndex = 5;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            startButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            startButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            startButton.Location = new Point(705, 513);
            startButton.Name = "startButton";
            startButton.Size = new Size(94, 29);
            startButton.TabIndex = 6;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            // 
            // DialogMultiRename
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 550);
            Controls.Add(startButton);
            Controls.Add(closeButton);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(fileView);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DialogMultiRename";
            Text = "Multi-Rename";
            groupBox1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            groupBox4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericStartAt).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericStep).EndInit();
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView fileView;
        private ColumnHeader oldName;
        private ColumnHeader extension;
        private ColumnHeader newName;
        private ColumnHeader size;
        private ColumnHeader date;
        private ColumnHeader location;
        private TextBox fileNameMask;
        private TextBox fileExtensionMask;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private TableLayoutPanel tableLayoutPanel5;
        private Button nameMaskAddName;
        private Button nameMaskAddDate;
        private Button nameMaskAddTime;
        private Button nameMaskAddPath;
        private Button nameMaskAddCounter;
        private Button button6;
        private Button extensionMaskAddExtension;
        private Button extensionMaskAddCounter;
        private Button button9;
        private TableLayoutPanel tableLayoutPanel6;
        private Button nameMaskClear;
        private NumericUpDown numericStartAt;
        private NumericUpDown numericStep;
        private ComboBox comboDigits;
        private TableLayoutPanel tableLayoutPanel7;
        private Button extensionMaskClear;
        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox groupBox5;
        private ComboBox comboLetterCase;
        private Button counterResetButton;
        private TableLayoutPanel tableLayoutPanel9;
        private CheckBox respectUpperCaseCheck;
        private CheckBox extensionReplaceCheck;
        private TextBox searchForTextBox;
        private TextBox replaceWithTextBox;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button closeButton;
        private Button startButton;
    }
}
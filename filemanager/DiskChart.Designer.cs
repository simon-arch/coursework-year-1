namespace filemanager
{
    partial class DiskChart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiskChart));
            menuStrip1 = new MenuStrip();
            closeButton = new ToolStripMenuItem();
            usedSpaceLabel = new Label();
            freeSpaceLabel = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            usedSpaceGB = new Label();
            freeSpaceGB = new Label();
            label3 = new Label();
            totalSpaceLabel = new Label();
            totalSpaceGB = new Label();
            fileSystemLabel = new Label();
            typeLabel = new Label();
            label4 = new Label();
            usedSpaceLegend = new PictureBox();
            freeSpaceLegend = new PictureBox();
            diskLabel = new Label();
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usedSpaceLegend).BeginInit();
            ((System.ComponentModel.ISupportInitialize)freeSpaceLegend).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.Bottom;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { closeButton });
            menuStrip1.Location = new Point(0, 195);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RightToLeft = RightToLeft.No;
            menuStrip1.Size = new Size(532, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip";
            // 
            // closeButton
            // 
            closeButton.Name = "closeButton";
            closeButton.RightToLeft = RightToLeft.No;
            closeButton.Size = new Size(59, 24);
            closeButton.Text = "Close";
            // 
            // usedSpaceLabel
            // 
            usedSpaceLabel.AutoSize = true;
            usedSpaceLabel.Dock = DockStyle.Right;
            usedSpaceLabel.Location = new Point(179, 0);
            usedSpaceLabel.Name = "usedSpaceLabel";
            usedSpaceLabel.RightToLeft = RightToLeft.No;
            usedSpaceLabel.Size = new Size(86, 30);
            usedSpaceLabel.TabIndex = 2;
            usedSpaceLabel.Text = "Used Space";
            // 
            // freeSpaceLabel
            // 
            freeSpaceLabel.AutoSize = true;
            freeSpaceLabel.Dock = DockStyle.Right;
            freeSpaceLabel.Location = new Point(184, 30);
            freeSpaceLabel.Name = "freeSpaceLabel";
            freeSpaceLabel.RightToLeft = RightToLeft.No;
            freeSpaceLabel.Size = new Size(81, 30);
            freeSpaceLabel.TabIndex = 3;
            freeSpaceLabel.Text = "Free Space";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.60471F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.8355751F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.5597153F));
            tableLayoutPanel1.Controls.Add(usedSpaceLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(freeSpaceLabel, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(usedSpaceGB, 2, 0);
            tableLayoutPanel1.Controls.Add(freeSpaceGB, 2, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(totalSpaceLabel, 1, 2);
            tableLayoutPanel1.Controls.Add(totalSpaceGB, 2, 2);
            tableLayoutPanel1.Controls.Add(fileSystemLabel, 0, 4);
            tableLayoutPanel1.Controls.Add(typeLabel, 0, 5);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Location = new Point(173, 34);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 34.93976F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 34.93976F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30.1204815F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.Size = new Size(352, 145);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 4;
            label1.Text = "Used space:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 5;
            label2.Text = "Free space:";
            // 
            // usedSpaceGB
            // 
            usedSpaceGB.AutoSize = true;
            usedSpaceGB.Dock = DockStyle.Right;
            usedSpaceGB.Location = new Point(321, 0);
            usedSpaceGB.Name = "usedSpaceGB";
            usedSpaceGB.Size = new Size(28, 30);
            usedSpaceGB.TabIndex = 6;
            usedSpaceGB.Text = "GB";
            // 
            // freeSpaceGB
            // 
            freeSpaceGB.AutoSize = true;
            freeSpaceGB.Dock = DockStyle.Right;
            freeSpaceGB.Location = new Point(321, 30);
            freeSpaceGB.Name = "freeSpaceGB";
            freeSpaceGB.Size = new Size(28, 30);
            freeSpaceGB.TabIndex = 7;
            freeSpaceGB.Text = "GB";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 60);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 8;
            label3.Text = "Capacity:";
            // 
            // totalSpaceLabel
            // 
            totalSpaceLabel.AutoSize = true;
            totalSpaceLabel.Dock = DockStyle.Right;
            totalSpaceLabel.Location = new Point(179, 60);
            totalSpaceLabel.Name = "totalSpaceLabel";
            totalSpaceLabel.RightToLeft = RightToLeft.No;
            totalSpaceLabel.Size = new Size(86, 25);
            totalSpaceLabel.TabIndex = 9;
            totalSpaceLabel.Text = "Total Space";
            // 
            // totalSpaceGB
            // 
            totalSpaceGB.AutoSize = true;
            totalSpaceGB.Dock = DockStyle.Right;
            totalSpaceGB.Location = new Point(321, 60);
            totalSpaceGB.Name = "totalSpaceGB";
            totalSpaceGB.Size = new Size(28, 25);
            totalSpaceGB.TabIndex = 10;
            totalSpaceGB.Text = "GB";
            // 
            // fileSystemLabel
            // 
            fileSystemLabel.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(fileSystemLabel, 2);
            fileSystemLabel.Location = new Point(3, 93);
            fileSystemLabel.Name = "fileSystemLabel";
            fileSystemLabel.Size = new Size(79, 20);
            fileSystemLabel.TabIndex = 11;
            fileSystemLabel.Text = "FileSystem";
            // 
            // typeLabel
            // 
            typeLabel.AutoSize = true;
            typeLabel.Location = new Point(3, 119);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new Size(40, 20);
            typeLabel.TabIndex = 12;
            typeLabel.Text = "Type";
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.Fixed3D;
            tableLayoutPanel1.SetColumnSpan(label4, 3);
            label4.Location = new Point(3, 85);
            label4.Name = "label4";
            label4.Size = new Size(346, 2);
            label4.TabIndex = 8;
            // 
            // usedSpaceLegend
            // 
            usedSpaceLegend.BackColor = Color.White;
            usedSpaceLegend.Location = new Point(154, 36);
            usedSpaceLegend.Name = "usedSpaceLegend";
            usedSpaceLegend.Size = new Size(20, 20);
            usedSpaceLegend.TabIndex = 5;
            usedSpaceLegend.TabStop = false;
            // 
            // freeSpaceLegend
            // 
            freeSpaceLegend.BackColor = Color.White;
            freeSpaceLegend.Location = new Point(154, 62);
            freeSpaceLegend.Name = "freeSpaceLegend";
            freeSpaceLegend.Size = new Size(20, 20);
            freeSpaceLegend.TabIndex = 6;
            freeSpaceLegend.TabStop = false;
            // 
            // diskLabel
            // 
            diskLabel.AutoSize = true;
            diskLabel.Location = new Point(37, 137);
            diskLabel.Name = "diskLabel";
            diskLabel.Size = new Size(81, 20);
            diskLabel.TabIndex = 7;
            diskLabel.Text = "Disk Name";
            // 
            // DiskChart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 223);
            ControlBox = false;
            Controls.Add(diskLabel);
            Controls.Add(freeSpaceLegend);
            Controls.Add(usedSpaceLegend);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "DiskChart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Disk Info";
            TransparencyKey = Color.OrangeRed;
            Paint += DiskChart_Paint;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)usedSpaceLegend).EndInit();
            ((System.ComponentModel.ISupportInitialize)freeSpaceLegend).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem closeButton;
        private Label usedSpaceLabel;
        private Label freeSpaceLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label usedSpaceGB;
        private Label freeSpaceGB;
        private Label label3;
        private Label totalSpaceLabel;
        private Label totalSpaceGB;
        private PictureBox usedSpaceLegend;
        private PictureBox freeSpaceLegend;
        private Label diskLabel;
        private Label fileSystemLabel;
        private Label label4;
        private Label typeLabel;
    }
}
namespace filemanager.Dialogs
{
    partial class DialogChangeAttribute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogChangeAttribute));
            groupBox1 = new GroupBox();
            systemAttr = new CheckBox();
            hiddenAttr = new CheckBox();
            readOnlyAttr = new CheckBox();
            archiveAttr = new CheckBox();
            groupBox2 = new GroupBox();
            currentButton = new Button();
            label2 = new Label();
            label1 = new Label();
            datePicker = new DateTimePicker();
            timePicker = new DateTimePicker();
            changeDateTime = new CheckBox();
            okButton = new Button();
            cancelButton = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(systemAttr);
            groupBox1.Controls.Add(hiddenAttr);
            groupBox1.Controls.Add(readOnlyAttr);
            groupBox1.Controls.Add(archiveAttr);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(290, 172);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Change attributes";
            // 
            // systemAttr
            // 
            systemAttr.AutoSize = true;
            systemAttr.Location = new Point(15, 128);
            systemAttr.Name = "systemAttr";
            systemAttr.Size = new Size(92, 24);
            systemAttr.TabIndex = 3;
            systemAttr.Text = "s  System";
            systemAttr.UseVisualStyleBackColor = true;
            // 
            // hiddenAttr
            // 
            hiddenAttr.AutoSize = true;
            hiddenAttr.Location = new Point(15, 98);
            hiddenAttr.Name = "hiddenAttr";
            hiddenAttr.Size = new Size(96, 24);
            hiddenAttr.TabIndex = 2;
            hiddenAttr.Text = "h  Hidden";
            hiddenAttr.UseVisualStyleBackColor = true;
            // 
            // readOnlyAttr
            // 
            readOnlyAttr.AutoSize = true;
            readOnlyAttr.Location = new Point(15, 68);
            readOnlyAttr.Name = "readOnlyAttr";
            readOnlyAttr.Size = new Size(110, 24);
            readOnlyAttr.TabIndex = 1;
            readOnlyAttr.Text = "r  Read only";
            readOnlyAttr.UseVisualStyleBackColor = true;
            // 
            // archiveAttr
            // 
            archiveAttr.AutoSize = true;
            archiveAttr.Location = new Point(15, 38);
            archiveAttr.Name = "archiveAttr";
            archiveAttr.Size = new Size(96, 24);
            archiveAttr.TabIndex = 0;
            archiveAttr.Text = "a  Archive";
            archiveAttr.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(currentButton);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(datePicker);
            groupBox2.Controls.Add(timePicker);
            groupBox2.Controls.Add(changeDateTime);
            groupBox2.Location = new Point(12, 190);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(290, 124);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // currentButton
            // 
            currentButton.Location = new Point(184, 23);
            currentButton.Name = "currentButton";
            currentButton.Size = new Size(94, 29);
            currentButton.TabIndex = 7;
            currentButton.Text = "Current";
            currentButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 94);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 6;
            label2.Text = "Time:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 61);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 5;
            label1.Text = "Date:";
            // 
            // datePicker
            // 
            datePicker.Format = DateTimePickerFormat.Short;
            datePicker.Location = new Point(150, 56);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(128, 27);
            datePicker.TabIndex = 4;
            // 
            // timePicker
            // 
            timePicker.Format = DateTimePickerFormat.Time;
            timePicker.Location = new Point(150, 89);
            timePicker.Name = "timePicker";
            timePicker.ShowUpDown = true;
            timePicker.Size = new Size(128, 27);
            timePicker.TabIndex = 3;
            // 
            // changeDateTime
            // 
            changeDateTime.AutoSize = true;
            changeDateTime.Location = new Point(15, 26);
            changeDateTime.Name = "changeDateTime";
            changeDateTime.Size = new Size(154, 24);
            changeDateTime.TabIndex = 0;
            changeDateTime.Text = "Change date/time:";
            changeDateTime.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            okButton.Location = new Point(62, 323);
            okButton.Name = "okButton";
            okButton.Size = new Size(94, 29);
            okButton.TabIndex = 2;
            okButton.Text = "Confirm";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(162, 323);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(94, 29);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // DialogChangeAttribute
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 361);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "DialogChangeAttribute";
            Text = "Attributes";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox systemAttr;
        private CheckBox hiddenAttr;
        private CheckBox readOnlyAttr;
        private CheckBox archiveAttr;
        private CheckBox changeDateTime;
        private DateTimePicker timePicker;
        private DateTimePicker datePicker;
        private Label label2;
        private Label label1;
        private Button currentButton;
        private Button okButton;
        private Button cancelButton;
    }
}
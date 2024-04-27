namespace filemanager.Dialogs
{
    partial class AssociationsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssociationsDialog));
            listView = new ListView();
            extensionColumn = new ColumnHeader();
            associatedPath = new ColumnHeader();
            extensionBox = new TextBox();
            pathBox = new TextBox();
            addButton = new Button();
            updateButton = new Button();
            deleteButton = new Button();
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // listView
            // 
            listView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView.Columns.AddRange(new ColumnHeader[] { extensionColumn, associatedPath });
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.Location = new Point(12, 12);
            listView.MultiSelect = false;
            listView.Name = "listView";
            listView.Size = new Size(449, 245);
            listView.TabIndex = 0;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            // 
            // extensionColumn
            // 
            extensionColumn.Text = "Extension";
            extensionColumn.Width = 100;
            // 
            // associatedPath
            // 
            associatedPath.Text = "Associated Path";
            associatedPath.Width = 345;
            // 
            // extensionBox
            // 
            extensionBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            extensionBox.Location = new Point(12, 263);
            extensionBox.Name = "extensionBox";
            extensionBox.Size = new Size(99, 27);
            extensionBox.TabIndex = 1;
            // 
            // pathBox
            // 
            pathBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pathBox.Location = new Point(117, 263);
            pathBox.Name = "pathBox";
            pathBox.Size = new Size(344, 27);
            pathBox.TabIndex = 2;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            addButton.Location = new Point(467, 261);
            addButton.Name = "addButton";
            addButton.Size = new Size(114, 29);
            addButton.TabIndex = 3;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            updateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            updateButton.Location = new Point(467, 226);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(114, 29);
            updateButton.TabIndex = 4;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            deleteButton.Location = new Point(467, 191);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(114, 29);
            deleteButton.TabIndex = 5;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            saveButton.Location = new Point(467, 12);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(114, 29);
            saveButton.TabIndex = 6;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cancelButton.Location = new Point(467, 47);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(114, 29);
            cancelButton.TabIndex = 7;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // AssociationsDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 302);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(deleteButton);
            Controls.Add(updateButton);
            Controls.Add(addButton);
            Controls.Add(pathBox);
            Controls.Add(extensionBox);
            Controls.Add(listView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(611, 349);
            Name = "AssociationsDialog";
            Text = "Associations Editor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView;
        private ColumnHeader extensionColumn;
        private ColumnHeader associatedPath;
        private TextBox extensionBox;
        private TextBox pathBox;
        private Button addButton;
        private Button updateButton;
        private Button deleteButton;
        private Button saveButton;
        private Button cancelButton;
    }
}
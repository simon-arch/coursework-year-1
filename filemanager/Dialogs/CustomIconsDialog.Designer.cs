namespace filemanager.Dialogs
{
    partial class CustomIconsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomIconsDialog));
            previewList = new ListView();
            previewImageList = new ImageList(components);
            avaliableList = new ListView();
            columnHeader = new ColumnHeader();
            cancelButton = new Button();
            applyButton = new Button();
            SuspendLayout();
            // 
            // previewList
            // 
            previewList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            previewList.FullRowSelect = true;
            previewList.GridLines = true;
            previewList.LargeImageList = previewImageList;
            previewList.Location = new Point(12, 12);
            previewList.MultiSelect = false;
            previewList.Name = "previewList";
            previewList.Size = new Size(177, 252);
            previewList.TabIndex = 0;
            previewList.TileSize = new Size(160, 25);
            previewList.UseCompatibleStateImageBehavior = false;
            previewList.View = View.Tile;
            // 
            // previewImageList
            // 
            previewImageList.ColorDepth = ColorDepth.Depth8Bit;
            previewImageList.ImageSize = new Size(16, 16);
            previewImageList.TransparentColor = Color.Transparent;
            // 
            // avaliableList
            // 
            avaliableList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            avaliableList.Columns.AddRange(new ColumnHeader[] { columnHeader });
            avaliableList.FullRowSelect = true;
            avaliableList.GridLines = true;
            avaliableList.Location = new Point(195, 12);
            avaliableList.MultiSelect = false;
            avaliableList.Name = "avaliableList";
            avaliableList.Size = new Size(120, 182);
            avaliableList.TabIndex = 1;
            avaliableList.UseCompatibleStateImageBehavior = false;
            avaliableList.View = View.Details;
            // 
            // columnHeader
            // 
            columnHeader.Text = "Pack Name";
            columnHeader.Width = 116;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.Location = new Point(195, 235);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(120, 29);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            applyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            applyButton.Location = new Point(195, 200);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(120, 29);
            applyButton.TabIndex = 3;
            applyButton.Text = "Apply";
            applyButton.UseVisualStyleBackColor = true;
            // 
            // CustomIconsDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 276);
            Controls.Add(applyButton);
            Controls.Add(cancelButton);
            Controls.Add(avaliableList);
            Controls.Add(previewList);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(343, 323);
            Name = "CustomIconsDialog";
            Text = "Custom Icons";
            ResumeLayout(false);
        }

        #endregion

        private ListView previewList;
        private ListView avaliableList;
        private Button cancelButton;
        private Button applyButton;
        private ImageList previewImageList;
        private ColumnHeader columnHeader;
    }
}
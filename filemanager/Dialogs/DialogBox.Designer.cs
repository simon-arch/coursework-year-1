namespace filemanager
{
    partial class DialogBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogBox));
            dialogMessage = new Label();
            userInput = new TextBox();
            okButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // dialogMessage
            // 
            dialogMessage.AutoSize = true;
            dialogMessage.Location = new Point(12, 21);
            dialogMessage.Name = "dialogMessage";
            dialogMessage.Size = new Size(67, 20);
            dialogMessage.TabIndex = 1;
            dialogMessage.Text = "Message";
            // 
            // userInput
            // 
            userInput.Location = new Point(12, 57);
            userInput.Name = "userInput";
            userInput.Size = new Size(292, 27);
            userInput.TabIndex = 0;
            // 
            // okButton
            // 
            okButton.Location = new Point(12, 104);
            okButton.Name = "okButton";
            okButton.Size = new Size(139, 32);
            okButton.TabIndex = 1;
            okButton.Text = "okButton";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(157, 104);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(147, 32);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "cancelButton";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // DialogBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 149);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(userInput);
            Controls.Add(dialogMessage);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DialogBox";
            Text = "DialogBox";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label dialogMessage;
        private TextBox userInput;
        private Button okButton;
        private Button cancelButton;
    }
}
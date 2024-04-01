using System.Text.RegularExpressions;

namespace filemanager
{
    public partial class DialogBox : Form
    {
        public string ReturnValue { get; set; }
        public DialogBox(string boxName, string labelText, string okText, string cancelText)
        {
            InitializeComponent();
            Text = boxName;
            dialogMessage.Text = labelText;
            okButton.Text = okText;
            cancelButton.Text = cancelText;

            okButton.Click += (sender, e) => { ReturnValue = userInput.Text; this.DialogResult = DialogResult.OK; };
            cancelButton.Click += (sender, e) => { this.DialogResult = DialogResult.Cancel; };
        }
    }
}

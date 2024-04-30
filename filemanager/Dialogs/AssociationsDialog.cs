using System.Collections.Generic;
using System.Configuration;
using System.Text.Json;

namespace filemanager.Dialogs
{
    public partial class AssociationsDialog : Form
    {
        public AssociationsDialog(Dictionary<string, string> associated)
        {
            InitializeComponent();

            foreach (KeyValuePair<string, string> data in associated)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems[0].Text = data.Key;
                item.SubItems.Add(data.Value);
                listView.Items.Add(item);
            }

            addButton.Click += (sender, e) =>
            {
                if (extensionBox.Text.Length > 0 && pathBox.Text.Length > 0)
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems[0].Text = extensionBox.Text;
                    item.SubItems.Add(pathBox.Text);
                    listView.Items.Add(item);
                }
            };

            deleteButton.Click += (sender, e) =>
            {
                if (listView.SelectedItems.Count > 0)
                {
                    listView.SelectedItems[0].Remove();
                    extensionBox.Text = string.Empty;
                    pathBox.Text = string.Empty;
                }
            };

            updateButton.Click += (sender, e) =>
            {
                if (listView.SelectedItems.Count > 0)
                {
                    if (extensionBox.Text.Length > 0 && pathBox.Text.Length > 0)
                    {
                        listView.SelectedItems[0].SubItems[0].Text = extensionBox.Text;
                        listView.SelectedItems[0].SubItems[1].Text = pathBox.Text;
                    }
                }
            };

            cancelButton.Click += (sender, e) => Dispose();

            saveButton.Click += (sender, e) =>
            {
                associated.Clear();
                foreach (ListViewItem target in listView.Items)
                    associated.Add(target.SubItems[0].Text, target.SubItems[1].Text);

                string jsonText = JsonSerializer.Serialize(associated);
                string jsonPath = ConfigurationManager.AppSettings["Path_CustomAssociations"];
                System.IO.File.WriteAllText(jsonPath, jsonText);

                DialogResult = DialogResult.OK;
            };

            listView.Click += (sender, e) =>
            {
                if (listView.SelectedItems.Count > 0)
                {
                    extensionBox.Text = listView.SelectedItems[0].SubItems[0].Text;
                    pathBox.Text = listView.SelectedItems[0].SubItems[1].Text;
                }
            };
        }
    }
}

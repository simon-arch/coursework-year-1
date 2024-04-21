namespace filemanager.Dialogs
{
    public partial class DialogChangeAttribute : Form
    {
        public DialogChangeAttribute(List<string> source)
        {
            InitializeComponent();

            if (source.Count > 1)
            {
                archiveAttr.CheckState = CheckState.Indeterminate;
                readOnlyAttr.CheckState = CheckState.Indeterminate;
                hiddenAttr.CheckState = CheckState.Indeterminate;
                systemAttr.CheckState = CheckState.Indeterminate;
            }
            else
            {
                FileInfo file = new FileInfo(source[0]);
                archiveAttr.CheckState = file.Attributes.HasFlag(FileAttributes.Archive) ? CheckState.Checked : CheckState.Unchecked;
                readOnlyAttr.CheckState = file.Attributes.HasFlag(FileAttributes.ReadOnly) ? CheckState.Checked : CheckState.Unchecked;
                hiddenAttr.CheckState = file.Attributes.HasFlag(FileAttributes.Hidden) ? CheckState.Checked : CheckState.Unchecked;
                systemAttr.CheckState = file.Attributes.HasFlag(FileAttributes.System) ? CheckState.Checked : CheckState.Unchecked;
            }

            currentButton.Click += (sender, e) =>
            {
                changeDateTime.CheckState = CheckState.Checked;
                datePicker.Value = DateTime.Now;
                timePicker.Value = DateTime.Now;
            };

            okButton.Click += (sender, e) =>
            {
                foreach (string item in source)
                {
                    var file = new FileInfo(item);

                    if (archiveAttr.CheckState == CheckState.Unchecked)
                        file.Attributes &= ~FileAttributes.Archive;
                    else file.Attributes |= FileAttributes.Archive;

                    if (readOnlyAttr.CheckState == CheckState.Unchecked)
                        file.Attributes &= ~FileAttributes.ReadOnly;
                    else file.Attributes |= FileAttributes.ReadOnly;

                    if (hiddenAttr.CheckState == CheckState.Unchecked)
                        file.Attributes &= ~FileAttributes.Hidden;
                    else file.Attributes |= FileAttributes.Hidden;

                    if (systemAttr.CheckState == CheckState.Unchecked)
                        file.Attributes &= ~FileAttributes.System;
                    else file.Attributes |= FileAttributes.System;

                    if (changeDateTime.CheckState == CheckState.Checked)
                    {
                        DateTime date = datePicker.Value.Date;
                        TimeSpan time = timePicker.Value.TimeOfDay;
                        DateTime combined = date.Date.Add(time);
                        System.IO.File.SetCreationTime(item, combined);
                    }
                }
                Dispose();
            };

            cancelButton.Click += (sender, e) => Dispose();
        }
    }
}

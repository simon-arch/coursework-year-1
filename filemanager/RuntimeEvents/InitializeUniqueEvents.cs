using System.Diagnostics;
using System.Windows.Forms;

namespace filemanager
{
    public partial class Manager
    {
        // TEMP TEMP TEMP TEMP
        public void InitializeUniqueEvents()
        {
            FormClosing += (sender, e) => loggerHandler.Log(LogCategory.end);

            systemPropertiesTool.Click += (sender, e) => { 
                ProcessCall.RunProcessInfo(new ProcessStartInfo()  { 
                    FileName = "sysdm.cpl", UseShellExecute = true 
                }); 
            };

            verticalArrangementTool.Click += (sender, e) => 
            {
                switch (verticalArrangementTool.Checked)
                {
                    case true:
                        tableLayoutPanel3.SetColumnSpan(tableLayoutPanel3, 2);
                        tableLayoutPanel3.SetRowSpan(tableLayoutPanel3, 1);

                        tableLayoutPanel4.SetColumnSpan(tableLayoutPanel4, 2);
                        tableLayoutPanel4.SetRowSpan(tableLayoutPanel4, 1);

                        tableLayoutPanel4.SetColumn(tableLayoutPanel4, 0);
                        tableLayoutPanel4.SetRow(tableLayoutPanel4, 1);
                    break;

                    case false:
                        tableLayoutPanel3.SetColumnSpan(tableLayoutPanel3, 1);
                        tableLayoutPanel3.SetRowSpan(tableLayoutPanel3, 2);

                        tableLayoutPanel4.SetColumnSpan(tableLayoutPanel4, 1);
                        tableLayoutPanel4.SetRowSpan(tableLayoutPanel4, 2);

                        tableLayoutPanel4.SetColumn(tableLayoutPanel4, 1);
                        tableLayoutPanel4.SetRow(tableLayoutPanel4, 0);
                    break;
                }
                
            };

            exitTool.Click += (sender, e) => Close();
            desktopTool.Click += (sender, e) => Desktop();
            sourceTargetEqualTool.Click += (sender, e) => GoTo(displayList[0].RootDirectory, displayList[1], directoryList[1], watcherList[1]);
            sourceTargetSwitchTool.Click += (sender, e) => 
            {
                RootDirectory temp = displayList[0].RootDirectory;
                GoTo(displayList[1].RootDirectory, displayList[0], directoryList[0], watcherList[0]);
                GoTo(temp, displayList[1], directoryList[1], watcherList[1]);
            };

            imagePreviewBox.MouseClick += (sender, e) => { 
                if (imagePreviewBox.Image != null && e.Button == MouseButtons.Left)
                {
                    ProcessCall.RunProcess("explorer", imagePreviewBox.ImageLocation);
                }
            };

            diskInfoTool.Click += (sender, e) =>
            {
                DiskChart disk = new DiskChart(driveComboBox.Text);
                DialogResult result = disk.ShowDialog();
            };

            binTool.Click += (sender, e) => ProcessCall.RunProcess("explorer.exe", "shell:RecycleBinFolder");
        }
    }
}

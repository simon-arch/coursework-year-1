using System.Diagnostics;

namespace filemanager
{
    public partial class Manager
    {
        public void InitializeUniqueEvents()
        {

            FormClosing += (sender, e) => loggerHandler.Log(LogCategory.end);

            systemPropertiesTool.Click += (sender, e) => { 
                ProcessCall.RunProcessInfo(new ProcessStartInfo()  { 
                    FileName = "sysdm.cpl", UseShellExecute = true 
                }); 
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

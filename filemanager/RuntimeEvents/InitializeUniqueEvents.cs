using System.Diagnostics;

namespace filemanager
{
    public partial class Manager
    {
        public void InitializeUniqueEvents()
        {
            this.FormClosing += (sender, e) =>
            {
                loggerHandler.Log(LogCategory.end);
                string logpath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"..\..\..\AppData\log.txt");
                System.IO.File.AppendAllText(logpath, logTextBox.Text);
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

            // TEMP TEMP TEMP TEMP TEMP
            imagePreviewBox.MouseClick += (sender, e) => { 
                if (imagePreviewBox.Image != null && e.Button == MouseButtons.Left)
                {
                    ProcessCall.RunProcess("explorer", imagePreviewBox.ImageLocation);
                }
            };
            // TEMP TEMP TEMP TEMP TEMP

            diskInfoTool.Click += (sender, e) =>
            {
                DiskChart disk = new DiskChart(driveComboBox.Text);
                DialogResult result = disk.ShowDialog();
            };

            binTool.Click += (sender, e) => ProcessCall.RunProcess("explorer.exe", "shell:RecycleBinFolder");
        }
    }
}

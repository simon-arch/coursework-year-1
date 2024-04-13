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

            desktopTool.Click += (sender, e) => Desktop();

            // TEMP TEMP TEMP TEMP TEMP
            imagePreviewBox.MouseClick += (sender, e) => { 
                if (imagePreviewBox.Image != null && e.Button == System.Windows.Forms.MouseButtons.Left)
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

            binTool.Click += (sender, e) =>
            {
                ProcessCall.RunProcess("explorer.exe", "shell:RecycleBinFolder");
            };
        }
    }
}

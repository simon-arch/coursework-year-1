namespace filemanager
{
    public partial class Form1
    {
        public void InitializeUniqueEvents()
        {
            this.FormClosing += (sender, e) =>
            {
                loggerHandler.Log(Category.end);
                string logpath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"..\..\..\Resources\log.txt");
                System.IO.File.AppendAllText(logpath, logTextBox.Text);
            };

            desktopTool.Click += (sender, e) => Desktop();

            // TEMP TEMP TEMP TEMP TEMP
            imagePreviewBox.Click += (sender, e) =>
            {
                if (imagePreviewBox.Image != null)
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

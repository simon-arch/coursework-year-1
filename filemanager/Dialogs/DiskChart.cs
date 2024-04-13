namespace filemanager
{
    public partial class DiskChart : Form
    {
        public string Drive { get; set; }
        public DiskChart(string drive)
        {
            InitializeComponent();
            closeButton.Click += (sender, e) => { Close(); };

            Drive = drive;
            DriveInfo driveInfo = new DriveInfo(Drive);
            long totalSpace = driveInfo.TotalSize;
            long usedSpace = driveInfo.TotalFreeSpace;

            usedSpaceLabel.Text = $"{totalSpace - usedSpace:n0} bytes";
            freeSpaceLabel.Text = $"{usedSpace:n0} bytes";
            totalSpaceLabel.Text = $"{totalSpace:n0} bytes";

            usedSpaceGB.Text = $"{(double)(totalSpace - usedSpace) / 1024 / 1024 / 1024:0.##} GB";
            freeSpaceGB.Text = $"{(double)(usedSpace) / 1024 / 1024 / 1024:0.##} GB";
            totalSpaceGB.Text = $"{(double)(totalSpace) / 1024 / 1024 / 1024:0.##} GB";

            fileSystemLabel.Text = $"File system: {driveInfo.DriveFormat}";
            typeLabel.Text = $"Type: {driveInfo.DriveType}";
            diskLabel.Text = $"Drive {drive}";

            freeSpaceLegend.BackColor = Color.FromArgb(255, 172, 172, 172);
            usedSpaceLegend.BackColor = Color.FromArgb(255, 38, 160, 218);
        }
        private void DiskChart_Paint(object sender, PaintEventArgs e)
        {
            long totalSpace = new DriveInfo(Drive).TotalSize;
            long usedSpace = new DriveInfo(Drive).TotalFreeSpace;
            int free = (int)(100 * (double)usedSpace / totalSpace);
            int[] pieData = { free + 1, 100 - free };
            DrawPie(pieData);
        }
        public void DrawPie(int[] pieData)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(255, 172, 172, 172));
            CreateGraphics().FillPie(brush, new Rectangle(new Point(10, 10),
                new Size(120, 120)), 0, pieData[0] * 360 / 100);
            brush.Color = Color.FromArgb(255, 38, 160, 218);
            CreateGraphics().FillPie(brush, new Rectangle(new Point(10, 10),
                new Size(120, 120)), pieData[0] * 360 / 100, pieData[1] * 360 / 100);
            brush.Color = this.BackColor;
            CreateGraphics().FillEllipse(brush, new Rectangle(new Point(30, 30), new Size(80, 80)));
            return;
        }
    }
}

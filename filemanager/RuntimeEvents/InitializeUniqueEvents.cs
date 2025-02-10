using filemanager.Dialogs;
using System.Diagnostics;

namespace filemanager
{
    public partial class Manager
    {
        public void InitializeUniqueEvents()
        {
            Controllers["ReloadCustomIcons"].Click += (sender, e) => InitCustomIcons(currentIconPack);

            Controllers["ViewCustomIcons"].Click += (sender, e) =>
            {
                CustomIconsDialog dialog = new CustomIconsDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    currentIconPack = dialog.SelectedPack;
                    InitCustomIcons("none");
                    if (currentIconPack == "none") Controllers["Refresh"].PerformClick();
                    else InitCustomIcons(currentIconPack);
                }
            };

            Controllers["EditAssociations"].Click += (sender, e) =>
            {
                AssociationsDialog dialog = new AssociationsDialog(associated);
                if (dialog.ShowDialog() == DialogResult.OK) InitCustomAssociations();
            };

            Controllers["ReloadAssociations"].Click += (sender, e) => InitCustomAssociations();

            Controllers["EditQuickBar"].Click += (sender, e) => 
            {
                QuickBarEditor dialog = new QuickBarEditor(Controllers);
                if (dialog.ShowDialog() == DialogResult.OK) InitQuickbar();
            };
            Controllers["ReloadQuickBar"].Click += (sender, e) => InitQuickbar();

            Controllers["SystemProperties"].Click += (sender, e) => { 
                ProcessCall.RunProcessInfo(new ProcessStartInfo() { FileName = "sysdm.cpl", UseShellExecute = true }); 
            };

            Controllers["VerticalArrangement"].CheckStateChanged += (sender, e) => 
            {
                switch (verticalArrangementTool.Checked)
                {
                    case true:
                        leftPanel.SetColumnSpan(leftPanel, 2);
                        leftPanel.SetRowSpan(leftPanel, 1);
                        rightPanel.SetColumnSpan(rightPanel, 2);
                        rightPanel.SetRowSpan(rightPanel, 1);
                        rightPanel.SetColumn(rightPanel, 0);
                        rightPanel.SetRow(rightPanel, 1);
                    break;

                    case false:
                        leftPanel.SetColumnSpan(leftPanel, 1);
                        leftPanel.SetRowSpan(leftPanel, 2);
                        rightPanel.SetColumnSpan(rightPanel, 1);
                        rightPanel.SetRowSpan(rightPanel, 2);
                        rightPanel.SetColumn(rightPanel, 1);
                        rightPanel.SetRow(rightPanel, 0);
                    break;
                }
            };

            void Desktop()
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                ProcessCall.RunProcess("explorer.exe", path);
            }

            Controllers["Exit"].Click += (sender, e) => Close();
            Controllers["Desktop"].Click += (sender, e) => Desktop();
            /*refactored*/ Controllers["TargetTarget"].Click += (sender, e) => mediatorRight.GoTo(mediatorLeft.Navigator.RootDirectory);
            /*refactored*/ Controllers["TargetSource"].Click += (sender, e) =>
            {
                RootDirectory temp = mediatorLeft.Navigator.RootDirectory;
                mediatorLeft.GoTo(mediatorRight.Navigator.RootDirectory);
                mediatorRight.GoTo(temp);
            };

            imagePreviewBox.MouseClick += (sender, e) => { 
                if (imagePreviewBox.Image != null && e.Button == MouseButtons.Left)
                {
                    ProcessCall.RunProcess("explorer", imagePreviewBox.ImageLocation);
                }
            };

            Controllers["DiskInfo"].Click += (sender, e) =>
            {
                DiskChart disk = new DiskChart(driveComboBox.Text);
                DialogResult result = disk.ShowDialog();
            };

            Controllers["RecycleBin"].Click += (sender, e) => ProcessCall.RunProcess("explorer.exe", "shell:RecycleBinFolder");
        }
    }
}

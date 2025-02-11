using filemanager.Dialogs;
using System.Diagnostics;

namespace filemanager
{
    public partial class Manager
    {
        public void InitializeUniqueEvents()
        {
            _controllers["ReloadCustomIcons"].Click += (sender, e) => InitCustomIcons(currentIconPack);

            _controllers["ViewCustomIcons"].Click += (sender, e) =>
            {
                CustomIconsDialog dialog = new CustomIconsDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    currentIconPack = dialog.SelectedPack;
                    InitCustomIcons("none");
                    if (currentIconPack == "none") _controllers["Refresh"].PerformClick();
                    else InitCustomIcons(currentIconPack);
                }
            };

            _controllers["EditAssociations"].Click += (sender, e) =>
            {
                AssociationsDialog dialog = new AssociationsDialog(_associated);
                if (dialog.ShowDialog() == DialogResult.OK) InitCustomAssociations();
            };

            _controllers["ReloadAssociations"].Click += (sender, e) => InitCustomAssociations();

            _controllers["EditQuickBar"].Click += (sender, e) => 
            {
                EditQuickBar dialog = new EditQuickBar(_controllers);
                if (dialog.ShowDialog() == DialogResult.OK) InitQuickBar();
            };
            _controllers["ReloadQuickBar"].Click += (sender, e) => InitQuickBar();

            _controllers["SystemProperties"].Click += (sender, e) => { 
                ProcessCall.RunProcessInfo(new ProcessStartInfo() { FileName = "sysdm.cpl", UseShellExecute = true }); 
            };

            _controllers["VerticalArrangement"].CheckStateChanged += (sender, e) => 
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

            _controllers["Exit"].Click += (sender, e) => Close();
            _controllers["Desktop"].Click += (sender, e) => Desktop();
            /*refactored*/ _controllers["TargetTarget"].Click += (sender, e) => _mediatorRight.GoTo(_mediatorLeft.Navigator.RootDirectory);
            /*refactored*/ _controllers["TargetSource"].Click += (sender, e) =>
            {
                RootDirectory temp = _mediatorLeft.Navigator.RootDirectory;
                _mediatorLeft.GoTo(_mediatorRight.Navigator.RootDirectory);
                _mediatorRight.GoTo(temp);
            };

            imagePreviewBox.MouseClick += (sender, e) => { 
                if (imagePreviewBox.Image != null && e.Button == MouseButtons.Left)
                {
                    ProcessCall.RunProcess("explorer", imagePreviewBox.ImageLocation);
                }
            };

            _controllers["DiskInfo"].Click += (sender, e) =>
            {
                DiskChart disk = new DiskChart(driveComboBox.Text);
                DialogResult result = disk.ShowDialog();
            };

            _controllers["RecycleBin"].Click += (sender, e) => ProcessCall.RunProcess("explorer.exe", "shell:RecycleBinFolder");
        }
    }
}

namespace filemanager
{
    public class UserSettings
    {
        private string startupFolder;
        public string StartupFolder {
            get { return startupFolder; }
            set {
                if (Path.Exists(StartupFolder))
                {
                    startupFolder = value;
                }
                else
                {
                    startupFolder = DriveInfo.GetDrives()[0].Name;
                }
            }
        }
        public bool ShowExtensions { get; set; }
        public bool ShowHidden { get; set; }
        public UserSettings() {
            StartupFolder = DriveInfo.GetDrives()[0].Name;
            ShowExtensions = false;
            ShowHidden = false;
        }
    }
}

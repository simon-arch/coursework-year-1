namespace filemanager
{
    public partial class Manager
    {
        public void PowerShell(DisplayHandler displayHandler)
        {
            if (!displayHandler.Focused) return;
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WorkingDirectory = displayHandler.RootDirectory.Path,
                FileName = "powershell.exe"
            };
            System.Diagnostics.Process.Start(startInfo);
        }
        public void Console(DisplayHandler displayHandler)
        {
            if (!displayHandler.Focused) return;
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WorkingDirectory = displayHandler.RootDirectory.Path,
                FileName = "cmd.exe"
            };
            System.Diagnostics.Process.Start(startInfo);
        }
        public void Desktop()
        {
            File desktop = new File();
            desktop.Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //desktop.View();
        }
    }
}

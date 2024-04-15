using System.Text.Json;

namespace filemanager
{
    public partial class Manager
    {
        private void SaveSettings(List<DisplayHandler> displayList)
        {
            // LIST SETTINGS //
            List<UserSettings> viewSettings = new List<UserSettings>();
            foreach (DisplayHandler displayHandler in displayList)
            {
                UserSettings settings = new UserSettings
                {
                    StartupFolder = displayHandler.RootDirectory.Path,
                    ShowExtensions = displayHandler.ShowExtensions,
                    ShowHidden = displayHandler.ShowHidden,
                    SortType = displayHandler.SortType,
                };
                viewSettings.Add(settings);
            }
            string json = JsonSerializer.Serialize(viewSettings);
            System.IO.File.WriteAllText(
            Path.Combine(System.IO.Directory.GetCurrentDirectory(),
            @"..\..\..\AppData\listsettings.json"), json);
            //

            // APP SETTINGS //
            AppSettings appSettings = new AppSettings()
            {
                DeleteAfterUnzip = deleteAfterUnzipTool.Checked
            }; // { ... }
            json = JsonSerializer.Serialize(appSettings);
            System.IO.File.WriteAllText(
            Path.Combine(System.IO.Directory.GetCurrentDirectory(),
            @"..\..\..\AppData\appsettings.json"), json);
            //
        }
    }
}

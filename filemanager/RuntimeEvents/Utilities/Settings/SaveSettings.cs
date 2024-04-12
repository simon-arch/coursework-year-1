using System.Text.Json;

namespace filemanager
{
    public partial class Form1
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
                };
                viewSettings.Add(settings);
            }
            string json = JsonSerializer.Serialize(viewSettings);
            System.IO.File.WriteAllText(
            Path.Combine(System.IO.Directory.GetCurrentDirectory(),
            @"..\..\..\Resources\listsettings.json"), json);
            //

            // APP SETTINGS //
            AppSettings appSettings = new AppSettings() { }; // { ... }
            json = JsonSerializer.Serialize(appSettings);
            System.IO.File.WriteAllText(
            Path.Combine(System.IO.Directory.GetCurrentDirectory(),
            @"..\..\..\Resources\appsettings.json"), json);
            //
        }
    }
}

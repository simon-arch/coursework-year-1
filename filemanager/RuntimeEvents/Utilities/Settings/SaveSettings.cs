using System.Text.Json;

namespace filemanager
{
    public partial class Manager
    {
        private void SaveSettings(List<DisplayHandler> displayList)
        {
            System.IO.Directory.CreateDirectory(Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"AppData"));
            string savepath, json;

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
            json = JsonSerializer.Serialize(viewSettings);
            savepath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"AppData\listsettings.json");
            System.IO.File.WriteAllText(savepath, json);

            // APP SETTINGS //
            AppSettings appSettings = new AppSettings()
            {
                DeleteAfterUnzip = deleteAfterUnzipTool.Checked
            };
            json = JsonSerializer.Serialize(appSettings);
            savepath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"AppData\appsettings.json");
            System.IO.File.WriteAllText(savepath, json);
        }
    }
}

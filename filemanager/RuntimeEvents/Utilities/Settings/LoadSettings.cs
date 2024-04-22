using System.Text.Json;

namespace filemanager
{
    public partial class Manager
    {
        private void LoadSettings(List<DisplayHandler> displayList, List<DirectoryHandler> directoryList, List<FileWatcher> watcherList)
        {
            System.IO.Directory.CreateDirectory(Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"AppData"));
            string target, json;

            // LIST SETTINGS //
            target = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "AppData/listsettings.json");
            using (FileStream file = new FileStream(target, FileMode.OpenOrCreate));
            json = System.IO.File.ReadAllText(target);
            UserSettings defaultSettings = new UserSettings();
            List<UserSettings> userSettings = new List<UserSettings>();
            try { userSettings = JsonSerializer.Deserialize<List<UserSettings>>(json); }
            catch (Exception ex)
            {
                userSettings.Add(defaultSettings);
                userSettings.Add(defaultSettings);
            }
            for (int i = displayList.Count - 1; i >= 0; i--)
            {
                string startpath = userSettings[i].StartupFolder;
                if (!Path.Exists(startpath)) startpath = DriveInfo.GetDrives()[0].Name;
                displayList[i].ShowExtensions = userSettings[i].ShowExtensions;
                displayList[i].ShowHidden = userSettings[i].ShowHidden;
                displayList[i].SortType = userSettings[i].SortType;
                GoTo(new RootDirectory("dir", startpath), displayList[i], directoryList[i], watcherList[i]);
            }
            //

            // APP SETTINGS //
            target = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "AppData/appsettings.json");
            using (FileStream file = new FileStream(target, FileMode.OpenOrCreate)) ;
            json = System.IO.File.ReadAllText(target);
            AppSettings appSettings = new AppSettings();
            try
            {
                appSettings = JsonSerializer.Deserialize<AppSettings>(json);
            }
            catch
            {

            }
            deleteAfterUnzipTool.Checked = appSettings.DeleteAfterUnzip;
            for (int i = directoryList.Count - 1; i >= 0; i--)
            {
                directoryList[i].DeleteSource = appSettings.DeleteAfterUnzip;
            }
            // . . . . .
        }
    }
}

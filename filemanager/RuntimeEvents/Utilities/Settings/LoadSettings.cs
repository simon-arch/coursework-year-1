using System.Text.Json;

namespace filemanager
{
    public partial class Manager
    {
        private void LoadSettings(List<DisplayHandler> displayList, List<DirectoryHandler> directoryList, List<FileWatcher> watcherList)
        {
            // LIST SETTINGS //
            string json = System.IO.File.ReadAllText(
            Path.Combine(System.IO.Directory.GetCurrentDirectory(),
            @"..\..\..\AppData\listsettings.json"));
            UserSettings defaultSettings = new UserSettings();
            List<UserSettings> userSettings = new List<UserSettings>();
            try
            {
                userSettings = JsonSerializer.Deserialize<List<UserSettings>>(json);
            }
            catch (Exception ex)
            {
                userSettings.Add(defaultSettings);
                userSettings.Add(defaultSettings);
                MessageBox.Show(ex.Message, "JSON error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            for (int i = displayList.Count - 1; i >= 0; i--)
            {
                //Focus(displayList[i]);
                string startpath = userSettings[i].StartupFolder;
                displayList[i].ShowExtensions = userSettings[i].ShowExtensions;
                displayList[i].ShowHidden = userSettings[i].ShowHidden;
                displayList[i].SortType = userSettings[i].SortType;
                GoTo(new RootDirectory("dir", startpath), displayList[i], directoryList[i], watcherList[i]);
            }
            //

            // APP SETTINGS //
            json = System.IO.File.ReadAllText(
            Path.Combine(System.IO.Directory.GetCurrentDirectory(),
            @"..\..\..\AppData\appsettings.json"));
            AppSettings appSettings = new AppSettings();
            try
            {
                appSettings = JsonSerializer.Deserialize<AppSettings>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "JSON error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

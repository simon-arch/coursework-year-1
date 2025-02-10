using filemanager.Dialogs.QuickBarEdit.Models;
using filemanager.Dialogs.QuickBarEdit.Settings;
using SystemFile = System.IO.File;

namespace filemanager.Dialogs.QuickBarEdit.Providers;

public class QuickBarSettingsProvider
{
    private const string Separator = ", ";

    private readonly string _rootPath;
    private readonly string _backupPath;

    public QuickBarSettingsProvider(string rootPath, string backupPath)
    {
        _rootPath = rootPath;
        _backupPath = backupPath;
    }

    public QuickBarSettings Load()
    {
        var lines = SystemFile.ReadAllLines(_rootPath);
        var preferences = lines[0].Split(Separator);

        var toolBarSize = int.Parse(preferences[0]);
        var imageSize = int.Parse(preferences[1]);
        var buttons = lines.Skip(1).Select(line =>
        {
            var data = line.Split(Separator);

            return new QuickBarButton()
            {
                Command = data[1],
                Icon = data[2],
            };
        }).ToList();

        return new QuickBarSettings(toolBarSize, imageSize, buttons);
    }

    public void BackupOld()
    {
        SystemFile.Move(_rootPath, _backupPath, true);
    }

    public void Save(QuickBarSettings settings)
    {
        using var sw = new StreamWriter(_rootPath, false);

        sw.WriteLine($"{settings.ToolBarSize}{Separator}{settings.ImageSize}");

        int i = 0;
        foreach (var button in settings.Buttons)
        {
            sw.WriteLine($"{i++:00}{Separator}{button.Command}{Separator}{button.Icon}");
        }
    }
}

using filemanager.Dialogs.QuickBarEdit.Models;
using System.Collections;
using System.Globalization;
using System.Resources;

namespace filemanager.Dialogs.QuickBarEdit.Providers;

public class QuickBarResourceProvider
{
    private readonly ResourceManager _resourceManager;
    private readonly CultureInfo _culture;

    public QuickBarResourceProvider(ResourceManager resourceManager, CultureInfo culture)
    {
        _resourceManager = resourceManager;
        _culture = culture;
    }

    public IList<IconResource> LoadIcons()
    {
        var resources = _resourceManager.GetResourceSet(_culture, true, true)!;

        var index = 0;
        return resources.Cast<DictionaryEntry>().Select(entry =>
        {
            var resourceKey = entry.Key.ToString()!;
            var icon = (Icon)_resourceManager.GetObject(resourceKey, _culture)!;
            return new IconResource(index++, resourceKey, icon);
        }).ToList();
    }
}

using filemanager.Dialogs.QuickBarEdit.Models;

namespace filemanager.Dialogs.QuickBarEdit.Settings;

public record QuickBarSettings(
    int ToolBarSize,
    int ImageSize,
    IList<QuickBarButton> Buttons
);

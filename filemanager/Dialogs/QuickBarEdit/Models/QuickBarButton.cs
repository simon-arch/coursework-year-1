namespace filemanager.Dialogs.QuickBarEdit.Models;

public class QuickBarButton
{
    public required string Icon { get; set; }

    public required string Command { get; set; }

    public int ImageIndex { get; set; } = -1;
}

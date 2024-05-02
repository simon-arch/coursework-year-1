namespace filemanager
{
    public partial class Manager
    {
        private void InitializeHandlers(Mediator mediator, ListView listView, TabControl tabControl)
        {
            mediator.Display.ListView = listView;
            mediator.Display.TabControl = tabControl;
            mediator.Display.ComboBox = driveComboBox;
            mediator.Display.Label = selectedFileSizeLabel;
            mediator.Display.UsedStorage = freeSpaceLabel;
            mediator.Display.ImageList = fileIconList;
            mediator.Display.ProgressBar = progressBar;
            mediator.Display.PreviewBox = previewBoxTabControl;
            mediator.Display.TextBox = searchTextBox;
        }
    }
}
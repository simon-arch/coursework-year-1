namespace filemanager
{
    public partial class Manager
    {
        private void InitContextEvents()
        {
            viewDetailsContext.Click    += (sender, e) => Controllers["ViewDetails"].PerformClick();
            viewSmallIconsContext.Click += (sender, e) => Controllers["ViewSmallIcons"].PerformClick();
            viewListContext.Click       += (sender, e) => Controllers["ViewList"].PerformClick();
            viewTilesContext.Click      += (sender, e) => Controllers["ViewTiles"].PerformClick();
            sortNameContext.Click       += (sender, e) => Controllers["SortName"].PerformClick();
            sortExtensionContext.Click  += (sender, e) => Controllers["SortExtension"].PerformClick();
            sortDateContext.Click       += (sender, e) => Controllers["SortDate"].PerformClick();
            sortSizeContext.Click       += (sender, e) => Controllers["SortSize"].PerformClick();
            cutContext.Click            += (sender, e) => Controllers["Cut"].PerformClick();
            copyContext.Click           += (sender, e) => Controllers["Copy"].PerformClick();
            pasteContext.Click          += (sender, e) => Controllers["Paste"].PerformClick();
            deleteContext.Click         += (sender, e) => Controllers["Delete"].PerformClick();
            renameContext.Click         += (sender, e) => Controllers["Rename"].PerformClick();
            newFolderContext.Click      += (sender, e) => Controllers["NewFolder"].PerformClick();
            refreshToolContext.Click    += (sender, e) => Controllers["Refresh"].PerformClick();
        }
        private void ShowContext()
        {
            contextMenu.Show(Cursor.Position);
        }
    }
}
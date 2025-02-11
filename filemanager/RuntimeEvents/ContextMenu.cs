namespace filemanager
{
    public partial class Manager
    {
        private void InitContextEvents()
        {
            viewDetailsContext.Click       += (sender, e) => _controllers["ViewDetails"].PerformClick();
            viewSmallIconsContext.Click    += (sender, e) => _controllers["ViewSmallIcons"].PerformClick();
            viewListContext.Click          += (sender, e) => _controllers["ViewList"].PerformClick();
            viewTilesContext.Click         += (sender, e) => _controllers["ViewTiles"].PerformClick();
            sortNameContext.Click          += (sender, e) => _controllers["SortName"].PerformClick();
            sortExtensionContext.Click     += (sender, e) => _controllers["SortExtension"].PerformClick();
            sortDateContext.Click          += (sender, e) => _controllers["SortDate"].PerformClick();
            sortSizeContext.Click          += (sender, e) => _controllers["SortSize"].PerformClick();
            reversedContext.Click          += (sender, e) => _controllers["SortReversed"].PerformClick();
            cutContext.Click               += (sender, e) => _controllers["Cut"].PerformClick();
            copyContext.Click              += (sender, e) => _controllers["Copy"].PerformClick();
            pasteContext.Click             += (sender, e) => _controllers["Paste"].PerformClick();
            deleteContext.Click            += (sender, e) => _controllers["Delete"].PerformClick();
            renameContext.Click            += (sender, e) => _controllers["Rename"].PerformClick();
            newFolderContext.Click         += (sender, e) => _controllers["NewFolder"].PerformClick();
            refreshToolContext.Click       += (sender, e) => _controllers["Refresh"].PerformClick();
            addQuickToolContext.Click      += (sender, e) => _controllers["QuickAccessAdd"].PerformClick();
            contextQuickAccessRemove.Click += (sender, e) => _controllers["QuickAccessRemove"].PerformClick();
        }
        private void ShowContext() {
            contextMenu.Show(Cursor.Position);
        }
        private void ShowQuickContext() {
            contextQuickAccess.Show(Cursor.Position);
        }
    }
}
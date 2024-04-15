namespace filemanager
{
    public partial class Manager
    {
        private void InitContextEvents(DisplayHandler displayHandler, DirectoryHandler directoryHandler, FileWatcher fileWatcher)
        {
            viewDetailsContext.Click += (sender, e) => { displayHandler.setView(1); };
            viewSmallIconsContext.Click += (sender, e) => { displayHandler.setView(2); };
            viewListContext.Click += (sender, e) => { displayHandler.setView(3); };
            viewTilesContext.Click += (sender, e) => { displayHandler.setView(4); };
            sortNameContext.Click += (sender, e) => Sort(SortType.name, displayHandler, directoryHandler);
            sortExtensionContext.Click += (sender, e) => Sort(SortType.extension, displayHandler, directoryHandler);
            sortDateContext.Click += (sender, e) => Sort(SortType.date, displayHandler, directoryHandler);
            sortSizeContext.Click += (sender, e) => Sort(SortType.size, displayHandler, directoryHandler);
            openContext.Click += (sender, e) => { DoubleClick(displayHandler, directoryHandler, fileWatcher); };
            cutContext.Click += (sender, e) => { exchangeBuffer.Copy(displayHandler.ListView.SelectedItems); exchangeBuffer.Cut = true; };
            copyContext.Click += (sender, e) => { exchangeBuffer.Copy(displayHandler.ListView.SelectedItems); exchangeBuffer.Cut = false; };
            pasteContext.Click += (sender, e) => { exchangeBuffer.Paste(directoryHandler.RootDirectory.Path); };
            deleteContext.Click += (sender, e) => { displayHandler.DeleteSelection(); };
            renameContext.Click += (sender, e) => { Rename(displayHandler, directoryHandler); };
            newFolderContext.Click += (sender, e) => { Directory.CreatePrompt(directoryHandler.RootDirectory.Path); };
            refreshToolContext.Click += (sender, e) => { Refresh(displayHandler, directoryHandler); };
        }
        private void ShowContext() 
        {
            ContextMenuStrip context = new ContextMenuStrip();
            contextMenu.Show(Cursor.Position);
        }
        private void ShowContext(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            contextMenu.Show(Cursor.Position);
        }
    }
}
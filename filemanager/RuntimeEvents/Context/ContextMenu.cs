namespace filemanager
{
    public partial class Manager
    {
        private void InitContextEvents(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            viewDetailsContext.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.setView(1); };
            viewSmallIconsContext.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.setView(2); };
            viewListContext.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.setView(3); };
            viewTilesContext.Click += (sender, e) => { if (displayHandler.Focused) displayHandler.setView(4); };
            sortNameContext.Click += (sender, e) => Sort(SortType.name, displayHandler, directoryHandler);
            sortExtensionContext.Click += (sender, e) => Sort(SortType.extension, displayHandler, directoryHandler);
            sortDateContext.Click += (sender, e) => Sort(SortType.date, displayHandler, directoryHandler);
            sortSizeContext.Click += (sender, e) => Sort(SortType.size, displayHandler, directoryHandler);
            openContext.Click += (sender, e) => { DoubleClick(displayHandler, directoryHandler); };
            cutContext.Click += (sender, e) => { exchangeBuffer.Copy(displayHandler.ListView.SelectedItems); exchangeBuffer.Cut = true; };
            copyContext.Click += (sender, e) => { exchangeBuffer.Copy(displayHandler.ListView.SelectedItems); exchangeBuffer.Cut = false; };
            pasteContext.Click += (sender, e) => { exchangeBuffer.Paste(directoryHandler.RootDirectory.Path); Refresh(displayHandler, directoryHandler); };
            deleteContext.Click += (sender, e) => { displayHandler.DeleteSelection(); Refresh(displayHandler, directoryHandler); };
            renameContext.Click += (sender, e) => { Rename(displayHandler, directoryHandler); };
            newFolderContext.Click += (sender, e) => { Directory.CreatePrompt(directoryHandler.RootDirectory.Path); Refresh(displayHandler, directoryHandler); };
            refreshTool.Click += (sender, e) => { Refresh(displayHandler, directoryHandler); };
        }
        private void ShowContext() 
        {
            contextMenu.Show(Cursor.Position);
        }
        private void ShowContext(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            contextMenu.Show(Cursor.Position);
        }
    }
}
namespace filemanager
{
    public partial class Manager
    {
        public void Sort(SortType sortType, DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (!displayHandler.Focused) return;
            displayHandler.SortType = sortType;
            Refresh(displayHandler, directoryHandler);
        }
    }
}

namespace filemanager
{
    public partial class Manager
    {
        public void Sort(SortType sortType, DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (displayHandler.Focused)
            {
                displayHandler.SortType = sortType;
                Refresh(displayHandler, directoryHandler);
            }
        }
    }
}

namespace filemanager
{
    public partial class Form1
    {
        public void Sort(string sortType, DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (displayHandler.Focused)
            {
                displayHandler.SortType = sortType;
                Refresh(displayHandler, directoryHandler);
            }
        }
    }
}

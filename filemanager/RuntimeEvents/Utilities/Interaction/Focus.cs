namespace filemanager
{
    public partial class Manager
    {
        public void Focus(DisplayHandler displayHandler)
        {
            displayList.Select(x => x.Focused = false).ToList();
            displayHandler.Focused = true;
        }
    }
}

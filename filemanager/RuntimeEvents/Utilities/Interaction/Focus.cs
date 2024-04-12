namespace filemanager
{
    public partial class Form1
    {
        public void Focus(DisplayHandler displayHandler)
        {
            displayList.Select(x => x.Focused = false).ToList();
            displayHandler.Focused = true;
        }
    }
}

namespace filemanager
{
    public partial class Manager
    {
        public void Properties(DisplayHandler displayHandler)
        {
            if (!displayHandler.Focused) return;
            if (displayHandler.isSelected())
            {
                Element selected = displayHandler.ListView.SelectedItems[0].ETag();
                if (selected.Type == "file")
                {
                    ((File)selected).Properties();
                }
            }
        }
    }
}

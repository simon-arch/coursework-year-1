namespace filemanager
{
    public partial class Form1
    {
        public void Properties(DisplayHandler displayHandler)
        {
            if (displayHandler.Focused && displayHandler.isSelected())
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

namespace filemanager
{
    public partial class Manager
    {
        private void Click(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (displayHandler.isSelected())
            {
                switch (displayHandler.ListView.SelectedItems[0].ETag().SubType)
                {
                    case "imagefile":
                        displayHandler.Preview("image");
                        displayHandler.PreviewBox.SelectedIndex = 0;
                        break;

                    case "documentfile":
                        displayHandler.Preview("document");
                        displayHandler.PreviewBox.SelectedIndex = 1;
                        break;

                    default:
                        displayHandler.Preview("clear");
                        break;
                }
            }
        }
    }
}

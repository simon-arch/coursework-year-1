namespace filemanager
{
    public partial class DirectoryHandler
    {
        public void UnzipArchive(ListView.SelectedListViewItemCollection source)
        {
            foreach (ListViewItem elem in source)
            {
                if (elem.ETag().SubType == "archive")
                {
                    try
                    {
                        ((ArchiveFile)elem.Tag).Unzip();
                        if (DeleteSource) ((ArchiveFile)elem.Tag).Delete();
                    }
                    catch
                    {
                        NotificationHandler.invokeError(ErrorType.unzipError);
                    }
                }
            }
        }
    }
}

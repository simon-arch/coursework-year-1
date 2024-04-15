namespace filemanager
{
    public partial class DirectoryHandler
    {
        public void ZipArchive(ListView.SelectedListViewItemCollection source)
        {
            if (source.Count > 0)
            {
                if (source.Count == 1 && source[0].ETag().Type == "utility") return;

                ExchangeBuffer buffer = new ExchangeBuffer();
                string zipPath = Path.Combine(Path.GetDirectoryName(source[source.Count - 1].ETag().Path), $"temp-{DateTime.Now.Ticks}");
                System.IO.Directory.CreateDirectory(zipPath);

                buffer.Copy(source);
                buffer.Paste(zipPath);

                string targetname = RecurringNames.GetExistingFileName($"{Path.Combine(zipPath, @"../")}" +
                    $"{source[source.Count - 1].ETag().Name}", ".zip");
                try { System.IO.Compression.ZipFile.CreateFromDirectory(zipPath, targetname); }
                catch { NotificationHandler.invokeError(ErrorType.zipError); }

                System.IO.Directory.Delete(zipPath, true);
            }
        }
    }
}

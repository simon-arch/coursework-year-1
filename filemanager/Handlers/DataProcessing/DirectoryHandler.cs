namespace filemanager
{
    public class DirectoryHandler : DataHandler
    {
        public List<string> ListedExtensions { get; set; }
        public int DisplayMode { get; set; }
        public bool DeleteSource { get; set; }
        public void PopulateDirectory()
        {
            RootDirectory.clearData();
            DirectoryInfo directoryInfo = new DirectoryInfo(RootDirectory.Path);
            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo f in files)
            {
                File file = new File();
                if(extensions.ContainsKey(f.Extension.ToLower()))
                {
                    switch (extensions[f.Extension.ToLower()])
                    {
                        case "image":
                            file = new ImageFile();
                            break;
                        case "video":
                            file = new VideoFile();
                            break;
                        case "audio":
                            file = new AudioFile();
                            break;
                        case "document":
                            file = new DocumentFile();
                            break;
                        case "archive":
                            file = new ArchiveFile();
                            break;
                    }
                }
                else
                {
                    file = new UnknownFile();
                }
                file.Name = Path.GetFileNameWithoutExtension(f.Name);
                file.Path = f.FullName.ToString();
                file.Size = f.Length;
                file.Extension = f.Extension.ToLower();
                file.CreationDate = f.CreationTime.ToString();
                file.Attributes += f.Attributes.HasFlag(FileAttributes.Archive)     ? "a" : "-";
                file.Attributes += f.Attributes.HasFlag(FileAttributes.ReadOnly)    ? "r" : "-";
                file.Attributes += f.Attributes.HasFlag(FileAttributes.Hidden)      ? "h" : "-";
                file.Attributes += f.Attributes.HasFlag(FileAttributes.System)      ? "s" : "-";
                switch (DisplayMode)
                {
                    case 0: file.IgnoreListing = false; break;
                    case 1:
                        if (file.Extension == ".exe")
                        {
                            file.IgnoreListing = false;
                        }
                        else
                        {
                            file.IgnoreListing = true;
                        }
                        break;
                    case 2: 
                        if (ListedExtensions.Contains(file.Extension.Replace('.',' ').Trim()))
                        {
                            file.IgnoreListing = false;
                        }
                        else
                        {
                            file.IgnoreListing = true;
                        }
                        break;
                }
                RootDirectory.appendFile(file);
            }

            DirectoryInfo[] dirs = directoryInfo.GetDirectories();
            foreach (DirectoryInfo d in dirs)
            {
                Directory dir = new Directory(
                        d.Name,
                        d.FullName
                    );
                dir.Attributes += d.Attributes.HasFlag(FileAttributes.Archive)   ? "a" : "-";
                dir.Attributes += d.Attributes.HasFlag(FileAttributes.ReadOnly)  ? "r" : "-";
                dir.Attributes += d.Attributes.HasFlag(FileAttributes.Hidden)    ? "h" : "-";
                dir.Attributes += d.Attributes.HasFlag(FileAttributes.System)    ? "s" : "-";
                if (d.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    dir.IsHidden = true;
                }
                dir.CreationDate = d.CreationTime.ToString();
                RootDirectory.appendDirectory(dir);
            }
        }
        public IEnumerable<string> SearchForFiles(string path, string key, bool isRecursive)
        {
            IEnumerable<string> result = System.IO.Directory.EnumerateFiles(path, $"*{key}*", new EnumerationOptions { RecurseSubdirectories = isRecursive, IgnoreInaccessible = true });
            return result;
        }
        public IEnumerable<string> SearchForDirectories(string path, string key, bool isRecursive)
        {
            IEnumerable<string> result = System.IO.Directory.EnumerateDirectories(path, $"*{key}*", new EnumerationOptions { RecurseSubdirectories = isRecursive, IgnoreInaccessible = true });
            return result;
        }
        protected static Dictionary<string, string> extensions = new Dictionary<string, string>()
        {
            {".jpg", "image"},
            {".png", "image"},
            {".gif", "image"},
            {".ico", "image"},

            {".mp4", "video"},
            {".mp3", "audio"},

            {".txt", "document"},
            {".doc", "document"},
            {".xml", "document"},
            {".pdf", "document"},

            {".zip", "archive"},

            {".lnk", "shortcut"}
        };
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

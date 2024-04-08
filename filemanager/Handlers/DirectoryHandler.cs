using filemanager.Resources;

namespace filemanager
{
    public class DirectoryHandler
    {
        protected static Dictionary<string, string> extensions = new Dictionary<string, string>()
        {
            {".jpg", "image"},
            {".png", "image"},
            {".gif", "image"},

            {".mp4", "video"},
            {".mp3", "audio"},

            {".txt", "document"},
            {".doc", "document"},
            {".xml", "document"},
            {".pdf", "document"},

            {".7z", "archive"},
            {".rar", "archive"},
            {".zip", "archive"},
        };
        public RootDirectory RootDirectory { get; set; }
        public void PopulateDirectory()
        {
            RootDirectory.clearData();
            DirectoryInfo directoryInfo = new DirectoryInfo(RootDirectory.Path);
            FileInfo[] files = directoryInfo.GetFiles();
            Directory root = new Directory("..", Path.GetFullPath(Path.Combine(RootDirectory.Path, @"..")));
            root.IgnoreListing = true;
            RootDirectory.appendDirectory(root);

            foreach (FileInfo f in files)
            {
                File file = new File();
                if(extensions.ContainsKey(f.Extension))
                {
                    switch (extensions[f.Extension])
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
                file.Extension = f.Extension.ToString();
                file.CreationDate = f.CreationTime.ToString();
                RootDirectory.appendFile(file);
            }

            DirectoryInfo[] dirs = directoryInfo.GetDirectories();
            foreach (DirectoryInfo d in dirs)
            {
                Directory dir = new Directory(
                        d.Name,
                        d.FullName
                    );
                if (d.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    dir.IsHidden = true;
                }
                dir.CreationDate = d.CreationTime.ToString();
                RootDirectory.appendDirectory(dir);
            }
        }
        public void ZipArchive(System.Windows.Forms.ListView.SelectedListViewItemCollection source)
        {
            if(source.Count > 0)
            {
                ExchangeBuffer buffer = new ExchangeBuffer();
                string zipPath = Path.Combine(Path.GetDirectoryName(((Element)source[source.Count - 1].Tag).Path), $"temp-{DateTime.Now.Ticks.ToString()}");
                System.IO.Directory.CreateDirectory(zipPath);

                buffer.Copy(source);
                buffer.Paste(zipPath);

                if(buffer.SourceItems.Count > 0)
                {
                    System.IO.Compression.ZipFile.CreateFromDirectory(zipPath, $"{Path.Combine(zipPath, @"../")}{((Element)source[source.Count - 1].Tag).Name}.zip");
                }
                System.IO.Directory.Delete(zipPath, true);
            }
        }
        public void UnzipArchive(ListView.SelectedListViewItemCollection source)
        {
            foreach (ListViewItem elem in source)
            {
                if (((Element)elem.Tag).SubType == "archive")
                {
                    ((ArchiveFile)elem.Tag).Unzip();
                }
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

    }
}

namespace filemanager
{
    public partial class DirectoryHandler : DataHandler
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
                if (d.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    dir.IsHidden = true;
                }
                dir.CreationDate = d.CreationTime.ToString();
                RootDirectory.appendDirectory(dir);
            }
        }
    }
}

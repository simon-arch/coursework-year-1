namespace filemanager
{
    public class DirectoryHandler
    {
        protected static Dictionary<String, String> extensions = new Dictionary<String, String>()
        {
            {".jpg", "image"},
            {".png", "image"},
            {".gif", "image"},

            {".mp4", "video"},
            {".mp3", "audio"},
        };
        public int CurrentFolder { get; set; }
        public RootDirectory RootDirectory { get; set; }
        public List<RootDirectory> FolderHistory { get; set; }
        public DirectoryHandler() {
            FolderHistory = new List<RootDirectory>(); 
            CurrentFolder = 0; 
        }
        public void PopulateDirectory()
        {
            RootDirectory.clearData();
            DirectoryInfo directoryInfo = new DirectoryInfo(RootDirectory.Path);
            FileInfo[] files = directoryInfo.GetFiles();

            RootDirectory.appendDirectory(new Directory(
                    "[..]", 
                    Path.GetFullPath(Path.Combine(RootDirectory.Path, @".."))
                    )
                );

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
                Directory dir = new Directory( // ??????
                        $"[{d.Name}]",
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

namespace filemanager
{
    public class DirectoryHandler
    {
        protected static Dictionary<String, String> extensions = new Dictionary<String, String>() 
        {
            {".jpg", "image"},
            {".mp4", "video"},
            {".mp3", "audio"},
        };
        protected List<RootDirectory> folderHistory = new List<RootDirectory>();
        protected int currentFolder = 0;
        protected RootDirectory rootDirectory = null!;
        public int CurrentFolder
        {
            get { return currentFolder; }
            set { currentFolder = value; }
        }
        public RootDirectory RootDirectory {
            get { return rootDirectory; } 
            set { rootDirectory = value; } 
        }
        public List<RootDirectory> FolderHistory
        {
            get { return folderHistory; }
            set { folderHistory = value; }
        }
        public void PopulateDirectory()
        {
            rootDirectory.clearData();
            DirectoryInfo directoryInfo = new DirectoryInfo(rootDirectory.Path);
            FileInfo[] files = directoryInfo.GetFiles();

            rootDirectory.appendDirectory(new Directory(
                    "[..]", 
                    Path.GetFullPath(Path.Combine(rootDirectory.Path, @".."))
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
                file.Name = Path.GetFileNameWithoutExtension(f.Name);
                file.Path = f.FullName.ToString();
                file.Size = f.Length;
                file.Extension = f.Extension.ToString();
                file.CreationDate = f.CreationTime.ToString();
                rootDirectory.appendFile(file);
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
                rootDirectory.appendDirectory(dir);
            }
        }
    }
}

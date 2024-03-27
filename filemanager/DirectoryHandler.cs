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

        protected RootDirectory rootDirectory = null!;
        public RootDirectory RootDirectory { 
            get { return rootDirectory; } 
            set { rootDirectory = value; } 
        }
        public void populateDirectory()
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
                file.Size = f.Length.ToString();
                file.Extension = f.Extension.ToString();
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
                rootDirectory.appendDirectory(dir);
            }
        }
    }
}

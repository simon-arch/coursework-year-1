namespace filemanager
{
    public class DirectoryHandler
    {
        protected static List<String> imageExtensions = new List<String>() { ".jpg", ".png", ".bmp", ".jpeg", ".ico", ".gif" };
        protected static List<String> videoExtensions = new List<String>() { ".mp4", ".avi", ".fla", ".m4v", ".mkv" };
        protected static List<String> audioExtensions = new List<String>() { ".mp3", ".wav", ".flac", ".wma" };
        
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
                if (imageExtensions.Contains(f.Extension))
                {
                    rootDirectory.appendFile(new ImageFile(
                            Path.GetFileNameWithoutExtension(f.Name),
                            f.FullName.ToString(),
                            f.Length.ToString(),
                            f.Extension.ToString()
                        )
                    );
                }

                else if (videoExtensions.Contains(f.Extension))
                {
                    rootDirectory.appendFile(new VideoFile(
                            Path.GetFileNameWithoutExtension(f.Name),
                            f.FullName.ToString(),
                            f.Length.ToString(),
                            f.Extension.ToString()
                        )
                    );
                }
                    
                else if (audioExtensions.Contains(f.Extension))
                {
                    rootDirectory.appendFile(new AudioFile(
                            Path.GetFileNameWithoutExtension(f.Name),
                            f.FullName.ToString(),
                            f.Length.ToString(),
                            f.Extension.ToString()
                        )
                    );
                }
            }

            DirectoryInfo[] dirs = directoryInfo.GetDirectories();
            foreach (DirectoryInfo d in dirs)
            {
                rootDirectory.appendDirectory(new Directory(
                        d.Name,
                        d.FullName
                    )
                );
            }
        }
    }
}

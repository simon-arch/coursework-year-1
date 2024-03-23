namespace filemanager
{
    public class DirectoryHandler
    {
        protected RootDirectory rootDirectory;
        public RootDirectory RootDirectory { get; set; }
        public void populateDirectory()
        {
            this.RootDirectory.clearData();
            DirectoryInfo directoryInfo = new DirectoryInfo(this.RootDirectory.Path);

            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo f in files)
            {
                this.RootDirectory.appendFile(new File(
                        Path.GetFileNameWithoutExtension(f.Name),
                        f.FullName.ToString(),
                        f.Length.ToString(),
                        f.Extension.ToString()
                    )
                );
            }

            DirectoryInfo[] dirs = directoryInfo.GetDirectories();
            foreach (DirectoryInfo d in dirs)
            {
                this.RootDirectory.appendDirectory(new Directory(
                        d.Name,
                        d.FullName
                    )
                );
            }
        }
    }
}

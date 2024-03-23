﻿namespace filemanager
{
    public class DirectoryHandler
    {
        protected RootDirectory rootDirectory;
        public RootDirectory RootDirectory { 
            get { return rootDirectory; } 
            set { rootDirectory = value; } 
        }
        public void populateDirectory()
        {
            rootDirectory.clearData();
            DirectoryInfo directoryInfo = new DirectoryInfo(rootDirectory.Path);

            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo f in files)
            {
                rootDirectory.appendFile(new File(
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
                rootDirectory.appendDirectory(new Directory(
                        d.Name,
                        d.FullName
                    )
                );
            }
        }
    }
}

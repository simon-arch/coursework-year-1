﻿namespace filemanager
{
    public partial class Manager
    {
        public void GoUp(DisplayHandler displayHandler, DirectoryHandler directoryHandler, FileWatcher fileWatcher)
        {
            if (!displayHandler.Focused) return;
            if (Path.GetPathRoot(directoryHandler.RootDirectory.Path) != directoryHandler.RootDirectory.Path)
            {
                RootDirectory root = new RootDirectory("dir", Path.GetDirectoryName(directoryHandler.RootDirectory.Path));
                GoTo(root, displayHandler, directoryHandler, fileWatcher);
            }
        }
    }
}

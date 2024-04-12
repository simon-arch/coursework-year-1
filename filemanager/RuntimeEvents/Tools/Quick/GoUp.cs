namespace filemanager
{
    public partial class Form1
    {
        public void GoUp(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            if (displayHandler.Focused)
            {
                if (Path.GetPathRoot(directoryHandler.RootDirectory.Path) != directoryHandler.RootDirectory.Path)
                {
                    RootDirectory root = new RootDirectory("dir", Path.GetDirectoryName(directoryHandler.RootDirectory.Path));
                    GoTo(root, displayHandler, directoryHandler);
                }
            }
        }
    }
}

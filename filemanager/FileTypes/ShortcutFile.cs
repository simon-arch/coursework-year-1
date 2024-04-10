namespace filemanager
{
    public class ShortcutFile : File
    {
        public ShortcutFile()
        {
            IconIndex = 7;
            SubType = "shortcut";
            Type = "file";
        }
        public string GetShortcut()
        {
            throw new NotImplementedException();
        }
    }
}

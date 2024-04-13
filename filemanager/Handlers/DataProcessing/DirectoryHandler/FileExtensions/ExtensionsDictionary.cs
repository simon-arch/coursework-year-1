namespace filemanager
{
    public partial class DirectoryHandler
    {
        protected static Dictionary<string, string> extensions = new Dictionary<string, string>()
        {
            {".jpg", "image"},
            {".png", "image"},
            {".gif", "image"},
            {".ico", "image"},

            {".mp4", "video"},
            {".mp3", "audio"},

            {".txt", "document"},
            {".doc", "document"},
            {".xml", "document"},
            {".pdf", "document"},

            {".7z", "archive"},
            {".rar", "archive"},
            {".zip", "archive"},

            {".lnk", "shortcut"}
        };
    }
}

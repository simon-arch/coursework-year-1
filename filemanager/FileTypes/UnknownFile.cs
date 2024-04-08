namespace filemanager
{
    public class UnknownFile : File
    {
        public UnknownFile()
        {
            SubType = "unknownfile";
            Type = "file";
            IconIndex = 4;
        }
    }
}
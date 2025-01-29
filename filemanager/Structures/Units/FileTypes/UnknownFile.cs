namespace filemanager
{
    public class UnknownFile : File
    {
        public UnknownFile()
        {
            SubType = "unknownfile";
            Type = ElementType.File;
        }
    }
}
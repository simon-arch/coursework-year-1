namespace filemanager
{
    public class ArchiveFile : File
    {
        public ArchiveFile() 
        {
            IconIndex = 6;
            SubType = "archive";
            Type = "file";
        }
        public void Unzip()
        {
            System.IO.Compression.ZipFile.ExtractToDirectory(Path, Path + " Unzipped");
        }
    }
}

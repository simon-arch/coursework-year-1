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
            int c = 1;
            string newname = Path + " Unzipped";
            string modname = newname;
            while (System.IO.Path.Exists(modname))
            {
                modname = $"{newname}({c})"; c++;
            }
            System.IO.Compression.ZipFile.ExtractToDirectory(Path, modname);
        }
    }
}

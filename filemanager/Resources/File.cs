namespace filemanager
{
    public class File : Element
    {
        public long Size { get; set; }
        public File(string name, string path, long size, string extension)
        {
            Name = name;
            Path = path;
            Size = size;
            Extension = extension;
        }
        public File() { }
        public override void delete()
        {
            System.IO.File.Delete(Path);
        }
    }
}

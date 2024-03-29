namespace filemanager
{
    public class File : Element
    {
        protected long size;
        public long Size { 
            get { return size; } 
            set { size = value; }
        }
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
            System.IO.File.Delete(path);
        }
    }
}

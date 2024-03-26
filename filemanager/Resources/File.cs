namespace filemanager
{
    public class File : Element
    {
        protected string size = string.Empty;
        public string Size { 
            get { return size; } 
            set { size = value; }
        }
        public File(string name, string path, string size, string extension)
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

namespace filemanager
{
    public class File : Element
    {
        protected string name = string.Empty;
        protected string size = string.Empty;
        protected string path = string.Empty;
        protected string extension = string.Empty;
        public string Name { get; set; }
        public string Size { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }

        public File(string name, string path, string size, string extension)
        {
            Name = name;
            Path = path;
            Size = size;
            Extension = extension;
        }
        public override void delete()
        {
            System.IO.File.Delete(this.Path);
        }
    }
}

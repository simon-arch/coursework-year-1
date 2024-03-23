namespace filemanager
{
    public class Directory : Element
    {
        protected string name = string.Empty;
        protected string path = string.Empty;
        public string Name { get; set; }
        public string Path { get; set; }
        public Directory(string name, string path)
        {
            Name = name;
            Path = path;
        }
        public override void delete()
        {
            System.IO.Directory.Delete(this.Path); //, true
        }
    }
}

namespace filemanager
{
    public class Directory : Element
    {
        protected string name = string.Empty;
        protected string path = string.Empty;
        public string Name {
            get { return name; }
            set { name = value; } 
        }
        public string Path {
            get { return path; }
            set { path = value; } 
        }
        public Directory(string name, string path)
        {
            Name = name;
            Path = path;
        }
        public override void delete()
        {
            System.IO.Directory.Delete(path); //, true
        }
    }
}

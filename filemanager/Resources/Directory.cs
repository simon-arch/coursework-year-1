namespace filemanager
{
    public class Directory : Element
    {
        public Directory(string name, string path)
        {
            Name = name;
            Path = path;
        }
        public Directory() { }
        public override void delete()
        {
            System.IO.Directory.Delete(path); //, true
        }
    }
}

namespace filemanager
{
    public class Directory : Element
    {
        public bool IsHidden { get; set; }
        public Directory(string name, string path)
        {
            Name = name;
            Path = path;
            IconIndex = 1;
            IsHidden = false;
        }
        public static void Create(string path)
        {
            System.IO.Directory.CreateDirectory(path + @"/New Folder");
        }
        public override void Delete()
        {
            System.IO.Directory.Delete(Path);
        }
    }
}

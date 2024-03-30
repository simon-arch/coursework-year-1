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
        public override void delete()
        {
            System.IO.Directory.Delete(Path);
        }
    }
}

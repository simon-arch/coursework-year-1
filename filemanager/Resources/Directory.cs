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
            string dirname = @"/New Folder";
            string newname = dirname;
            for (int i = 1; System.IO.Directory.Exists(path + newname); i++) 
            {
                newname = string.Format("{0}({1})", dirname, i);
            }
            System.IO.Directory.CreateDirectory(path + newname);
        }
        public override void Delete()
        {
            System.IO.Directory.Delete(Path, true);
        }
    }
}

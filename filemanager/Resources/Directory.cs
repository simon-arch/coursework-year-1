namespace filemanager
{
    public class Directory : Element
    {
        protected bool isHidden = false;
        public bool IsHidden
        {
            get { return isHidden; }
            set { isHidden = value; }
        }
        public Directory(string name, string path)
        {
            Name = name;
            Path = path;
        }
        public Directory() { IconIndex = 0; }
        public override void delete()
        {
            System.IO.Directory.Delete(path); //, true
        }
    }
}

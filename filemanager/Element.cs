namespace filemanager
{
    public class Element
    {
        protected string name = string.Empty;
        protected string path = string.Empty;
        protected string extension = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        public string Extension
        {
            get { return extension; }
            set { extension = value; }
        }
        public virtual void delete() { }
    }
}

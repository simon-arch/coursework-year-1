namespace filemanager
{
    public abstract class Element
    {
        protected string name = string.Empty;
        protected string path = string.Empty;
        protected string extension = string.Empty;
        protected string creationDate = string.Empty;
        public int IconIndex { get; protected set; }
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
        public string CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
        public virtual void delete() { }
    }
}

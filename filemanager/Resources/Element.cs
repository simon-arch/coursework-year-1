namespace filemanager
{
    public abstract class Element
    {
        public int IconIndex { get; protected set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public string CreationDate { get; set; }
        public virtual void Delete() { }
    }
}

namespace filemanager
{
    public class ImageFile : File
    {
        protected int width;
        protected int height;
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public ImageFile(string name, string path, long size, string extension)
            : base(name, path, size, extension) { }
        public ImageFile() { }
    }
}

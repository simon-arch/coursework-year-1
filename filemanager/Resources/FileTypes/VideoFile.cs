namespace filemanager
{
    public class VideoFile : File
    {
        protected int width;
        protected int height;
        protected int frameRate;
        protected int bitRate;
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
        public int FrameRate
        {
            get { return frameRate; }
            set { frameRate = value; }
        }
        public int BitRate
        {
            get { return bitRate; }
            set { bitRate = value; }
        }
        public VideoFile(string name, string path, string size, string extension)
            : base(name, path, size, extension) { }
        public VideoFile() { }
    }
}

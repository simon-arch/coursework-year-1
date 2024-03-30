namespace filemanager
{
    public class VideoFile : File
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int FrameRate { get; set; }
        public int BitRate { get; set; }
        public VideoFile(string name, string path, long size, string extension)
            : base(name, path, size, extension) { }
        public VideoFile() {
            IconIndex = 4;
        }
    }
}

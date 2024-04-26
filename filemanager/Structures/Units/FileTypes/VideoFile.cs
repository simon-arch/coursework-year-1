namespace filemanager
{
    public class VideoFile : File
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int FrameRate { get; set; }
        public int BitRate { get; set; }
        public VideoFile() {
            SubType = "videofile";
            Type = "file";
        }
    }
}

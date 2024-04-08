namespace filemanager
{
    public class AudioFile : File
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Channels { get; set; }
        public int BitRate { get; set; }
        public AudioFile(string name, string path, long size, string extension)
            : base(name, path, size, extension) { }
        public AudioFile() {
            IconIndex = 3;
            SubType = "audiofile";
            Type = "file";
        }
    }
}

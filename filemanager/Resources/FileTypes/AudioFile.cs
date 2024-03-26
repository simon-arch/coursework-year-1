using System.Threading.Channels;

namespace filemanager
{
    public class AudioFile : File
    {
        protected int width;
        protected int height;
        protected int channels;
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
        public int Channels
        {
            get { return channels; }
            set { channels = value; }
        }
        public int BitRate
        {
            get { return bitRate; }
            set { bitRate = value; }
        }
        public AudioFile(string name, string path, string size, string extension)
            : base(name, path, size, extension) { }
        public AudioFile() { }
    }
}

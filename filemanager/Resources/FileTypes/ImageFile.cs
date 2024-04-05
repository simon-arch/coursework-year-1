using System.Diagnostics;

namespace filemanager
{
    public class ImageFile : File
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ImageFile(string name, string path, long size, string extension)
            : base(name, path, size, extension) { }
        public ImageFile() { 
            IconIndex = 2;
        }
        public override void Edit()
        {
            Process.Start("mspaint.exe", Path);
        }
    }
}

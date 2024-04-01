using System.Diagnostics;

namespace filemanager
{
    public class File : Element
    {
        public long Size { get; set; }
        public File(string name, string path, long size, string extension)
        {
            Name = name;
            Path = path;
            Size = size;
            Extension = extension;
        }
        public File() { }
        public void View()
        {
            System.Diagnostics.Process explorer = new System.Diagnostics.Process();
            explorer.StartInfo.FileName = "explorer";
            explorer.StartInfo.Arguments = Path;
            explorer.Start();
        }
        public override void Edit()
        {
            Process.Start("notepad.exe", Path);
        }
        public override void Delete()
        {
            System.IO.File.Delete(Path);
        }
    }
}

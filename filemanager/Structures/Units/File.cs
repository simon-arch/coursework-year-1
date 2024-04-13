using System.Diagnostics;
using System.IO;

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
            Type = "file";
        }
        public File() 
        {
            Type = "file";
        }
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
        public void Properties()
        {
            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = Path,
                UseShellExecute = true,
                Verb = "Properties"
            };
            Process.Start(info);
        }
        public override long GetSize()
        {
            return new FileInfo(Path).Length;
        }
    }
}

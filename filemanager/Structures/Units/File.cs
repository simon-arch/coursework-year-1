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
        public void View(Dictionary<string, string> associated)
        {
            System.Diagnostics.Process explorer = new System.Diagnostics.Process();

            explorer.StartInfo.FileName = associated.ContainsKey(Extension) 
                ? associated[Extension] : "explorer";

            explorer.StartInfo.Arguments = Path;
            try { explorer.Start(); }
            catch
            {
                explorer.StartInfo.FileName = "explorer";
                explorer.Start();
            }
        }
        public override void Edit()
        {
            Process.Start("notepad.exe", Path);
        }
        public override void Delete()
        {
            System.IO.File.Delete(Path);
        }
        public override long GetSize()
        {
            return new FileInfo(Path).Length;
        }
    }
}

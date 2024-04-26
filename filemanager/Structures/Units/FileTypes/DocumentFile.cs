using System.Diagnostics;

namespace filemanager
{
    public class DocumentFile : File
    {
        public DocumentFile()
        {
            SubType = "documentfile";
            Type = "file";
        }
        public void PrintDocument(string filePath, string printer)
        {
            DefaultPrinter.SetDefaultPrinter(printer);
            ProcessStartInfo info = new ProcessStartInfo() 
            {
                FileName = filePath,
                UseShellExecute = true,
                Verb = "print"
            };
            Process.Start(info);
        }
    }
}
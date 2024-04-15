using System.Diagnostics;

namespace filemanager
{
    public static class ProcessCall
    {
        public static void RunProcess(string process, string arguments)
        {
            System.Diagnostics.Process explorer = new System.Diagnostics.Process();
            explorer.StartInfo.FileName = process;
            explorer.StartInfo.Arguments = arguments;
            explorer.Start();
        }
        public static void RunProcessInfo(ProcessStartInfo arguments)
        {
            Process explorer = new Process();
            explorer.StartInfo = arguments;
            explorer.Start();
        }
    }
}

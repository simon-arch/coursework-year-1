using System.Runtime.InteropServices;

namespace filemanager
{
    internal class DefaultPrinter
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Name);
    }
}

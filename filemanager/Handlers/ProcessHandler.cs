namespace filemanager
{
    public class ProcessHandler
    {
        public void RunProcess(string process, string arguments)
        {
            System.Diagnostics.Process explorer = new System.Diagnostics.Process();
            explorer.StartInfo.FileName = process;
            explorer.StartInfo.Arguments = arguments;
            explorer.Start();
        }
    }
}

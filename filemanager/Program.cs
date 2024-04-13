namespace filemanager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Manager());
            Console.WriteLine("test");
        }
    }
}
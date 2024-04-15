namespace filemanager
{
    public class AppSettings
    {
        public bool DeleteAfterUnzip { get; set; }
        public AppSettings()
        {
            DeleteAfterUnzip = false;
        }
    }
}

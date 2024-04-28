namespace filemanager
{
    public class AppSettings
    {
        public bool DeleteAfterUnzip { get; set; }
        public string SelectedIconPack { get; set; }
        public AppSettings()
        {
            DeleteAfterUnzip = false;
            SelectedIconPack = "none";
        }
    }
}

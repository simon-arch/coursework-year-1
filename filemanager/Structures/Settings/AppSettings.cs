namespace filemanager
{
    public class AppSettings
    {
        public bool VerticalMode { get; set; }
        public bool DeleteAfterUnzip { get; set; }
        public string SelectedIconPack { get; set; }
        public AppSettings()
        {
            VerticalMode = false;
            DeleteAfterUnzip = false;
            SelectedIconPack = "none";
        }
    }
}

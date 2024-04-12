namespace filemanager
{
    public enum Category
    {
        start,
        navigation,
        interaction,
        end
    }
    public class LoggerHandler
    {
        public RichTextBox rtb { get; set; }
        public bool showNavigation { get; set; }
        public bool showInteraction { get; set; }
        public LoggerHandler() 
        {
            showNavigation = true;
            showInteraction = true;
        }
        public void Log(Category category, params string[] logdata)
        {
            rtb.AppendText($" [{DateTime.Now}] <{category}> ");
            switch (category)
            {
                case Category.start:
                    rtb.AppendText($"Logging started...");
                break;

                case Category.navigation: 
                    if(showNavigation) rtb.AppendText($"Moving from {logdata[0]} to {logdata[1]}");
                break;

                case Category.interaction:
                    if (showInteraction) rtb.AppendText($"Interacting with ({logdata[0]}:{logdata[1]}) {logdata[2]}{logdata[3]}");
                break;

                case Category.end:
                    rtb.AppendText($"Logging ended...\n");
                break;
            }
            rtb.AppendText($"\n");
        }
    }
}

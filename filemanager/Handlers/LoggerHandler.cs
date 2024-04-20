using System.IO;

namespace filemanager
{
    public enum LogCategory
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
        public void Log(LogCategory category, params string[] logdata)
        {
            rtb.AppendText($" [{DateTime.Now}] <{category}> ");
            switch (category)
            {
                case LogCategory.start:
                    rtb.AppendText($"Logging started...");
                break;

                case LogCategory.navigation: 
                    if(showNavigation) rtb.AppendText($"Moving from {logdata[0]} to {logdata[1]}");
                break;

                case LogCategory.interaction:
                    if (showInteraction) rtb.AppendText($"Interacting with ({logdata[0]}:{logdata[1]}) {logdata[2]}{logdata[3]}");
                break;

                case LogCategory.end:
                    rtb.AppendText($"Logging ended...\n");
                    string logpath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"log.txt");
                    using (var file = new StreamWriter(logpath, true)) file.WriteLine(rtb.Text);
                    break;
            }
            rtb.AppendText($"\n");
        }
    }
}

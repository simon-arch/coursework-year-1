namespace filemanager
{
    public class NotificationHandler
    {
        public static void invokeError(int type)
        {
            switch(type)
            {
                case 1:
                    MessageBox.Show("Source path equals target path!");
                break;

                case 2:
                    MessageBox.Show("Can't delete main tab!");
                break;

                default:
                    MessageBox.Show("Unknown error.");
                break;
            }
        }
    }
}

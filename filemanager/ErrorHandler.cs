namespace filemanager
{
    public class ErrorHandler
    {
        public void invokeError(int type)
        {
            switch(type)
            {
                case 1:
                    MessageBox.Show("Source path equals target path!");
                break;

                default:
                    MessageBox.Show("Unknown error.");
                break;
            }
        }
    }
}

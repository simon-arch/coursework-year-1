namespace filemanager
{
    public class NotificationHandler
    {
        public static void invokeError(int type)
        {
            switch(type)
            {
                case 1:
                    MessageBox.Show("Wrong path!", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;

                case 2:
                    MessageBox.Show("Can't delete main tab!", "Tab Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;

                case 3:
                    MessageBox.Show("Path does not exist!", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;

                case 4:
                    MessageBox.Show("Error while zipping files!", "Zip Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;

                default:
                    MessageBox.Show("Unknown error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;
            }
        }
    }
}

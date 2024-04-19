namespace filemanager
{
    public enum ErrorType
    {
        wrongPathError,
        tabDeletionError,
        noPathError,
        zipError,
        unzipError,
        noObject
    }
    public class NotificationHandler
    {
        public static void invokeError(ErrorType type, params string[] data)
        {
            switch (type)
            {
                case ErrorType.wrongPathError:
                    MessageBox.Show("Wrong path!", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case ErrorType.tabDeletionError:
                    MessageBox.Show("Can't delete main tab!", "Tab Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case ErrorType.noPathError:
                    MessageBox.Show("Path does not exist!", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case ErrorType.zipError:
                    MessageBox.Show("Error while zipping files!", "Zip Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case ErrorType.unzipError:
                    MessageBox.Show("Error while unzipping files!", "Unzip Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case ErrorType.noObject:
                    MessageBox.Show($"Selected {data[0]} '{data[1]}' does not exist!", "Object Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                default:
                    MessageBox.Show("Unknown error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}

namespace filemanager
{
    public partial class Manager
    {
        private void InitializeHandlers(DisplayHandler displayHandler, ListView listView, TabControl tabControl, ComboBox comboBox, Label label1, Label label2, PictureBox pictureBox, ImageList imageList, ProgressBar progressBar, TabControl tabControl2, TextBox textBox)
        {
            displayHandler.ListView = listView;
            displayHandler.TabControl = tabControl;
            displayHandler.ComboBox = comboBox;
            displayHandler.Label = label1;
            displayHandler.UsedStorage = label2;
            displayHandler.PictureBox = pictureBox;
            displayHandler.ImageList = imageList;
            displayHandler.ProgressBar = progressBar;
            displayHandler.PreviewBox = tabControl2;
            displayHandler.TextBox = textBox;

            DoubleBuffering.SetDoubleBuffering(displayHandler.ListView, true);
            displayHandler.setView(1);
        }
    }
}
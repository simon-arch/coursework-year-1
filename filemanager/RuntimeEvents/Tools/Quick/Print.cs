namespace filemanager
{
    public partial class Manager
    {
        public void Print(DisplayHandler displayHandler)
        {
            if (displayHandler.Focused && displayHandler.isSelected())
            {
                Element printfile = displayHandler.ListView.SelectedItems[0].ETag();
                if (printfile.SubType == "documentfile")
                {
                    using (PrintDialog printDialog = new PrintDialog())
                    {
                        if (printDialog.ShowDialog() == DialogResult.OK)
                        {
                            ((DocumentFile)printfile).PrintDocument(printfile.Path,
                                printDialog.PrinterSettings.PrinterName);
                        }
                    }
                }
            }
        }
    }
}

namespace filemanager
{
    public partial class Manager
    {
        public void CalculateSpace(DisplayHandler displayHandler)
        {
            if (displayHandler.Focused && displayHandler.isSelected())
            {
                long totalSize = 0;
                int totalFiles = 0;
                int totalDirectories = 0;
                foreach (ListViewItem elem in displayHandler.ListView.SelectedItems)
                {
                    if (elem.ETag().Type == "file")
                    {
                        totalSize += ((File)elem.ETag()).GetSize();
                        totalFiles++;
                    }
                    else if (elem.ETag().Type == "directory")
                    {
                        if (((Directory)elem.ETag()).IgnoreListing == false)
                        {
                            totalSize += ((Directory)elem.ETag()).GetSize();
                            totalDirectories += 1 + System.IO.Directory.GetDirectories(((Directory)elem.ETag()).Path, "*", SearchOption.AllDirectories).Length;
                            totalFiles += System.IO.Directory.GetFiles(((Directory)elem.ETag()).Path, "*", SearchOption.AllDirectories).Length;
                        }
                    }
                }
                DriveInfo driveInfo = new DriveInfo(displayHandler.ComboBox.Text); // REWORK LATER / ADD RECURSIVE LAG CHECK
                long totalSpace = driveInfo.TotalSize;
                long usedSpace = driveInfo.TotalFreeSpace;
                MessageBox.Show($"Total space occupied:\n {totalSize:n0} bytes in {totalFiles:n0} file(s)," +
                    $"\n in {totalDirectories} directories\n\n{driveInfo.Name} : {usedSpace / 1000:n0} k of {totalSpace / 1000:n0} k free", "File Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

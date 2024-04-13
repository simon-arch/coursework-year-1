﻿namespace filemanager
{
    public partial class Manager
    {
        private void Refresh(DisplayHandler displayHandler, DirectoryHandler directoryHandler)
        {
            directoryHandler.PopulateDirectory();
            displayHandler.populateDrives();

            displayHandler.populateList();
            displayHandler.getFileInfo();

            displayHandler.SelectDrive();
            displayHandler.StorageSize();
            displayHandler.Preview("clear");
        }
    }
}
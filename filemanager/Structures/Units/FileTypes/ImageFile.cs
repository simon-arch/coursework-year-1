﻿using System.Diagnostics;

namespace filemanager
{
    public class ImageFile : File
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ImageFile() { 
            SubType = "imagefile";
            Type = ElementType.File;
        }
        public override void Edit()
        {
            Process.Start("mspaint.exe", Path);
        }
    }
}

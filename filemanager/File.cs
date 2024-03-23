﻿namespace filemanager
{
    public class File : Element
    {
        protected string name = string.Empty;
        protected string size = string.Empty;
        protected string path = string.Empty;
        protected string extension = string.Empty;
        public string Name { 
            get { return name; } 
            set { name = value; }
        }
        public string Size { 
            get { return size; } 
            set { size = value; }
        }
        public string Path { 
            get { return path; } 
            set { path = value; }
        }
        public string Extension { 
            get { return extension; } 
            set { extension = value; }
        }

        public File(string name, string path, string size, string extension)
        {
            Name = name;
            Path = path;
            Size = size;
            Extension = extension;
        }
        public override void delete()
        {
            System.IO.File.Delete(path);
        }
    }
}

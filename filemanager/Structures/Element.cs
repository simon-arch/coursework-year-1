﻿using System.Diagnostics;
using System.Reflection;

namespace filemanager
{
    public abstract class Element
    {
        public int IconIndex { get; protected set; }
        public bool IgnoreListing { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public string CreationDate { get; set; }
        public virtual void Delete() { }
        public virtual void Edit() { }
        public virtual long GetSize() { return 0; }
        public virtual void Rename(string newname) {
            if (newname != "" && newname != (Name))
            {
                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    newname = newname.Replace(c, '_');
                }
                string oldpath = Path;
                string newpath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Path), newname + Extension);
                try
                {
                    System.IO.Directory.Move(oldpath, newpath);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

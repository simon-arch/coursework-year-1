namespace filemanager
{
    public abstract class Element
    {
        public bool IgnoreListing { get; set; }
        public string Attributes { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public string CreationDate { get; set; }
        public virtual void Delete() { }
        public virtual void Edit() { }
        public virtual long GetSize() { return 0; }
        public virtual void Rename(string newname, bool useExtension, bool ignoreError) {
            if (newname != "" && newname != (Name))
            {
                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    newname = newname.Replace(c, '_');
                }
                string oldpath = Path;
                string newpath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Path), newname);

                if (useExtension) newpath += Extension;
                try { System.IO.Directory.Move(oldpath, newpath); }
                catch(Exception ex) { if(!ignoreError) MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}

namespace filemanager
{
    public class Directory : Element
    {
        public bool IsHidden { get; set; }
        public Directory(string name, string path)
        {
            Name = name;
            Path = path;
            IconIndex = 1;
            IsHidden = false;
            Type = "directory";
            IgnoreListing = false;
        }
        public static void CreatePrompt(string path)
        {
            DialogBox dialog = new DialogBox("Folder creation", "Folder name:", "Create", "Cancel");

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string dirname = dialog.ReturnValue;
                dialog.Dispose();

                if (dirname == "") {
                    dirname = "New Folder";
                }

                string newname = dirname;

                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    newname = newname.Replace(c, '_');
                }

                for (int i = 1; System.IO.Directory.Exists(path + @"/" + newname); i++)
                {
                    newname = string.Format("{0}({1})", dirname, i);
                }

                System.IO.Directory.CreateDirectory(path + @"/" + newname);
            } 
            else
            {
                dialog.Dispose();
                return;
            }
        }
        public override void Delete()
        {
            System.IO.Directory.Delete(Path, true);
        }
        public override long GetSize()
        {
            return System.IO.Directory.GetFiles(Path, "*", new EnumerationOptions { RecurseSubdirectories = true, IgnoreInaccessible = true }).Sum(t => (new FileInfo(t).Length)); ;
        }
    }
}

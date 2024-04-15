namespace filemanager
{
    public class ExchangeBuffer
    {
        public Queue<Element> SourceItems { get; set; }
        public List<Element> Buffer { get; set; }
        public bool Cut { get; set; }
        public ExchangeBuffer() { 
            SourceItems = new Queue<Element>();
            Cut = false;
        }
        public void Copy(ListView.SelectedListViewItemCollection listitems)
        {
            if (listitems.Count > 0)
            {
                Clear();
                System.Collections.Specialized.StringCollection paths = new System.Collections.Specialized.StringCollection();
                for (int i = 0; i < listitems.Count; i++)
                {
                    if(listitems[i].ETag().IgnoreListing == false)
                    {
                        SourceItems.Enqueue(listitems[i].ETag());
                        paths.Add(listitems[i].ETag().Path);
                    }
                }
                Clipboard.SetFileDropList(paths);
            }
        }
        public void Paste(string targetPath) 
        {
            foreach (Element sourceItem in SourceItems)
            {
                if (sourceItem.Type == "file") ///// MOVE SYSTEM.IO METHODS TO CLASS METHODS (FILE.MOVE, FILE.COPY, etc ...)
                {
                    try
                    {
                        if (Cut)
                        {
                            System.IO.File.Move(sourceItem.Path, Path.Combine(targetPath, sourceItem.Name + sourceItem.Extension));
                        }
                        else
                        {
                            string targetname = RecurringNames.GetExistingFileName(Path.Combine(targetPath, sourceItem.Name), sourceItem.Extension);
                            System.IO.File.Copy(sourceItem.Path, targetname);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                else if (sourceItem.Type == "directory")
                {
                    try
                    {
                        if (Cut)
                        {
                            System.IO.Directory.Move(sourceItem.Path, Path.Combine(targetPath, sourceItem.Name));
                        }
                        else
                        {
                            string targetname = RecurringNames.GetExistingDirectoryName(Path.Combine(targetPath, sourceItem.Name));
                            if (!targetPath.Contains(sourceItem.Path))
                            {
                                System.IO.Directory.CreateDirectory(targetname);
                                CopyFilesRecursively(sourceItem.Path, targetname);
                            }
                            else
                            {
                                throw new InvalidOperationException();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }
        }
        public void Clear()
        {
            SourceItems.Clear();
        }
        private static void CopyFilesRecursively(string source, string target)
        {
            foreach (string dir in System.IO.Directory.GetDirectories(source))
            {
                string newpath = Path.Combine(target, Path.GetFileName(dir));
                System.IO.Directory.CreateDirectory(newpath);
                CopyFilesRecursively(dir, newpath);
            }
            foreach (string file in System.IO.Directory.GetFiles(source))
            {
                System.IO.File.Copy(file, Path.Combine(target, Path.GetFileName(file)));
            }
        }
    }
}

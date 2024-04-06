﻿namespace filemanager
{
    public class ExchangeBuffer
    {
        public Queue<Element> SourceItems { get; set; }
        public List<Element> Buffer { get; set; }
        public bool Cut { get; set; }
        public ExchangeBuffer() { 
            SourceItems = new Queue<Element>();
        }
        public void Copy(ListView.SelectedListViewItemCollection listitems)
        {
            if (listitems.Count > 0)
            {
                Clear();
                for (int i = 0; i < listitems.Count; i++)
                {
                    SourceItems.Enqueue(((Element)listitems[i].Tag));
                }
            }
        }
        public void Paste(string targetPath) 
        {
            foreach (Element sourceItem in SourceItems)
            {
                if (sourceItem.GetType().BaseType!.Name.Equals("File")) ///// MOVE SYSTEM.IO METHODS TO CLASS METHODS (FILE.MOVE, FILE.COPY, etc ...)
                {
                    try
                    {
                        if (Cut)
                        {
                            System.IO.File.Move(sourceItem.Path, Path.Combine(targetPath, sourceItem.Name + sourceItem.Extension));
                        }
                        else
                        {
                            System.IO.File.Copy(sourceItem.Path, Path.Combine(targetPath, sourceItem.Name + sourceItem.Extension));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        break;
                    }
                }
                else if (sourceItem.GetType().Name.Equals("Directory"))
                {
                    try
                    {
                        if (Cut)
                        {
                            System.IO.Directory.Move(sourceItem.Path, Path.Combine(targetPath, sourceItem.Name));
                        }
                        else
                        {
                            if (!targetPath.Contains(sourceItem.Path))
                            {
                                System.IO.Directory.CreateDirectory(Path.Combine(targetPath, sourceItem.Name));
                                CopyFilesRecursively(sourceItem.Path, Path.Combine(targetPath, sourceItem.Name));
                            }
                            else
                            {
                                throw new InvalidOperationException();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        break;
                    }
                }
            }
        }
        public void Clear()
        {
            SourceItems.Clear();
        }
        public static void CopyFilesRecursively(string source, string target)
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

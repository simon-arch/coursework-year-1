namespace filemanager
{
    public class ExchangeBuffer
    {
        public Queue<Element> Buffer { get; set; } = new Queue<Element>();
        public bool Cut { get; set; } = false;
        public void ClearBuffer()
        {
            Buffer.Clear();
        }

        public void Copy(ListView.SelectedListViewItemCollection BufferItems)
        {
            if (BufferItems.Count <= 0) return;

            ClearBuffer();
            var copiedPaths = new System.Collections.Specialized.StringCollection();

            foreach (ListViewItem bufferItem in BufferItems)
            {
                var element = bufferItem.ETag();
                if (!element.IgnoreListing)
                {
                    Buffer.Enqueue(element);
                    copiedPaths.Add(element.Path);
                }
            }

            if (copiedPaths.Count > 0)
                Clipboard.SetFileDropList(copiedPaths);
        }

        public void Paste(string targetPath)
        {
            try 
            {
                foreach (Element element in Buffer)
                {
                    switch (element.Type)
                    {
                        case Element.ElementType.File:
                            HandleFilePaste(element, targetPath);
                            break;

                        case Element.ElementType.Directory:
                            HandleDirectoryPaste(element, targetPath);
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void HandleFilePaste(Element sourceItem, string targetPath)
        {
            string targetFullName = Path.Combine(targetPath, sourceItem.Name + sourceItem.Extension);

            if (Cut)
            {
                MoveFile(sourceItem, targetFullName);
            }
            else
            {
                CopyFile(sourceItem, targetFullName);
            }
        }

        private void HandleDirectoryPaste(Element sourceItem, string targetPath)
        {
            string targetFullName = Path.Combine(targetPath, sourceItem.Name);

            if (Cut)
            {
                MoveDirectory(sourceItem.Path, targetFullName);
            }
            else
            {
                CopyDirectory(sourceItem.Path, targetFullName);
            }
        }

        private void MoveDirectory(string sourcePath, string targetPath)
        {
            System.IO.Directory.Move(sourcePath, targetPath);
        }

        private bool CanCopyDirectory(string sourcePath, string targetPath)
        {
            return !targetPath.Contains(sourcePath);
        }

        private void CopyDirectory(string sourcePath, string targetPath)
        {
            targetPath = RecurringNames.GetUniqueNameForExistingDirectory(targetPath);
            if (CanCopyDirectory(sourcePath, targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
                CopyFilesRecursively(sourcePath, targetPath);
            }
            else
            {
                throw new InvalidOperationException("Cannot copy directory inside itself.");
            }
        }

        private void MoveFile(Element file, string targetPath)
        {
            System.IO.File.Move(file.Path, targetPath);
        }

        private void CopyFile(Element file, string targetPath)
        {
            string targetFullName = RecurringNames.GetUniqueNameForExistingFile(Path.Combine(targetPath, file.Name), file.Extension);
            System.IO.File.Copy(file.Path, targetFullName);
        }

        private void ShowError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Buffer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            foreach (string directory in System.IO.Directory.GetDirectories(sourcePath))
            {
                string targetFullPath = Path.Combine(targetPath, Path.GetFileName(directory));
                System.IO.Directory.CreateDirectory(targetFullPath);
                CopyFilesRecursively(directory, targetFullPath);
            }

            foreach (string file in System.IO.Directory.GetFiles(sourcePath))
            {
                string targetFile = Path.Combine(targetPath, Path.GetFileName(file));
                System.IO.File.Copy(file, targetFile);
            }
        }
    }
}
namespace filemanager
{
    public class ExchangeBuffer
    {
        public List<Element> Buffer { get; set; }
        public ExchangeBuffer() {
            Buffer = new List<Element>();
        }
        public void Add(Element element)
        {
            Buffer.Add(element);
        }
        public void Copy(ListView.SelectedListViewItemCollection listitems)
        {
            if (listitems.Count > 0)
            {
                Clear();
                for (int i = 0; i < listitems.Count; i++)
                {
                    Add((Element)listitems[i].Tag);
                }
            }
        }
        public void Paste(string newPath) 
        {
            string pathBuffer = newPath;
            foreach (Element element in Buffer)
            {
                if (element.GetType().BaseType!.Name.Equals("File"))
                {
                    newPath = Path.Combine(newPath, $"{element.Name}{element.Extension}");
                    if (Buffer[0].Path != newPath)
                    {
                        System.IO.File.Copy(element.Path, newPath, true);
                        newPath = pathBuffer;
                    }
                    else
                    {
                        NotificationHandler.invokeError(1);
                        break;
                    }
                }

                //if (element.GetType().Name.Equals("Directory"))
                //{
                //    //
                //}
            }
        }
        public void Clear()
        {
            Buffer.Clear();
        }
    }
}

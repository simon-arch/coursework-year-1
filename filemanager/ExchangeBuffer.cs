namespace filemanager
{
    public class ExchangeBuffer
    {
        public List<Element> Buffer { get; set; }
        public ExchangeBuffer() {
            Buffer = new List<Element>();
        }
        public void Copy(Element element)
        {
            Buffer.Add(element);
        }
        public void Paste(string newPath) 
        {
            foreach (Element element in Buffer)
            {
                if (element.GetType().BaseType!.Name.Equals("File"))
                {
                    System.IO.File.Copy(element.Path, Path.Combine(newPath, $"{element.Name}{element.Extension}"), true);
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

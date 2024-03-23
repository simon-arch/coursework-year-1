namespace filemanager
{
    public class ExchangeBuffer
    {
        protected List<Element> buffer = new List<Element>();
        public List<Element> Buffer
        {
            get { return buffer; }
            set { buffer = value; }
        }
        public void Copy(Element element)
        {
            buffer.Add(element);
        }
        public void Paste(string newPath) 
        {
            foreach (Element element in buffer) 
            {
                if (element.GetType().Name.Equals("File"))
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
            buffer.Clear();
        }
    }
}

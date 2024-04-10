namespace filemanager
{
    public static class ETagExtension
    {
        public static Element ETag(this ListViewItem item)
        {
            return (Element)item.Tag;
        }
    }
}

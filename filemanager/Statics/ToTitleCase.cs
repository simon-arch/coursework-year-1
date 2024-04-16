using System.Globalization;

namespace filemanager
{
    public static class ToTitleCase
    {
        public static string CaseString(this string title)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
        }
    }
}

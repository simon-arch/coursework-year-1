namespace filemanager
{
    public static class RecurringNames
    {
        public static string GetUniqueNameForExistingDirectory(string targetname)
        {
            int c = 1;
            string modname = targetname;
            while (Path.Exists($"{modname}")) 
            { 
                modname = $"{targetname}({c})"; 
                c++; 
            }
            return modname;
        }
        public static string GetUniqueNameForExistingFile(string targetname, string extension)
        {
            int c = 1;
            string modname = targetname;
            while (Path.Exists($"{modname + extension}"))
            {
                modname = $"{targetname}({c})";
                c++;
            }
            return modname + extension;
        }
    }
}

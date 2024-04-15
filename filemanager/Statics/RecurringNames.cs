namespace filemanager
{
    public static class RecurringNames
    {
        public static string GetExistingDirectoryName(string targetname)
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
        public static string GetExistingFileName(string targetname, string extension)
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

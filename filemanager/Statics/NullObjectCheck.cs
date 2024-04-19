namespace filemanager
{
    public static class NullObjectCheck
    {
        public static bool IsNull(Element obj)
        {
            if (!Path.Exists(obj.Path) && obj.Type != "utility")
            {
                NotificationHandler.invokeError(ErrorType.noObject, obj.Type, obj.Name);
                return true;
            }
            return false;
        }
    }
}
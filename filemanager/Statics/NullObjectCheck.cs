namespace filemanager
{
    public static class NullObjectCheck
    {
        public static bool IsNull(Element obj)
        {
            if (!Path.Exists(obj.Path) && obj.Type != Element.ElementType.Utility)
            {
                NotificationHandler.invokeError(ErrorType.noObject, obj.Type.ToString(), obj.Name);
                return true;
            }
            return false;
        }
    }
}
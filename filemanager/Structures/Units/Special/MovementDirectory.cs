namespace filemanager
{
    public class MovementDirectory : Element
    {
        public MovementDirectory() 
        {
            Type = "utility";
            IgnoreListing = true;
        }
        public override void Delete() { }
        public override void Edit() { }
        public override void Rename(string newname, bool useExtension, bool errorIgnore) { }
        public override long GetSize() { return 0; }
    }
}

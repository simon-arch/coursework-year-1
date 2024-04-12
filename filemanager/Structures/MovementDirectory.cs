namespace filemanager
{
    public class MovementDirectory : Element
    {
        public MovementDirectory() 
        {
            Type = "utility";
        }
        public override void Delete() { }
        public override void Edit() { }
        public override void Rename(string newname) { }
        public override long GetSize() { return 0; }
    }
}

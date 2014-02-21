namespace Features
{
    public abstract class Magic
    {
        public string Name { get;  protected set; }
        public string Description { get; protected set; }
        public string Hero { get; protected set; }
        public int ManaCost { get; protected set; }
        public int CooldownTime { get; protected set; }


        public Magic()
        {
        }
    }
}

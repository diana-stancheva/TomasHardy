namespace Dota
{
    public abstract class Magic
    {
        public Magic()
        {

        }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Hero { get; protected set; }
        public int ManaCost { get; protected set; }
        public int CooldownTime { get; protected set; }
        public int Damage { get; protected set; }

        public abstract void Use(Hero hero, Creep creep);
    }
}
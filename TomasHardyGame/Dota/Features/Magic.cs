namespace Dota.Features
{
    public abstract class Magic : Features
    {
        public int ManaCost { get; protected set; }
        public int CooldownTime { get; protected set; }
        public int Damage { get; protected set; }
        
        public Magic()
            :base()
        {

        }

        public abstract void Use(Hero hero, Creep creep);
    }
}
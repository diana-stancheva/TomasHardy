namespace Dota
{
    using System;

    class Earthshock : Magic
    {
        private static Earthshock instance = null;
        private static object syncRoot = new Object();

        public static Earthshock Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Earthshock();
                    }
                    return instance;
                }
            }
        }

        private Earthshock()
            :base()
        {
            this.Name = "Earthshock";
            this.Description = "Ursa slams the earth, causing a powerful shock to damage all enemy units in a nearby area.";  // BIG RANGE
            this.ManaCost = 120;
            this.CooldownTime = 40;
            this.Damage = 90;
        }

        public override void Use(Hero hero, Creep creep)
        {
            //hero.Color = ConsoleColor.Magenta;
            if (hero.Mana >= this.ManaCost)
            {
                hero.Mana -= this.ManaCost;
                creep.Health -= this.Damage;
            }
        }
    }
}

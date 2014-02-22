namespace Dota
{
    using System;

    class Earthshock : Magic, IEnchantable
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
            this.Description = "Ursa slams the earth, causing a powerful shock to damage and slow all enemy units in a nearby area for 4 seconds.";
            this.ManaCost = 75;
            this.CooldownTime = 6;
        }

        public void Use(Hero hero)
        {
            //hero.Color = ConsoleColor.Magenta;

            //if (hero.Mana >= 100)
            //{
            //    hero.Mana -= this.ManaCost; 
            //    hero.Damage -= 100;
            //}
        }
    }
}

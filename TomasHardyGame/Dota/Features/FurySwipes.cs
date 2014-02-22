namespace Dota.Features
{
    using System;

    class FurySwipes : Magic
    {
        private static FurySwipes instance = null;
        private static object syncRoot = new Object();

        public static FurySwipes Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new FurySwipes();
                    }
                    return instance;
                }
            }
        }

        private FurySwipes()
            :base()
        {
            this.Name = "Fury Swipes";
            this.Description = "Ursa's claws dig deeper wounds in the enemy, causing consecutive attacks to the same enemy to deal more damage.";
            this.ManaCost = 35;
            this.CooldownTime = 5;
        }

        public override void Use(Hero hero)
        {
            hero.Color = ConsoleColor.Magenta;            

            //if (hero.Mana >= 100)
            //{
            //    hero.Mana -= this.ManaCost; 
            //    hero.Damage -= 100;
            //}
        }
    }
}

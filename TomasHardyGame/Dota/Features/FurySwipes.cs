namespace Dota.Features
{
    using System;

    public class FurySwipes : Magic
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
            : base()
        {
            this.Name = "Fury Swipes";
            this.Description = "Hero's claws dig deeper wounds in the enemy, causing consecutive attacks to the same enemy, after each hit, hero makes 35 more damage.";
            this.ManaCost = 35;
            this.CooldownTime = 155;
            this.Damage = 15;
        }

        public override void Use(Hero hero, Creep creep)
        {
            if (hero.Mana >= this.ManaCost)
            {
                hero.Mana -= this.ManaCost;
                creep.Health -= this.Damage;
                this.Damage += 35;
            }
        }
    }
}
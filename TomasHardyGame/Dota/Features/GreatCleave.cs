namespace Dota.Features
{
    using System;

    public class GreatCleave : Magic
    {
        private static GreatCleave instance = null;
        private static object syncRoot = new Object();

        public static GreatCleave Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new GreatCleave();
                    }

                    return instance;
                }
            }
        }

        private GreatCleave()
            : base()
        {
            this.Name = "Great Cleave";
            this.Description = "Sven strikes with great force, cleaving the enemy unit with his attack.";
            this.ManaCost = 80;
            this.CooldownTime = 35;
            this.Damage = 20;
        }

        public override void Use(Hero hero, Creep creep)
        {
            if (hero.Mana >= this.ManaCost)
            {
                hero.Mana -= this.ManaCost;
                creep.Health -= this.Damage;
            }
        }
    }
}
namespace Dota.Features
{
    using System;

    public class WraithfireBlast : Magic
    {
        private static WraithfireBlast instance = null;
        private static object syncRoot = new Object();

        public static WraithfireBlast Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new WraithfireBlast();
                    }

                    return instance;
                }
            }
        }

        private WraithfireBlast()
            : base()
        {
            this.Name = "Wraithfire Blast";
            this.Description = "Wraith King sears an enemy unit with spectral fire, dealing damage.";
            this.ManaCost = 140;
            this.CooldownTime = 8;
            this.Damage = 50;

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
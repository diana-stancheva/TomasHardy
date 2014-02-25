namespace Dota.Features
{
    using System;

    public class Impale : Magic
    {
        private static Impale instance = null;
        private static object syncRoot = new Object();

        public static Impale Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Impale();
                    }

                    return instance;
                }
            }
        }

        private Impale()
            : base()
        {
            this.Name = "Impale";
            this.Description = "Rock spikes burst from the earth along a straight path and enemy unit take damage.";
            this.ManaCost = 95;
            this.CooldownTime = 111;
            this.Damage = 80;
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
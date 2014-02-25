namespace Dota.Features
{
    using System;

    public class Bloodrage : Magic
    {
        private static Bloodrage instance = null;
        private static object syncRoot = new Object();

        public static Bloodrage Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Bloodrage();
                    }

                    return instance;
                }
            }
        }

        private Bloodrage()
            : base()
        {
            this.Name = "Bloodrage";
            this.Description = "Drives an enemy unit into a bloodthirsty rage, during which it makes attack damage and takes the same damage every second";
            this.ManaCost = 95;
            this.CooldownTime = 25;
            this.Damage = 35;
        }

        public override void Use(Hero hero, Creep creep)
        {
            if (hero.Mana >= this.ManaCost)
            {
                hero.Mana -= this.ManaCost;
                creep.Health -= this.Damage;
                hero.Health -= this.Damage;
            }
        }
    }
}
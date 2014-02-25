namespace Dota.Features
{
    using System;

    public class Overpower : Magic
    {
        private static Overpower instance = null;
        private static object syncRoot = new Object();

        public static Overpower Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Overpower();
                    }

                    return instance;
                }
            }
        }

        private Overpower()
            : base()
        {
            this.Name = "Overpower";
            this.Description = "Using his skill in combat, Hero gains increased attack speed for a set number of attacks or until the duration expires.";
            this.ManaCost = 45;
            this.CooldownTime = 10;
            this.Damage = 15;
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
namespace Dota.Features
{
    using System;

    public class BurningSpear : Magic
    {
        private static BurningSpear instance = null;
        private static object syncRoot = new Object();

        public static BurningSpear Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new BurningSpear();
                    }

                    return instance;
                }
            }
        }

        private BurningSpear()
            : base()
        {
            this.Name = "Burning Spear";
            this.Description = "Huskar sets his spears aflame, dealing damage over time with his regular attack. Each attack drains some of Huskar's health.";
            this.ManaCost = 100;
            this.CooldownTime = 40;
            this.Damage = 5;
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
namespace Dota.Features
{
    using System;

    public class ThundergodWrath : Magic
    {
        private static ThundergodWrath instance = null;
        private static object syncRoot = new Object();

        public static ThundergodWrath Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new ThundergodWrath();
                    }

                    return instance;
                }
            }
        }

        private ThundergodWrath()
            : base()
        {
            this.Name = "Thundergod's Wrath";
            this.Description = "Strikes the enemy hero with a bolt of lightning, damaging it.";
            this.ManaCost = 300;
            this.CooldownTime = 150;
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
namespace Dota.Features
{
    using System;

    public class ArcLightning : Magic
    {
        private static ArcLightning instance = null;
        private static object syncRoot = new Object();

        public static ArcLightning Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new ArcLightning();
                    }

                    return instance;
                }
            }
        }

        private ArcLightning()
            : base()
        {
            this.Name = "Arc Lightning";
            this.Description = "Hurls a bolt of lightning that damages the enemy creep and Roshan.";
            this.ManaCost = 65;
            this.CooldownTime = 10;
            this.Damage = 85;
        }

        public override void Use(Hero hero, Creep creep)
        {
            if (hero.Mana >= this.ManaCost)
            {
                hero.Mana -= this.ManaCost;
                creep.Health -= this.Damage;
                // roshan.Health -= this.Damage;
            }
        }
    }
}
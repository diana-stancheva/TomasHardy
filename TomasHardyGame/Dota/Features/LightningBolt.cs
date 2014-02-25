namespace Dota.Features
{
    using System;

    public class LightningBolt : Magic
    {
        private static LightningBolt instance = null;
        private static object syncRoot = new Object();

        public static LightningBolt Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new LightningBolt();
                    }

                    return instance;
                }
            }
        }

        private LightningBolt()
            : base()
        {
            this.Name = "Lightning Bolt";
            this.Description = "Summons a bolt of lightning to strike an enemy unit, causing damage.";
            this.ManaCost = 75;
            this.CooldownTime = 6;
            this.Damage = 100;
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
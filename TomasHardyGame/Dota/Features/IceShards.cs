namespace Dota.Features
{
    using System;

    public class IceShards : Magic
    {
        private static IceShards instance = null;
        private static object syncRoot = new Object();

        public static IceShards Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new IceShards();
                    }

                    return instance;
                }
            }
        }

        private IceShards()
            : base()
        {
            this.Name = "Ice Shards";
            this.Description = "Hero compresses 5 shards of ice into a ball of frozen energy that damages the enemy that comes in contact with.";
            this.ManaCost = 100;
            this.CooldownTime = 130;
            this.Damage = 70;
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
namespace Dota
{
    using System;

    class IceShards : Magic
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
            :base()
        {
            this.Name = "Ice Shards";
            this.Description = "Tusk compresses 5 shards of ice into a ball of frozen energy that damages all enemies it comes in contact with.";
            this.ManaCost = 120;
            this.CooldownTime = 18;
        }

        public override void Use(Hero hero)
        {
            //hero.Color = ConsoleColor.Magenta;

            //if (hero.Mana >= 100)
            //{
            //    hero.Mana -= this.ManaCost; 
            //    hero.Damage -= 100;
            //}
        }
    }
}

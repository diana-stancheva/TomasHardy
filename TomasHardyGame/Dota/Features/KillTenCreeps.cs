namespace Dota
{
    using System;

    class KillTenCreeps : Bonus
    {
        private static KillTenCreeps instance = null;
        private static object syncRoot = new Object();

        public static KillTenCreeps Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new KillTenCreeps();
                    }

                    return instance;
                }
            }
        }

        public KillTenCreeps()
            : base()
        {
            this.Name = "Kill Ten Creeps";
            this.Description = "After killing ten creep, the hero can recieve this bonus dots";
            this.BonusDots = 100;
        }

        public override void GetBonus(Hero hero)
        {
            hero.Experience += this.BonusDots;
        }
    }
}

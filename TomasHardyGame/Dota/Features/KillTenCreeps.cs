namespace Dota
{
    using System;

    public class KillTenCreeps : Bonus
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
            this.Description = "After killing ten creeps, the hero can recieve bonus experience";
            this.BonusDots = 100;
        }

        public void GetBonus(Hero hero)
        {
            hero.Experience += this.BonusDots;
        }
    }
}

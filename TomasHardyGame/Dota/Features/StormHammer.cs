namespace Dota
{
    using System;

    class StormHammer : Magic
    {
        private static StormHammer instance = null;
        private static object syncRoot = new Object();

        public static StormHammer Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new StormHammer();
                    }
                    return instance;
                }
            }
        }

        private StormHammer()
            :base()
        {
            this.Name = "Storm Hammer";
            this.Description = "Sven unleashes his magical gauntlet that deals damage and stuns enemy units.";
            this.ManaCost = 140;
            this.CooldownTime = 13;
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

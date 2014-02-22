namespace Dota
{
    using System;

    class DragonTrail : Magic
    {
        private static DragonTrail instance = null;
        private static object syncRoot = new Object();


        public static DragonTrail Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new DragonTrail();
                    }
                    return instance;
                }
            }
        }

        private DragonTrail()
            :base()
        {
            this.Name = "Dragon Trail";
            this.Description = "Dragon Knight smites an enemy unit in melee range with his shield, while dealing minor damage.";
            this.ManaCost = 50;
            this.CooldownTime = 15;
        }

        public override void Use(Hero hero)
        {
            //hero.Color = ConsoleColor.Magenta;

            //if (hero.Mana >= 100)
            //{
            //    hero.Mana -= this.ManaCost; 
            //    hero.Damage -= 100;
            //    hero.Stun ???
            //}
        }
    }
}

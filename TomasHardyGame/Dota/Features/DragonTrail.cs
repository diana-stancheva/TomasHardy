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
            this.Description = "Unleashes a breath of fire on enemy units in a cone in front of Dragon Knight";
            this.ManaCost = 100;
            this.CooldownTime = 12;
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

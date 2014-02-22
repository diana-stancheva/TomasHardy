namespace Dota
{
    using System;

    class BloodBath : Magic
    {
        private static BloodBath instance = null;
        private static object syncRoot = new Object();

        public static BloodBath Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new BloodBath();
                    }
                    return instance;
                }
            }
        }

        private BloodBath()
            :base()
        {
            this.Name = "Blood Bath";
            this.Description = "Whenever the hero kills a unit, he bathes himself in the blood, regenerating his life source.";
            this.ManaCost = 0;
            this.CooldownTime = 0;
        }

        public override void Use(Hero hero)
        {
            //hero.Color = ConsoleColor.Magenta;

            //if (hero.Mana >= 80)
            //{
            //    hero.Mana -= this.ManaCost; 
            //    hero.Damage -= 100;
            //}
        }
    }
}

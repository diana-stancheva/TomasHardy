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
            this.Description = "Whenever the hero attacks a unit, he bathes that unit in blood, damaging it.";
            this.ManaCost = 80;
            this.CooldownTime =35;
        }

        public override void Use(Hero hero)
        {
            if (hero.Mana >= 80)
            {
                // hero.Color = ConsoleColor.Magenta;
                hero.Mana -= this.ManaCost;
            }
        }
    }
}

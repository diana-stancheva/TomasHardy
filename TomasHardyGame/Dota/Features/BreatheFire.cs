namespace Dota
{
    using System;

    class BreatheFire : Magic, IEnchantable
    {
        private static BreatheFire instance = null;
        private static object syncRoot = new Object();


        public static BreatheFire Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new BreatheFire();
                    }
                    return instance;
                }
            }
        }

        private BreatheFire()
            :base()
        {
            this.Name = "Breathe Fire";
            this.Description = "Unleashes a breath of fire on enemy units in a cone in front of Dragon Knight";
            this.ManaCost = 100;
            this.CooldownTime = 12;
        }

        public void Use(Hero hero)
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

namespace Dota
{
    using System;

    class BreatheFire : Magic
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
            this.ManaCost = 70;
            this.CooldownTime = 20;
            this.Damage = 90;
        }

        public override void Use(Hero hero, Creep creep)
        {
            //hero.Color = ConsoleColor.Magenta;
            if (hero.Mana >= this.ManaCost)
            {
                hero.Mana -= this.ManaCost;
                creep.Health -= this.Damage;
            }
        }
    }
}

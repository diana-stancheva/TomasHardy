namespace Dota
{
    using System;

    public class Bloodrage : Magic
    {
        private static Bloodrage instance = null;
        private static object syncRoot = new Object();


        public static Bloodrage Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Bloodrage();
                    }
                    return instance;
                }
            }
        }

        private Bloodrage()
            :base()
        {
            this.Name = "Bloodrage";
            this.Description = "Drives a unit into a bloodthirsty rage, during which it has higher attack damage, but cannot cast spells and takes damage every second";
            this.ManaCost = 100;
            this.CooldownTime = 25;
        }

        public override void Use(Hero hero)
        {
            //hero.Color = ConsoleColor.Cyan;
            //int coolDown = 0;

            //if (hero.Mana >= 80)
            //{
            //    hero.Mana -= this.ManaCost; 
            //    hero.Damage += 100;
            //    hero.Silince = true;
            //}

            //throw new NotImplementedException();
        }
    }
}

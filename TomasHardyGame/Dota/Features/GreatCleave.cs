﻿namespace Dota
{
    using System;

    class GreatCleave : Magic, IEnchantable
    {
        private static GreatCleave instance = null;
        private static object syncRoot = new Object();

        public static GreatCleave Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new GreatCleave();
                    }
                    return instance;
                }
            }
        }

        private GreatCleave()
            :base()
        {
            this.Name = "Great Cleave";
            this.Description = "Sven strikes with great force, cleaving all nearby enemy units with his attack.";
            this.ManaCost = 0;
            this.CooldownTime = 0;
        }

        public void Use(Hero hero)
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

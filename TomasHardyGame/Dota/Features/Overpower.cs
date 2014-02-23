namespace Dota
{
    using System;

    class Overpower : Magic
    {
        public DateTime startTime = DateTime.Now;
        private static Overpower instance = null;
        private static object syncRoot = new Object();

        public static Overpower Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Overpower();
                    }
                    return instance;
                }
            }
        }

        private Overpower()
            :base()
        {
            this.Name = "Overpower";
            this.Description = "Using his skill in combat, Ursa gains increased attack speed for a set number of attacks or until the duration expires.";
            this.ManaCost = 45;
            this.CooldownTime = 10;
        }

        public override void Use(Hero hero)
        {
            // hero.Color = ConsoleColor.Magenta;
            //int heroXPosition = hero.X;
            //int HeroYPosition = hero.Y;

            string filePath = "../../Map1.txt";
            var mapHandling = new MapHandling(filePath);
            mapHandling.ReadFromFile();
            char[,] map = mapHandling.MapMatrix;

            

            //if (hero.Mana >= 100)
            //{
            //    hero.Mana -= this.ManaCost; 
            //    hero.Damage -= 100;
            //}
        }
    }
}

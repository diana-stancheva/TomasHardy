using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota
{
    class ArcLightning:Magic
    {
        private static ArcLightning instance = null;
        private static object syncRoot = new Object();

        public static ArcLightning Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new ArcLightning();
                    }
                    return instance;
                }
            }
        }

        private ArcLightning()
            :base()
        {
            this.Name = "Arc Lightning";
            this.Description = "Hurls a bolt of lightning that leaps through nearby enemy units.";  
            this.ManaCost = 65;
            this.CooldownTime = 10;
            this.Damage = 85;
        }

        public override void Use(Hero hero, Creep creep)
        {
            if (hero.Mana >= this.ManaCost)
            {
                //hero.Color = ConsoleColor.Cyan;
                hero.Mana -= this.ManaCost;
                creep.Health -= this.Damage;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota.Features
{
    class BurningSpear:Magic
    {
        private static BurningSpear instance = null;
        private static object syncRoot = new Object();

        public static BurningSpear Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new BurningSpear();
                    }
                    return instance;
                }
            }
        }

        private BurningSpear()
            :base()
        {
            this.Name = "Burning Spear";
            this.Description = "Huskar sets his spears aflame, dealing damage over time with his regular attack. Multiple attacks will stack additional damage. Each attack drains some of Huskar's health.";
            this.ManaCost = 100;
            this.CooldownTime = 40;
        }
        public override void Use(Hero hero)
        {
            //throw new NotImplementedException();
        }
    }
}

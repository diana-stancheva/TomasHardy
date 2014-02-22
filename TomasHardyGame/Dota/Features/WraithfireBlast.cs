using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota.Features
{
    class WraithfireBlast:Magic
    {
        private static WraithfireBlast instance = null;
        private static object syncRoot = new Object();

        public static WraithfireBlast Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new WraithfireBlast();
                    }
                    return instance;
                }
            }
        }

        private WraithfireBlast()
            :base()
        {
            this.Name = "Wraithfire Blast";
            this.Description = "Wraith King sears an enemy unit with spectral fire, dealing damage and stunning, then dealing damage over time and slowing the target.";
            this.ManaCost = 140;
            this.CooldownTime = 8;
        }
        public override void Use(Hero hero)
        {
            //throw new NotImplementedException();
        }
    }
}

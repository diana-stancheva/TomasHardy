using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota.Features
{
    class Impale:Magic
    {
        private static Impale instance = null;
        private static object syncRoot = new Object();

        public static Impale Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Impale();
                    }
                    return instance;
                }
            }
        }

        private Impale()
            :base()
        {
            this.Name = "Impale";
            this.Description = "Rock spikes burst from the earth along a straight path. Enemy units are hurled into the air, then are stunned and take damage when they fall.";
            this.ManaCost = 95;
            this.CooldownTime = 11;
        }
        public override void Use(Hero hero)
        {
            //throw new NotImplementedException();
        }
    }
}

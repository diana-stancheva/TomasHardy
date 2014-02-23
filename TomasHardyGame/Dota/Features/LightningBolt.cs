using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota
{
    class LightningBolt:Magic
    {
        private static LightningBolt instance = null;
        private static object syncRoot = new Object();

        public static LightningBolt Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new LightningBolt();
                    }
                    return instance;
                }
            }
        }

        private LightningBolt()
            :base()
        {
            this.Name = "Lightning Bolt";
            this.Description = "Summons a bolt of lightning to strike an enemy unit, causing damage and a ministun.";
            this.ManaCost = 75;
            this.CooldownTime = 6;
        }
        public override void Use(Hero hero)
        {
            //throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota.Features
{
    class InnerVitality:Magic
    {
        private static InnerVitality instance = null;
        private static object syncRoot = new Object();

        public static InnerVitality Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new InnerVitality();
                    }
                    return instance;
                }
            }
        }

        private InnerVitality()
            :base()
        {
            this.Name = "Inner Vitality";
            this.Description = "Unlocks the regenerative power of a friendly unit, with healing based upon its primary attribute. If the target is below 40% it will heal faster. Lasts 16 seconds.";
            this.ManaCost = 170;
            this.CooldownTime = 25;
        }
        public override void Use(Hero hero)
        {
            //throw new NotImplementedException();
        }
    }
}

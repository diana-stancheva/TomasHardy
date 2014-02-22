using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota.Features
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
        }

        public override void Use(Hero hero)
        {
            //throw new NotImplementedException();      // malko damage
        }
    }
}

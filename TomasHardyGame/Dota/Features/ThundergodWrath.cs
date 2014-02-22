using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota.Features
{
    class ThundergodWrath:Magic
    {
        private static ThundergodWrath instance = null;
        private static object syncRoot = new Object();

        public static ThundergodWrath Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new ThundergodWrath();
                    }
                    return instance;
                }
            }
        }

        private ThundergodWrath()
            :base()
        {
            this.Name = "Thundergod's Wrath";
            this.Description = "Strikes all enemy heroes with a bolt of lightning, no matter where they may be.";
            this.ManaCost = 225;
            this.CooldownTime = 120;
        }
        public override void Use(Hero hero)
        {
            ///throw new NotImplementedException();
        }
    }
}

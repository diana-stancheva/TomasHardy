using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota.Features
{
    class BattleTrance:Magic
    {
        private static BattleTrance instance = null;
        private static object syncRoot = new Object();

        public static BattleTrance Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new BattleTrance();
                    }
                    return instance;
                }
            }
        }

        private BattleTrance()
            :base()
        {
            this.Name = "Battle Trance";
            this.Description = "Troll's presence on the battlefield increases the attack speed of himself.";
            this.ManaCost = 55;
            this.CooldownTime = 30;
        }
        public override void Use(Hero hero)
        {
            //throw new NotImplementedException();     // only movement speed
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota.Features
{
    class Vendetta:Magic
    {
        private static Vendetta instance = null;
        private static object syncRoot = new Object();

        public static Vendetta Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Vendetta();
                    }
                    return instance;
                }
            }
        }

        private Vendetta()
            :base()
        {
            this.Name = "Vendetta";
            this.Description = "Allows Nyx Assassin to become invisible and gain a speed bonus.";
            this.ManaCost = 160;
            this.CooldownTime = 70;
        }
        public override void Use(Hero hero)
        {
            //throw new NotImplementedException();
        }
    }
}

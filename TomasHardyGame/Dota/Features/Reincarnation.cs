namespace Dota.Features
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Reincarnation : Magic
    {
        private static Reincarnation instance = null;
        private static object syncRoot = new Object();

        public static Reincarnation Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Reincarnation();
                    }

                    return instance;
                }
            }
        }

        private Reincarnation()
            : base()
        {
            this.Name = "Reincarnation";
            this.Description = "Wraith King shocks the enemy creep, causing repeatable damage.";
            this.ManaCost = 140;
            this.CooldownTime = 260;
            this.Damage = 75;
        }

        public override void Use(Hero hero, Creep creep)
        {
            if (hero.Mana >= this.ManaCost)
            {
                hero.Mana -= this.ManaCost;
                creep.Health -= this.Damage;
            }
        }
    }
}
namespace Dota
{
    using System;

    public class DragonTrail : Magic
    {
        private static DragonTrail instance = null;
        private static object syncRoot = new Object();

        public static DragonTrail Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new DragonTrail();
                    }

                    return instance;
                }
            }
        }

        private DragonTrail()
            : base()
        {
            this.Name = "Dragon Trail";
            this.Description = "Dragon Knight smites an enemy unit in melee range with his shield, while dealing minor damage.";
            this.ManaCost = 50;
            this.CooldownTime = 15;
            this.Damage = 25;
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
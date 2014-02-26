namespace Dota.Features
{
    using System;

    public class Vendetta : Magic
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
            : base()
        {
            this.Name = "Vendetta";
            this.Description = "Allows Nyx Assassin to gain a speed bonus.";
            this.ManaCost = 160;
            this.CooldownTime = 70;
            this.Damage = 90;
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
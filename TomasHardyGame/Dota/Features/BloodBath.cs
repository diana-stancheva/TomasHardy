namespace Dota.Features
{
    using System;

    public class BloodBath : Magic
    {
        private static BloodBath instance = null;
        private static object syncRoot = new Object();

        public static BloodBath Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new BloodBath();
                    }

                    return instance;
                }
            }
        }

        private BloodBath()
            : base()
        {
            this.Name = "Blood Bath";
            this.Description = "Whenever the hero attacks a unit, he bathes that unit in blood, damaging it.";
            this.ManaCost = 80;
            this.CooldownTime = 35;
            this.Damage = 30;
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
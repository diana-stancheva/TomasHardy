﻿namespace Dota.Features
{
    using System;

    public class StormHammer : Magic
    {
        private static StormHammer instance = null;
        private static object syncRoot = new Object();

        public static StormHammer Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new StormHammer();
                    }

                    return instance;
                }
            }
        }

        private StormHammer()
            : base()
        {
            this.Name = "Storm Hammer";
            this.Description = "Hero unleashes his magical gauntlet that deals damage on enemy unit.";
            this.ManaCost = 140;
            this.CooldownTime = 55;
            this.Damage = 100;
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
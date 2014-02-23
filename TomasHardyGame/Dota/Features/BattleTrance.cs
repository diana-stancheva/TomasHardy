﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota
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
            this.Damage = 60;
        }
        public override void Use(Hero hero, Creep creep)
        {
            if (hero.Mana >= this.ManaCost)
            {
                //hero.Color = ConsoleColor.Cyan;
                hero.Mana -= this.ManaCost;
                creep.Health -= this.Damage;
            }
        }
    }
}

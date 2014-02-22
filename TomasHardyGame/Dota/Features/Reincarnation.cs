﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota.Features
{
    class Reincarnation:Magic
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
            :base()
        {
            this.Name = "Reincarnation";
            this.Description = "Wraith King's members regroup after death, allowing him to resurrect when killed in battle.";
            this.ManaCost = 140;
            this.CooldownTime = 260;
        }
        public override void Use(Hero hero)
        {
            //throw new NotImplementedException();
        }
    }
}
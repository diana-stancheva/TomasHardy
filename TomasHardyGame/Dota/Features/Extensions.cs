using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota
{
    public static class Extensions
    {
        public static void BloodrageMagic(this Character hero){
            Bloodrage bloodrage = new Bloodrage();
            bloodrage.Use(hero);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    public class Bloodrage : Magic, IEnchantable
    {
        public Bloodrage()
            :base()
        {
            this.Name = "Blood Rage";
            this.Description = "Drives a unit into a bloodthirsty rage, during which it has higher attack damage, but cannot cast spells and takes damage every second";
            this.ManaCost = 80;
            this.CooldownTime = 12;
        }

        public void Use()
        {
            throw new NotImplementedException();
        }
    }
}

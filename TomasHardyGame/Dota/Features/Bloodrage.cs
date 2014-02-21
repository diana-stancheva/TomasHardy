namespace Dota
{
    using System;

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

        public void Use(Character hero)
        {
            hero.Color = ConsoleColor.Cyan;
            //int coolDown = 0;

            //if (hero.Mana >= 80)
            //{
            //    hero.Mana -= this.ManaCost;   

            //}

            //throw new NotImplementedException();
        }
    }
}

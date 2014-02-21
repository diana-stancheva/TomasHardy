namespace Dota
{
    using System;

    public abstract class CharacterSisiDido
    {
        private string name;
        private int health;
        private int damage;
        private bool isDead;

        public CharacterSisiDido(string name, int health, int damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name of the character must be a valid string!");
                }

                this.name = value;
            }
        }

        public int Health
        {
            get { return this.health; }

            set
            {
                if (value <= 0)
                {
                    this.IsDead = true;
                    value = 0;
                }

                this.health = value;
            }
        }

        public int Damage
        {
            get { return this.damage; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The damage must be positive!");
                }

                this.damage = value;
            }
        }

        public bool IsDead
        {
            get { return this.isDead; }
            set { this.isDead = value; }
        }

        public void Attack(CharacterSisiDido opponent)
        {
            opponent.Health -= this.damage;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}\nHealth: {1}\nDamage: {2}\n", this.name, this.health, this.damage);
        }
    }
}
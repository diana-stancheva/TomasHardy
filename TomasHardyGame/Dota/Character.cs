namespace Dota
{
    using System;

    public abstract class Character
    {
        private string name;
        private int health;
        private int damage;
        private bool isDead;
        private CharacterPosition position;

        public Character()
        {

        }

        public Character(string name, int health, int damage, CharacterPosition position)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Position = position;
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

        public CharacterPosition Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        //public void Attack(Character opponent)
        //{
        //    opponent.Health -= this.damage;
        //}
    }
}
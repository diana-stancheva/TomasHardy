﻿namespace Dota
{
    using System;

    public abstract class Character
    {
        private string name;
        private int health;
        private int damage;
        private bool isDead;
        // private string symbol;
        private ConsoleColor color;
         
        public Character(string name, int health, int damage/*, string symbol*/, ConsoleColor color)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            // this.Symbol = symbol;
            this.Color = color;
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

        //public string Symbol
        //{
        //    get { return this.symbol; }
        //    set { this.symbol = value; }
        //}

        public ConsoleColor Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        

        public void Attack(Character opponent)
        {
            opponent.Health -= this.damage;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}\nHealth: {1}\nDamage: {2}\n", this.name, this.health, this.damage);
        }
    }
}
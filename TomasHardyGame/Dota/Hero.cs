namespace Dota
{
    using System;
    using System.Collections.Generic;

    public class Hero : Character
    {
        private int mana;
        private int experience;
        private int level;
        private int attackSpeed;
        private int moveSpeed;
        private readonly int initialMana;
        private readonly int initialHealth;
        private List<Magic> magics;

        public Hero(string name, int health, int damage, int mana, int attackSpeed, int moveSpeed, 
            List<Magic> magicList, CreepPosition position = default(CreepPosition))
            : base(name, health, damage, position)
        {
            this.Mana = mana;
            this.AttackSpeed = attackSpeed;
            this.MoveSpeed = moveSpeed;
            this.Experience = 0;
            this.Level = 1;
            this.initialMana = mana;
            this.initialHealth = health;
            this.Magics = magicList;
        }

        public int Mana
        {
            get { return this.mana; }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.mana = value;
            }
        }

        public int Experience
        {
            get { return this.experience; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The experience must be positive!");
                }

                this.experience = value;

                LevelUp();
            }
        }

        public int Level
        {
            get { return this.level; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The level must be positive!");
                }

                if (value > 10)
                {
                    value = 10;
                }

                this.level = value;
            }
        }

        public int AttackSpeed
        {
            get { return this.attackSpeed; }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.attackSpeed = value;
            }
        }

        public int MoveSpeed
        {
            get { return this.moveSpeed; }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.moveSpeed = value;
            }
        }

        public int InitialMana
        {
            get { return this.initialMana; }
        }

        public int InitialHealth
        {
            get { return this.initialHealth; }
        }

        public List<Magic> Magics
        {
            get { return this.magics; }
            set { this.magics = value; }
        }

        private void LevelUp()
        {
            if (this.Experience >= 1000)
            {
                this.experience = this.experience % 1000;
                this.Level++;
            }
        }

        public void ManaAndHealthIncrease()
        {
            if (this.mana < this.initialMana)
            {
                this.mana++;
            }

            if (this.Health < this.initialHealth)
            {
                this.Health++;
            }
        }

        public void ManaAndHealthIncreaseFountain()
        {
            if (this.mana < this.initialMana - 20)
            {
                this.mana+=20;
            }

            if (this.Health < this.initialHealth - 20)
            {
                this.Health+=20;
            }
        }
    }
}
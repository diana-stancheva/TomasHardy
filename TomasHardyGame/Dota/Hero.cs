namespace Dota
{
    using System;

    public class Hero : Character
    {
        private int mana;
        private int experience;
        private int level;
        // private List<Magic> magics;

        public Hero(string name, int health, int damage, string symbol, ConsoleColor color, int x, int y, int mana)
            : base(name, health, damage, symbol, color, x, y)
        {
            this.Mana = mana;
            this.Experience = 0;
            this.Level = 1;
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

        private void LevelUp()
        {
            if (this.Experience >= 1000)
            {
                this.Experience = this.Experience % 1000;
                this.Level++;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Mana: {0}\n", this.mana);
        }
    }
}
namespace Dota
{
    using System;
    using System.Threading;

    public class Hero : Character, IMovable
    {
        private const int PlayerFieldLimitX = 78;
        private const int PlayerFieldLimitY = 47;

        private int x;
        private int y;
        private int mana;
        private int experience;
        private int level;
        private readonly int initialMana;
        private readonly int initialHealth;
        // private List<Magic> magics;

        public Hero(string name, int health, int damage, string symbol, ConsoleColor color, int x, int y, int mana)
            : base(name, health, damage, symbol, color)
        {
            this.X = x;
            this.Y = y;
            this.Mana = mana;
            this.Experience = 0;
            this.Level = 1;
            this.initialMana = mana;
            this.initialHealth = health;
        }

        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
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

        public int InitialMana
        {
            get { return this.mana; }
        }

        public int InitialHealth
        {
            get { return this.initialHealth; }
        }

        private void LevelUp()
        {
            if (this.Experience >= 1000)
            {
                this.Experience = this.Experience % 1000;
                this.Level++;
            }
        }

        public void Draw()
        {
            Console.ForegroundColor = this.Color;
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(this.Symbol);
        }

        public void ClearPath()
        {
            Console.ForegroundColor = this.Color;
            Console.SetCursorPosition(this.X, this.Y);
            Console.CursorVisible = true;
            Console.Write(' ');
        }

        public void Move(int xDelta, int yDelta)
        {
            this.ClearPath();

            if (this.X + xDelta >= 1 && this.X + xDelta < PlayerFieldLimitX)
            {
                this.X += xDelta;
            }
            if (this.Y + yDelta >= 1 && this.Y + yDelta < PlayerFieldLimitY)
            {
                this.Y += yDelta;
            }
        }

        public void ManaAndHealthIncrease()
        {
            //Thread.Sleep(1200);

            if (this.mana < this.initialMana)
            {
                this.mana++;
            }

            if (this.Health < this.initialHealth)
            {
                this.Health++;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Mana: {0}\n", this.mana);
        }
    }
}
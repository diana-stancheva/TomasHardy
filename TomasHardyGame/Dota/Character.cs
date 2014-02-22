namespace Dota
{
    using System;

    public abstract class Character : IMovable
    {
        private const int PlayerFieldLimitX = 78;
        private const int PlayerFieldLimitY = 47;

        private string name;
        private int health;
        private int damage;
        private bool isDead;
        private string symbol;
        private int x;
        private int y;
        private ConsoleColor color;
         
        public Character(string name, int health, int damage, string symbol, ConsoleColor color, int x, int y)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Symbol = symbol;
            this.Color = color;
            this.X = x;
            this.Y = y;
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

        public string Symbol
        {
            get { return this.symbol; }
            set { this.symbol = value; }
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

        public ConsoleColor Color
        {
            get { return this.color; }
            set { this.color = value; }
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
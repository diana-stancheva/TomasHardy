namespace Dota
{
    using System;

    public class Character : IMovable
    {
        private const int PlayerFieldLimitX = 78;
        private const int PlayerFieldLimitY = 47;

        public Character(string symbol, ConsoleColor color, int x, int y)
        {
            this.Symbol = symbol;
            this.Color = color;
            this.X = x;
            this.Y = y;
        }

        public string Symbol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public ConsoleColor Color { get; set; }

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
    }
}

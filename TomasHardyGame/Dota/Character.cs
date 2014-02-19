namespace Dota
{
    using System;

    public class Character : IMovable
    {
        public Character(string symbol, ConsoleColor color, int x, int y)
        {
            this.Symbol = symbol;
            this.Color = color;
            this.X = x;
            this.Y = y;
        }

        public string Symbol { get; set; }
        // public ConsoleColor color;
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
            Console.Write(" ");
        }

        public void Move(int xDelta, int yDelta)
        {
            this.ClearPath();
            this.X += xDelta;
            this.Y += yDelta;
        }
    }
}

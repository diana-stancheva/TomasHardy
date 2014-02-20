namespace Ivo
{
    using System;

    public class PlayerMovement
    {
        private const char PlayerSymbol = '@';
        private const char WhiteSpaceSymbol = ' ';
        private const char WallSymbol = '#';

        private readonly char[,] playerMap;
        private int positionOnRow;
        private int positionOnCol;

        public PlayerMovement(char[,] map)
        {
            this.playerMap = map;
        }

        public int PositionOnRow
        {
            get { return this.positionOnRow; }
            set { this.positionOnRow = value; }
        }
        public int PositionOnCol
        {
            get { return this.positionOnCol; }
            set { this.positionOnCol = value; }
        }

        public void GetPlayerStartPosition()
        {
            for (int row = 0; row < this.playerMap.GetLength(0); row++)
            {
                for (int col = 0; col < this.playerMap.GetLength(1); col++)
                {
                    if (this.playerMap[row, col].Equals(PlayerSymbol))
                    {
                        this.PositionOnRow = row;
                        this.PositionOnCol = col;
                        PrintSymbol(PlayerSymbol);
                    }
                }
            }
        }

        public void Move()
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            // To remove lag! Check if needed.
            //while (Console.KeyAvailable)
            //{
            //    Console.ReadKey();
            //}

            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                this.PrintSymbol(WhiteSpaceSymbol);
                this.MoveUp();
                this.PrintSymbol(PlayerSymbol);
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                this.PrintSymbol(WhiteSpaceSymbol);
                this.MoveDown();
                this.PrintSymbol(PlayerSymbol);
            }
            else if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                this.PrintSymbol(WhiteSpaceSymbol);
                this.MoveLeft();
                this.PrintSymbol(PlayerSymbol);
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                this.PrintSymbol(WhiteSpaceSymbol);
                this.MoveRight();
                this.PrintSymbol(PlayerSymbol);
            }
        }

        private int nextPosition = 0;

        private void MoveUp()
        {
            nextPosition = this.PositionOnRow - 1;

            if (this.playerMap[nextPosition, this.PositionOnCol] != WallSymbol)
            {
                this.PositionOnRow--;
            }
        }

        private void MoveDown()
        {
            nextPosition = this.PositionOnRow + 1;

            if (this.playerMap[nextPosition, this.PositionOnCol] != WallSymbol)
            {
                this.PositionOnRow++;
            }
        }

        private void MoveLeft()
        {
            nextPosition = this.PositionOnCol - 1;

            if (this.playerMap[this.PositionOnRow, nextPosition] != WallSymbol)
            {
                this.PositionOnCol--;
            }
        }

        private void MoveRight()
        {
            nextPosition = this.PositionOnCol + 1;

            if (this.playerMap[this.PositionOnRow, nextPosition] != WallSymbol)
            {
                this.PositionOnCol++;
            }
        }

        private void PrintSymbol(char symbol)
        {
            Console.SetCursorPosition(this.PositionOnCol, this.PositionOnRow);

            switch (symbol)
            {
                case PlayerSymbol: Console.ForegroundColor = ConsoleColor.Green; break;
                default: Console.ResetColor(); break;
            }

            Console.Write(symbol);
            Console.ResetColor();
        }
    }
}

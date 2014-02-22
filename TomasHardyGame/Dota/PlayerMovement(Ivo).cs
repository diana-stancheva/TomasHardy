namespace Dota
{
    using System;

    public class PlayerMovement
    {
        private const char PlayerSymbol = '@';
        private const char WhiteSpaceSymbol = ' ';
        private const char WoodSymbol = '#';
        private const char WallSymbolOne = '_';
        private const char WallSymbolTwo = '|';
        private const char DotSymbol = '.';
        private const char SemiColonSymbol = ':';
        private const char EnemySymbolOne = '[';
        private const char EnemySymbolTwo = 'd';
        private const char EnemySymbolThree = '*';
        private const char EnemySymbolFour = 'b';
        private const char EnemySymbolFive = ']';
        private char[] forbiddenSymbos = new char[] { WoodSymbol, WallSymbolOne, WallSymbolTwo, DotSymbol, SemiColonSymbol,
                                                      EnemySymbolOne, EnemySymbolTwo, EnemySymbolThree, EnemySymbolFour, EnemySymbolFive};

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

        private bool checkFobidden = true;

        private void MoveUp()
        {
            foreach (var item in this.forbiddenSymbos)
            {
                if (this.playerMap[this.PositionOnRow - 1, this.PositionOnCol] == item )
                {
                    this.checkFobidden = false;
                    break;
                }
            }

            if (this.checkFobidden)
            {
                this.PositionOnRow--;
            }

            // reset
            this.checkFobidden = true;
        }

        private void MoveDown()
        {
            foreach (var item in this.forbiddenSymbos)
            {
                if (this.playerMap[this.PositionOnRow + 1, this.PositionOnCol] == item)
                {
                    this.checkFobidden = false;
                    break;
                }
            }

            if (this.checkFobidden)
            {
                this.PositionOnRow++;
            }

            // reset
            this.checkFobidden = true;
        }

        private void MoveLeft()
        {
            foreach (var item in this.forbiddenSymbos)
            {
                if (this.playerMap[this.PositionOnRow, this.PositionOnCol - 1] == item)
                {
                    this.checkFobidden = false;
                    break;
                }
            }

            if (this.checkFobidden)
            {
                this.PositionOnCol--;
            }

            // reset
            this.checkFobidden = true;
        }

        private void MoveRight()
        {
            foreach (var item in this.forbiddenSymbos)
            {
                if (this.playerMap[this.PositionOnRow, this.PositionOnCol + 1] == item)
                {
                    this.checkFobidden = false;
                    break;
                }
            }

            if (this.checkFobidden)
            {
                this.PositionOnCol++;
            }

            // reset
            this.checkFobidden = true;
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

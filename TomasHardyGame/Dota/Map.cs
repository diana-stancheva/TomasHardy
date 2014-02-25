namespace Dota
{
    using System;
    using System.IO;

    public class Map : IScreen
    {
        private const int ConsoleHeight = 50;
        private const int ConsoleWidth = 110;
        private readonly string filePath;
        private char[,] mapMatrix;

        public Map(string mapPath)
        {
            this.filePath = mapPath;
        }

        public char[,] Matrix
        {
            get { return this.mapMatrix; }
            private set { this.mapMatrix = value; }
        }

        public static int MapScreenHeight
        {
            get { return ConsoleHeight; }
        }

        public static int MapScreenWidth
        {
            get { return ConsoleWidth; }
        }

        // read a map from a file
        public void ReadFromFile()
        {
            try
            {
                StreamReader reader = new StreamReader(this.filePath);

                using (reader)
                {
                    string line = reader.ReadLine();
                    string[] lineAsArray = line.Split(' ');
                    int totalRows = int.Parse(lineAsArray[0]);
                    int totalCols = int.Parse(lineAsArray[1]);
                    this.Matrix = new char[totalRows, totalCols];

                    for (int row = 0; row < totalRows; row++)
                    {
                        line = reader.ReadLine();

                        for (int col = 0; col < totalCols; col++)
                        {
                            this.Matrix[row, col] = line[col];
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileLoadException("Missing file to read from.");
            }
            catch (IOException exc)
            {
                Console.WriteLine("Error: {0}.", exc.Message);
            }
        }

        // print it on the console
        public void LoadOnScreen()
        {
            Console.BufferHeight = Console.WindowHeight = ConsoleHeight;
            Console.BufferWidth = Console.WindowWidth = ConsoleWidth;

            for (int row = 0; row < this.Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.Matrix.GetLength(1); col++)
                {
                    switch (this.Matrix[row, col])
                    {
                        case '#': Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                        case '[': Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                        case 'd': Console.ForegroundColor = ConsoleColor.Blue; break;
                        case 'b': Console.ForegroundColor = ConsoleColor.Blue; break;
                        case '*': Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                        case ']': Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                        case '-': Console.ForegroundColor = ConsoleColor.Magenta; break;
                        case '=': Console.ForegroundColor = ConsoleColor.Magenta; break;
                        case '0': Console.ForegroundColor = ConsoleColor.Green; break;
                        default: Console.ResetColor(); break;
                    }
                    Console.Write(this.Matrix[row, col]);
                }

                Console.WriteLine();
            }

            PrintOnPosition(ConsoleWidth - 25, ConsoleHeight - 11, "Creep info:", ConsoleColor.DarkCyan);

            Console.CursorVisible = false;
        }

        public static void PrintOnPosition(int x, int y, string str, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(str);
        }
    }
}
﻿namespace Dota
{
    using System;
    using System.IO;

    public class MapHandling
    {
        private const int Height = 50;
        private const int Width = 110;
        private readonly string filePath;
        private char[,] mapMatrix;
        
        public MapHandling(string mapPath)
        {
            this.filePath = mapPath;
        }

        public char[,] MapMatrix
        {
            get { return this.mapMatrix; }
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
                    this.mapMatrix = new char[totalRows, totalCols];

                    for (int row = 0; row < totalRows; row++)
                    {
                        line = reader.ReadLine();

                        for (int col = 0; col < totalCols; col++)
                        {
                            this.mapMatrix[row, col] = line[col];
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileLoadException("Missing file to read from.");
            }
        }

        // print it on the console
        public void LoadMapOnScreen()
        {
            Console.BufferHeight = Console.WindowHeight = Height;
            Console.BufferWidth = Console.WindowWidth = Width;

            for (int row = 0; row < this.mapMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.mapMatrix.GetLength(1); col++)
                {
                    switch (this.mapMatrix[row, col])
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
                    Console.Write(this.mapMatrix[row, col]);
                }

                Console.WriteLine();
            }
            Console.CursorVisible = false;
        }
    }
}
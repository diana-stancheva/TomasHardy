namespace Dota
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class File
    {
        public File(string fileName)
        {
            this.FileName = fileName;
        }
        public string FileName { get; private set; }

        public char[,] LoadMap()
        {
            using (StreamReader sr = new StreamReader(this.FileName, Encoding.UTF8.IsBrowserDisplay))
            {
                string line = sr.ReadLine();
                string[] list = line.Split(' ');
                
                List<int> listDimension = new List<int> ();
                listDimension.Add(int.Parse(list[0]));
                listDimension.Add(int.Parse(list[1]));

                char[,] matrix = new char[listDimension[0], listDimension[1]];

                line = sr.ReadLine();
                int row = 0;
                while(line != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        matrix[row, i] = line[i];
                    }

                    Console.ForegroundColor = ConsoleColor.Blue;
                    row++;
                    Console.WriteLine(line);

                    line = sr.ReadLine();
                }

                return matrix;
            }
        }
    }
}

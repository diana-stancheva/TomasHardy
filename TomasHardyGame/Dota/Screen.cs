namespace Dota
{
    using System;
    using System.IO;
    using System.Threading;

    public class Screen : IScreen
    {
        // const string FileName = @"..\..\StartScreen.txt";
        public Screen(string fileName)
        {
            this.FileName = fileName;
        }
        public string FileName { get; set; }

        public void LoadScreen()
        {
            using (StreamReader sr = new StreamReader(this.FileName))
            {
                string line = sr.ReadToEnd();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(0, 0);

                Console.WriteLine(line);

                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < 70; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write('|');
                    Thread.Sleep(50);
                }
                Console.ResetColor();
                Console.Clear();
            }
        }
    }
}

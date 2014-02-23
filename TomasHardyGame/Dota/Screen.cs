namespace Dota
{
    using System;
    using System.IO;
    using System.Threading;

    public class Screen : IScreen
    {
        const int HeightStartScreen = 20;
        const int WidthStartScreen = 70;
        const string GameTitle = "Dota v. 0.1®";

        // const string FileName = @"..\..\StartScreen.txt";
        public Screen(string fileName)
        {
            this.FileName = fileName;
        }
        public string FileName { get; set; }

        public void LoadScreen()
        {
            Console.Title = String.Format(GameTitle);

            Console.BufferHeight = Console.WindowHeight = HeightStartScreen;
            Console.BufferWidth = Console.WindowWidth = WidthStartScreen;

            using (StreamReader sr = new StreamReader(this.FileName))
            {
                string line = sr.ReadToEnd();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(0, 0);

                Console.WriteLine(line);

                Console.WriteLine("\n\n\n\n\n");

                for (int i = 0; i < 70; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write('|');
                    Thread.Sleep(5);
                }
                Console.ResetColor();
                Console.Clear();
            }
        }
    }
}

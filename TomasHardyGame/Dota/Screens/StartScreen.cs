namespace Dota.Screens
{
    using System;
    using System.IO;
    using System.Threading;

    // Singleton class!!!
    public class StartScreen : Screen, IScreen
    {
        private const int HeightStartScreen = 20;
        private const int WidthStartScreen = 70;
        private const int DelayTime = 5;
        private const string GameTitle = "Dota v. 0.1®";
        private const string FileName = @"..\..\Screens\StartScreen.txt";
        private static StartScreen instance;

        private StartScreen() { }

        public static StartScreen Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StartScreen();
                }

                return instance;
            }
        }
                
        public override void LoadOnScreen()
        {
            Console.Title = String.Format(GameTitle);

            Console.BufferHeight = Console.WindowHeight = HeightStartScreen;
            Console.BufferWidth = Console.WindowWidth = WidthStartScreen;

            using (StreamReader reader = new StreamReader(FileName))
            {
                string text = reader.ReadToEnd();
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.WriteLine(text);

                Console.WriteLine("\n\n\n\n\n");

                for (int i = 0; i < WidthStartScreen; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write('|');
                    Thread.Sleep(DelayTime);
                }

                Console.ResetColor();
                Console.Clear();
            }
        }
    }
}
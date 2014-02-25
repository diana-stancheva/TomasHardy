namespace Dota.Screens
{
    using System;

    // Singleton class!!!
    public class MapScreen : Screen
    {
        private const int ConsoleHeight = 32;
        private const int ConsoleWidth = 60;
        private string filePath;
        private static MapScreen instance;

        private MapScreen() { }

        public static MapScreen Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MapScreen();
                }

                return instance;
            }
        }

        public string FilePath
        {
            get { return this.filePath; }
            private set { this.filePath = value; }
        }

        public override void LoadOnScreen()
        {
            MapHandling.PrintOnPosition(ConsoleWidth - 38, ConsoleHeight - 29, "CHOOSE A MAP", ConsoleColor.Magenta);

            PrintMapMenu(ConsoleWidth - 37, ConsoleHeight - 23, Maps.Backalley, "<B>");
            PrintMapMenu(ConsoleWidth - 37, ConsoleHeight - 15, Maps.Iceworld, "<I>");
            PrintMapMenu(ConsoleWidth - 37, ConsoleHeight - 7, Maps.Compound, "<C>");

            Console.CursorVisible = false;
            ConsoleKeyInfo pressedKeyMap = Console.ReadKey(true);
            bool mapLetter = false;

            while (!mapLetter)
            {
                switch (pressedKeyMap.Key)
                {
                    case ConsoleKey.B:
                        this.FilePath = "../../Maps/Map2.txt";
                        mapLetter = true;
                        Console.Clear();
                        break;
                    case ConsoleKey.I:
                        this.FilePath = "../../Maps/Map1.txt";
                        mapLetter = true;
                        Console.Clear();
                        break;
                    case ConsoleKey.C:
                        this.FilePath = "../../Maps/Map3.txt";
                        mapLetter = true;
                        Console.Clear();
                        break;
                    default:
                        pressedKeyMap = Console.ReadKey(true);
                        break;
                }
            }
        }

        private static void PrintMapMenu(int x, int y, Maps mapName, string letter, ConsoleColor color = ConsoleColor.Red)
        {
            Console.BufferHeight = Console.WindowHeight = ConsoleHeight;
            Console.BufferWidth = Console.WindowWidth = ConsoleWidth;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(mapName);
            Console.SetCursorPosition(x + (mapName.ToString().Length / 2 == 0 ? mapName.ToString().Length / 2 : mapName.ToString().Length / 2 - 1), y + 1);

            //Console.SetCursorPosition(x + (mapName.Length / 2 == 0 ? mapName.Length / 2 : mapName.Length / 2 - 1), y + 1);

            Console.WriteLine(letter);
            Console.SetCursorPosition(x, y + 2);
        }
    }
}

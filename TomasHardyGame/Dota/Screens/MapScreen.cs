namespace Dota.Screens
{
    using System;

    public class MapScreen
    {
        private const int ConsoleHeight = 32;
        private const int ConsoleWidth = 60;

        public static string LoadOnScreen()
        {
            string filePath = null;

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
                        filePath = "../../Maps/Map2.txt";
                        mapLetter = true;
                        Console.Clear();
                        break;
                    case ConsoleKey.I:
                        filePath = "../../Maps/Map1.txt";
                        mapLetter = true;
                        Console.Clear();
                        break;
                    //case ConsoleKey.C:
                    //    filePath = "../../Map3.txt";
                    //    mapLetter = true;
                    //    break;
                    default:
                        pressedKeyMap = Console.ReadKey(true);
                        break;
                }
            }

            return filePath;
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

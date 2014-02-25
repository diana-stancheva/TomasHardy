namespace Dota.Screens
{
    using System;

    public class MapScreen
    {
        private const int Height = 50;
        private const int Width = 110;

        public static string LoadOnScreen()
        {
            string filePath = null;

            MapHandling.PrintOnPosition(Width - 86, Height - 47, "CHOOSE A MAP", ConsoleColor.Magenta);

            PrintMapMenu(Width - 87, Height - 41, Maps.Backalley, "<B>");
            PrintMapMenu(Width - 87, Height - 33, Maps.Iceworld, "<I>");
            PrintMapMenu(Width - 87, Height - 25, Maps.Compound, "<C>");

            //string filePath = "";
            Console.CursorVisible = false;
            ConsoleKeyInfo pressedKeyMap = Console.ReadKey(true);
            bool mapLetter = false;

            while (!mapLetter)
            {
                switch (pressedKeyMap.Key)
                {
                    case ConsoleKey.B:
                        filePath = "../../Map2.txt";
                        mapLetter = true;
                        Console.Clear();
                        break;
                    case ConsoleKey.I:
                        filePath = "../../Map1.txt";
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
            Console.BufferHeight = Console.WindowHeight = 32;
            Console.BufferWidth = Console.WindowWidth = 60;
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

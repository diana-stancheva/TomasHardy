namespace Dota
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    class Dota
    {
        const int HeightStartScreen = 20;
        const int WidthStartScreen = 70;
        const int Height = 50;
        const int Width = 110;
        const int delay = 150;
        public static char[,] arrayMapCells;

        static void ClearBuffer()
        {
            // Read keys until they finish without diplaying
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        static void StartNewGame()
        {
            Character hero = new Character("@", ConsoleColor.Green, 2, Height - 4);
            hero.Draw();

            bool isKilled = false;

            while (!isKilled)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();
                    if (keyPressed.Key == ConsoleKey.Spacebar)
                    {
                        hero.Color = ConsoleColor.Magenta;
                    }
                    else if (keyPressed.Key == ConsoleKey.LeftArrow)
                    {
                        hero.Color = ConsoleColor.Green;

                        // int left = Console.CursorLeft;
                        // int top = Console.CursorTop;
                        if (arrayMapCells[hero.Y, hero.X - 1] == '#')
                        {
                            continue;
                        }
                        else
                        {
                            hero.Move(-1, 0);
                        }
                    }
                    else if (keyPressed.Key == ConsoleKey.RightArrow)
                    {
                        hero.Color = ConsoleColor.Green;

                        if (arrayMapCells[hero.Y, hero.X + 2] == '#')
                        {
                            continue;
                        }
                        else
                        {
                            hero.Move(1, 0);
                        }
                    }
                    else if (keyPressed.Key == ConsoleKey.UpArrow)
                    {
                        hero.Color = ConsoleColor.Green;

                        if (
                                arrayMapCells[hero.Y - 1, hero.X] == '#' ||
                                arrayMapCells[hero.Y - 1, hero.X + 1] == '#' ||
                                arrayMapCells[hero.Y - 1, hero.X - 1] == '#'
                            )
                        {
                            continue;
                        }
                        else
                        {
                            hero.Move(0, -1);
                        }
                    }
                    else if (keyPressed.Key == ConsoleKey.DownArrow)
                    {
                        hero.Color = ConsoleColor.Green;

                        if (
                                arrayMapCells[hero.Y + 1, hero.X] == '#' || 
                                arrayMapCells[hero.Y + 1, hero.X - 1] == '#' || 
                                arrayMapCells[hero.Y + 1, hero.X + 1] == '#'
                            )
                        {
                            continue;
                        }
                        else
                        {
                            hero.Move(0, 1);
                        }
                    }
                    else if (keyPressed.Key == ConsoleKey.Escape)
                    {
                        // Return to menu
                        return;
                    }
                }

                ClearBuffer();

                hero.Draw();

                Thread.Sleep(delay);
            }



        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = String.Empty;

            Console.BufferHeight = Console.WindowHeight = HeightStartScreen;
            Console.BufferWidth = Console.WindowWidth = WidthStartScreen;

            File file = new File(@"..\..\Map.txt");

            Screen startScreen = new Screen(@"..\..\StartScreen.txt");
            startScreen.LoadScreen();

            Console.BufferHeight = Console.WindowHeight = Height;
            Console.BufferWidth = Console.WindowWidth = Width;
            arrayMapCells = file.LoadMap();
            //file.LoadMap();

            while (true)
            {
                StartNewGame();
            }
        }
    }
}

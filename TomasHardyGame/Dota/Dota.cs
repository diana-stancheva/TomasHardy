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
        const int HEIGHT = 50;
        const int WIDTH = 130;
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

            Character hero = new Character("@", ConsoleColor.Green, 2, HEIGHT - 4);
            hero.Draw();

            bool isKilled = false;

            while (!isKilled)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();
                    if (keyPressed.Key == ConsoleKey.Spacebar)
                    {

                    }
                    else if (keyPressed.Key == ConsoleKey.LeftArrow)
                    {
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
            Console.BufferHeight = Console.WindowHeight = HEIGHT;
            Console.BufferWidth = Console.WindowWidth = WIDTH;

            File file = new File(@"..\..\Map.txt");

            arrayMapCells = file.LoadMap();
            //file.LoadMap();

            while (true)
            {
                StartNewGame();
            }
        }
    }
}

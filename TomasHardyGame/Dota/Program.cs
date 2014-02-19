namespace Dota
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        const int HEIGHT = 50;
        const int WIDTH = 130;

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
                        hero.Move(-1, 0);
                    }
                    else if (keyPressed.Key == ConsoleKey.RightArrow)
                    {
                        hero.Move(1, 0);
                    }
                    else if (keyPressed.Key == ConsoleKey.UpArrow)
                    {
                        hero.Move(0, -1);
                    }
                    else if (keyPressed.Key == ConsoleKey.DownArrow)
                    {
                        hero.Move(0, 1);
                    }
                    else if (keyPressed.Key == ConsoleKey.Escape)
                    {
                        // Return to menu
                        return;
                    }
                }

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                
                hero.Draw();

                Thread.Sleep(150);
            }

            

        }

        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = HEIGHT;
            Console.BufferWidth = Console.WindowWidth = WIDTH;

            File file = new File(@"..\..\Map.txt");

            file.LoadMap();

            while (true)
            {
                StartNewGame();          
            }
        }
    }
}

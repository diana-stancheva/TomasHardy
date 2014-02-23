﻿namespace Dota
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    class DotaMain
    {
        const int HeightStartScreen = 20;
        const int WidthStartScreen = 70;
        const int Height = 50;
        const int Width = 110;
        const int delay = 150;
        public static char[,] arrayMapCells;

        //static Hero hero = new Hero("Bloodseeker", 500, 50, ConsoleColor.Green, 300);

        static List<Hero> heroes = new List<Hero>
        {
            new Hero("Bloodseeker", 500, 50, ConsoleColor.Green, 300, new List<Magic> { Bloodrage.Instance, BloodBath.Instance }), 
            new Hero("Dragon Knight", 300, 50, ConsoleColor.Green, 300, new List<Magic> { BreatheFire.Instance, DragonTrail.Instance }), 
            new Hero("Sven", 500, 50, ConsoleColor.Green, 300, new List<Magic> { StormHammer.Instance, GreatCleave.Instance }), 
            new Hero("Tusk", 500, 50, ConsoleColor.Green, 300, new List<Magic> { IceShards.Instance, StormHammer.Instance }), 
            new Hero("Ursa", 500, 50, ConsoleColor.Green, 300, new List<Magic> { Earthshock.Instance, Overpower.Instance }), 
            new Hero("Zeus", 500, 50, ConsoleColor.Green, 300, new List<Magic> { LightningBolt.Instance, FurySwipes.Instance }), 
            new Hero("Troll Warlord", 500, 50, ConsoleColor.Green, 300, new List<Magic> { ArcLightning.Instance, BattleTrance.Instance }), 
            new Hero("Wraithking", 500, 50, ConsoleColor.Green, 300, new List<Magic> { WraithfireBlast.Instance, Reincarnation.Instance }), 
            new Hero("Nyx Assassin", 500, 50, ConsoleColor.Green, 300, new List<Magic> { Vendetta.Instance, Impale.Instance }), 
            new Hero("Huskar", 500, 50, ConsoleColor.Green, 300, new List<Magic> { InnerVitality.Instance, BurningSpear.Instance })
        };

        //static void ClearBuffer()
        //{
        //    // Read keys until they finish without diplaying
        //    while (Console.KeyAvailable)
        //    {
        //        Console.ReadKey(true);
        //    }
        //}

        //static void StartNewGame()
        //{
            // Moved hero initialisation on line 19.
            //Character hero = new Character("@", ConsoleColor.Green, 2, Height - 4);
            // hero.Draw();

        //    bool isKilled = false;

        //    while (!isKilled)
        //    {
        //        if (Console.KeyAvailable)
        //        {
        //            ConsoleKeyInfo keyPressed = Console.ReadKey();
        //            if (keyPressed.Key == ConsoleKey.Spacebar)
        //            {
        //                hero.Color = ConsoleColor.Magenta;
        //            }
        //            else if (keyPressed.Key == ConsoleKey.LeftArrow)
        //            {
        //                hero.Color = ConsoleColor.Green;

        //                // int left = Console.CursorLeft;
        //                // int top = Console.CursorTop;
        //                if (arrayMapCells[hero.Y, hero.X - 1] != '#')
        //                {
        //                    hero.Move(-1, 0);
        //                }
        //            }
        //            else if (keyPressed.Key == ConsoleKey.RightArrow)
        //            {
        //                hero.Color = ConsoleColor.Green;

        //                if (arrayMapCells[hero.Y, hero.X + 2] != '#')
        //                {
        //                    hero.Move(1, 0);
        //                }
        //            }
        //            else if (keyPressed.Key == ConsoleKey.UpArrow)
        //            {
        //                hero.Color = ConsoleColor.Green;

        //                if (
        //                        arrayMapCells[hero.Y - 1, hero.X] != '#' ||
        //                        arrayMapCells[hero.Y - 1, hero.X + 1] != '#' ||
        //                        arrayMapCells[hero.Y - 1, hero.X - 1] != '#'
        //                    )
        //                {
        //                    hero.Move(0, -1);
        //                }
        //            }
        //            else if (keyPressed.Key == ConsoleKey.DownArrow)
        //            {
        //                hero.Color = ConsoleColor.Green;

        //                if (
        //                        arrayMapCells[hero.Y + 1, hero.X] != '#' || 
        //                        arrayMapCells[hero.Y + 1, hero.X - 1] != '#' || 
        //                        arrayMapCells[hero.Y + 1, hero.X + 1] != '#'
        //                    )
        //                {
        //                    hero.Move(0, 1);
        //                }
        //            }
        //            else if (keyPressed.Key == ConsoleKey.Escape)
        //            {
        //                // Return to menu
        //                return;
        //            }
        //            else if (keyPressed.Key == ConsoleKey.Insert)
        //            {
        //                // choose magic from menu
        //                SelectMagic();
                        
        //            }
        //        }

        //        ClearBuffer();

        //        hero.Draw();

        //        Thread.Sleep(delay);

        //        hero.ManaAndHealthIncrease();
        //    }
        //}

        static void SelectMagic()
        {
            PrintOnPosition(Width - 25, Height - 45, "F1 Bloodrage");
            PrintOnPosition(Width - 25, Height - 44, "F2 Blood Bath");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.Key == ConsoleKey.F1)
                    {
                        hero.Magics[0].Use(hero);
                        //hero.BloodrageMagic();
                        // hero.Draw();
                        //StartNewGame();
                    }
                    
                }
            }
        }

        //Prints on position and apply color for string
        static void PrintOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(str);
        }

        static void Main(string[] args)
        {
            Console.Title = String.Format("Dota v. 0.1®");

            Console.BufferHeight = Console.WindowHeight = HeightStartScreen;
            Console.BufferWidth = Console.WindowWidth = WidthStartScreen;

            //File file = new File(@"..\..\Map.txt");

            Screen startScreen = new Screen(@"..\..\StartScreen.txt");
            startScreen.LoadScreen();

            Console.BufferHeight = Console.WindowHeight = Height;
            Console.BufferWidth = Console.WindowWidth = Width;

            string filePath = "../../Map2.txt";
            var mapHandling = new MapHandling(filePath);
            mapHandling.ReadFromFile();
            mapHandling.LoadMapOnScreen();

            var player = new PlayerMovement(mapHandling.MapMatrix);
            player.GetPlayerStartPosition();

            CreepInitialization creepIni = new CreepInitialization(mapHandling.MapMatrix);
            creepIni.CreateCreeps();
            
            hero.Mana -= 100;
            hero.Health -= 100;

            while (true)
            {

                PrintOnPosition(Width - 25, Height - 45, string.Format("HEALTH: {0}", hero.Health));
                PrintOnPosition(Width - 25, Height - 43, string.Format("MANA: {0}", hero.Mana));

                //                          NE TRII, NE TRII, NE TRII KOMENTARITE
                // TO DO Da izchakva max secunda za natiskane na kopche ili neshto takova
                // Create new stopwatch
                Stopwatch stopwatch = new Stopwatch();
                // Begin timing
                stopwatch.Start();

                // Do something
                while (stopwatch.ElapsedMilliseconds < 2000)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        player.Move(pressedKey);
                    }

                    creepIni.CheckForCreeps(player.PositionOnRow, player.PositionOnCol);
                }


                hero.ManaAndHealthIncrease();
                // Stop timing
                stopwatch.Stop();

                // Write result
                //PrintOnPosition(Width - 45, Height - 43, string.Format("Time elapsed: {0}",
                //    stopwatch.Elapsed));

                // check on each step for creeps
                creepIni.CheckForCreeps(player.PositionOnRow, player.PositionOnCol);

            }

            //arrayMapCells = file.LoadMap();
            ////file.LoadMap();


            //while (true)
            //{
            //    StartNewGame();
            //}


            //   CHARACTER SISI DIDO:


            //Character dido = new Hero(15, 20, 30);
            //Character stefan = new Hero(100, 20, 30);

            ////dido.Health -= 20;
            ////Console.WriteLine(dido.Health);
            //dido.Attack(stefan);
            //Console.WriteLine(stefan.Health);

            //var roshan = new Roshan("Roshan", 5000, 100);

            //var creeps = new List<Creep>
            //{
            //    new Creep("Wolf", 300, 50), 
            //    new Creep("Tiger", 300, 50), 
            //    new Creep("Dog", 300, 50), 
            //    new Creep("Lion", 300, 50), 
            //    new Creep("Sheep", 300, 50)
            //};

            //foreach (var item in heroes)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //Hero current = new Hero("Chicho Dido", 1000, 100, 200);

            //Console.WriteLine(current.Experience);
            //Console.WriteLine(current.Level);
            //current.Experience = 1002;
            //Console.WriteLine(current.Experience);
            //Console.WriteLine(current.Level);
        }
    }
}

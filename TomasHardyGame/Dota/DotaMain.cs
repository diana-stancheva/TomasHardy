namespace Dota
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

        static Hero hero = new Hero("Bloodseeker", 500, 50/*, ConsoleColor.Green*/, 300, 4, 2, new List<Magic> { Bloodrage.Instance, BloodBath.Instance });

        static List<Hero> heroes = new List<Hero>
        {
            new Hero("Bloodseeker", 500, 50/*, ConsoleColor.Green*/, 300, 4, 2, new List<Magic> { Bloodrage.Instance, BloodBath.Instance }), 
            new Hero("Dragon Knight", 300, 50/*, ConsoleColor.Green*/, 300, 4, 2, new List<Magic> { BreatheFire.Instance, DragonTrail.Instance }), 
            new Hero("Anti Mage", 500, 50/*, ConsoleColor.Green*/, 300, 4, 2, new List<Magic> { StormHammer.Instance, GreatCleave.Instance }), 
            new Hero("Juggernaut", 500, 50/*, ConsoleColor.Green*/, 300, 4, 2, new List<Magic> { IceShards.Instance, StormHammer.Instance }), 
            new Hero("Morphiling", 500, 40/*, ConsoleColor.Green*/, 300, 4, 2, new List<Magic> { Earthshock.Instance, Overpower.Instance }), 
            new Hero("Spirit Breaker", 1000, 50/*, ConsoleColor.Green*/, 300, 4, 2, new List<Magic> { LightningBolt.Instance, FurySwipes.Instance }), 
            new Hero("Troll Warlord", 500, 50/*, ConsoleColor.Green*/, 300, 4, 2, new List<Magic> { ArcLightning.Instance, BattleTrance.Instance }), 
            new Hero("Wraithking", 500, 50/*, ConsoleColor.Green*/, 300, 4, 2, new List<Magic> { WraithfireBlast.Instance, Reincarnation.Instance }), 
            new Hero("Nyx Assassin", 500, 50/*, ConsoleColor.Green*/, 300, 4, 2, new List<Magic> { Vendetta.Instance, Impale.Instance }),
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
            PrintOnPosition(Width - 25, Height - 45, "F1 Bloodrage", ConsoleColor.Gray);
            PrintOnPosition(Width - 25, Height - 44, "F2 Blood Bath", ConsoleColor.Gray);

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
        static void PrintOnPosition(int x, int y, string str, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(str);
        }



        static void PrintChoosingHero(int x, int y,Hero hero, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine("health: " + hero.Health);
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("mana: " + hero.Mana);
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("damage: " + hero.Damage);
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("move speed: " + hero.MoveSpeed);
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("attack speed: " + hero.AttackSpeed);
        }

        static void PrintHeroName(int x, int y, Hero hero, string letter, ConsoleColor color = ConsoleColor.Red)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(hero.Name);
            Console.SetCursorPosition(x + (hero.Name.Length / 2 == 0 ? hero.Name.Length / 2 : hero.Name.Length / 2 - 1), y + 1);
            Console.WriteLine(letter);
            Console.SetCursorPosition(x, y + 2);
        }

        static void PrintChooseText(int x, int y, string name, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(name);
        }
        



        public static void Main()
        {
            Console.Title = String.Format("Dota v. 0.1®");

            Console.BufferHeight = Console.WindowHeight = HeightStartScreen;
            Console.BufferWidth = Console.WindowWidth = WidthStartScreen;

            //File file = new File(@"..\..\Map.txt");

            Screen startScreen = new Screen(@"..\..\StartScreen.txt");
            startScreen.LoadScreen();

            Console.BufferHeight = Console.WindowHeight = Height;
            Console.BufferWidth = Console.WindowWidth = Width;


            PrintChooseText(Width - 66, Height - 48, "CHOOSE YOUR HERO", ConsoleColor.Magenta);

            PrintHeroName(Width - 100, Height - 43, heroes[0], "<B>");
            PrintChoosingHero(Width - 100, Height - 41, heroes[0], ConsoleColor.Gray);
            PrintHeroName(Width - 65, Height - 43, heroes[1], "<D>");
            PrintChoosingHero(Width - 65, Height - 41, heroes[1], ConsoleColor.Gray);
            PrintHeroName(Width - 30, Height - 43, heroes[2], "<A>");
            PrintChoosingHero(Width - 30, Height - 41, heroes[2], ConsoleColor.Gray);
            PrintHeroName(Width - 100, Height - 30, heroes[3], "<J>");
            PrintChoosingHero(Width - 100, Height - 28, heroes[3], ConsoleColor.Gray);
            PrintHeroName(Width - 65, Height - 30, heroes[4], "<M>");
            PrintChoosingHero(Width - 65, Height - 28, heroes[4], ConsoleColor.Gray);
            PrintHeroName(Width - 30, Height - 30, heroes[5], "<S>");
            PrintChoosingHero(Width - 30, Height - 28, heroes[5], ConsoleColor.Gray);
            PrintHeroName(Width - 100, Height - 17, heroes[0], "<T>");
            PrintChoosingHero(Width - 100, Height - 15, heroes[0], ConsoleColor.Gray);
            PrintHeroName(Width - 65, Height - 17, heroes[1], "<K>");
            PrintChoosingHero(Width - 65, Height - 15, heroes[1], ConsoleColor.Gray);
            PrintHeroName(Width - 30, Height - 17, heroes[2], "<N>");
            PrintChoosingHero(Width - 30, Height - 15, heroes[2], ConsoleColor.Gray);


            ConsoleKeyInfo pressedKeyHero = Console.ReadKey(true);
            bool heroLetter = false;
            while (!heroLetter)
            {
                switch (pressedKeyHero.Key) 
                {
                    case ConsoleKey.B:
                        hero = heroes[0];
                        heroLetter = true;
                        break;
                    case ConsoleKey.D:
                        hero = heroes[1];
                        heroLetter = true;
                        break;
                    case ConsoleKey.A:
                        hero = heroes[2];
                        heroLetter = true;
                        break;
                    case ConsoleKey.J:
                        hero = heroes[3];
                        heroLetter = true;
                        break;
                    case ConsoleKey.M:
                        hero = heroes[4];
                        heroLetter = true;
                        break;
                    case ConsoleKey.S:
                        hero = heroes[5];
                        heroLetter = true;
                        break;
                    case ConsoleKey.T:
                        hero = heroes[6];
                        heroLetter = true;
                        break;
                    case ConsoleKey.K:
                        hero = heroes[7];
                        heroLetter = true;
                        break;
                    case ConsoleKey.N:
                        hero = heroes[8];
                        heroLetter = true;
                        break;
                }
            }



            string filePath = "../../Map2.txt";
            var mapHandling = new MapHandling(filePath);
            mapHandling.ReadFromFile();
            mapHandling.LoadMapOnScreen();

            var player = new PlayerMovement(mapHandling.MapMatrix);
            player.GetPlayerStartPosition();

            CreepInitialization creepIni = new CreepInitialization(mapHandling.MapMatrix);
            creepIni.CreateCreeps();

            hero.Mana -= 100;
            hero.Health -= 50;

            Stopwatch timeElapsed = new Stopwatch();
            timeElapsed.Start();

            while (true)
            {
                PrintOnPosition(Width - 19, Height - 48, string.Format("{0:D2}:{1:D2}:{2:D2}",
                    timeElapsed.Elapsed.Hours, timeElapsed.Elapsed.Minutes, timeElapsed.Elapsed.Seconds), ConsoleColor.DarkCyan);

                PrintOnPosition(Width - 25, Height - 44, string.Format("MANA: {0}", hero.Mana), ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 42, string.Format("HEALTH: {0}", hero.Health), ConsoleColor.Gray);


                //                          NE TRII, NE TRII, NE TRII KOMENTARITE
                // TO DO Da izchakva max secunda za natiskane na kopche ili neshto takova
                // Create new stopwatch

                // Begin timing
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                // Do something
                while (stopwatch.ElapsedMilliseconds < 1000)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        player.Move(pressedKey);

                        // check for creeps on each step (if the player moves)
                        creepIni.CheckForCreeps(player.PositionOnRow, player.PositionOnCol);
                    }
                }

                hero.ManaAndHealthIncrease();
                // Stop timing
                stopwatch.Stop();

                

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

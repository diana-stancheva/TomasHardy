namespace Dota
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;

    class DotaMain
    {
        const int Height = 50;
        const int Width = 110;

        static Hero hero;

        static List<Hero> heroes = new List<Hero>
        {
            new Hero("Bloodseeker", 566, 50/*, ConsoleColor.Green*/, 320, 2, 2, new List<Magic> { Bloodrage.Instance, BloodBath.Instance }), 
            new Hero("Dragon Knight", 550, 60/*, ConsoleColor.Green*/, 150, 3, 2, new List<Magic> { BreatheFire.Instance, DragonTrail.Instance }), 
            new Hero("Anti Mage", 444, 60/*, ConsoleColor.Green*/, 380, 1, 2, new List<Magic> { StormHammer.Instance, GreatCleave.Instance }), 
            new Hero("Juggernaut", 500, 42/*, ConsoleColor.Green*/, 300, 2, 2, new List<Magic> { IceShards.Instance, StormHammer.Instance }), 
            new Hero("Morphiling", 399, 44/*, ConsoleColor.Green*/, 400, 1, 2, new List<Magic> { Earthshock.Instance, Overpower.Instance }), 
            new Hero("Spirit Breaker", 509, 39/*, ConsoleColor.Green*/, 200, 3, 2, new List<Magic> { LightningBolt.Instance, FurySwipes.Instance }), 
            new Hero("Troll Warlord", 512, 48/*, ConsoleColor.Green*/, 340, 1, 2, new List<Magic> { ArcLightning.Instance, BattleTrance.Instance }), 
            new Hero("Wraith King", 333, 66/*, ConsoleColor.Green*/, 444, 2, 2, new List<Magic> { WraithfireBlast.Instance, Reincarnation.Instance }), 
            new Hero("Nyx Assassin", 600, 27/*, ConsoleColor.Green*/, 270, 1, 2, new List<Magic> { Vendetta.Instance, Impale.Instance }),
        };

        //static void SelectMagic()
        //{
        //    PrintOnPosition(Width - 25, Height - 45, "F1 Bloodrage", ConsoleColor.Gray);
        //    PrintOnPosition(Width - 25, Height - 44, "F2 Blood Bath", ConsoleColor.Gray);

        //    while (true)
        //    {
        //        if (Console.KeyAvailable)
        //        {
        //            ConsoleKeyInfo key = Console.ReadKey();

        //            if (key.Key == ConsoleKey.F1)
        //            {
        //                hero.Magics[0].Use(hero);
        //                //hero.BloodrageMagic();
        //                // hero.Draw();
        //                //StartNewGame();
        //            }

        //        }
        //    }
        //}

        //Prints on position and apply color for string
        public static void PrintOnPosition(int x, int y, string str, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(str);
        }

        static void PrintChoosingHero(int x, int y, Hero hero, ConsoleColor color)
        {
            Console.BufferHeight = Console.WindowHeight = 50;
            Console.BufferWidth = Console.WindowWidth = 110;
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

        static void PrintMapMenu(int x, int y, string mapName, string letter, ConsoleColor color = ConsoleColor.Red)
        {
            Console.BufferHeight = Console.WindowHeight = 32;
            Console.BufferWidth = Console.WindowWidth = 60;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(mapName);
            Console.SetCursorPosition(x + (mapName.Length / 2 == 0 ? mapName.Length / 2 : mapName.Length / 2 - 1), y + 1);
            Console.WriteLine(letter);
            Console.SetCursorPosition(x, y + 2);
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

        static void PrintMagics(int x, int y, Hero hero, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(hero.Magics[0].Description);
            Console.SetCursorPosition(x + 3, y + 3);
            Console.WriteLine(hero.Magics[1].Description);
        }



        public static void Main()
        {
            StartScreen.LoadOnScreen();

            Console.BufferHeight = Console.WindowHeight = Height;
            Console.BufferWidth = Console.WindowWidth = Width;

            PrintChooseText(Width - 86, Height - 47, "CHOOSE A MAP", ConsoleColor.Magenta);

            PrintMapMenu(Width - 87, Height - 41, "dota_backalley", "<B>");
            PrintMapMenu(Width - 87, Height - 33, "dota_iceworld", "<I>");
            PrintMapMenu(Width - 87, Height - 25, "dota_compound", "<C>");

            string filePath = "";
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

            PrintChooseText(Width - 66, Height - 48, "CHOOSE YOUR HERO", ConsoleColor.Magenta);

            PrintHeroName(Width - 100, Height - 41, heroes[0], "<B>");
            PrintChoosingHero(Width - 100, Height - 39, heroes[0], ConsoleColor.Gray);
            PrintHeroName(Width - 65, Height - 41, heroes[1], "<D>");
            PrintChoosingHero(Width - 65, Height - 39, heroes[1], ConsoleColor.Gray);
            PrintHeroName(Width - 30, Height - 41, heroes[2], "<A>");
            PrintChoosingHero(Width - 30, Height - 39, heroes[2], ConsoleColor.Gray);
            PrintHeroName(Width - 100, Height - 28, heroes[3], "<J>");
            PrintChoosingHero(Width - 100, Height - 26, heroes[3], ConsoleColor.Gray);
            PrintHeroName(Width - 65, Height - 28, heroes[4], "<M>");
            PrintChoosingHero(Width - 65, Height - 26, heroes[4], ConsoleColor.Gray);
            PrintHeroName(Width - 30, Height - 28, heroes[5], "<S>");
            PrintChoosingHero(Width - 30, Height - 26, heroes[5], ConsoleColor.Gray);
            PrintHeroName(Width - 100, Height - 15, heroes[6], "<T>");
            PrintChoosingHero(Width - 100, Height - 13, heroes[6], ConsoleColor.Gray);
            PrintHeroName(Width - 65, Height - 15, heroes[7], "<W>");
            PrintChoosingHero(Width - 65, Height - 13, heroes[7], ConsoleColor.Gray);
            PrintHeroName(Width - 30, Height - 15, heroes[8], "<N>");
            PrintChoosingHero(Width - 30, Height - 13, heroes[8], ConsoleColor.Gray);

            Console.CursorVisible = false;
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
                    case ConsoleKey.W:
                        hero = heroes[7];
                        heroLetter = true;
                        break;
                    case ConsoleKey.N:
                        hero = heroes[8];
                        heroLetter = true;
                        break;
                    default:
                        pressedKeyHero = Console.ReadKey(true);
                        break;
                }
            }

            // Reading map from file and printing it on the screen
            //string filePath = "../../Map2.txt";
            var mapHandling = new MapHandling(filePath);
            mapHandling.ReadFromFile();
            mapHandling.LoadOnScreen();

            // player logic
            var player = new PlayerMovement(mapHandling.MapMatrix);
            player.GetPlayerStartPosition();

            // creep logic
            CreepHandling creepHandl = new CreepHandling(mapHandling.MapMatrix);
            creepHandl.CreateCreeps();
            Creep tempCreep = new Creep();
            tempCreep = null;

            //hero.Mana -= 100;
            //hero.Health -= 50;

            Stopwatch timeElapsed = new Stopwatch();
            timeElapsed.Start();

            while (true)
            {
                PrintOnPosition(Width - 19, Height - 48, string.Format("{0:D2}:{1:D2}:{2:D2}",
                    timeElapsed.Elapsed.Hours, timeElapsed.Elapsed.Minutes, timeElapsed.Elapsed.Seconds), ConsoleColor.DarkCyan);

                PrintOnPosition(Width - 25, Height - 44, string.Format("NAME: {0}", hero.Name), ConsoleColor.Yellow);
                PrintOnPosition(Width - 25, Height - 42, string.Format("HEALTH: {0,4}", hero.Health), ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 40, string.Format("MANA: {0,4}", hero.Mana), ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 38, string.Format("DAMAGE: {0}", hero.Damage), ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 36, string.Format("MOVE SPEED: {0}", hero.MoveSpeed), ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 34, string.Format("ATTACK SPEED: {0}", hero.AttackSpeed), ConsoleColor.Gray);
                // ne trii zachistva Experience na geroq !!!!!!!!!!!!!!!!!!!!!!!
                PrintOnPosition(Width - 25, Height - 32, string.Format("EXPERIENCE:     "), ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 32, string.Format("EXPERIENCE: {0}", hero.Experience), ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 30, string.Format("LEVEL: {0}", hero.Level), ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 28, string.Format("MAGICS: "), ConsoleColor.Gray);

                // magics
                PrintOnPosition(Width - 25, Height - 25, string.Format(hero.Magics[0].Name + "  <Q>"), ConsoleColor.Yellow);
                PrintOnPosition(Width - 25, Height - 24, "Damage: " + hero.Magics[0].Damage, ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 23, "ManaCost: " + hero.Magics[0].ManaCost, ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 22, "Cooldown: " + hero.Magics[0].CooldownTime, ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 20, string.Format(hero.Magics[1].Name + "  <W>"), ConsoleColor.Yellow);
                PrintOnPosition(Width - 25, Height - 19, "Damage: " + hero.Magics[1].Damage, ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 18, "ManaCost: " + hero.Magics[1].ManaCost, ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 17, "Cooldown: " + hero.Magics[1].CooldownTime, ConsoleColor.Gray);

                // Begin timing
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                while (stopwatch.ElapsedMilliseconds < 2000)
                {
                    if (stopwatch.ElapsedMilliseconds >= 1000)
                    {
                        PrintOnPosition(Width - 19, Height - 48, string.Format("{0:D2}:{1:D2}:{2:D2}",
                                        timeElapsed.Elapsed.Hours, timeElapsed.Elapsed.Minutes,
                                        timeElapsed.Elapsed.Seconds), ConsoleColor.DarkCyan);
                    }

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        player.Move(pressedKey);

                        if (pressedKey.Key == ConsoleKey.Q)
                        {
                            creepHandl.AttakCreep(tempCreep, hero, 0, true);
                        }
                        else if (pressedKey.Key == ConsoleKey.W)
                        {
                            creepHandl.AttakCreep(tempCreep, hero, 1, true);
                        }
                        else if (pressedKey.Key == ConsoleKey.A)
                        {
                            creepHandl.AttakCreep(tempCreep, hero);
                        }

                        if (tempCreep != null && tempCreep.IsDead)
                        {
                            player.PrintSymbol('@');
                        }

                        // check for creeps around our hero
                        tempCreep = creepHandl.CheckForCreeps(player.PositionOnRow, player.PositionOnCol);
                    }
                }

                // print position 3 47
                //PrintOnPosition(Width - 19, Height - 50, player.PositionOnCol + " " + player.PositionOnRow, ConsoleColor.DarkCyan);

                if (tempCreep != null && tempCreep.IsDead == false)
                {
                    hero.Health -= tempCreep.Damage;
                }

                if (player.PositionOnCol == 1 && player.PositionOnRow == 47)
                {
                    hero.ManaAndHealthIncreaseFountain();
                }
                else if (!hero.IsDead)
                {
                    hero.ManaAndHealthIncrease();
                }

                // Stop timing
                stopwatch.Stop();

                if (hero.IsDead)
                {
                    PrintOnPosition(Width - 25, Height - 42, string.Format("HEALTH: {0,4}", hero.Health), ConsoleColor.Gray);

                    if (hero.InitialHealth > 150)
                    {
                        int currentLevel = hero.Level;
                        int currentExperience = hero.Experience;
                        player.PrintSymbol(' ');
                        Thread.Sleep(10000);
                        hero = new Hero(hero.Name, hero.InitialHealth - 150, hero.Damage, hero.InitialMana,
                            hero.AttackSpeed, hero.MoveSpeed, hero.Magics, hero.Position);
                        hero.Level = currentLevel;
                        hero.Experience = currentExperience;
                        player.PositionOnCol = 3;
                        player.PositionOnRow = 47;
                        player.PrintSymbol('@');
                        tempCreep = null; // importnat line! (when we reset the player there is no creep around him!)
                    }
                    else
                    {
                        // KAKVOTO RESHI SHTE PISHE NAKRAQ!!!!!!!!!!!!!!!!
                        Console.Clear();
                        Console.WriteLine("GAME OVER!");
                        break;
                    }

                }
            }
        }

        //private static void AttakCreep(Creep tempCreep, List<Creep> creepsList, int index = -1, bool isMagic = false)
        //{
        //    foreach (var creep in creepsList)
        //    {
        //        if (tempCreep != null && creep.Position.Equals(tempCreep.Position))
        //        {
        //            if (isMagic)
        //            {
        //                hero.Magics[index].Use(hero, creep);
        //            }
        //            else
        //            {
        //                creep.Health -= hero.Damage;

        //                if (creep.IsDead == true)
        //                {
        //                    if (hero.Level != 10)
        //                    {
        //                        hero.Experience += 50;
        //                    }
        //                }
        //            }

        //            break;
        //        }
        //    }
        //}
    }
}

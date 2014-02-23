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
        const int Height = 50;
        const int Width = 110;

        static Hero hero;

        static List<Hero> heroes = new List<Hero>
        {
            new Hero("Bloodseeker", 500, 50/*, ConsoleColor.Green*/, 300, 2, 2, new List<Magic> { Bloodrage.Instance, BloodBath.Instance }), 
            new Hero("Dragon Knight", 550, 60/*, ConsoleColor.Green*/, 150, 3, 2, new List<Magic> { BreatheFire.Instance, DragonTrail.Instance }), 
            new Hero("Anti Mage", 500, 50/*, ConsoleColor.Green*/, 300, 1, 2, new List<Magic> { StormHammer.Instance, GreatCleave.Instance }), 
            new Hero("Juggernaut", 500, 50/*, ConsoleColor.Green*/, 300, 2, 2, new List<Magic> { IceShards.Instance, StormHammer.Instance }), 
            new Hero("Morphiling", 500, 40/*, ConsoleColor.Green*/, 300, 1, 2, new List<Magic> { Earthshock.Instance, Overpower.Instance }), 
            new Hero("Spirit Breaker", 1000, 50/*, ConsoleColor.Green*/, 300, 3, 2, new List<Magic> { LightningBolt.Instance, FurySwipes.Instance }), 
            new Hero("Troll Warlord", 500, 50/*, ConsoleColor.Green*/, 300, 1, 2, new List<Magic> { ArcLightning.Instance, BattleTrance.Instance }), 
            new Hero("Wraith King", 500, 50/*, ConsoleColor.Green*/, 300, 2, 2, new List<Magic> { WraithfireBlast.Instance, Reincarnation.Instance }), 
            new Hero("Nyx Assassin", 500, 50/*, ConsoleColor.Green*/, 300, 1, 2, new List<Magic> { Vendetta.Instance, Impale.Instance }),
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
        static void PrintOnPosition(int x, int y, string str, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(str);
        }


        static void PrintChoosingHero(int x, int y, Hero hero, ConsoleColor color)
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
            Screen startScreen = new Screen(@"..\..\StartScreen.txt");
            startScreen.LoadScreen();

            Console.BufferHeight = Console.WindowHeight = Height;
            Console.BufferWidth = Console.WindowWidth = Width;

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
            PrintHeroName(Width - 65, Height - 15, heroes[7], "<K>");
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
                    case ConsoleKey.K:
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

            // creating and loading map
            string filePath = "../../Map2.txt";
            var mapHandling = new MapHandling(filePath);
            mapHandling.ReadFromFile();
            mapHandling.LoadMapOnScreen();

            // player logic
            var player = new PlayerMovement(mapHandling.MapMatrix);
            player.GetPlayerStartPosition();

            // creep logic
            CreepInitialization creepIni = new CreepInitialization(mapHandling.MapMatrix);
            creepIni.CreateCreeps();
            Creep tempCreep = new Creep();
            tempCreep = null;

            hero.Mana -= 100;
            hero.Health -= 50;

            Stopwatch timeElapsed = new Stopwatch();
            timeElapsed.Start();

            while (true)
            {
                PrintOnPosition(Width - 19, Height - 48, string.Format("{0:D2}:{1:D2}:{2:D2}",
                    timeElapsed.Elapsed.Hours, timeElapsed.Elapsed.Minutes, timeElapsed.Elapsed.Seconds), ConsoleColor.DarkCyan);

                PrintOnPosition(Width - 25, Height - 44, string.Format("NAME: {0}", hero.Name), ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 42, string.Format("HEALTH: {0,4}", hero.Health), ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 40, string.Format("MANA: {0,4}", hero.Mana), ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 38, string.Format("DAMAGE: {0}", hero.Damage), ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 36, string.Format("MOVE SPEED: {0}", hero.MoveSpeed), ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 34, string.Format("ATTACK SPEED: {0}", hero.AttackSpeed), ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 32, string.Format("EXPERIENCE: {0}", hero.Experience), ConsoleColor.Gray);
                PrintOnPosition(Width - 25, Height - 30, string.Format("LEVEL: {0}", hero.Level), ConsoleColor.Gray);

                PrintOnPosition(Width - 25, Height - 11, "Creep info:", ConsoleColor.Gray);

                // printing creep info on the screen if available
                if (tempCreep != null)
                {
                    PrintOnPosition(Width - 25, Height - 10, new string(' ', 25), ConsoleColor.Gray);
                    PrintOnPosition(Width - 25, Height - 10, string.Format("Name: {0}", tempCreep.Name), ConsoleColor.Gray);
                    PrintOnPosition(Width - 25, Height - 9, new string(' ', 25), ConsoleColor.Gray);
                    PrintOnPosition(Width - 25, Height - 9, string.Format("Health: {0,3}", tempCreep.Health), ConsoleColor.Gray);
                    PrintOnPosition(Width - 25, Height - 8, string.Format("Damage: {0}", tempCreep.Damage), ConsoleColor.Gray);
                    PrintOnPosition(Width - 25, Height - 7, new string(' ', 25), ConsoleColor.Gray);
                    PrintOnPosition(Width - 25, Height - 7, (tempCreep.IsDead ? "Dead" : "Alive"), ConsoleColor.Gray);
                }
                else
                {
                    PrintOnPosition(Width - 25, Height - 10, new string(' ', 25), ConsoleColor.Gray);
                    PrintOnPosition(Width - 25, Height - 9, new string(' ', 25), ConsoleColor.Gray);
                    PrintOnPosition(Width - 25, Height - 8, new string(' ', 25), ConsoleColor.Gray);
                    PrintOnPosition(Width - 25, Height - 7, new string(' ', 25), ConsoleColor.Gray);
                }

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

                        

                        // check for creeps on each step (if the player moves)
                        tempCreep = creepIni.CheckForCreeps(player.PositionOnRow, player.PositionOnCol);

                        List<Creep> creepsList = creepIni.Creeps;

                        if (pressedKey.Key == ConsoleKey.Q)
                        {
                            //hero.Magics[0].Use(hero);
                            AttakCreep(tempCreep, creepsList, 0, true);
                        }
                        else if (pressedKey.Key == ConsoleKey.W)
                        {
                            //hero.Magics[1].Use(hero);
                            AttakCreep(tempCreep, creepsList, 1, true);
                        }
                        else if (pressedKey.Key == ConsoleKey.A)
                        {
                            AttakCreep(tempCreep, creepsList);
                        }
                    }
                }

                if (tempCreep != null && tempCreep.IsDead == false)
                {
                    hero.Health -= tempCreep.Damage;
                }

                if (player.PositionOnCol <= 2 && player.PositionOnRow >= 47)
                {
                    hero.ManaAndHealthIncreaseFountain();
                }

                hero.ManaAndHealthIncrease();

                // Stop timing
                stopwatch.Stop();
            }
        }

        private static void AttakCreep(Creep tempCreep, List<Creep> creepsList, int index = -1, bool isMagic = false)
        {
            foreach (var creep in creepsList)
            {
                if (tempCreep != null && creep.Position.Equals(tempCreep.Position))
                {
                    if (isMagic)
                    {
                        hero.Magics[index].Use(hero, creep);
                    }
                    else
                    {
                        creep.Health -= hero.Damage;

                        if (creep.IsDead == true)
                        {
                            PrintOnPosition(creep.Position.Col, creep.Position.Row, string.Format("\b\b[d*b]"), ConsoleColor.Gray);
                            creepsList.Remove(creep);

                            if (hero.Level != 10)
                            {
                                hero.Experience += 50;
                            }
                        }
                    }

                    break;
                }
            }
        }
    }
}

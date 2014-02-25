namespace Dota
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    using Dota.Screens;
    using Dota.Features;

    public class DotaMain
    {
        public static Hero hero;

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

        // unused method
        private static void PrintMagics(int x, int y, Hero hero, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(hero.Magics[0].Description);
            Console.SetCursorPosition(x + 3, y + 3);
            Console.WriteLine(hero.Magics[1].Description);
        }

        public static void Main()
        {
            StartScreen.Instance.LoadOnScreen();
            MapScreen.Instance.LoadOnScreen();
            HeroScreen.Instance.LoadOnScreen();

            // Reading a map from file and printing it on the screen
            var mapHandling = new MapHandling(MapScreen.Instance.FilePath);
            mapHandling.ReadFromFile();
            mapHandling.LoadOnScreen();

            //Hero logic
            var heroHandling = new HeroHandling(mapHandling.MapMatrix);
            heroHandling.HeroMovement.GetPlayerStartPosition();

            // player(hero) movement logic
            //var player = new HeroMovement(mapHandling.MapMatrix);
            //player.GetPlayerStartPosition();

            // creep logic
            CreepHandling creepHandl = new CreepHandling(mapHandling.MapMatrix);
            creepHandl.CreateCreeps();
            Creep tempCreep = new Creep();
            tempCreep = null;

            Stopwatch timeElapsed = new Stopwatch();
            Stopwatch attackTime = new Stopwatch();
            Stopwatch firstCoolDown = new Stopwatch();
            Stopwatch secondCoolDown = new Stopwatch();

            timeElapsed.Start();

            while (true)
            {
                MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 19, MapHandling.MapScreenHeight - 48, string.Format("{0:D2}:{1:D2}:{2:D2}",
                    timeElapsed.Elapsed.Hours, timeElapsed.Elapsed.Minutes, timeElapsed.Elapsed.Seconds), ConsoleColor.DarkCyan);

                HeroHandling.PrintOnScreen();
                
                // Begin timing
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                while (stopwatch.ElapsedMilliseconds < 2000)
                {
                    if (stopwatch.ElapsedMilliseconds >= 1000)
                    {
                        MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 19, MapHandling.MapScreenHeight - 48, string.Format("{0:D2}:{1:D2}:{2:D2}",
                                        timeElapsed.Elapsed.Hours, timeElapsed.Elapsed.Minutes,
                                        timeElapsed.Elapsed.Seconds), ConsoleColor.DarkCyan);
                    }

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        heroHandling.HeroMovement.Move(pressedKey);

                        if (pressedKey.Key == ConsoleKey.Q)
                        {
                            creepHandl.AttakCreep(hero, 0, true);
                        }
                        else if (pressedKey.Key == ConsoleKey.W)
                        {
                            creepHandl.AttakCreep(hero, 1, true);
                        }
                        else if (pressedKey.Key == ConsoleKey.A && !attackTime.IsRunning)
                        {
                            creepHandl.AttakCreep(hero);
                            attackTime.Start();
                        }

                        if (tempCreep != null && tempCreep.IsDead)
                        {
                            heroHandling.HeroMovement.PrintSymbol('@');
                        }

                        // check for creeps around our hero
                        tempCreep = creepHandl.CheckForCreeps(heroHandling.HeroMovement.PositionOnRow, heroHandling.HeroMovement.PositionOnCol);
                    }

                    if (attackTime.ElapsedMilliseconds >= hero.AttackSpeed * 1000)
                    {
                        attackTime.Reset();
                    }
                }

                //if (attackTime.ElapsedMilliseconds >= hero.AttackSpeed * 1000)
                //{
                //    attackTime.Reset();
                //}

                if (tempCreep != null && tempCreep.IsDead == false)
                {
                    hero.Health -= tempCreep.Damage;
                }

                if (heroHandling.HeroMovement.PositionOnCol == 1 && heroHandling.HeroMovement.PositionOnRow == 47)
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
                    MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 42, string.Format("HEALTH: {0,4}", hero.Health), ConsoleColor.Gray);

                    if (hero.InitialHealth > 150)
                    {
                        int currentLevel = hero.Level;
                        int currentExperience = hero.Experience;
                        heroHandling.HeroMovement.PrintSymbol(' ');
                        Thread.Sleep(10000);
                        hero = new Hero(hero.Name, hero.InitialHealth - 150, hero.Damage, hero.InitialMana,
                            hero.AttackSpeed, hero.MoveSpeed, hero.Magics, hero.Position);
                        hero.Level = currentLevel;
                        hero.Experience = currentExperience;
                        heroHandling.HeroMovement.PositionOnCol = 3;
                        heroHandling.HeroMovement.PositionOnRow = 47;
                        heroHandling.HeroMovement.PrintSymbol('@');
                        tempCreep = null; // importnat line! (when we reset the player there is no creep around him!)
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("GAME OVER!");
                        break;
                    }

                }
            }
        }
    }
}

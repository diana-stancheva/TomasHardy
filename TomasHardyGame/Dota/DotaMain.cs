namespace Dota
{
    using System;
    using System.Diagnostics;

    using Dota.Screens;

    public class DotaMain
    {
        public static void Main()
        {
            // Loading startup screens
            StartScreen.Instance.LoadOnScreen();
            ChooseMapScreen.Instance.LoadOnScreen();
            HeroScreen.Instance.LoadOnScreen();

            // Reading a map from file. Creating a new map matrix and printing it on the screen.
            var map = new Map(ChooseMapScreen.Instance.FilePath);
            map.ReadFromFile();
            map.LoadOnScreen();

            //Hero logic
            var heroHandling = new HeroHandling(map.Matrix);
            heroHandling.HeroMovement.GetPlayerStartPosition();
            heroHandling.ChosenHero = HeroScreen.Instance.ChosenHero;

            // Creep logic
            CreepHandling creepHandl = new CreepHandling(map.Matrix);
            creepHandl.CreateCreeps();

            Stopwatch timeElapsed = new Stopwatch();
            Stopwatch attackTime = new Stopwatch();
            Stopwatch firstCoolDown = new Stopwatch();
            Stopwatch secondCoolDown = new Stopwatch();

            timeElapsed.Start();

            while (true)
            {
                Map.PrintOnPosition(Map.MapScreenWidth - 19, Map.MapScreenHeight - 48, string.Format("{0:D2}:{1:D2}:{2:D2}",
                    timeElapsed.Elapsed.Hours, timeElapsed.Elapsed.Minutes, timeElapsed.Elapsed.Seconds), ConsoleColor.DarkCyan);

                heroHandling.PrintOnScreen();
                
                // Begin timing
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                while (stopwatch.ElapsedMilliseconds < 2000)
                {
                    if (stopwatch.ElapsedMilliseconds >= 1000)
                    {
                        Map.PrintOnPosition(Map.MapScreenWidth - 19, Map.MapScreenHeight - 48, string.Format("{0:D2}:{1:D2}:{2:D2}",
                                        timeElapsed.Elapsed.Hours, timeElapsed.Elapsed.Minutes,
                                        timeElapsed.Elapsed.Seconds), ConsoleColor.DarkCyan);
                    }

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        heroHandling.HeroMovement.Move(pressedKey);

                        if (pressedKey.Key == ConsoleKey.Q)
                        {
                            creepHandl.AttakCreep(heroHandling.ChosenHero, 0, true);
                        }
                        else if (pressedKey.Key == ConsoleKey.W)
                        {
                            creepHandl.AttakCreep(heroHandling.ChosenHero, 1, true);
                        }
                        else if (pressedKey.Key == ConsoleKey.A && !attackTime.IsRunning)
                        {
                            creepHandl.AttakCreep(heroHandling.ChosenHero);
                            attackTime.Start();
                        }

                        if (creepHandl.TempCreep != null && creepHandl.TempCreep.IsDead)
                        {
                            heroHandling.HeroMovement.PrintSymbol('@');
                        }

                        // check for creeps around our hero
                        creepHandl.CheckForCreeps(heroHandling.HeroMovement.PositionOnRow, heroHandling.HeroMovement.PositionOnCol);
                    }

                    if (attackTime.ElapsedMilliseconds >= heroHandling.ChosenHero.AttackSpeed * 1000)
                    {
                        attackTime.Reset();
                    }
                }

                //if (attackTime.ElapsedMilliseconds >= hero.AttackSpeed * 1000)
                //{
                //    attackTime.Reset();
                //}

                if (creepHandl.TempCreep != null && creepHandl.TempCreep.IsDead == false)
                {
                    heroHandling.ChosenHero.Health -= creepHandl.TempCreep.Damage;
                }

                if (heroHandling.HeroMovement.PositionOnCol == 1 && heroHandling.HeroMovement.PositionOnRow == 47)
                {
                    heroHandling.ChosenHero.ManaAndHealthIncreaseFountain();
                }
                else if (!heroHandling.ChosenHero.IsDead)
                {
                    heroHandling.ChosenHero.ManaAndHealthIncrease();
                }

                // Stop timing
                stopwatch.Stop();

                heroHandling.CheckIfHeroIsDead(creepHandl.TempCreep);
            }
        }

        // unused method
        private static void PrintMagics(int x, int y, Hero hero, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(hero.Magics[0].Description);
            Console.SetCursorPosition(x + 3, y + 3);
            Console.WriteLine(hero.Magics[1].Description);
        }

        // Please delete if you don't use!

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
    }
}

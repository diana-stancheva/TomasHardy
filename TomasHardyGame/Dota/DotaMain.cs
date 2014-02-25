﻿namespace Dota
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;

    using Dota.Screens;

    public class DotaMain
    {
        private const int Height = 50;
        private const int Width = 110;

        public static Hero hero;

        public static List<Hero> heroes = new List<Hero>
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
            StartScreen.LoadOnScreen();
            string filePath = MapScreen.LoadOnScreen();            
            HeroScreen.LoadOnScreen();

            // Reading a map from file and printing it on the screen
            var mapHandling = new MapHandling(filePath);
            mapHandling.ReadFromFile();
            mapHandling.LoadOnScreen();

            // player(hero) movement logic
            var player = new PlayerMovement(mapHandling.MapMatrix);
            player.GetPlayerStartPosition();

            // creep logic
            CreepHandling creepHandl = new CreepHandling(mapHandling.MapMatrix);
            creepHandl.CreateCreeps();
            Creep tempCreep = new Creep();
            tempCreep = null;

            Stopwatch timeElapsed = new Stopwatch();
            timeElapsed.Start();

            while (true)
            {
                MapHandling.PrintOnPosition(Width - 19, Height - 48, string.Format("{0:D2}:{1:D2}:{2:D2}",
                    timeElapsed.Elapsed.Hours, timeElapsed.Elapsed.Minutes, timeElapsed.Elapsed.Seconds), ConsoleColor.DarkCyan);

                MapHandling.PrintOnPosition(Width - 25, Height - 44, string.Format("NAME: {0}", hero.Name), ConsoleColor.Yellow);
                MapHandling.PrintOnPosition(Width - 25, Height - 42, string.Format("HEALTH: {0,4}", hero.Health), ConsoleColor.Gray);
                MapHandling.PrintOnPosition(Width - 25, Height - 40, string.Format("MANA: {0,4}", hero.Mana), ConsoleColor.Gray);
                MapHandling.PrintOnPosition(Width - 25, Height - 38, string.Format("DAMAGE: {0}", hero.Damage), ConsoleColor.Gray);
                MapHandling.PrintOnPosition(Width - 25, Height - 36, string.Format("MOVE SPEED: {0}", hero.MoveSpeed), ConsoleColor.Gray);
                MapHandling.PrintOnPosition(Width - 25, Height - 34, string.Format("ATTACK SPEED: {0}", hero.AttackSpeed), ConsoleColor.Gray);
                MapHandling.PrintOnPosition(Width - 25, Height - 32, string.Format("EXPERIENCE:     "), ConsoleColor.Gray);
                MapHandling.PrintOnPosition(Width - 25, Height - 32, string.Format("EXPERIENCE: {0}", hero.Experience), ConsoleColor.Gray);
                MapHandling.PrintOnPosition(Width - 25, Height - 30, string.Format("LEVEL: {0}", hero.Level), ConsoleColor.Gray);
                MapHandling.PrintOnPosition(Width - 25, Height - 28, string.Format("MAGICS: "), ConsoleColor.Gray);

                // magics
                MapHandling.PrintOnPosition(Width - 25, Height - 25, string.Format(hero.Magics[0].Name + "  <Q>"), ConsoleColor.Yellow);
                MapHandling.PrintOnPosition(Width - 25, Height - 24, "Damage: " + hero.Magics[0].Damage, ConsoleColor.Gray);
                MapHandling.PrintOnPosition(Width - 25, Height - 23, "ManaCost: " + hero.Magics[0].ManaCost, ConsoleColor.Gray);
                MapHandling.PrintOnPosition(Width - 25, Height - 22, "Cooldown: " + hero.Magics[0].CooldownTime, ConsoleColor.Gray);
                MapHandling.PrintOnPosition(Width - 25, Height - 20, string.Format(hero.Magics[1].Name + "  <W>"), ConsoleColor.Yellow);
                MapHandling.PrintOnPosition(Width - 25, Height - 19, "Damage: " + hero.Magics[1].Damage, ConsoleColor.Gray);
                MapHandling.PrintOnPosition(Width - 25, Height - 18, "ManaCost: " + hero.Magics[1].ManaCost, ConsoleColor.Gray);
                MapHandling.PrintOnPosition(Width - 25, Height - 17, "Cooldown: " + hero.Magics[1].CooldownTime, ConsoleColor.Gray);

                // Begin timing
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                while (stopwatch.ElapsedMilliseconds < 2000)
                {
                    if (stopwatch.ElapsedMilliseconds >= 1000)
                    {
                        MapHandling.PrintOnPosition(Width - 19, Height - 48, string.Format("{0:D2}:{1:D2}:{2:D2}",
                                        timeElapsed.Elapsed.Hours, timeElapsed.Elapsed.Minutes,
                                        timeElapsed.Elapsed.Seconds), ConsoleColor.DarkCyan);
                    }

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        player.Move(pressedKey);

                        if (pressedKey.Key == ConsoleKey.Q)
                        {
                            creepHandl.AttakCreep(hero, 0, true);
                        }
                        else if (pressedKey.Key == ConsoleKey.W)
                        {
                            creepHandl.AttakCreep(hero, 1, true);
                        }
                        else if (pressedKey.Key == ConsoleKey.A)
                        {
                            creepHandl.AttakCreep(hero);
                        }

                        if (tempCreep != null && tempCreep.IsDead)
                        {
                            player.PrintSymbol('@');
                        }

                        // check for creeps around our hero
                        tempCreep = creepHandl.CheckForCreeps(player.PositionOnRow, player.PositionOnCol);
                    }
                }

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
                    MapHandling.PrintOnPosition(Width - 25, Height - 42, string.Format("HEALTH: {0,4}", hero.Health), ConsoleColor.Gray);

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

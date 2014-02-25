namespace Dota.Screens
{
    using System;

    public static class HeroScreen
    {
        private const int ConsoleHeight = 50;
        private const int ConsoleWidth = 110;

        public static void LoadOnScreen()
        {
            Console.BufferHeight = Console.WindowHeight = ConsoleHeight;
            Console.BufferWidth = Console.WindowWidth = ConsoleWidth;

            MapHandling.PrintOnPosition(ConsoleWidth - 66, ConsoleHeight - 48, "CHOOSE YOUR HERO", ConsoleColor.Magenta);

            PrintHeroName(ConsoleWidth - 100, ConsoleHeight - 41, DotaMain.heroes[0], "<B>");
            PrintChoosingHero(ConsoleWidth - 100, ConsoleHeight - 39, DotaMain.heroes[0], ConsoleColor.Gray);
            PrintHeroName(ConsoleWidth - 65, ConsoleHeight - 41, DotaMain.heroes[1], "<D>");
            PrintChoosingHero(ConsoleWidth - 65, ConsoleHeight - 39, DotaMain.heroes[1], ConsoleColor.Gray);
            PrintHeroName(ConsoleWidth - 30, ConsoleHeight - 41, DotaMain.heroes[2], "<A>");
            PrintChoosingHero(ConsoleWidth - 30, ConsoleHeight - 39, DotaMain.heroes[2], ConsoleColor.Gray);
            PrintHeroName(ConsoleWidth - 100, ConsoleHeight - 28, DotaMain.heroes[3], "<J>");
            PrintChoosingHero(ConsoleWidth - 100, ConsoleHeight - 26, DotaMain.heroes[3], ConsoleColor.Gray);
            PrintHeroName(ConsoleWidth - 65, ConsoleHeight - 28, DotaMain.heroes[4], "<M>");
            PrintChoosingHero(ConsoleWidth - 65, ConsoleHeight - 26, DotaMain.heroes[4], ConsoleColor.Gray);
            PrintHeroName(ConsoleWidth - 30, ConsoleHeight - 28, DotaMain.heroes[5], "<S>");
            PrintChoosingHero(ConsoleWidth - 30, ConsoleHeight - 26, DotaMain.heroes[5], ConsoleColor.Gray);
            PrintHeroName(ConsoleWidth - 100, ConsoleHeight - 15, DotaMain.heroes[6], "<T>");
            PrintChoosingHero(ConsoleWidth - 100, ConsoleHeight - 13, DotaMain.heroes[6], ConsoleColor.Gray);
            PrintHeroName(ConsoleWidth - 65, ConsoleHeight - 15, DotaMain.heroes[7], "<W>");
            PrintChoosingHero(ConsoleWidth - 65, ConsoleHeight - 13, DotaMain.heroes[7], ConsoleColor.Gray);
            PrintHeroName(ConsoleWidth - 30, ConsoleHeight - 15, DotaMain.heroes[8], "<N>");
            PrintChoosingHero(ConsoleWidth - 30, ConsoleHeight - 13, DotaMain.heroes[8], ConsoleColor.Gray);

            Console.CursorVisible = false;
            ConsoleKeyInfo pressedKeyHero = Console.ReadKey(true);
            bool heroLetter = false;

            while (!heroLetter)
            {
                switch (pressedKeyHero.Key)
                {
                    case ConsoleKey.B:
                        DotaMain.hero = DotaMain.heroes[0];
                        heroLetter = true;
                        break;
                    case ConsoleKey.D:
                        DotaMain.hero = DotaMain.heroes[1];
                        heroLetter = true;
                        break;
                    case ConsoleKey.A:
                        DotaMain.hero = DotaMain.heroes[2];
                        heroLetter = true;
                        break;
                    case ConsoleKey.J:
                        DotaMain.hero = DotaMain.heroes[3];
                        heroLetter = true;
                        break;
                    case ConsoleKey.M:
                        DotaMain.hero = DotaMain.heroes[4];
                        heroLetter = true;
                        break;
                    case ConsoleKey.S:
                        DotaMain.hero = DotaMain.heroes[5];
                        heroLetter = true;
                        break;
                    case ConsoleKey.T:
                        DotaMain.hero = DotaMain.heroes[6];
                        heroLetter = true;
                        break;
                    case ConsoleKey.W:
                        DotaMain.hero = DotaMain.heroes[7];
                        heroLetter = true;
                        break;
                    case ConsoleKey.N:
                        DotaMain.hero = DotaMain.heroes[8];
                        heroLetter = true;
                        break;
                    default:
                        pressedKeyHero = Console.ReadKey(true);
                        break;
                }
            }
        }

        private static void PrintHeroName(int x, int y, Hero hero, string letter, ConsoleColor color = ConsoleColor.Red)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(hero.Name);
            Console.SetCursorPosition(x + (hero.Name.Length / 2 == 0 ? hero.Name.Length / 2 : hero.Name.Length / 2 - 1), y + 1);
            Console.WriteLine(letter);
            Console.SetCursorPosition(x, y + 2);
        }

        private static void PrintChoosingHero(int x, int y, Hero hero, ConsoleColor color)
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

    }
}

namespace Dota.Screens
{
    using System;

    // Singleton class!!!
    public class HeroScreen : Screen, IScreen
    {
        private const int ConsoleHeight = 50;
        private const int ConsoleWidth = 110;
        private static HeroScreen instance;
        private Hero hero; // chosen hero

        private HeroScreen() 
        {
            this.ChosenHero = new Hero();
        }

        public static HeroScreen Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HeroScreen();
                }

                return instance;
            }
        }

        public Hero ChosenHero
        {
            get { return this.hero; }
            set { this.hero = value; }
        }
        
        public override void LoadOnScreen()
        {
            Console.BufferHeight = Console.WindowHeight = ConsoleHeight;
            Console.BufferWidth = Console.WindowWidth = ConsoleWidth;

            Map.PrintOnPosition(ConsoleWidth - 66, ConsoleHeight - 48, "CHOOSE YOUR HERO", ConsoleColor.Magenta);

            PrintHeroName(ConsoleWidth - 100, ConsoleHeight - 41, HeroHandling.ListOfHeroes[0], "<B>");
            PrintChoosenHero(ConsoleWidth - 100, ConsoleHeight - 39, HeroHandling.ListOfHeroes[0], ConsoleColor.Gray);
            PrintHeroName(ConsoleWidth - 65, ConsoleHeight - 41, HeroHandling.ListOfHeroes[1], "<D>");
            PrintChoosenHero(ConsoleWidth - 65, ConsoleHeight - 39, HeroHandling.ListOfHeroes[1], ConsoleColor.Gray);
            PrintHeroName(ConsoleWidth - 30, ConsoleHeight - 41, HeroHandling.ListOfHeroes[2], "<A>");
            PrintChoosenHero(ConsoleWidth - 30, ConsoleHeight - 39, HeroHandling.ListOfHeroes[2], ConsoleColor.Gray);
            PrintHeroName(ConsoleWidth - 100, ConsoleHeight - 28, HeroHandling.ListOfHeroes[3], "<J>");
            PrintChoosenHero(ConsoleWidth - 100, ConsoleHeight - 26, HeroHandling.ListOfHeroes[3], ConsoleColor.Gray);
            PrintHeroName(ConsoleWidth - 65, ConsoleHeight - 28, HeroHandling.ListOfHeroes[4], "<M>");
            PrintChoosenHero(ConsoleWidth - 65, ConsoleHeight - 26, HeroHandling.ListOfHeroes[4], ConsoleColor.Gray);
            PrintHeroName(ConsoleWidth - 30, ConsoleHeight - 28, HeroHandling.ListOfHeroes[5], "<S>");
            PrintChoosenHero(ConsoleWidth - 30, ConsoleHeight - 26, HeroHandling.ListOfHeroes[5], ConsoleColor.Gray);
            PrintHeroName(ConsoleWidth - 100, ConsoleHeight - 15, HeroHandling.ListOfHeroes[6], "<T>");
            PrintChoosenHero(ConsoleWidth - 100, ConsoleHeight - 13, HeroHandling.ListOfHeroes[6], ConsoleColor.Gray);
            PrintHeroName(ConsoleWidth - 65, ConsoleHeight - 15, HeroHandling.ListOfHeroes[7], "<W>");
            PrintChoosenHero(ConsoleWidth - 65, ConsoleHeight - 13, HeroHandling.ListOfHeroes[7], ConsoleColor.Gray);
            PrintHeroName(ConsoleWidth - 30, ConsoleHeight - 15, HeroHandling.ListOfHeroes[8], "<N>");
            PrintChoosenHero(ConsoleWidth - 30, ConsoleHeight - 13, HeroHandling.ListOfHeroes[8], ConsoleColor.Gray);

            Console.CursorVisible = false;
            ConsoleKeyInfo pressedKeyHero = Console.ReadKey(true);
            bool heroLetter = false;

            while (!heroLetter)
            {
                switch (pressedKeyHero.Key)
                {
                    case ConsoleKey.B:
                        this.ChosenHero = HeroHandling.ListOfHeroes[0];
                        heroLetter = true;
                        break;
                    case ConsoleKey.D:
                        this.ChosenHero = HeroHandling.ListOfHeroes[1];
                        heroLetter = true;
                        break;
                    case ConsoleKey.A:
                        this.ChosenHero = HeroHandling.ListOfHeroes[2];
                        heroLetter = true;
                        break;
                    case ConsoleKey.J:
                        this.ChosenHero = HeroHandling.ListOfHeroes[3];
                        heroLetter = true;
                        break;
                    case ConsoleKey.M:
                        this.ChosenHero = HeroHandling.ListOfHeroes[4];
                        heroLetter = true;
                        break;
                    case ConsoleKey.S:
                        this.ChosenHero = HeroHandling.ListOfHeroes[5];
                        heroLetter = true;
                        break;
                    case ConsoleKey.T:
                        this.ChosenHero = HeroHandling.ListOfHeroes[6];
                        heroLetter = true;
                        break;
                    case ConsoleKey.W:
                        this.ChosenHero = HeroHandling.ListOfHeroes[7];
                        heroLetter = true;
                        break;
                    case ConsoleKey.N:
                        this.ChosenHero = HeroHandling.ListOfHeroes[8];
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

        private static void PrintChoosenHero(int x, int y, Hero hero, ConsoleColor color)
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

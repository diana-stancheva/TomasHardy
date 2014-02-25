namespace Dota
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using Dota.Features;

    class HeroHandling
    {
        private static readonly List<Hero> listOfHeroes = new List<Hero>
        {
            new Hero("Bloodseeker", 566, 50/*, ConsoleColor.Green*/, 320, 4, 2, new List<Magic> { Bloodrage.Instance, BloodBath.Instance }), 
            new Hero("Dragon Knight", 550, 60/*, ConsoleColor.Green*/, 150, 4, 2, new List<Magic> { BreatheFire.Instance, DragonTrail.Instance }), 
            new Hero("Anti Mage", 444, 60/*, ConsoleColor.Green*/, 380, 1, 2, new List<Magic> { StormHammer.Instance, GreatCleave.Instance }), 
            new Hero("Juggernaut", 500, 42/*, ConsoleColor.Green*/, 300, 2, 2, new List<Magic> { IceShards.Instance, StormHammer.Instance }), 
            new Hero("Morphiling", 399, 44/*, ConsoleColor.Green*/, 400, 1, 2, new List<Magic> { Earthshock.Instance, Overpower.Instance }), 
            new Hero("Spirit Breaker", 509, 39/*, ConsoleColor.Green*/, 200, 4, 2, new List<Magic> { LightningBolt.Instance, FurySwipes.Instance }), 
            new Hero("Troll Warlord", 512, 48/*, ConsoleColor.Green*/, 340, 3, 2, new List<Magic> { ArcLightning.Instance, BattleTrance.Instance }), 
            new Hero("Wraith King", 333, 66/*, ConsoleColor.Green*/, 444, 2, 2, new List<Magic> { WraithfireBlast.Instance, Reincarnation.Instance }), 
            new Hero("Nyx Assassin", 600, 27/*, ConsoleColor.Green*/, 270, 4, 2, new List<Magic> { Vendetta.Instance, Impale.Instance }),
        };

        private readonly char[,] matrix;
        private HeroMovement heroMovement;
        private Hero hero; // chosen hero

        public static List<Hero> ListOfHeroes
        {
            get { return listOfHeroes; }
        }

        public HeroMovement HeroMovement
        {
            get { return this.heroMovement; }
            private set { this.heroMovement = value; }
        }

        public Hero ChosenHero
        {
            get { return this.hero; }
            set { this.hero = value; }
        }
        
        public HeroHandling(char[,] mapMatrix)
        {
            this.matrix = mapMatrix;
            this.HeroMovement = new HeroMovement(this.matrix);
            this.ChosenHero = new Hero();
        }

        public void CheckIfHeroIsDead(Creep temporarilyCreep)
        {
            if (hero.IsDead)
            {
                Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 42, string.Format("HEALTH: {0,4}", hero.Health), ConsoleColor.Gray);

                if (hero.InitialHealth > 150)
                {
                    int currentLevel = hero.Level;
                    int currentExperience = hero.Experience;
                    this.HeroMovement.PrintSymbol(' ');
                    Thread.Sleep(10000);
                    hero = new Hero(hero.Name, hero.InitialHealth - 150, hero.Damage, hero.InitialMana,
                        hero.AttackSpeed, hero.MoveSpeed, hero.Magics, hero.Position);
                    hero.Level = currentLevel;
                    hero.Experience = currentExperience;
                    this.HeroMovement.PositionOnCol = 3;
                    this.HeroMovement.PositionOnRow = 47;
                    this.HeroMovement.PrintSymbol('@');
                    temporarilyCreep = null; // importnat line! (when we reset the player there is no creep around him!)
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("GAME OVER!");
                }

            }
        }

        public void PrintOnScreen()
        {
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 44, string.Format("NAME: {0}", this.ChosenHero.Name), ConsoleColor.Yellow);
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 42, string.Format("HEALTH: {0,4}", this.ChosenHero.Health), ConsoleColor.Gray);
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 40, string.Format("MANA: {0,4}", this.ChosenHero.Mana), ConsoleColor.Gray);
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 38, string.Format("DAMAGE: {0}", this.ChosenHero.Damage), ConsoleColor.Gray);
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 36, string.Format("MOVE SPEED: {0}", this.ChosenHero.MoveSpeed), ConsoleColor.Gray);
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 34, string.Format("ATTACK SPEED: {0}", this.ChosenHero.AttackSpeed), ConsoleColor.Gray);
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 32, string.Format("EXPERIENCE:     "), ConsoleColor.Gray);
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 32, string.Format("EXPERIENCE: {0}", this.ChosenHero.Experience), ConsoleColor.Gray);
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 30, string.Format("LEVEL: {0}", this.ChosenHero.Level), ConsoleColor.Gray);
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 28, string.Format("MAGICS: "), ConsoleColor.Gray);

            // magics
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 25, string.Format(this.ChosenHero.Magics[0].Name + "  <Q>"), ConsoleColor.Yellow);
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 24, "Damage: " + this.ChosenHero.Magics[0].Damage, ConsoleColor.Gray);
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 23, "ManaCost: " + this.ChosenHero.Magics[0].ManaCost, ConsoleColor.Gray);
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 22, "Cooldown: " + this.ChosenHero.Magics[0].CooldownTime, ConsoleColor.Gray);
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 20, string.Format(this.ChosenHero.Magics[1].Name + "  <W>"), ConsoleColor.Yellow);
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 19, "Damage: " + this.ChosenHero.Magics[1].Damage, ConsoleColor.Gray);
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 18, "ManaCost: " + this.ChosenHero.Magics[1].ManaCost, ConsoleColor.Gray);
            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 17, "Cooldown: " + this.ChosenHero.Magics[1].CooldownTime, ConsoleColor.Gray);

            Map.PrintOnPosition(Map.MapScreenWidth - 25, Map.MapScreenHeight - 15, "Attack  <A>", ConsoleColor.Yellow);
        }
    }
}

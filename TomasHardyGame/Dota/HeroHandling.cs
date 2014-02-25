namespace Dota
{
    using System;
    using System.Collections.Generic;

    using Dota.Features;
    class HeroHandling
    {
        private readonly char[,] matrix;
        private HeroMovement heroMovement;
        private static List<Hero> listOfHeroes = new List<Hero>
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

        public HeroMovement HeroMovement
        {
            get { return this.heroMovement; }
        }

        public static List<Hero> ListOfHeroes
        {
            get { return listOfHeroes; }
        }

        public HeroHandling(char[,] mapMatrix)
        {
            this.matrix = mapMatrix;
            this.heroMovement = new HeroMovement(this.matrix);
        }        

        public static void PrintOnScreen()
        {
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 44, string.Format("NAME: {0}", DotaMain.hero.Name), ConsoleColor.Yellow);
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 42, string.Format("HEALTH: {0,4}", DotaMain.hero.Health), ConsoleColor.Gray);
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 40, string.Format("MANA: {0,4}", DotaMain.hero.Mana), ConsoleColor.Gray);
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 38, string.Format("DAMAGE: {0}", DotaMain.hero.Damage), ConsoleColor.Gray);
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 36, string.Format("MOVE SPEED: {0}", DotaMain.hero.MoveSpeed), ConsoleColor.Gray);
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 34, string.Format("ATTACK SPEED: {0}", DotaMain.hero.AttackSpeed), ConsoleColor.Gray);
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 32, string.Format("EXPERIENCE:     "), ConsoleColor.Gray);
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 32, string.Format("EXPERIENCE: {0}", DotaMain.hero.Experience), ConsoleColor.Gray);
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 30, string.Format("LEVEL: {0}", DotaMain.hero.Level), ConsoleColor.Gray);
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 28, string.Format("MAGICS: "), ConsoleColor.Gray);

            // magics
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 25, string.Format(DotaMain.hero.Magics[0].Name + "  <Q>"), ConsoleColor.Yellow);
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 24, "Damage: " + DotaMain.hero.Magics[0].Damage, ConsoleColor.Gray);
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 23, "ManaCost: " + DotaMain.hero.Magics[0].ManaCost, ConsoleColor.Gray);
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 22, "Cooldown: " + DotaMain.hero.Magics[0].CooldownTime, ConsoleColor.Gray);
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 20, string.Format(DotaMain.hero.Magics[1].Name + "  <W>"), ConsoleColor.Yellow);
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 19, "Damage: " + DotaMain.hero.Magics[1].Damage, ConsoleColor.Gray);
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 18, "ManaCost: " + DotaMain.hero.Magics[1].ManaCost, ConsoleColor.Gray);
            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 17, "Cooldown: " + DotaMain.hero.Magics[1].CooldownTime, ConsoleColor.Gray);

            MapHandling.PrintOnPosition(MapHandling.MapScreenWidth - 25, MapHandling.MapScreenHeight - 15, "Attack  <A>", ConsoleColor.Yellow);

        }
    }
}

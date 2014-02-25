namespace Dota
{
    using System;
    using System.Collections.Generic;

    using Dota.Features;
    class HeroHandling
    {
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

        public static List<Hero> ListOfHeroes
        {
            get { return listOfHeroes; }
        }
    }
}


namespace Dota
{
    using System.Collections.Generic;
    using System;

    public static class MagicExtensions
    {
        public static void BloodrageMagic(this Hero hero)
        {
            Bloodrage bloodrage = Bloodrage.Instance;
            bloodrage.Use(hero);
        }

        public static void BloodBathMagic(this Hero hero)
        {
            BloodBath bloodbath = BloodBath.Instance;
            bloodbath.Use(hero);
        }

        public static void BreatheFireMagic(this Hero hero)
        {
            BreatheFire breatheFire = BreatheFire.Instance;
            breatheFire.Use(hero);
        }

        public static void DragonTrailMagic(this Hero hero)
        {
            DragonTrail dragonTrail = DragonTrail.Instance;
            dragonTrail.Use(hero);
        }

        public static void StormHammerMagic(this Hero hero)
        {
            StormHammer stormHammer = StormHammer.Instance;
            stormHammer.Use(hero);
        }

        public static void GreatCleaveMagic(this Hero hero)
        {
            GreatCleave greatCleave = GreatCleave.Instance;
            greatCleave.Use(hero);
        }

        public static void IceShardsMagic(this Hero hero)
        {
            IceShards iceShards = IceShards.Instance;
            //IceShards iceShards = new IceShards();
            iceShards.Use(hero);
        }

        public static void EarthshockMagic(this Hero hero)
        {
            Earthshock earthshock = Earthshock.Instance;
            earthshock.Use(hero);
        }

        public static void OverpowerMagic(this Hero hero)
        {
            Overpower overpower = Overpower.Instance;
            //Overpower overpower = new Overpower();
            overpower.Use(hero);
        }
    }
}

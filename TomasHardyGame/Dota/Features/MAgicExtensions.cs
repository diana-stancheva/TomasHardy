namespace Dota
{
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
    }
}

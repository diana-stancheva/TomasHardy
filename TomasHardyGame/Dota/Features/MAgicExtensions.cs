namespace Dota
{
    public static class MagicExtensions
    {
        public static void BloodrageMagic(this Character hero){
            //Bloodrage bloodrage = new Bloodrage();

            Bloodrage bloodrage = Bloodrage.Instance;
            bloodrage.Use(hero);
        }

        public static void BloodBathMagic(this Character hero)
        {
            BloodBath bloodbath = BloodBath.Instance;
            bloodbath.Use(hero);
        }
    }
}

namespace Dota
{
    public static class MagicExtensions
    {
        public static void BloodrageMagic(this Character hero){

            Bloodrage bloodrage = new Bloodrage();
            bloodrage.Use(hero);

        }
    }
}

namespace Dota
{
    public static class Extensions
    {
        public static void BloodrageMagic(this Character hero){
            Bloodrage bloodrage = new Bloodrage();
            bloodrage.Use(hero);
        }
    }
}

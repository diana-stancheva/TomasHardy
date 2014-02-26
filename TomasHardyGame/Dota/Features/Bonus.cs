namespace Dota
{
    public abstract class Bonus : Feature
    {
        public int BonusDots { get;  set; }

        public Bonus()
            : base()
        {

        }

        public abstract void GetBonus(Hero hero);

    }
}

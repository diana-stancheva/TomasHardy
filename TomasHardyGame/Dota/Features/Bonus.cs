namespace Dota
{
    class Bonus : Feature
    {
        public int BonusDots { get; protected set; }

        public Bonus()
            : base()
        {

        }

        public abstract void GetBonus(Hero hero);

    }
}

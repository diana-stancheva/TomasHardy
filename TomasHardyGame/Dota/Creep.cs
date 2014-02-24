namespace Dota
{
    public class Creep : Character
    {
        public Creep()
        {

        }

        public Creep(string name, int health, int damage/*, string symbol, ConsoleColor color*/, CreepPosition position)
            : base(name, health, damage/*, symbol, color*/, position)
        {

        }
    }
}
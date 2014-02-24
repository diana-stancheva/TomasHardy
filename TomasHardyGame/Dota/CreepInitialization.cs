namespace Dota
{
    using System;
    using System.Collections.Generic;

    public class CreepInitialization
    {
        private const char CreepSymbol = '*';
        private const int CreepMaxHealth = 350;
        private const int CreepMinHealth = 150;
        private const int CreepMaxDamage = 35;
        private const int CreepMinDamage = 15;
        private readonly List<string> creepyNames = new List<string> 
        { 
            "Barnabas", "Bloody Mary", "Spooky Lion", "Fang", "Frankenstein", "Hulk", "Morticia", "Salem", "Zorak"
            , "Wednesday", "Sasquatch", "Phantom", "Quasimodo", "Merlin", "Midnight", "Freddie Krueger", "Fester",
            "Endora", "Chaos"
        };

        private readonly List<CreepPosition> creepsPosition;
        private readonly char[,] matrix;
        private readonly Random random;

        public CreepInitialization(char[,] matrix)
        {
            this.matrix = matrix;
            this.Creeps = new List<Creep>();
            this.creepsPosition = new List<CreepPosition>();
            this.random = new Random();
        }

        public List<Creep> Creeps
        {
            get;
            private set;
        }

        // Search for the creeps in the map and add them to a list of creeps.
        private void ReadCreeps()
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    if (this.matrix[row, col].Equals(CreepSymbol) &&
                      !(this.matrix[row, col + 1].Equals(CreepSymbol)) &&
                      !(this.matrix[row, col - 1].Equals(CreepSymbol)))
                    {
                        creepsPosition.Add(new CreepPosition(row, col));
                    }
                }
            }
        }

        public void CreateCreeps()
        {
            this.ReadCreeps();

            for (int i = 0; i < creepsPosition.Count; i++)
            {
                this.Creeps.Add(new Creep(
                    creepyNames[random.Next(creepyNames.Count)], 
                    random.Next(CreepMinHealth, CreepMaxHealth),
                    random.Next(CreepMinDamage, CreepMaxDamage), creepsPosition[i]));
            }
        }

        public Creep CheckForCreeps(int row, int col)
        {
            foreach (var creep in this.Creeps)
            {
                // checking around the creeps
                if ((creep.Position.Row + 1 == row && creep.Position.Col == col) ||
                    (creep.Position.Row + 1 == row && creep.Position.Col + 1 == col) ||
                    (creep.Position.Row + 1 == row && creep.Position.Col + 2 == col) ||
                    (creep.Position.Row + 1 == row && creep.Position.Col + 3 == col) ||
                    (creep.Position.Row + 1 == row && creep.Position.Col - 1 == col) ||
                    (creep.Position.Row + 1 == row && creep.Position.Col - 2 == col) ||
                    (creep.Position.Row + 1 == row && creep.Position.Col - 3 == col) ||
                    (creep.Position.Row == row && creep.Position.Col - 3 == col) ||
                    (creep.Position.Row == row && creep.Position.Col + 3 == col) ||
                    (creep.Position.Row - 1 == row && creep.Position.Col == col) ||
                    (creep.Position.Row - 1 == row && creep.Position.Col + 1 == col) ||
                    (creep.Position.Row - 1 == row && creep.Position.Col + 2 == col) ||
                    (creep.Position.Row - 1 == row && creep.Position.Col + 3 == col) ||
                    (creep.Position.Row - 1 == row && creep.Position.Col - 1 == col) ||
                    (creep.Position.Row - 1 == row && creep.Position.Col - 2 == col) ||
                    (creep.Position.Row - 1 == row && creep.Position.Col - 3 == col)
                    )
                {
                    Console.SetCursorPosition(col, row);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('@');

                    this.PrintCreepInfo(creep);
                    return creep;
                }
            }

            this.PrintCreepInfo(null);
            return null;
        }

        private void PrintCreepInfo(Creep tempCreep)
        {
            // printing creep info on the screen if available
            if (tempCreep != null)
            {
                DotaMain.PrintOnPosition(MapHandling.ScreenWidth - 25, MapHandling.ScreenHeight - 10, new string(' ', 25), ConsoleColor.Gray);
                DotaMain.PrintOnPosition(MapHandling.ScreenWidth - 25, MapHandling.ScreenHeight - 10, string.Format("Name: {0}", tempCreep.Name), ConsoleColor.Gray);
                DotaMain.PrintOnPosition(MapHandling.ScreenWidth - 25, MapHandling.ScreenHeight - 9, new string(' ', 25), ConsoleColor.Gray);
                DotaMain.PrintOnPosition(MapHandling.ScreenWidth - 25, MapHandling.ScreenHeight - 9, string.Format("Health: {0,3}", tempCreep.Health), ConsoleColor.Gray);
                DotaMain.PrintOnPosition(MapHandling.ScreenWidth - 25, MapHandling.ScreenHeight - 8, string.Format("Damage: {0}", tempCreep.Damage), ConsoleColor.Gray);
                DotaMain.PrintOnPosition(MapHandling.ScreenWidth - 25, MapHandling.ScreenHeight - 7, new string(' ', 25), ConsoleColor.Gray);
                DotaMain.PrintOnPosition(MapHandling.ScreenWidth - 25, MapHandling.ScreenHeight - 7, (tempCreep.IsDead ? "Dead" : "Alive"), ConsoleColor.Gray);
            }
            else
            {
                DotaMain.PrintOnPosition(MapHandling.ScreenWidth - 25, MapHandling.ScreenHeight - 10, new string(' ', 25), ConsoleColor.Gray);
                DotaMain.PrintOnPosition(MapHandling.ScreenWidth - 25, MapHandling.ScreenHeight - 9, new string(' ', 25), ConsoleColor.Gray);
                DotaMain.PrintOnPosition(MapHandling.ScreenWidth - 25, MapHandling.ScreenHeight - 8, new string(' ', 25), ConsoleColor.Gray);
                DotaMain.PrintOnPosition(MapHandling.ScreenWidth - 25, MapHandling.ScreenHeight - 7, new string(' ', 25), ConsoleColor.Gray);
            }
        }
    }
}

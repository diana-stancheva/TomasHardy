﻿namespace Dota
{
    using System;

    public class Creep : Character
    {
        public Creep(string name, int health, int damage, string symbol, ConsoleColor color, int x, int y)
            : base(name, health, damage, symbol, color, x, y)
        {

        }
    }
}
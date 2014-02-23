namespace Dota
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Timers;

    public class Hero : Character
    {
        //private const int PlayerFieldLimitX = 78;
        //private const int PlayerFieldLimitY = 47;

        //private int x;
        //private int y;
        private int mana;
        private int experience;
        private int level;
        private int attackSpeed;
        private int moveSpeed;
        private readonly int initialMana;
        private readonly int initialHealth;
        public List<Magic> Magics { get; set; }

        public Hero(string name, int health, int damage/*, string symbol, ConsoleColor color, int x, int y*/, int mana,
            int attackSpeed, int moveSpeed, List<Magic> magicList, CreepPosition position = default(CreepPosition))
            : base(name, health, damage/*, symbol, color*/, position)
        {
            //this.X = x;
            //this.Y = y;
            this.Mana = mana;
            this.AttackSpeed = attackSpeed;
            this.MoveSpeed = moveSpeed;
            this.Experience = 0;
            this.Level = 1;
            this.initialMana = mana;
            this.initialHealth = health;
            //magics = new List<Magic>();
            this.Magics = magicList;
        }

        //public int X
        //{
        //    get { return this.x; }
        //    set { this.x = value; }
        //}

        //public int Y
        //{
        //    get { return this.y; }
        //    set { this.y = value; }
        //}

        public int Mana
        {
            get { return this.mana; }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.mana = value;
            }
        }

        public int Experience
        {
            get { return this.experience; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The experience must be positive!");
                }

                this.experience = value;

                LevelUp();
            }
        }

        public int Level
        {
            get { return this.level; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The level must be positive!");
                }

                if (value > 10)
                {
                    value = 10;
                }

                this.level = value;
            }
        }

        public int AttackSpeed
        {
            get { return this.attackSpeed; }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.attackSpeed = value;
            }
        }

        public int MoveSpeed
        {
            get { return this.moveSpeed; }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.moveSpeed = value;
            }
        }



        public int InitialMana
        {
            get { return this.mana; }
        }

        public int InitialHealth
        {
            get { return this.initialHealth; }
        }

        //public List<Magic> Magics
        //{
        //    get { return this.magics; }
        //    set { this.magics = value; }
        //}

        private void LevelUp()
        {
            if (this.Experience >= 1000)
            {
                this.Experience = this.Experience % 1000;
                this.Level++;
            }
        }

        //public void Draw()
        //{
        //    Console.ForegroundColor = this.Color;
        //    Console.SetCursorPosition(this.X, this.Y);
        //    Console.Write(this.Symbol);
        //}

        //public void ClearPath()
        //{
        //    Console.ForegroundColor = this.Color;
        //    Console.SetCursorPosition(this.X, this.Y);
        //    Console.CursorVisible = true;
        //    Console.Write(' ');
        //}

        //public void Move(int xDelta, int yDelta)
        //{
        //    this.ClearPath();

        //    if (this.X + xDelta >= 1 && this.X + xDelta < PlayerFieldLimitX)
        //    {
        //        this.X += xDelta;
        //    }
        //    if (this.Y + yDelta >= 1 && this.Y + yDelta < PlayerFieldLimitY)
        //    {
        //        this.Y += yDelta;
        //    }
        //}

        public void ManaAndHealthIncrease()
        {
            if (this.mana < this.initialMana)
            {
                this.mana++;
            }

            if (this.Health < this.initialHealth)
            {
                this.Health++;
            }
        }

        public async void PutTaskDelay()
        {
            await Task.Delay(2000);
            ManaAndHealthIncrease();
        }

        //public override string ToString()
        //{

        //    StringBuilder result = new StringBuilder();

        //    result.Append(base.ToString());
        //    result.AppendFormat("Mana: {0}\n".PadLeft(95), this.mana);
        //    result.AppendFormat("Experience: {0}\n".PadLeft(101), this.experience);
        //    result.AppendFormat("Level: {0}\n".PadLeft(96), this.level);

        //    return result.ToString();
        //    //return base.ToString() + string.Format("Mana: {0}\nExperience: {1}\nLevel: {2}\n", this.mana, this.experience, this.level);
        //}
    }
}
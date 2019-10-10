using System;
using System.Drawing;

namespace Castle
{
    /// <summary>
    /// Warrior базовый абстрактый класс для всех воинов мира, 
    /// реализует общую функциональность
    /// </summary>
    public abstract class Warrior : IWorldObject, IPosition, IActive, IDrawable
    {
        protected static Random rnd = new Random();
        internal WarriorState state = WarriorState.Start;
        internal double targetX = -1, targetY = -1;
        

        internal enum WarriorState
        {
            Start,
            SearchingAndFighting,
            Moving,
            Stop
        }


        public double Health { get; set; }


        public virtual double X
        {
            get;
            protected set;
        }
        

        public virtual double Y
        {
            get;
            protected set;
        }


        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }


        public abstract void Action();


        public abstract void Draw(Graphics g);


        public virtual double GetDistance(double X, double Y)
        {
            double dx = X - this.X,
                   dy = Y - this.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }


        protected void MoveTo(double x, double y, double speed)
        {
            double dx = x - X,
                   dy = y - Y;
            double k = dy / dx;
            if (double.IsInfinity(k) || double.IsNaN(k))
            {
                dx = 0;
                dy = Math.Sign(dy) * Math.Min(speed, Math.Abs(dy));
            }
            else
            {
                dx = Math.Sign(dx) * Math.Min(speed / Math.Sqrt(1 + k * k), Math.Abs(dx));
                dy = Math.Sign(dy) * Math.Min(Math.Abs(dx * k), Math.Abs(dy));
            }

            X += dx;
            Y += dy;
        }
    }
}

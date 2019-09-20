using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Castle
{
    public abstract class WarriorEnemy : Warrior
    {
        public IWorld World
        {
            get;
            private set;
        }
        public T FindNearestWarrior<T>() where T : IWorldObject
        {
            T obj = default(T);
            double minD = int.MaxValue;

            foreach (IWorldObject item in World.Defenders)
            {
                if (item.GetType() == typeof(T) && item.GetDistance(X, Y) < minD)
                {
                    obj = (T)item;
                    minD = item.GetDistance(X, Y);
                }
            }
            return obj;
        }
        public IOptions WorldOptions
        {
            get
            {
                return World == null ? null : World.WorldOut;
            }
        }

        protected WarriorEnemy(IWorld world, double x, double y)
        {
            this.X = x;
            this.Y = y;
            this.World = world;
        }

        //protected WarriorEnemy(IWorld world)
        //  : this(world, 0, 0)
        //{
        //}

        protected double RandomX
        {
            get
            {
                return rnd.NextDouble() * WorldOptions.WorldWidth;
            }
        }
        protected double RandomY
        {
            get
            {
                return rnd.NextDouble() * WorldOptions.WorldHeight;
            }
        }
    }




}

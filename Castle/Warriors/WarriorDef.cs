using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Castle
{
    public abstract class WarriorDef : Warrior
    {
        protected double RandomXDef
        {
            get
            {
                return rnd.NextDouble() * WorldCastle.WorldWidth;
            }
        }


        protected double RandomYDef
        {
            get
            {
                return rnd.NextDouble() * WorldCastle.WorldHeight;
            }
        }


        public IWorld World
        {
            get;
            private set;
        }


        public IOptions WorldOptions
        {
            get
            {
                return World == null ? null : World.WorldCastle;
            }
        }


        public IOptions WorldCastle
        {
            get
            {
                return World == null ? null : World.WorldCastle;
            }
        }


        protected WarriorDef(IWorld world): this(world, 0, 0) {}

        protected WarriorDef(IWorld world, double x, double y)
        {
            this.X = x;
            this.Y = y;
            this.World = world;
        }


        public T FindNearestWarrior<T>() where T : IWorldObject
        {
            T obj = default(T);
            double minDistance = int.MaxValue;

            foreach (IWorldObject item in World.Enemies)
            {
                if (item.GetType() == typeof(T) && item.GetDistance(X, Y) < minDistance)
                {
                    obj = (T)item;
                    minDistance = item.GetDistance(X, Y);
                }
            }
            return obj;
        }
    } 
}

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
        public T FindNearestWarrior<T>() where T : IWorldObject
        {
            T obj = default(T);
            double minD = int.MaxValue;

            foreach (IWorldObject item in World.Enemies)
            {
                if (item.GetType() == typeof(T) && item.GetDistance(X, Y) < minD)
                {
                    obj = (T)item;
                    minD = item.GetDistance(X, Y);
                }
            }
            return obj;
        }
        protected WarriorDef(IWorld world, double x, double y)
        {
            this.X = x;
            this.Y = y;
            this.World = world;
        }

        protected WarriorDef(IWorld world)
          : this(world, 0, 0)
        {
        }

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

    }
  
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle
{
    public class Enemy : IOptions
    {
        public double WorldWidth { get;  }
        public double WorldHeight { get;  }

        public Enemy(double worldWidth, double worldHeight)
        {
            WorldWidth = worldWidth;
            WorldHeight = worldHeight;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle
{
    public class Defenders : IOptions
    {
        public double WorldWidth { get; set; }
        public double WorldHeight { get; set; }
            
        public Defenders(double worldWidth, double worldHeight)
        {
            WorldWidth = worldWidth;
            WorldHeight = worldHeight;
        }
    }
}

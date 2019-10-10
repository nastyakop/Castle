using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle
{
    public interface IPosition
    {
        double X { get; }
        double Y { get; }
        double GetDistance(double X, double Y);
    }
}

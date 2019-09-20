using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle
{
    public interface IOptions
    {
        // размеры мира
        double WorldWidth { get; }
        double WorldHeight { get; }
       
    }
}

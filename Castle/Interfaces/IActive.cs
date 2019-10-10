using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle
{
    public interface IActive
    {
        bool IsAlive { get; }
        void Action();
    }
}

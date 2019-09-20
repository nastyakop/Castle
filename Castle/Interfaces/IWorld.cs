using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle
{
    public interface IWorld : IActive, IDrawable
    {
        ICollection<IWorldObject> Enemies { get; set; }
        ICollection<IWorldObject> Defenders { get; set; }
        IOptions WorldCastle { get; }
        IOptions WorldOut { get; }
        bool Supplies();
    }
}

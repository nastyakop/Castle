using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castle
{
    public interface IActive
    {
        bool Living { get; }  // "жив" ли еще объект
        void Action();        // действие объекта за один игровой цикл
    }
}

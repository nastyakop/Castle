using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Castle
{
    // интерфейс объекта, умеющего себя изображать
    public interface IDrawable
    {
        void Draw(Graphics g);  // предполагается, что центр объекта должен отрисовываться в точке (0, 0)
    }
}

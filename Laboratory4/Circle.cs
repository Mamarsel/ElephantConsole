using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory4
{
    class Circle : Ellipse
    {
        public Circle(float x, float y, float a) : base(x, y, a, a)
        {
            this.name = "Круг ";
            this.name += Convert.ToString(Figure.id);
        }
    }
}


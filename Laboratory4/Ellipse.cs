using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratory4
{
    public class Ellipse : Figure
    {
        public Ellipse(float x, float y, float w, float h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.name = "Эллипс ";
            Figure.id++;
            this.name += Convert.ToString(Figure.id);
        }
        public override void Draw()
        {
            Graphics e = Graphics.FromImage(Init.bitmap);
            e.DrawEllipse(Init.pen, this.x, this.y, this.w, this.h);
            Init.pictureBox.Image = Init.bitmap;
        }

    }
}

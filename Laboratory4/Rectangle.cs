using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratory4
{
    public class Rectangle : Figure
    {

        public Rectangle(float x, float y, float w, float h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.name = "Прямоугольник ";
            Figure.id++;
            this.name += Convert.ToString(Figure.id);
        }

        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawRectangle(Init.pen, this.x, this.y, this.w, this.h);
            Init.pictureBox.Image = Init.bitmap;
        }

    }
}

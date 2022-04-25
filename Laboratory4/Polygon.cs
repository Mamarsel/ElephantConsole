using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratory4
{
    public class Polygon : Figure
    {
        public PointF[] pointFs;
        public static int PolygonID = 0;


        public Polygon(int count, PointF[] pointFs)
        {
            this.name = "Многоугольник";
            Polygon.PolygonID++;
            this.name += Convert.ToString(Polygon.PolygonID);
            this.pointFs = new PointF[count];
        }
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawPolygon(Init.pen, pointFs);
            Init.pictureBox.Image = Init.bitmap;
        }
    }
}

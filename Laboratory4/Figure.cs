using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratory4
{
    abstract public class Figure
    {
        public float x, y, w, h;
        public string name;
        public static int id = 0;
        abstract public void Draw();
        public virtual void MoveTo(int x, int y)
        {
            if (!(this.x + x < 0 || this.y + y < 0 || this.x + this.w + x > Init.pictureBox.Width || this.y + this.h + y > Init.pictureBox.Height))
            {
                this.x += x;
                this.y += y;
                ShapeContain.DrawAll();
            }

            if (this.GetType() == typeof(Polygon))
            {
                Polygon polygon = (Polygon)this;
                int sign = 1;
                for (int i = 0; i < polygon.pointFs.Length && i >= 0; i += sign)
                {
                    if (!(polygon.pointFs[i].X + x < 0 || polygon.pointFs[i].Y + y < 0 || polygon.pointFs[i].X + x > Init.pictureBox.Width || polygon.pointFs[i].Y + this.h + y > Init.pictureBox.Height))
                    {
                        polygon.pointFs[i].X += x;
                        polygon.pointFs[i].Y += y;
                    }
                    else
                    {
                        sign = -1;
                        x = -x;
                        y = -y;
                    }
                }
                ShapeContain.DrawAll();
            }
        }
        public void DeleteF(Figure figure, bool flag = true)
        {
            ShapeContain.list.Remove(figure);
            ShapeContain.DrawAll();
        }
        public void Clear()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.Gray);
        }

    }
}

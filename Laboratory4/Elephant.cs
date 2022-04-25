using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Laboratory4
{
    public class Elephant : Figure
    {
        Rectangle Body, Larm1, Larm2, Rarm1, Rarm2;
        Circle Head, eye;
        Polygon ears;
        Circle c1, c2, c3, c4, c5, c6, c7;
        public static PointF[] pointFs = new PointF[4];

        public Elephant(int w, int y, int x, string name)//Слон
        {

            h = w;
            this.name = name;
            
            this.Body = new Rectangle(x, y, w + w / 2, h);
            this.Larm1 = new Rectangle(x, y + h, (w - 5) / 4, h / 2);
            this.Larm2 = new Rectangle(x + w / 4, y + h, (w - 5) / 4, h / 2);
            this.Rarm1 = new Rectangle(x + w, y + h, (w - 5) / 4, h / 2);
            this.Rarm2 = new Rectangle(x + w + (this.Rarm1.w + 3) * (float)(0.99), y + h, (w - 5) / 4, h / 2);
            this.Head = new Circle(x, y + this.Body.w / 1.5f, -this.Body.w / 1.5f);
            this.ears = new Polygon(4, pointFs);


            ears.pointFs[0] = new PointF(x + this.Head.w / 2, y - this.Head.h / 2);//левая
            ears.pointFs[1] = new PointF(x - this.Head.w / 4 + this.Head.w / 1.75f, y - this.Head.h / 6);//верхняя
            ears.pointFs[2] = new PointF(x + this.Head.w / 2 - this.Head.w / (3 - 0.25f), y - this.Head.h + this.Head.h / 2);//правая
            ears.pointFs[3] = new PointF(x - this.Head.w / 4 + this.Head.w / 1.75f, y - this.Head.h + this.Head.h / 6); //нижняя точка


            eye = new Circle(this.Head.x + this.Head.w - this.Head.w / 5.0f, y - this.Head.w / 1.5f, w / 8);
            c1 = new Circle(x + this.Head.w / 1.2f, y - this.Head.h / 1.05f, w / 4);


            c2 = new Circle(x + this.Head.w / 1.32f, y - this.Head.h / 0.84f, w / 5.5f);
            c3 = new Circle(x + this.Head.w / 1.24f, y - this.Head.h / 0.73f, w / 6.5f);
            c4 = new Circle(x + this.Head.w / 1.09f, y - this.Head.h / 0.705f, w / 7.8f);
            c5 = new Circle(x + this.Head.w / 1.01f, y - this.Head.h / 0.75f, w / 8.5f);
            c6 = new Circle(x + this.Head.w / 0.96f, y - this.Head.h / 0.808f, w / 9.7f);
            c7 = new Circle(x + this.Head.w / 0.9f, y - this.Head.h / 0.84f, w / 13f);

            float left = this.c7.x;
            float up = this.Head.y;
            float right = this.Head.x + this.Body.w;
            float down = this.Rarm2.y + this.Rarm2.h;
            if (left > 0 && right < Init.pictureBox.Width && up > 0 && down < Init.pictureBox.Height)
            {
                this.Draw();
                ShapeContain.AddFigure(this);
            }
            else
            {
                DeleteF(this);
                MessageBox.Show("Фигура выходит за границы, измените координаты, либо уменьшите размер");
            }

        }
        public override void Draw()
        {

            this.Head.Draw();
            this.Body.Draw();
            this.Larm1.Draw();
            this.Larm2.Draw();
            this.Rarm1.Draw();
            this.Rarm2.Draw();
            this.ears.Draw();
            this.eye.Draw();
            this.c1.Draw(); this.c2.Draw(); this.c3.Draw(); this.c4.Draw(); this.c5.Draw(); this.c6.Draw(); this.c7.Draw();
            Init.pictureBox.Image = Init.bitmap;

        }
        public override void MoveTo(int y, int x)
        {

            float left = this.c7.x + x;
            float up = this.Head.y + y;
            float right = this.Head.x + this.Body.w + x;
            float down = this.Rarm2.y + this.Rarm2.h + y;
            if (left > 0 && right < Init.pictureBox.Width && up > 0 && down < Init.pictureBox.Height)
            {

                this.Body.MoveTo(x, y);
                this.Larm1.MoveTo(x, y);
                this.Larm2.MoveTo(x, y);
                this.Rarm2.MoveTo(x, y);
                this.Rarm1.MoveTo(x, y);
                this.Head.MoveTo(x, y);
                this.ears.MoveTo(x, y);
                this.eye.MoveTo(x, y);
                this.c1.MoveTo(x, y); this.c2.MoveTo(x, y); this.c3.MoveTo(x, y); this.c4.MoveTo(x, y); this.c5.MoveTo(x, y); this.c6.MoveTo(x, y); this.c7.MoveTo(x, y);

            }
            else
            {

                MessageBox.Show("Фигура выходит за границы");

            }

        }
    }
}

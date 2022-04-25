using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratory4
{
    public static class ShapeContain
    {
        public static List<Figure> list;
        static ShapeContain()
        {
            list = new List<Figure>();
        }
        public static void DrawAll()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.Black);
            Init.pictureBox.Image = Init.bitmap;
            foreach (Figure figure in list)
            {
                figure.Draw();
            }
        }
        public static void AddFigure(Figure figure)
        {
            list.Add(figure);
        }
        public static Figure FindFigure(string name)
        {
            foreach (Figure figure in list)
            {
                if (figure.name == name)
                {
                    return figure;
                }
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    public class Karakter
    {
        private static int _chickID = 0;

        public int ID { get; private set; }
        public string Ad { get; set; }
        public Point Lokasyon { get; set; }

        public Karakter(string hirsizCivciv)
        {
            ID = ++_chickID;
            Ad = hirsizCivciv;
            Lokasyon = Point.Empty;
        }

        public void RastgeleDogma(int haritaBoyutu)
        {
            Random random = new Random();
            Lokasyon = new Point(random.Next(haritaBoyutu), random.Next(haritaBoyutu));
        }

        public List<Point> EnKisaYol(Point hedef)
        {
            List<Point> yol = new List<Point>();

            int deltaX = hedef.X - Lokasyon.X;
            int deltaY = hedef.Y - Lokasyon.Y;

            while (deltaX != 0 || deltaY != 0)
            {
                if (Math.Abs(deltaX) > 0)
                {
                    int hareketX = Math.Sign(deltaX);
                    Lokasyon = new Point(Lokasyon.X + hareketX, Lokasyon.Y);
                    deltaX -= hareketX;
                }

                if (Math.Abs(deltaY) > 0)
                {
                    int hareketY = Math.Sign(deltaY);
                    Lokasyon = new Point(Lokasyon.X, Lokasyon.Y + hareketY);
                    deltaY -= hareketY;
                }

                yol.Add(Lokasyon);
            }

            return yol;
        }
    }
}

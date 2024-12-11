using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    public class NesneBilgisi
    {
        public Rectangle Alan { get; set; }

        public NesneBilgisi(Point konum, Size boyut)
        {
            Alan = new Rectangle(konum, boyut);
        }
    }
}
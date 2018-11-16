using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klet
{
    class Cell
    {
        private int[] RGBold = { 0,0,0};
        private int[] RGBnew = { 0, 0, 0 };
        public Cell()
        {
        }
        public int[] colorRGB {
            get { return RGBold; }
            set {
                value.CopyTo(RGBold, 0);
            }
        }
        public int colorR {
            get { return RGBold[0]; }
            set { RGBnew[0] = value; }
        }
        public int colorG
        {
            get { return RGBold[1]; }
            set { RGBnew[1] = value; }
        }
        public int colorB
        {
            get { return RGBold[2]; }
            set { RGBnew[2] = value; }
        }
        public void nextRGB() {
            RGBnew.CopyTo(RGBold, 0);
        }
        
    }
}

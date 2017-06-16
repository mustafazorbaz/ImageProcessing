using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing
{
    class Row
    {
        private int r;
        private int g;
        private int b;
        public Row(int r,int g,int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
        public int getR()
        {
            return r;
        }

        public int getG()
        {
            return g;
        }
        public int getB()
        {
            return b;
        }
    }
}

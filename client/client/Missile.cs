using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class Missile
    {
        private int r, c;
        public Missile(int r, int c)
        {
            this.r = r;
            this.c = c;
        }
        public int getRiga()
        {
            return r;
        }
        public int getColonna()
        {
            return c;
        }
    }
}

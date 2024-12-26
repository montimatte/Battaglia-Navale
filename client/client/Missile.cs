using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class Missile
    {
        private int x, y;
        public Missile(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int getx()
        {
            return x;
        }
        public int gety()
        {
            return y;
        }
    }
}

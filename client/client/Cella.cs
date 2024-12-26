using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class Cella
    {
        private int x, y;
        private bool barca;
        private bool colpita;

        public Cella(int x, int y, bool barca)
        {
            this.x = x;
            this.y = y;
            this.barca = barca;
            this.colpita = false;
        }

        public int getx()
        {
            return x;
        }
        public int gety()
        {
            return y;
        }
        public bool getbarca()
        {
            return barca;
        }
        public bool getcolpita()
        {
            return colpita;
        }
        public void setColpita()
        {
            colpita = true;
        }
    }
}

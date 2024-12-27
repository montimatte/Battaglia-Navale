using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class Cella
    {
        private int r, c;
        private bool barca;
        private bool colpita;

        public Cella(int r, int c, bool barca)
        {
            this.r = r;
            this.c = c;
            this.barca = barca;
            this.colpita = false;
        }

        public int getRiga()
        {
            return r;
        }
        public int getColonna()
        {
            return c;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class Barca
    { 
        private int r, c;
        private Cella[] celle;
        private int lunghezza;
        private bool orizzontale;
        private int colpi;
        private bool affondata;
        private bool alreadyChecked;
        public Barca(int r, int c, int lunghezza, bool orizzontale)
        {
            this.r = r;
            this.c = c;
            this.celle=new Cella[lunghezza];
            this.lunghezza = lunghezza;
            this.orizzontale = orizzontale;
            this.colpi = 0;
            this.affondata = false;
            this.alreadyChecked = false;

            //inizializza celle

            //int posX = barche[k].getOrizzontale() ? barche[k].getx() + i : barche[k].getx(); //la x cambia in lungo
            //nt posY = barche[k].getOrizzontale() ? barche[k].gety() : barche[k].gety() + i;
            if (orizzontale)
            {
                for(int i = 0; i < lunghezza; i++)
                {
                    this.celle[i]=new Cella(r,c+i+1,true); //la x cambia in lungo
                }
            }
            else
            {
                for (int i = 0; i < lunghezza; i++)
                {
                    this.celle[i] = new Cella(c , r + (i + 1), true);
                }
            }
        }
        public int getLunghezza(){
            return lunghezza;
        }
        public bool getOrizzontale()
        {
            return orizzontale;
        }
        public int getRiga()
        {
            return r;
        }
        public int getColonna()
        {
            return c;
        }
        public Cella GetCella(int i)
        {
            return this.celle[i];
        }
        public void setCella(Cella cella, int i)
        {
            this.celle[i] = cella;
        }

        //controlla se il missile ha colpito la barca: se si aumenta i colpi subiti e controlla se la barca è affondata
        public bool checkAffondata(int riga, int colonna)
        {
            if (alreadyChecked)
            {
                return false;
            }

            for (int i = 0; i < this.celle.Length; i++)
            {
                if (riga == this.celle[i].getRiga() && colonna == this.celle[i].getColonna()) { 
                    colpi++;
                    this.celle[i].setColpita();
                    if (this.colpi == this.lunghezza)
                    {
                        this.alreadyChecked = true;
                        this.affondata=true;
                    }
                }
            }
            return this.affondata;
        }
    }
}

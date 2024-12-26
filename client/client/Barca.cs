using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class Barca
    {
        private int x, y;
        private Cella[] celle;
        private int lunghezza;
        private bool orizzontale;
        private int colpi;
        private bool affondata;
        public Barca(int x, int y, int lunghezza, bool orizzontale)
        {
            this.x = x;
            this.y = y;
            this.celle=new Cella[lunghezza];
            this.lunghezza = lunghezza;
            this.orizzontale = orizzontale;
            this.colpi = 0;
            this.affondata = false;

            //inizializza celle
            if(orizzontale)
            {
                for(int i = 0; i < lunghezza; i++)
                {
                    this.celle[i]=new Cella(x*(i+1),y,true); //la x cambia in lungo
                }
            }
            else
            {
                for (int i = 0; i < lunghezza; i++)
                {
                    this.celle[i] = new Cella(x , y * (i + 1), true);
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
        public int getx()
        {
            return x;
        }
        public int gety()
        {
            return y;
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
        public bool checkColpita(Missile m)
        {
            for (int i = 0; i < this.celle.Length; i++)
            {
                if (m.getx() == this.celle[i].getx() && m.gety() == this.celle[i].gety()) { 
                    colpi++;
                    this.celle[i].setColpita();
                    if (this.colpi == this.lunghezza)
                    {
                        this.affondata=true;
                    }
                }
            }
            return this.affondata;
        }
    }
}

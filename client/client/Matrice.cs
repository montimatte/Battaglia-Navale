using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class Matrice
    {
        private Cella[,] griglia;
        private int dimensione=10;

        public Matrice()
        {
            griglia = new Cella[dimensione, dimensione];

            //inizializza
            for (int x = 0; x < dimensione; x++)
            {
                for (int y = 0; y < dimensione; y++)
                {
                    griglia[x, y] = new Cella(x, y, false);
                }
            }
        }

        public Cella GetCella(int x,int y)
        {
            return griglia[x, y];
        }

        public bool AggiungiBarche(List<Barca> barche)
        {
            for (int k = 0; k < barche.Count; k++)
            {

                // Controlla se la barca può essere posizionata
                for (int i = 0; i < barche[k].getLunghezza(); i++)
                {
                    int posX = barche[k].getOrizzontale() ? barche[k].getx() + i : barche[k].getx(); //la x cambia in lungo
                    int posY = barche[k].getOrizzontale() ? barche[k].gety() : barche[k].getx() + i;

                    if (posX >= dimensione || posY >= dimensione || griglia[posX, posY].getbarca())
                    {
                        return false; // Spazio occupato o fuori dai limiti
                    }
                }

                // Posiziona la barca
                for (int i = 0; i < barche[k].getLunghezza(); i++)
                {
                    int posX = barche[k].getOrizzontale() ? barche[k].getx() + i : barche[k].getx();
                    int posY = barche[k].getOrizzontale() ? barche[k].gety() : barche[k].getx() + i;

                    griglia[posX, posY] = new Cella(posX, posY, true);
                    barche[k].setCella(griglia[posX, posY], i);
                }
            }
            return true;
        }
    }
}

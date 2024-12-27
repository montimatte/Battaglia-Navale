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
            for (int r = 0; r < dimensione; r++)
            {
                for (int c = 0; c < dimensione; c++)
                {
                    griglia[r, c] = new Cella(r, c, false);
                }
            }
        }

        public Cella GetCella(int r,int c)
        {
            return griglia[r, c];
        }

        public bool AggiungiBarche(List<Barca> barche)
        {
            for (int k = 0; k < barche.Count; k++)
            {

                // Controlla se la barca può essere posizionata
                for (int i = 0; i < barche[k].getLunghezza(); i++)
                {
                    int posColonna = barche[k].getOrizzontale() ? barche[k].getColonna() + i : barche[k].getColonna(); //la x cambia in lungo
                    int posRiga = barche[k].getOrizzontale() ? barche[k].getRiga() : barche[k].getRiga() + i;

                    if (posColonna >= dimensione || posRiga >= dimensione || griglia[posColonna, posRiga].getbarca())
                    {
                        return false; // Spazio occupato o fuori dai limiti
                    }
                }

                // Posiziona la barca
                for (int i = 0; i < barche[k].getLunghezza(); i++)
                {
                    int posColonna = barche[k].getOrizzontale() ? barche[k].getColonna() + i : barche[k].getColonna(); //la x cambia in lungo
                    int posRiga = barche[k].getOrizzontale() ? barche[k].getRiga() : barche[k].getRiga() + i;

                    //griglia[posX, posY] = new Cella(posX, posY, true); ??????
                    griglia[posRiga, posColonna] = new Cella(posRiga, posColonna, true);
                    barche[k].setCella(griglia[posRiga, posColonna], i);
                }
            }
            return true;
        }
    }
}

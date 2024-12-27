using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Campo : Form
    {
        private Matrice m;
        public Campo(Matrice m)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog; //non permette di ridimensionare
            this.m = m;
            creaMatrice();
        }

        public void creaMatrice()
        {
            int width = 50;
            int height = 50;
            Button[,] campo = new Button[10, 10];
            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    campo[r, c] = new Button();
                    campo[r, c].Width = width;
                    campo[r, c].Height = height;
                    campo[r, c].Location = new Point((c + 1) * width, (r + 1) * height);
                    if (m.GetCella(r, c).getbarca())
                    {
                        campo[r, c].BackColor = Color.FromArgb(0, 0, 0);
                    }
                    else
                    {
                        campo[r, c].BackColor = Color.FromArgb(161, 255, 255);
                    }
                    this.Controls.Add(campo[r, c]);

                }
            }
        }
    }
}

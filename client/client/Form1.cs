using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {
        private List<Barca> barche=new List<Barca>();
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog; //non permette di ridimensionare
        }

        private async void buttonReady_ClickAsync(object sender, EventArgs e)
        {
            //debug
            ComboBoxRiga5.SelectedItem = "1";
            comboBoxRiga4.SelectedItem = "5";
            comboBoxRiga31.SelectedItem = "10";
            comboBoxRiga32.SelectedItem = "6";
            comboBoxRiga21.SelectedItem = "9";
            comboBoxRiga22.SelectedItem = "8";

            comboBoxColonna5.SelectedItem= "1";
            comboBoxColonna4.SelectedItem = "3";
            comboBoxColonna31.SelectedItem = "2";
            comboBoxColonna32.SelectedItem = "4";
            comboBoxColonna21.SelectedItem = "1";
            comboBoxColonna22.SelectedItem = "6";

            comboBoxOr5.SelectedItem = "Verticale";
            comboBoxOr4.SelectedItem = "Orizzontale";
            comboBoxOr31.SelectedItem = "Orizzontale";
            comboBoxOr32.SelectedItem = "Verticale";
            comboBoxOr21.SelectedItem = "Orizzontale";
            comboBoxOr22.SelectedItem = "Verticale";



            //check campi vuoti
            if (comboBoxColonna21.SelectedItem==null||
                comboBoxColonna22.SelectedItem==null||
                comboBoxColonna31.SelectedItem==null||
                comboBoxColonna32.SelectedItem==null||
                comboBoxColonna4.SelectedItem==null||
                comboBoxColonna5.SelectedItem==null||
                comboBoxOr21.SelectedItem==null||
                comboBoxOr22.SelectedItem==null||
                comboBoxOr31.SelectedItem==null||
                comboBoxOr32.SelectedItem==null||
                comboBoxOr4.SelectedItem==null||
                comboBoxOr5.SelectedItem==null||
                comboBoxRiga21.SelectedItem==null||
                comboBoxRiga22.SelectedItem==null||
                comboBoxRiga31.SelectedItem==null||
                comboBoxRiga32.SelectedItem==null||
                comboBoxRiga4.SelectedItem==null||
                ComboBoxRiga5.SelectedItem == null)
            {
                MessageBox.Show("una o più barche non sono state piazzate!", "ERRORE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //crea lista
            barche.Add(new Barca(int.Parse(ComboBoxRiga5.Text)-1, int.Parse(comboBoxColonna5.Text) - 1, 5,comboBoxOr5.Text=="Orizzontale"?true:false)); //barca da 5
            barche.Add(new Barca(int.Parse(comboBoxRiga4.Text) - 1, int.Parse(comboBoxColonna4.Text) - 1, 4, comboBoxOr4.Text == "Orizzontale" ? true : false)); //barca da 4
            barche.Add(new Barca(int.Parse(comboBoxRiga31.Text) - 1, int.Parse(comboBoxColonna31.Text) - 1, 3, comboBoxOr31.Text == "Orizzontale" ? true : false)); //barca da 3
            barche.Add(new Barca(int.Parse(comboBoxRiga32.Text) - 1, int.Parse(comboBoxColonna32.Text) - 1, 3, comboBoxOr32.Text == "Orizzontale" ? true : false)); //barca da 3
            barche.Add(new Barca(int.Parse(comboBoxRiga21.Text) - 1, int.Parse(comboBoxColonna21.Text) - 1  , 2, comboBoxOr21.Text == "Orizzontale" ? true : false)); //barca da 2
            barche.Add(new Barca(int.Parse(comboBoxRiga22.Text) - 1, int.Parse(comboBoxColonna22.Text) - 1, 2, comboBoxOr22.Text == "Orizzontale" ? true : false)); //barca da 2

            //crea matrice
            Matrice matrix = new Matrice();
            if (!matrix.AggiungiBarche(barche))
            {
                MessageBox.Show("Una o più barche contengono coordinate errate!","ERRORE!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                barche.Clear();
                return;
            }

            //visualizzo finestra di gioco
            Campo c = new Campo(matrix);
            c.Show();
            this.Hide();

            /*
            //invio socket e attendo risposta

            buttonReady.Enabled = false; //disattivo il bottone

            UdpClient client = new UdpClient();
            byte[] data = Encoding.ASCII.GetBytes("pronto");
            client.Send(data, data.Length, "127.0.0.1", 12345);

            IPEndPoint recieveEP = new IPEndPoint(IPAddress.Any, 0);
            byte[] datarecieved = null;

            //task per rendere non bloccanti le chiamate
            Task t = Task.Factory.StartNew(() =>
            {
                datarecieved = client.Receive(ref recieveEP);
            });
            await t; //funziona asincrona che non rende bloccante la chiamata

            String risposta = Encoding.ASCII.GetString(datarecieved);

            if (risposta == "inizio")
            {
                //visualizzo finestra di gioco
                Campo c = new Campo(matrix);
                c.Show();
                this.Close();
            }  
            */
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    internal class Gioco
    {
        Matrice campo;
        Matrice nemico;
        Campo c;
        Nemico n;
        public Gioco(Matrice m) { 
            this.campo = m;
            this.nemico = new Matrice();
            this.c=new Campo(this.campo);
            this.n=new Nemico(this.nemico);
        }

        public /*async*/ void pronto()
        {
            UdpClient client = new UdpClient();
            byte[] data = Encoding.ASCII.GetBytes("pronto");
            client.Send(data, data.Length, "127.0.0.1", 12345);

            IPEndPoint recieveEP = new IPEndPoint(IPAddress.Any, 0);
            byte[] datarecieved = null;

            datarecieved = client.Receive(ref recieveEP);
            /*
            //task per rendere non bloccanti le chiamate
            Task t = Task.Factory.StartNew(() =>
            {
                
            });
            await t; //funziona asincrona che non rende bloccante la chiamata
            */

            String risposta = Encoding.ASCII.GetString(datarecieved);

            if (risposta == "inizio")
            {
                //invio la matrice al server
                data = Encoding.ASCII.GetBytes(campo.toString());
                client.Send(data, data.Length, "127.0.0.1", 12345);

                //visualizzo finestra di gioco
                c.Show();
            }
        }

        public void turno()
        {
            UdpClient client = new UdpClient();
            IPEndPoint recieveEP = new IPEndPoint(IPAddress.Any, 0);
            byte[] datarecieved = null;

            datarecieved = client.Receive(ref recieveEP);
            String risposta = Encoding.ASCII.GetString(datarecieved);
            if(risposta =="è il tuo turno")
            {
                Attacco a = new Attacco();
                a.Show();
            }

            recieveEP = new IPEndPoint(IPAddress.Any, 0);
            datarecieved = null;
            risposta = Encoding.ASCII.GetString(datarecieved);

            //repaint
            String[] campi = risposta.Split(';');
            int riga=int.Parse(campi[0]);
            int colonna=int.Parse(campi[1]);
            int colpita=int.Parse(campi[2]);

            c.Close();
            n.Close();

            if (colpita == 1)
            {
                MessageBox.Show("Centro!","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if(colpita == 0)
            {
                MessageBox.Show("Acqua!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            nemico.GetCella(riga, colonna).setColpita();
            if (colpita == 1)
            {
                nemico.GetCella(riga,colonna).setBarca();
            }
            
            n=new Nemico(nemico);
            c.Show();
            n.Show();
        }

        public void avversario()
        {
            UdpClient client = new UdpClient();
            IPEndPoint recieveEP = new IPEndPoint(IPAddress.Any, 0);
            byte[] datarecieved = null;

            datarecieved = client.Receive(ref recieveEP);
            String risposta = Encoding.ASCII.GetString(datarecieved);

            String[] campi = risposta.Split(';');
            int riga = int.Parse(campi[0]);
            int colonna = int.Parse(campi[1]);
            int colpita = int.Parse(campi[2]);

            c.Close();
            n.Close();

            if (colpita == 1)
            {
                MessageBox.Show("L'avversario ha fatto centro! ("+riga+";"+colonna+")", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (colpita == 0)
            {
                MessageBox.Show("L'avversario ha fatto acqua! ("+riga+";"+colonna+")", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            campo.GetCella(riga, colonna).setColpita();

            c=new Campo(campo);
            c.Show();
            n.Show();
        }
    }
}

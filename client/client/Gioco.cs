using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace client
{
    internal class Gioco
    {
        List<Barca> barche;
        Matrice campo;
        Matrice nemico;
        Campo c;
        Nemico n;
        int nAffondate;
        UdpClient client;
        public Gioco(Matrice m, List<Barca> barche)
        {
            this.campo = m;
            this.nemico = new Matrice();
            this.c = new Campo(this.campo);
            this.n = new Nemico(this.nemico);
            this.barche = barche;
            this.nAffondate = 0;
            client = new UdpClient();
        }

        public void SendMessage(String messaggio)
        {
            byte[] data = Encoding.ASCII.GetBytes(messaggio);
            client.Send(data, data.Length, "127.0.0.1", 12345);
            Console.WriteLine("messaggio inviato: " + messaggio);
        }
        public async Task<string> RecieveMessage()
        {
            IPEndPoint recieveEP = new IPEndPoint(IPAddress.Any,0);
            byte[] datarecieved = null;
            /**/
            Task t = Task.Factory.StartNew(() =>
            {
                datarecieved = client.Receive(ref recieveEP);
            });
            await t;
            /**/
            //datarecieved = client.Receive(ref recieveEP);
            string risposta = Encoding.ASCII.GetString(datarecieved);
            Console.WriteLine("messaggio ricevuto: " + risposta);
            return risposta;
        }

        public async void pronto()
        {
            SendMessage("pronto");

            string risposta= await RecieveMessage();

            if (risposta == "inizio")
            {
                //invio la matrice al server
                SendMessage(campo.toString());
                //visualizzo finestra di gioco
                c.Show();
                n.Show();
                gioca();
            }
        }

        public async void gioca()
        {
            while (true)
            {
                string risposta = await RecieveMessage();
                if (risposta == "e il tuo turno")
                {
                    await turno();
                }
                else
                {
                    await avversario();
                }
            }
        }

        public async Task<int> turno()
        {
            Attacco a = new Attacco();
            a.Show();

            string risposta = await RecieveMessage();

            //repaint
            String[] campi = risposta.Split(';');
            int riga=int.Parse(campi[0]);
            int colonna=int.Parse(campi[1]);
            int colpita=int.Parse(campi[2]);

            c.Hide();
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

            risposta= await RecieveMessage();
            if(risposta=="fine gioco")
            {
                MessageBox.Show("GAME OVER!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Application.Exit();
            }

            n =new Nemico(nemico);
            c.Show();
            n.Show();
            return 0;
        }

        public async Task<int> avversario()
        {
            string risposta= await RecieveMessage();

            String[] campi = risposta.Split(';');
            int riga = int.Parse(campi[0]);
            int colonna = int.Parse(campi[1]);
            int colpita = int.Parse(campi[2]);

            c.Close();
            n.Hide();

            if (colpita == 1)
            {
                MessageBox.Show("L'avversario ha fatto centro! ("+(riga+1)+";"+(colonna + 1) +")", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                for(int i = 0; i < barche.Count; i++)
                {
                    bool affondata=barche[i].checkAffondata(riga,colonna);
                    if (affondata)
                    {
                        MessageBox.Show("Una barca è stata affondata!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        nAffondate++;
                    }
                }
            }
            else if (colpita == 0)
            {
                MessageBox.Show("L'avversario ha fatto acqua! ("+(riga+1)+";"+(colonna+1)+")", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            campo.GetCella(riga, colonna).setColpita();

            if (nAffondate == barche.Count)
            {
                SendMessage("game over");
            }
            else
            {
                SendMessage("continua");
            }

            risposta = await RecieveMessage();
            if (risposta == "fine gioco")
            {
                MessageBox.Show("GAME OVER!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                client.Close();
                Application.Exit();
            }

            c =new Campo(campo);
            c.Show();
            n.Show();
            return 0;
        }
    }
}

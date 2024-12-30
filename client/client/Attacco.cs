using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Attacco : Form
    {
        public Attacco()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog; //non permette di ridimensionare
        }

        private void buttonAttacca_Click(object sender, EventArgs e)
        {
            if(comboBoxRiga.SelectedItem == null ||
                comboBoxColonna.SelectedItem == null)
            {
                MessageBox.Show("seleziona le coordinate!", "ERRORE!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int riga=int.Parse(comboBoxRiga.SelectedItem.ToString())-1;
            int colonna = int.Parse(comboBoxColonna.SelectedItem.ToString()) - 1;
            string str = riga+";"+colonna;

            UdpClient client = new UdpClient();
            byte[] data = Encoding.ASCII.GetBytes(str);
            client.Send(data, data.Length, "127.0.0.1", 12345);
            this.Close();
        }
    }
}

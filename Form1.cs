using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using SimpleTCP;

namespace TCPESP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;



        }

        private void Client_DataReceived(object sender , SimpleTCP.Message e)
        {
            txtRecebe.Invoke((MethodInvoker)delegate () {

                txtRecebe.Text += e.MessageString;         
            
                       
            });

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            client.Connect(txtHost.Text, Convert.ToInt32(txtPorta.Text));
            btnConectar.Enabled = false;
            btnDesconecta.Enabled = true;
        }




        private void btnDesconecta_Click(object sender, EventArgs e)
        {

            if (client.TcpClient.Connected == true)
            {
                client.Disconnect();

                btnDesconecta.Enabled = false;
                btnConectar.Enabled = true;
            }

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (client.TcpClient.Connected == true)
            {
                client.Write(txtEnvia.Text);

            }

            txtEnvia.Text = "";
        }
    }
}

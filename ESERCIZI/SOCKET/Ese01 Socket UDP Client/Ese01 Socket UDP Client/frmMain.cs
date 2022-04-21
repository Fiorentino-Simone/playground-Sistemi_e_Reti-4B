using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ese01_Socket_UDP_Client
{
    public partial class frmMain : Form
    {
        static Random rnd = new Random();   
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAttivaDisattiva_Click(object sender, EventArgs e)
        {
            timer.Enabled = btnAttivaDisattiva.Text == "ATTIVA CLIENT";
            txtServerIP.Enabled = !timer.Enabled;
            nupServerPort.Enabled = !timer.Enabled;
            btnAttivaDisattiva.Text = (btnAttivaDisattiva.Text == "ATTIVA CLIENT" ? "DISATTIVA CLIENT" : "ATTIVA CLIENT");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //ogni 5 secondi il timer eseguira questa procedura
            try
            {
                ClsUDPClient clsUdpClient;
                clsMessage clsMessage = new clsMessage();
                clsUdpClient = new ClsUDPClient(IPAddress.Parse(txtServerIP.Text),Convert.ToInt32(nupServerPort.Value));
                clsMessage.Messaggio = rnd.Next(1, 100).ToString();
                clsUdpClient.invia(clsMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore generato: ",ex.Message);
            }
        }
    }
}

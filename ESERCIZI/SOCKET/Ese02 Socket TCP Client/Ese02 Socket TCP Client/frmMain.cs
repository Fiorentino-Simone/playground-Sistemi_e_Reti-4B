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

namespace Ese02_Socket_TCP_Client
{
    public partial class frmMain : Form
    {
        private clsTCPClient client; 

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            impostaButton(true);
        }

        private void impostaButton(bool enable)
        {
            btnConnetti.Enabled = enable;
            btnDisconetti.Enabled = !enable;
            btnInvia.Enabled = !enable;
        }

        private void btnConnetti_Click(object sender, EventArgs e)
        {
            impostaButton(false);
            IPAddress ip;
            ip = clsAddress.FindIp(txtIp.Text.ToString());
            client = new clsTCPClient(ip, Convert.ToInt32(nupServerPort.Value));
            client.erroreConnessioneEvent += new erroreConnectionEventHandler(visualizzaErrore);
            client.Connetti();
        }

        private void visualizzaErrore(string msg)
        {
            MessageBox.Show(msg, this.Text);
            impostaButton(true);
        }

        private void btnDisconetti_Click(object sender, EventArgs e)
        {
            impostaButton(true);
            client.Disconnetti();
        }

        private void btnInvia_Click(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate ()
            {
                clsMessage msg;
                //invio dati al server
                client.invia(txtMessaggio.Text.ToString());
                msg = client.ricevi(); //aspettiamo risposta server
                txtMessaggio.Text += "[Data/Ora]" + msg.Ip + ":" + msg.Port + "-" + msg.Messaggio + Environment.NewLine;
            });
        }
    }
}

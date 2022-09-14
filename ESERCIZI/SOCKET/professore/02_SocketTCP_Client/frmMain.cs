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

namespace _02_SocketTCP_Client
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

        private void impostaButton(bool enabled)
        {
            btnStart.Enabled = enabled;
            btnStop.Enabled = !enabled;
            btnInviaMsg.Enabled = !enabled; 
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            ip = clsAddress.findIP(txtServerIP.Text.ToString());
            // istanza socket 
            client = new clsTCPClient(ip, Convert.ToInt32(nudServerPort.Value));
            client.erroreConnessioneEvent += new erroreConnessioneEventHandler(visualizzaErrore); 
            client.connetti();
            impostaButton(false);
        }

        private void visualizzaErrore(string msg)
        {
            MessageBox.Show(msg, this.Text);
            impostaButton(true); 
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            impostaButton(true);
            client.disconnetti(); 
        }

        private void btnInviaMsg_Click(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate () {
                clsMessage msg;
                // Invio dati al server
                client.invia(txtMsgInvio.Text);
                // Aspetto risposta server
                msg = client.ricevi();
                txtMsgRicevuti.Text += "[Data/Ora]" + msg.Ip + ":" + msg.Port + " - " + msg.Messaggio + Environment.NewLine;
            });
        }
    }
}

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

namespace Ese01_Socket_UDP
{
    public partial class frmMain : Form
    {
        clsUDPServer clsServer;

        public frmMain()
        {
            InitializeComponent();
        }
        
        private void frmMain_Load(object sender, EventArgs e)
        {
            clsAddress.FindIp();
            cmbIP.DataSource = clsAddress.ipList;
            dgvSocket.RowHeadersVisible = false;
            dgvSocket.ColumnCount = 3;
            dgvSocket.Columns[0].HeaderText = "IP";
            dgvSocket.Columns[1].HeaderText = "PORT";
            dgvSocket.Columns[2].HeaderText = "MSG";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            cmbIP.Enabled = false;
            clsServer = new clsUDPServer((IPAddress)cmbIP.SelectedItem, Convert.ToInt32(nudPorta.Value));
            clsServer.datiRicevutiEvent += ClsServer_datiRicevutiEvent;
            clsServer.avviaAscolto();
        }

        private void ClsServer_datiRicevutiEvent(clsMessage clsMsg)
        {
            //procedura che si attiva quando ricevremo un messaggio
            //, andando ad avviare il server e procedere all'ascolto

            //il main thread non deve lavorare, perchè fa solo avvio e chiusura

            BeginInvoke((MethodInvoker)delegate()
            {
                dgvSocket.Rows.Insert(0, clsMsg.toArray());
            });
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            clsServer.chiudi();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            cmbIP.Enabled = true;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!btnStart.Enabled) clsServer.chiudi();
        }
    }
}

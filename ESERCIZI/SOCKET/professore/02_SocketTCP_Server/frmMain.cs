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

namespace _02_SocketTCP_Server
{
    public delegate void aggiornaInterfacciaGraficaDatiHandler(clsMessage msg);
    public delegate void aggiornaStatoEventHandler(string msg); 
    public partial class frmMain : Form
    {
        private clsTCPServer server; 
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            clsAddress.findIP();
            cmbServerIP.DataSource = clsAddress.ipList;

            btnStart.Enabled = true;
            btnStop.Enabled = false; 

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
                server.termina(); 
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            server.termina();
            server = null;
            /* Gestione Bottoni */
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            cmbServerIP.Enabled = true; 
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            ip = clsAddress.ipList[cmbServerIP.SelectedIndex];

            server = new clsTCPServer(ip, Convert.ToInt32(nudServerPort.Value));
            server.datiRicevutiEvent += new datiRicevutiEventHandler(datiRicevuti);
            server.erroreConnessioneEvent += new erroreConnessioneEventHandler(visualizzaErrore);
            server.statoConnessioneEvent += new statoConnessioneEventHandler(visualizzaStato); 

            server.avvia();
            /* Gestione Bottoni */
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            cmbServerIP.Enabled = false; 
        }

        private void datiRicevuti(clsMessage msg)
        {
            aggiornaInterfacciaGraficaDatiHandler pt = new aggiornaInterfacciaGraficaDatiHandler(aggiornaGrafica);
            this.Invoke(pt, msg);
            // Server Risponde al Client
            server.invia("ACK");
            // Test Coda Client
            if (MessageBox.Show("Continuo a ricevere dal client?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                server.chiudiConnessione();
        }

        private void aggiornaGrafica(clsMessage msg)
        {
            BeginInvoke((MethodInvoker)delegate () {
                txtMsgRicevuti.Text += msg.Ip + ": " + msg.Port + " - " + msg.Messaggio + Environment.NewLine;
            });
        }

        private void visualizzaErrore(string msg)
        {
            aggiornaStatoEventHandler pt = new aggiornaStatoEventHandler(visualizzaStato);
            this.Invoke(pt, msg); 
        }

        private void visualizzaStato(string msg)
        {
            Console.WriteLine("ERRORE STATO: " + msg);
        }
    }
}

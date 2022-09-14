using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Ese02_Socket_TCP_Server
{
    public delegate void aggiornaInterfacciaGraficaDatiEventHandler(clsMessage msg);
    public delegate void aggiornaStatoEventHandler(string msg); // dobbiamo controllare la connessione

    public partial class frmMain : Form
    {
        private ClsTCPServer server;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            clsAddress.FindIp();
            cmbServer.DataSource = clsAddress.ipList;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
                server.termina();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IPAddress ip = clsAddress.ipList[cmbServer.SelectedIndex];
            server = new ClsTCPServer(ip, Convert.ToInt32(nupServerPort.Value));
            server.datiRicevutiEvent += new datiRicevutiHandler(datiRicevuti);
            server.erroreConnessioneEvent += new erroreConnessioneEventHandler(visualizzaErrore);
            server.statoConnessioneEvent += new statoConnessioneEventHandler(visualizzaStato);


            server.avvia();

            /***GESTION BOTTONI ***/
            btnStart.Enabled = false;
            btnStart.Enabled = true;
            cmbServer.Enabled = false;
        }

        private void visualizzaStato(string msg)
        {
            aggiornaStatoEventHandler aggiornaStato = new aggiornaStatoEventHandler(visualizzaStato);
            Invoke(aggiornaStato, msg);
            //Server Risponde al Client che è andato tutto bene
            server.invia("ACK"); //ACK --> acknowledge
            //Test coda client
            if (MessageBox.Show("Continua a ricevere dal client?",
                "RICEZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                //se è no chiudo la connessione
                server.chiudiConnessione();
            }
        }

        private void visualizzaErrore(string msg)
        {
            Console.WriteLine("ERRORE STATO: " + msg);
        }

        private void datiRicevuti(clsMessage clsMess)
        {
            aggiornaInterfacciaGraficaDatiEventHandler aggInterfaccia = new aggiornaInterfacciaGraficaDatiEventHandler(aggiornaInterfaccia);
        }

        private void aggiornaInterfaccia(clsMessage msg)
        {
            BeginInvoke((MethodInvoker) delegate ()
            {
                txtRisultato.Text += msg.Ip + ": "
                + msg.Port + " - " + msg.Messaggio + Environment.NewLine;
            });   
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            server.termina();
            server = null;

            /***GESTIONE BOTTONI ***/
            btnStart.Enabled = true;
            btnStart.Enabled = false;
            cmbServer.Enabled = true;
        }
    }
}

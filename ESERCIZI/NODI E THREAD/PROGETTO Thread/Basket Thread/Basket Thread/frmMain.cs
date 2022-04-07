using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basket_Thread
{
    public partial class frmMain : Form
    {
        public const int TURNI = 10;
        public const int PALLONE_X = 275; //costante di partenza della palla sull'asse delle X
        public const int GIOCATORI = 2;
        public const int PALLONE_Y = 151; //costante di partenza della palla sull'asse delle Y
        public const int PALLONE_CANESTRO_Y = 347; //costante di fine della palla sull'asse delle Y


        volatile Dictionary<string, int> basketDict = new Dictionary<string, int>(); //uso il dict per gestire i punteggi di ogni giocatore
        volatile Random rnd;
        Thread arbitro;
        Thread[] giocatori;
        volatile object lock_campo = new object();

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAvviaGara_Click(object sender, EventArgs e)
        {
            rnd = new Random();
            
            caricoDict(txtGiocatore1.Text, txtGiocatore2.Text);

            //fare con l'arbitro che gestisce 10 turni e c'è una probabilità del tiro del 33%
            lblGara.Text = basketDict.ElementAt(0) + " VS " + basketDict.ElementAt(1);
            arbitro = new Thread(arbitroThread); //diciamo all'arbitro thread di eseguire quella funzione 
            arbitro.Start();
        }

        private void caricoDict(string atleta_1, string atleta_2)
        {
            
            pulisciTutto();
            basketDict.Add(atleta_1, 0); //ATLETA NOME + PUNTEGGIO [0]
            basketDict.Add(atleta_2, 0);
        }

        private void pulisciTutto()
        {
            basketDict.Clear();
            lblControllo.Text = "";
            lblGara.Text = "";
            lblStatus.Text = "";
            lblTiro.Text = "";
        }

        private void arbitroThread() //--> deve gestire 10 turni
        {
            int turniResidui = TURNI;
            int turno = 0; //contatore 
            while (turniResidui > 0)
            {
                //bisogna scorrere per gli giocatori e andare a farli gareggiare
                setValore(lblTiro, "TURNO: " + (++turno).ToString());
                eseguiGara();
                Thread.Sleep(500); //facciamo aspettare il thread almeno 1 secondo (TRA UN TURNO E L'ALTRO)
                turniResidui--;
            }

            BeginInvoke((MethodInvoker)delegate
            {
                if (basketDict[txtGiocatore1.Text] > basketDict[txtGiocatore2.Text])
                {
                    MessageBox.Show("PARTITA TERMINATA, CON VINCITORE: " + txtGiocatore1.Text);
                }
                else if (basketDict[txtGiocatore1.Text] == basketDict[txtGiocatore2.Text])
                {
                    MessageBox.Show("PARTITA TERMINATA IN PAREGGIO");
                }
                else
                {
                    MessageBox.Show("PARTITA TERMINATA, CON VINCITORE: " + txtGiocatore2.Text);
                }
            });
        }

        private void eseguiGara() //--> deve gestire il numer di partite per turno (2)
        {
            giocatori = new Thread[GIOCATORI];
            for (int i = 0; i < GIOCATORI; i++)
            {
                giocatori[i] = new Thread(garaAtleta);
                giocatori[i].Name = basketDict.ElementAt(i).Key;
                giocatori[i].Start();
            }

            setValore(lblStatus, "PRONTI.....");
            for (int i = 0; i < GIOCATORI; i++)
                giocatori[i].Join(); //deve assicurarsi che abbiano finito
            Thread.Sleep(2000);
        }

        private void garaAtleta(object parametri)
        {            
            //SPIEGAZIONE: 
            // il primo thread che arriva deve giocare, muovendo la palla,
            // l'altro deve aspettarlo (quindi quando uno dei thread deve eseguire delle azioni
            // e gli altri aspettano, questo si identifica come la sezione critica)


            lock (lock_campo) // ogni thread che entra setta a 1 il semaforo quindi ferma gli altri thread 
            {
                Thread.Sleep(500);
                string giocatoreCorrente = Thread.CurrentThread.Name; //ci segnamo il giocatore corrente
                setPos(palla, palla.Location.X, PALLONE_Y); //palla.Location.X ==> uguale a mettere PALLONE_X
                setValore(lblStatus, "VIA!");
                do
                {
                    Thread.Sleep(200); //tempo che serve tra uno spostamento ed un altro
                    setPos(palla, PALLONE_X, palla.Location.Y + rnd.Next(1, 20));
                } while (palla.Location.Y < PALLONE_CANESTRO_Y); //PALLONE_CANESTRO_Y ==> Y finale  

                //dopo aver fatto arrivare la palla a canestro, devo decidere tramite una probabilità del 33% se la palla entra o no nel canestro
                int casuale = rnd.Next(0, 3);
                Console.WriteLine("RND: " + casuale);
                if (casuale==0) //che il giocatore ha fatto gol 
                {
                    basketDict[giocatoreCorrente]++; //aumento il punteggio del giocatore corrente
                    setValore(lblControllo, "IL GIOCATORE " + giocatoreCorrente + " HA FATTO PUNTO!");
                }
                else
                {
                    setValore(lblControllo, "IL GIOCATORE " + giocatoreCorrente + " NON HA FATTO PUNTO!");
                }
            } 

            setValore(lblStatus, "FINE!");
            setPos(palla, PALLONE_X, PALLONE_Y);
            setValore(lblGara, basketDict.ElementAt(0) + " VS " + basketDict.ElementAt(1));
        }

        private void setPos(PictureBox palla, int x, int y)
        {
            BeginInvoke((MethodInvoker)delegate //ogni volta che la si usa parte un thread
            {
                palla.Location = new Point(x, y);
            });
        }

        private void setValore(Label lbl, string msg)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                lbl.Text = msg;
            });
        }
    }
}

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
        public const int PALLONE_X = 275;
        public const int PALLONE_Y = 173;
        //public const int TOTALE_TIRI = 10;
        //public const int PALLONE_CENTRO_X = 369;
        //public const int PALLONE_CENTRO_Y = 247;
        public const int PALLONE_CANESTRO_Y = 347;

        //volatile int[] punteggio = new int[2];
        volatile Dictionary<string, int> AtletaDict = new Dictionary<string, int>(); //the same to use a int vector


        volatile Random rnd;
        volatile bool primoArrivato;
        Thread arbitro;
        Thread[] atleti;
        volatile object lock_campo = new object();

        public const int TURNI = 2;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAvviaGara_Click(object sender, EventArgs e)
        {
            rnd = new Random();
            caricoDict(txtGiocatore1.Text, txtGiocatore2.Text);

            //fare con l'arbitro che gestisce 10 turni e c'è una probabilità del tiro del 33%
            lblGara.Text = AtletaDict.ElementAt(0) + " VS " + AtletaDict.ElementAt(1);
            arbitro = new Thread(arbitroThread); //diciamo all'arbitro thread di eseguire quella funzione 
            arbitro.Start();
        }

        private void caricoDict(string atleta_1, string atleta_2)
        {
            AtletaDict.Add(atleta_1, 0); //ATLETA NOME + PUNTEGGIO
            AtletaDict.Add(atleta_2, 0);
        }

        private void arbitroThread()
        {
            int turniResidui = TURNI;
            int turno = 0;
            while (turniResidui > 0)
            {
                //bisogna scorrere per gli atleti e andare a farli gareggiare
                setValore(lblTiro, "TURNO: " + (++turno).ToString());
                eseguiGara();
                Thread.Sleep(1000); //facciamo aspettare il thread almeno 3 secondi
                turniResidui--;
            }
            MessageBox.Show("PARTITA TERMINATA");
        }

        private void eseguiGara()
        {
            atleti = new Thread[2];
            primoArrivato = false;
            for (int i = 0; i < 2; i++)
            {
                //true nella bool delle lock 
                atleti[i] = new Thread(garaAtleta);
                atleti[i].Name = AtletaDict.ElementAt(i).Key;
                atleti[i].Start(palla);
            }

            setValore(lblStatus, "PRONTI.....");
            for (int i = 0; i < 2; i++)
                atleti[i].Join(); //deve assicurarsi che abbiano finito
            Thread.Sleep(3000);
        }

        private void garaAtleta(object parametri)
        {
            PictureBox pictPalla = (parametri as PictureBox);

            string atleta = Thread.CurrentThread.Name; //ci segnamo l'atleta corrente
            setPos(pictPalla, PALLONE_X, PALLONE_Y);
            Thread.Sleep(2000);
            setValore(lblStatus, "VIA!");
            do
            {
                Thread.Sleep(300);
                setPos(pictPalla, PALLONE_X, pictPalla.Location.Y + rnd.Next(1, 30));
            } while (pictPalla.Location.Y < PALLONE_CANESTRO_Y);

            lock (lock_campo) //il primo thread che arriva entra ed esegue le istruzioni
            {
                //la lock è come un semaforo cioè gestisce la sezione critica
                if (!primoArrivato) //controlliamo con una bool che arrivi solo un thread
                {
                    AtletaDict[atleta]++;//vado ad incrementare il valore del punteggio nel dict
                    setValore(lblControllo, "VINCE: "+atleta);
                    primoArrivato = true;
                }
                else
                {
                    //quelli che hanno perso
                    Console.WriteLine("PERDE NON: " + atleta);
                }
            }

            setValore(lblStatus, "FINE!");
            setPos(pictPalla, pictPalla.Location.X, PALLONE_Y);
            setValore(lblGara, AtletaDict.ElementAt(0) + " VS " + AtletaDict.ElementAt(1));
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

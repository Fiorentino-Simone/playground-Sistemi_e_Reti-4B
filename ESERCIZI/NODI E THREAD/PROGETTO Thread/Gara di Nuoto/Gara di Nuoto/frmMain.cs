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

namespace Gara_di_Nuoto
{
    public partial class frmMain : Form
    {
        volatile object lock_campo=new object();
        volatile Random rnd;
        Thread arbitro;
        Thread[] altBatterie;
        volatile Dictionary<string,int> atleti = new Dictionary<string,int>(); //volatile perchè gestisce thread
        volatile int atletiLetti;
        volatile bool primoArrivato;

        const int BATTERIE = 4;
        const int INIZIO_Y = 15;
        const int INIZIO_CORSIA = 60;
        const int YFINALE = 655;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAvvia_Click(object sender, EventArgs e)
        {
            //caricamento in un dict i partecipanti
            rnd = new Random();
            lblGbEliminati.Text = "";
            lblGbFinalisti.Text = "";
            arbitro = new Thread(arbitroThread); //diciamo all'arbitro thread di eseguire quella funzione 
            arbitro.Start();
        }

        private void arbitroThread() //thread arbitro che serve per gestire le 4 gare, per evitare che partano più gare in simultaneea e per far si che possiamo utilizzare il form nel frattempo che viene fatta l'esecuzione
        {
            int atletiResidui = atletiLetti;
            int turno = 0;
            while (atletiResidui > 0)
            {
                //bisogna scorrere per gli atleti e andare a farli gareggiare
                setValore(lblTurno, "TURNO: " + (++turno).ToString());
                eseguiGara();
                Thread.Sleep(1000); //facciamo aspettare il thread almeno 1 secondo
                atletiResidui -= BATTERIE;
            }
            MessageBox.Show("ELIMINATORIE TERMINATE !!!");

            //ora bisogna dare il via alla fase finale

            setValore(lblGbFinalisti, "");
            for (int i = 0; i < atleti.Count; i++)
            {
                if (atleti.ElementAt(i).Value == 2)
                {
                    atleti[atleti.ElementAt(i).Key] = 1;
                }
            }
            eseguiGara();
        }

        private void eseguiGara(int a=0) //parametro non obligatorio che ci serve per gestire il vincitore
        {
            //il thread arbitro deve prendere i primi 4 partecipanti e poi bisogna usare 4 thread che gestiscono ogni 4 thread
            int posAtl;
            //mi darà il valore estratto intero (posizione nel dictionary)

            altBatterie = new Thread[BATTERIE];
            primoArrivato = false;
            TextBox txtP;
            for (int i = 0; i < BATTERIE; i++)
            {
                txtP = new TextBox();
                txtP = (TextBox)Controls["txtP" + (i + 1).ToString()]; //vado a prendere la textbox in questione
                posAtl = rnd.Next(0, atletiLetti);
                while (atleti.ElementAt(posAtl).Value != 1) //itero finche non trova uno diverso da 0
                {
                    posAtl = rnd.Next(0, atletiLetti);
                }
                atleti[atleti.ElementAt(posAtl).Key] = 0;
                BeginInvoke((MethodInvoker)delegate
                {
                    txtP.Text = atleti.ElementAt(posAtl).Key;
                });
                Thread.Sleep(100);
                //true nella bool delle lock 
                altBatterie[i] = new Thread(garaAtleta);
                altBatterie[i].Name = atleti.ElementAt(posAtl).Key;
                altBatterie[i].Start(txtP); 
                
            }

            setValore(lblStato, "PRONTI.....");
            stampaAtletiResidui();
            for (int i = 0; i < BATTERIE; i++)
                altBatterie[i].Join(); //deve assicurarsi che abbiano finito
            Thread.Sleep(3000);
        }

        private void garaAtleta(object parametri) //perche gli lo passiamo nello start
        {
            TextBox txtAtl=(parametri as TextBox);

            string atleta = txtAtl.Text; //ci segnamo l'atleta corrente
            setPos(txtAtl, txtAtl.Location.X, INIZIO_CORSIA);
            Thread.Sleep(2000);
            setValore(lblStato, "VIA!");
            do
            {
                Thread.Sleep(300);
                setPos(txtAtl, txtAtl.Location.X, txtAtl.Location.Y + rnd.Next(1, 50));
            } while (txtAtl.Location.Y < YFINALE);

            lock (lock_campo) //il primo thread che arriva entra ed esegue le istruzioni
            {
                //la lock è come un semaforo cioè gestisce la sezione critica
                if (!primoArrivato) //controlliamo con una bool che arrivi solo un thread
                {
                    atleti[Thread.CurrentThread.Name] = 2;//vado a mettere il vincitore a 2 dal dict
                    setValore(lblGbFinalisti, lblGbFinalisti.Text + Thread.CurrentThread.Name.ToString() + Environment.NewLine);
                    primoArrivato = true;
                }
                else
                {
                    //quelli che hanno perso
                    setValore(lblGbEliminati, lblGbEliminati.Text + Thread.CurrentThread.Name.ToString() + Environment.NewLine);
                }
            }

            setValore(lblStato, "FINE!");
            setPos(txtAtl, txtAtl.Location.X, INIZIO_Y);
            setValoreTxt(txtAtl, "");
        }

        private void setPos(TextBox txt, int x, int y)
        {
            //si occupera di spostare con le NUOVE coordinate la txt, richiamato da un thread esterno quindi usare i delegate
            BeginInvoke((MethodInvoker)delegate //ogni volta che la si usa parte un thread
            {
                txt.Location = new Point(x, y);
            });
        }


        private void setValore(Label lbl, string msg)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                lbl.Text = msg;
            });
        }

        private void setValoreTxt(TextBox txt, string msg)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                txt.Text = msg;
            });
        }

        #region FUNCTIONS
        private void caricoPartecipanti()
        {
            StreamReader sr = new StreamReader("atleti.txt");
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                lblPartecipanti.Text += line + Environment.NewLine;
                atleti.Add(line, 1); //inizializzo a 1
            }
            sr.Close(); //importante chiudere sempre lo streamReader
            stampaAtletiResidui();
            atletiLetti = atleti.Count;
        }

        private void stampaAtletiResidui()
        {
            //all'inziio non serve il delegate siccome lo usa il main thread ma dopo verra richiamato da un thread quindi serve
            BeginInvoke((MethodInvoker)delegate
            {
                //un altro thread esegue le istruzioni su questa procedura
                lblPartecipanti.Text="";
                foreach (var item in atleti)
                {
                    if (item.Value==1)
                        lblPartecipanti.Text += item.Key.ToString() + Environment.NewLine;
                }
            });
        }
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            caricoPartecipanti();
        }
    }
}

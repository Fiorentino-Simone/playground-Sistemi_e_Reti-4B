using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Torneo
{
    public partial class FrmMain : Form
    {
        volatile object lock_campo = new object(); 
        volatile Random rnd; 
        volatile int squadreLette; //una variabile volatile significa che l'accesso in scrittura e in lettura NON viene gestita dalla cpu ma solo dal thread che ci può accedere
        Thread arbitro;
        Thread[] partite; // Gestore delle partite 
        Dictionary<int, string> associazioni = new Dictionary<int, string>();
        public FrmMain()
        {
            InitializeComponent();
            associazioni.Add(0, "V");
            associazioni.Add(1, "F");
            associazioni.Add(2, "S");
            associazioni.Add(4, "Q");
            associazioni.Add(8, "O");
            // Associazioni relative alle componenti FORM 
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("squadre.txt");
            string line;
            int i = 1; 
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                Controls["txtQ" + (i++).ToString()].Text = line; 
            }
            sr.Close();
            squadreLette = i - 1; 
        }

        private void btnAvvia_Click(object sender, EventArgs e)
        {
            //il programma deve smaltire velocemente l'assegnazione del turno e partita
            rnd = new Random();
            arbitro = new Thread(arbitroThread); 
            arbitro.Start();
        }

        private void arbitroThread()
        {
            //si occupa di fare 3 turni e un ultimo per posizionare il vincitore
            while(squadreLette > 0)
            {
                eseguiTurno(squadreLette/2); //ogni turno si dimezzano di 2
                squadreLette /= 2; 
            }
        }
        private void eseguiTurno(int totalePartite)
        {
            //passa il totale delle partite che giocano nel turno
            int part;
            TextBox[] txtS; 
            partite = new Thread[totalePartite]; //le coppie di squadre che dovranno competere 
            for(int i=0; i<totalePartite*2; i += 2)
            { // 0 - 2 - 4 - 6 
                //Es: per i quarti loro faranno partire 4 thread insieme
                part = i / 2;
                partite[part] = new Thread(avviaPartita); //configuriamo il thread che fa partire la partita 
                txtS = new TextBox[3]; //un vettore di 3 textbox che vanno ad accedere alle textbox (2 delle partite e poi quello del vincitore)
                txtS[0] = (TextBox)Controls["txt" + associazioni[totalePartite] + (i + 1).ToString()];
                txtS[1] = (TextBox)Controls["txt" + associazioni[totalePartite] + (i + 2).ToString()];
                txtS[2] = (TextBox)Controls["txt" + associazioni[totalePartite/2] + (part + 1).ToString()];
                partite[part].Start(txtS);
            }
            for (int i = 0; i < totalePartite; i++)
                partite[i].Join(); //finchè quel turno non è eseguito lui deve aspettare per poi nuovamente ciclare 
        }

        private void avviaPartita(object parametri)
        {
            TextBox txtSq1 = (parametri as TextBox[])[0]; 
            TextBox txtSq2 = (parametri as TextBox[])[1];   
            TextBox txtVincitore = (parametri as TextBox[])[2]; //devo fare il cast con as siccome esso è un oggetto
            string sq1 = txtSq1.Text; 
            string sq2 = txtSq2.Text;
            string vincitore = "";
            int gol1 = 0, gol2 = 0;
            int tempoMin = 0;
            int tempoPerGol; 
            switch (txtSq1.Name[3]) //ci chiediamo in quale turno siamo 
            {
                case 'Q': //quarti
                    tempoMin = 10000; //tempo per svolgere la partita 
                    break;
                case 'S': //semifinale
                    tempoMin = 15000; 
                    break;
                case 'F': //finale
                    tempoMin = 20000; 
                    break;
            }
            Thread.Sleep(rnd.Next(100, 2000)); // Vado a sospendere i thread (4 per i quarti) e aspettano che finisca la partita
            //INIZIO SEZIONE CRITICA
            lock (lock_campo) //il costrutto lock ci evita di usare i semafori binari ma gestisce la SEZIONE CRITICA, cioè un semaforo alla volta (cioè far scendere in campo uno per volta)
            {
                setCampo(sq1, sq2); 
                // 
                while(tempoMin > 0 || gol1 == gol2)
                {
                    tempoPerGol = rnd.Next(500, 1500); //ogni mezzo secondo a secondo e mezzo si fa gol
                    Thread.Sleep(tempoPerGol); //il thread attuale va a dormire il tempo del gol
                    tempoMin -= tempoPerGol; //si riduce il tempo della partita per il tempo del gol
                    //gestendo una probabilità del 50%
                    if (tempoPerGol % 5 == 0) 
                        gol2++;
                    else if(tempoPerGol %5 == 1)
                        gol1++; //dispari
                    //set Campo
                    setCampo(sq1 + " (" + gol1.ToString()+")", sq2 + " ("+gol2.ToString() + ")");

                }
                //fine della partita
                setCampo("", "");
                Thread.Sleep(rnd.Next(100, 800));//facciamo una pausa tra una partita ad un altra 
            }
            //FINE SEZIONE CRITICA
            vincitore = (gol1 > gol2) ? sq1 : sq2; //possiamo farlo anche dopo la sezione critica tanto la partita ormai è finita

            //bisogna riusare la delega perchè senno non funziona siccome è del mainthread
            BeginInvoke((MethodInvoker)delegate ()
            {
                txtPartite.Text += sq1 + "(" + gol1.ToString() + "-" + gol2.ToString() + ")" + sq2 + Environment.NewLine; //per inserire un /n
                txtVincitore.Text = vincitore;
            });
        }

        private void setCampo(string sq1, string sq2)
        {
            BeginInvoke((MethodInvoker)delegate () { //il main thread delega la gestione del testo al fine di dare la possibilità al thread passato di gestire le label
                lblSQ1.Text = sq1;
                lblSQ2.Text = sq2; 
            });
        }
    }
}

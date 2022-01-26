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
    public partial class Form1 : Form
    {
        volatile int nSquadLette; //volatile = non importa la priorita' di accesso da parte dei thread
        volatile Random rnd;
        volatile object lock_campo = new object();

        Thread arbitro;   // avvia le partite
        Thread[] partite; // gestore delle partite
        
        Dictionary<int, string> associazioni = new Dictionary<int, string>();

        public Form1()
        {
            InitializeComponent();
            associazioni.Add(0,"V");
            associazioni.Add(1,"F");
            associazioni.Add(2,"S");
            associazioni.Add(4,"Q");
            associazioni.Add(8,"O");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("squadre.txt");
            string line;
            int i = 1;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                this.Controls["txtSquadQ" + (i++).ToString()].Text = line;
            }
            nSquadLette = i-1;

            sr.Close();
        }

        private void btnAvvia_Click(object sender, EventArgs e)
        {
            rnd = new Random();
            arbitro = new Thread(arbitroThread);
            arbitro.Start();
        }

        private void arbitroThread() //procedura eseguita dal thread parallelo al mainThread
        {
            while(nSquadLette > 0)
            {
                eseguiTurno(nSquadLette/2);
                nSquadLette /= 2;
            }
        }

        private void eseguiTurno(int nPartite)
        {
            int part;
            partite = new Thread[nPartite];
            TextBox[] txtSquad = new TextBox[3];
            for(int i = 0; i < nPartite*2; i += 2)
            {//i = 0 - 2 - 4 - 6
                part = i / 2;
                partite[part] = new Thread(avviaPartita);
                txtSquad[0] = (TextBox)this.Controls["txtSquad" + associazioni[nPartite] + (i + 1)];
                txtSquad[1] = (TextBox)this.Controls["txtSquad" + associazioni[nPartite] + (i + 2)];
                txtSquad[2] = (TextBox)this.Controls["txtSquad" + associazioni[nPartite/2] + (part + 1)];
                partite[part].Start(txtSquad);
            }
            for(int i = 0; i < nPartite; i++)
            {
                partite[i].Join(); //finche tutti i thread del vettore non sono terminati, il programmma e' bloccato in questo cliclo
            }
        }

        private void avviaPartita(object parametri)
        {
            TextBox txtSq1 = (parametri as TextBox[])[0];
            TextBox txtSq2 = (parametri as TextBox[])[1];
            TextBox txtSqV = (parametri as TextBox[])[2];

            string sq1 = txtSq1.Text;
            string sq2 = txtSq2.Text;
            string sqv = "";

            int sq1goal = 0, sq2goal = 0;

            int tempoMin = 0;
            int tempoPetGoal = 0;

            switch (txtSq1.Name[8])
            {
                case 'Q':
                    tempoMin = 100000;
                    break;
                case 'S':
                    tempoMin = 150000;
                    break;
                case 'F':
                    tempoMin = 200000;
                    break;
            }
            Thread.Sleep(rnd.Next(100, 2000));

            lock (lock_campo)
            {
                //zona critica
                setCampo(sq1, sq2);
                while(tempoMin > 0 || sq1goal == sq2goal)
                {
                    tempoPetGoal = rnd.Next(500, 1500);
                    Thread.Sleep(tempoPetGoal);
                    tempoMin -= tempoPetGoal;
                    if (tempoPetGoal % 2 == 0)
                        sq1goal++;
                    else
                        sq2goal++;
                }
                //fine zona critica
            }

        }

        private void setCampo(string sq1, string sq2)
        {
            BeginInvoke((MethodInvoker)delegate() //mandiamo una richiesta al mainThread che gestisce i componenti grafici di andare ad aggiornare le due label
            {
                lblSquad1.Text = sq1;
                lblSquad2.Text = sq2;
            });
        }
    }
}

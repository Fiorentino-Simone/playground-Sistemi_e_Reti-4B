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

namespace Verifica_Thread_B
{
    public partial class FrmMain : Form
    {
        const int PALLA_INIZIO_X = 400;
        const int PALLA_FINE_X = 20;
        const int TIRI = 2;
        const int CORSIE = 4;
         

        volatile Dictionary<string, int> giocatori=new Dictionary<string, int>();
        volatile int totGiocatori;
        volatile int nGioc; //giocatori effettuati dall'utente
        volatile int[] puntiGiocatori; //array parallelo al dict per gestire il punteggoionel file
        object lock_campo=new object();
        Random rnd;
        Thread arbitro;
        Thread[] thArbCampo; //Thread gestori del campo
        Thread[] thCampo; //Giocatore impegnato nella gara

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("giocatori.txt");
            int cnt = 0;
            while (!sr.EndOfStream)
            {
                //sr.ReadLine();
                giocatori.Add(sr.ReadLine(), 0); //tutti i giocatori presenti nel file
                cnt++;
            }
            sr.Close();
            nUDpartecipanti.Maximum = cnt; // Massimo numero numericUpDown
            puntiGiocatori = new int[cnt];
            totGiocatori = cnt;
        }

        private void btnAvvia_Click(object sender, EventArgs e)
        {
            rnd = new Random();
            //recupero partecipanti effettivi
            nGioc = Convert.ToInt32(nUDpartecipanti.Value);
            arbitro = new Thread(gestoreTorneo);
            arbitro.Start();
        }

        private void gestoreTorneo()
        {
            //istruzioni che deve eseguire l'arbitro --> controllare se sono rimasti dei giocatori
            thArbCampo = new Thread[CORSIE];
            //estraggo giocatori partecipanti al torneo
            int posGioc;
            for (int i = 0; i <= nGioc; i++)
            {
                do
                {
                    posGioc = rnd.Next(0, totGiocatori);//totale e non nGioc senno li prende tutti
                } while (giocatori.ElementAt(posGioc).Value == 1);
                giocatori[giocatori.ElementAt(posGioc).Key] = 1;

                //
            }
            stampaPunteggio();

            //configurazione ed avvio thread gestori dei campi
            for (int i = 0; i < CORSIE; i++)
            {
                thArbCampo[i] = new Thread(gestisciCampo);
                thArbCampo[i].Name = (i + 1).ToString();
                thArbCampo[i].Start();
            }

            //bisogna aspettare che tutti e questi 4 arbitri abbiano finito la gara
            for (int i = 0; i < CORSIE; i++)
            {
                thArbCampo[i].Join();
            }

            //calcolo del vincitori
            setLabel(lblEsito, "");
            for (int i = 0; i < puntiGiocatori.Length; i++)
            {
                if (puntiGiocatori[i] == puntiGiocatori.Max())
                {
                    setLabel(lblEsito, lblEsito.Text + Environment.NewLine + giocatori.ElementAt(i).Key);
                }
            }

        }

        private void gestisciCampo()
        {
            //4 Thread eseguono le istruzioni successive
            //controllo e accesso al dict in maniera esculusiva
            int posGioc;
            Label[] lblGioco;
            PictureBox picGio;
            Control[] parametri = new Control[3];
            lock (lock_campo)
            {
                Thread.Sleep(1000);
                if(giocatoriResidui() > 0)
                {
                    do
                    {
                        posGioc = rnd.Next(0, totGiocatori);
                    } while (giocatori.ElementAt(posGioc).Value != 1);
                    giocatori[giocatori.ElementAt(posGioc).Key] = 2; //impostiamo a 2 siccome ora è stato estratto
                    thCampo[Convert.ToInt32(Thread.CurrentThread.Name)-1] = new Thread(Eseguipartita);
                    lblGioco = new Label[2];
                    picGio = new PictureBox();
                    lblGioco[0] = (Label)Controls["lblGioc" + (Thread.CurrentThread.Name)];
                    setLabel(lblGioco[0], giocatori.ElementAt(posGioc).Key);
                    Thread.Sleep(300); //perchè viene creato un altro thread
                    lblGioco[1] = (Label)Controls["lblGioc" + (Thread.CurrentThread.Name)];
                    picGio = (PictureBox)Controls["picB" + (Thread.CurrentThread.Name)];
                    parametri[0] = lblGioco[0];
                    parametri[1] = lblGioco[1];
                    parametri[2] = picGio;

                    thCampo[Convert.ToInt32(Thread.CurrentThread.Name) - 1].Name = posGioc.ToString();
                    thCampo[Convert.ToInt32(Thread.CurrentThread.Name) - 1].Start(parametri);
                }
            }//Accesso bloccato
            thCampo[Convert.ToInt32(Thread.CurrentThread.Name) - 1].Join();
            //JOIN

            if (giocatoriResidui() > 0)
            {
                gestisciCampo();
            }
        }

        private void setLabel(Label label, string msg)
        {
            BeginInvoke((MethodInvoker)delegate ()
            {
                label.Text = msg;
            });
        }

        private void Eseguipartita(object param)
        {
            Label[] lbl = new Label[2];
            PictureBox pic = new PictureBox();
            int punteggio;
            int posGioc;

            lbl[0] = (Label)(param as Control[])[0];
            lbl[1] = (Label)(param as Control[])[1];
            pic = (PictureBox)(param as Control[])[2];

            for (int i = 0; i < TIRI; i++)
            {
                do
                {
                    setPos(pic, pic.Location.X - rnd.Next(10, 20), pic.Location.Y);
                    Thread.Sleep(rnd.Next(10, 50));
                } while (pic.Location.X >= PALLA_FINE_X);
                setPos(pic, PALLA_INIZIO_X, pic.Location.Y);
                punteggio = rnd.Next(0, 10);
                posGioc = Convert.ToInt32(Thread.CurrentThread.Name);
                puntiGiocatori[posGioc] += punteggio;
                setLabel(lbl[1], puntiGiocatori[posGioc].ToString());
            }
        }

        private void setPos(PictureBox pic, int x, int y)
        {
            BeginInvoke((MethodInvoker)delegate ()
            {
                pic.Location = new Point(x, y);
            });
        }

        private int giocatoriResidui()
        {
            int giocRes = 0;
            for (int i = 0; i < giocatori.Count; i++)
            {
                if (giocatori.ElementAt(i).Value == 1)
                {
                    giocRes++;
                }
            }
            return giocRes;
        }

        private void stampaPunteggio()
        {
            BeginInvoke((MethodInvoker)delegate()
            {
                txtPunteggio.Text = "";
                for (int i = 0; i < giocatori.Count; i++)
                {
                    //scorriamo tutto il dict e concateniamo i dati che ci interessano mostrare
                    txtPunteggio.Text += "[" + giocatori.ElementAt(i).Value + "]"
                    + giocatori.ElementAt(i).Key + " : " + puntiGiocatori[i].ToString();
                    txtPunteggio.Text+=Environment.NewLine;
                }
            });
        }
    }
}

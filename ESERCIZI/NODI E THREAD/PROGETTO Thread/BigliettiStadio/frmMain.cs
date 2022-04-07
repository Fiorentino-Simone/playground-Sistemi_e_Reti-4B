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
using System.IO;
namespace BigliettiStadio
{
    public partial class frmMain : Form
    {
        bool isAttentato = false;
        String[] log = new String[4]; //0Nord, 1Sud, 2Est, 3Ovest
        //log[idBiglietteria] += "Cliente: " + cli[pos].idCliente + " ha acquistato un biglietto in posizione: " + postiStadio[rndPos].idPosto.toString();
        const int BIGLIETTERIE = 4;
        object lock_campo = new object();
        object lock_biglietti = new object();
        int totClienti, totPosti;
        volatile Random rnd;
        Label[] labels = new Label[4];
        Thread[] biglietteria;

        public struct Clienti
        {
            public int idCliente;
            public int idBiglietteria; //0Nord, 1Sud, 2Est, 3Ovest
            public bool acquistato;//acquistato= transizione eseguita o meno
            public bool smaltito;//true= se ha cercato di acquistare
        }
        volatile Clienti[] cli;

        public struct PostiStadio
        {
            public int idPosto;
            public bool occupato;
            public int idCliente;
        }
        PostiStadio[] postiStadio;


        public frmMain()
        {
            InitializeComponent();
            labels[0] = labelN;
            labels[1] = labelSud;
            labels[2] = labelE;
            labels[3] = labelO;
        }
        private void BtnAvvia_Click(object sender, EventArgs e)
        {
            Thread t;
            rnd = new Random();
            totClienti = Convert.ToInt32(txtTotClienti.Text);
            totPosti = Convert.ToInt32(txtPostiDisponibili.Text);

            cli = new Clienti[totClienti];
            postiStadio = new PostiStadio[totPosti];

            /* Attivazione gestore principale */
            t = new Thread(gestore);
            t.Start(); 
        }

        private void gestore()
        {
            // Smistamento clienti in tutte le casse disponibili

            setLabel(lblStatus, "Vendita in corso!"); 
            /* 1. Assegnazione casuale cliente-biglietteria */
            for(int i=0; i<cli.Length; i++)
            {
                cli[i].idCliente = (i + 1);
                cli[i].idBiglietteria = rnd.Next(0, 4);
                cli[i].acquistato = false; 
            } // SIMULAZIONE DELLA CODA 
            /* 2. Inizializzazione struttura stadio */
            for(int i=0; i<postiStadio.Length; i++)
            {
                postiStadio[i].idPosto = (i + 1);
                postiStadio[i].idCliente = 0;
                postiStadio[i].occupato = false; 
            }

            /* 3. Attivo le biglietterie */
            biglietteria = new Thread[BIGLIETTERIE]; 
            for(int i=0; i<BIGLIETTERIE; i++)
            {
                biglietteria[i] = new Thread(smaltisciCoda);
                biglietteria[i].Name = i.ToString(); 
                biglietteria[i].Start(); 
            }
            /* 4.  */
            for (int i = 0; i < BIGLIETTERIE; i++)
            {
                biglietteria[i].Join();
            }
            setLabel(lblStatus, "Fine Vendita");
            stampaFile();
        }

        private void smaltisciCoda()
        {
            /* 4 Thread accedono a questa sezione 
             * 1. Individuare punto d'uscita 
             * 2. Individuare sezioni critiche e accessi a medesime risorse 
             */
            int posEstratto = 0;
            int idBiglietteria = Convert.ToInt32(Thread.CurrentThread.Name);
            if (getPostiStadioDisponibili() > 0 && getClientiDisponibili(idBiglietteria) > 0)
            {
                // Procedo con l'estrazione di un cliente (appartenente alla mia cassa) e procedo con il tentativo di acquisto
                do
                {
                    posEstratto = rnd.Next(0, cli.Length);


                } while (cli[posEstratto].idBiglietteria != idBiglietteria ||
                          cli[posEstratto].smaltito == true);
                // Ho in pos la posizione estratta per la cassa attuale
                acquistaBiglietto(posEstratto);
                cli[posEstratto].smaltito = true;
                Console.WriteLine(cli[posEstratto].idBiglietteria.ToString() + " " +
                                    cli[posEstratto].idCliente.ToString());
                Thread.Sleep(1000);


            }
            setLabel(labels[idBiglietteria], getClientiDisponibili(idBiglietteria).ToString());
            setLabel(labelPosti, (getPostiStadioDisponibili() -1).ToString());
            if (getPostiStadioDisponibili() > 1 && getClientiDisponibili(idBiglietteria) > 0)
            {
                smaltisciCoda();
            }
            else
            {
                setLabel(labels[idBiglietteria], "0");
                Thread.CurrentThread.Abort();
            }
        }
        private int getPostiStadioDisponibili()
        {
            lock (lock_campo)
            {
                int cnt = 0;
                for (int i = 0; i < postiStadio.Length; i++)
                    if (postiStadio[i].idCliente == 0)
                        cnt++;
                return cnt;
            }
        }
        private int getClientiDisponibili(int cassa)
        {
            int cnt = 0;
            for (int i = 0; i < cli.Length; i++)
                if (cli[i].idBiglietteria == cassa && cli[i].smaltito == false)
                    cnt++;
            return cnt;
        }
        private int getClientiMorti()
        {
            int cnt = 0;
            for (int i = 0; i < cli.Length; i++)
                if (cli[i].smaltito == false)
                    cnt++;
            return cnt;
        }
        private void acquistaBiglietto(int pos)
        {// 1. Il cliente esegue richiesta di acquisto biglietto
         // 2. Se il posto che si vuole acquistatare è attualmente occupato o già acquistato si prendono strade diverse (es. posto occupato: attendo qualche secondo | posto già acquistato: cerco un'altra postazione o termino 
         // 3. Avvio procedura di vendita: la vendita va a buon fine con una prob. del 75%
         // SE Biglietto VENDUTO
         // SE Biglietto NON VENDUTO
            string aus = null;
            int nBiglietti = rnd.Next(1, 6);
            if (getPostiStadioDisponibili() > nBiglietti) {
                for (int i = 0; i < nBiglietti; i++)
                {
                    int rndPos;
                    do
                    {
                        rndPos = rnd.Next(0, totPosti);
                    } while (postiStadio[rndPos].occupato == true);
                    //nel caso sia disponibile il posto

                    //postiStadio[rndPos].idPosto.ToString() + "\n"
                    

                    lock (lock_biglietti)
                    {
                        //probabilità acquisto 75%
                        int prob = rnd.Next(0, 4);
                        if (prob != 1)
                        {
                            if (aus != null)
                            {
                                aus += ", " + postiStadio[rndPos].idPosto.ToString();
                            }
                            else
                            {
                                aus = postiStadio[rndPos].idPosto.ToString();
                            }
                            cli[pos].acquistato = true;
                            postiStadio[rndPos].occupato = true;
                            postiStadio[rndPos].idCliente = cli[pos].idCliente;
                            
                        }
                    }
                    //Console.WriteLine("Il cliente "+ cl.idCliente + " ha acquistato il posto" + postiStadio[rndPos].idPosto + " // " + contClientiSmaltiti);
                }
            }
            if (aus != null)
            {
                log[cli[pos].idBiglietteria] += "Cliente: " + cli[pos].idCliente + " ha acquistato un biglietto in posizione: " + aus + "\n";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //NORD
            MessageBox.Show(log[0]);
        }

        private void scrivoFile(string fn, int index)
        {
            StreamWriter sw;
            DateTime val;
            val = DateTime.Now;
            sw = new StreamWriter(fn+".txt", true);
            sw.WriteLine("\n"+"Fine vendita biglietti: " + val.ToString() +"\n", true);
            sw.WriteLine(log[index]);
            sw.Flush(); //svuoto buffer
            sw.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //OVEST
            MessageBox.Show(log[3]);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //EST
            MessageBox.Show(log[2]);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //SUD
            MessageBox.Show(log[1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isAttentato = true;
            for (int i = 0; i < BIGLIETTERIE; i++)
            {
                biglietteria[i].Abort();
            }
        }

        private void stampaFile()
        {
            if (isAttentato == false)
            {
                MessageBox.Show("E' possibile visualizzare i log di ogni cassa. Inoltre i vari dati verranno scaricati anche localmente");
            }
            else
            {
                MessageBox.Show("ATTENTATO IN CORSO!" + "\n" + "HANNO PERSO LA VITA: " + getClientiMorti().ToString());

            }
            scrivoFile("nord", 0);
            scrivoFile("sud", 1);
            scrivoFile("est", 2);
            scrivoFile("ovest", 3);
        }

        private void setLabel(Label lbl, string msg)
        {
            BeginInvoke((MethodInvoker)delegate () {
                lbl.Text = msg; 
            }); 
        }
        
    }
}

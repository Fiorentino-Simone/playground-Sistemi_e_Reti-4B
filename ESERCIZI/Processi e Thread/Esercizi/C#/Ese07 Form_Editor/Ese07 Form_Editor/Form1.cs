using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Ese07_Form_Editor
{
    public partial class Form1 : Form
    {
        static Thread tConta, tSalva;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr;
            /* Caricamento del contenuto da file */
            if (!File.Exists("miofile.txt")) File.Create("miofile.txt");

            sr = new StreamReader("miofile.txt");
            rtb.Text = sr.ReadToEnd();
            sr.Close();
            lblCaratteri.Text = "Caratteri: " + rtb.Text.Trim().Length;

            //il conteggio e il salvataggio devono essere gestiti in sezione critica
            tConta = new Thread(avviaConteggio);
            tSalva = new Thread(avviaSalvataggio);
        }

        private void rtb_KeyUp(object sender, KeyEventArgs e)
        {
            //uguale al textChanged semplicemente questo evento viene richiamato quando viene premuto un tasto

            //GESTIONE SEZIONE CRITICA (SALVATAGGIO E CONTEGGIO)
            tConta.Start();
            tSalva.Start();
        }

        private void avviaSalvataggio()
        {
            //salvataggio file
            this.Invoke(new EventHandler(salva));
            
        }

        private void salva(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("miofile.txt");
            sw.Write(rtb.Text); //bisogna passare dai delegated siccome il thread principale al compito di gestire UNIVOCAMENTE tutti gli elementi grafici della pagina.
            sw.Close();
        }

        private void avviaConteggio()
        {
            //conteggio dei caratteri
            this.Invoke(new EventHandler(conta)); //bisogna usare il delegated tramite l'invoke della form
        }

        private void conta(object sender, EventArgs e)
        {
            lblCaratteri.Text = "Caratteri: " + rtb.Text.Trim().Length;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            /* Visualizzo directory contenente il mio file*/

        }
    }
}

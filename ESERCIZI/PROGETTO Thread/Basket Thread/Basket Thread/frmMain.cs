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
        public const int PALLONE_X = 369;
        public const int PALLONE_Y = 59;
        public const int TOTALE_TIRI = 10;
        public const int PALLONE_CENTRO_X = 369;
        public const int PALLONE_CENTRO_Y = 247;
        public const int PALLONE_CANESTRO_Y = 412;

        volatile int[] punteggio = new int[2];
        volatile Random rnd;
        Thread arbitro;
        volatile object lock_campo = new object(); 

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAvviaGara_Click(object sender, EventArgs e)
        {
            string atleta_1 = txtGiocatore1.Text;
            string atleta_2 = txtGiocatore2.Text;

            //fare con l'arbitro che gestisce 10 turni e c'è una probabilità del tiro del 33%
        }
    }
}

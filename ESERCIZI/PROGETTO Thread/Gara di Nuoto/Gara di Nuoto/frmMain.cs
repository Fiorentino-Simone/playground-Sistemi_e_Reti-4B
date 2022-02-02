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

namespace Gara_di_Nuoto
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            caricoPartecipanti();
        }

        private void btnAvvia_Click(object sender, EventArgs e)
        {
            //caricamento in un dict i partecipanti

        }


        #region FUNCTIONS
        private void caricoPartecipanti()
        {
            StreamReader sr = new StreamReader("atleti.txt");
            while (!sr.EndOfStream)
            {
                lblPartecipanti.Text += sr.ReadLine() + Environment.NewLine;
            }
        }
        #endregion
    }
}

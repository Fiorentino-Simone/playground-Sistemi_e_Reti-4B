using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ese02_Socket_TCP_Server
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            clsAddress.FindIp();
            cmbServer.DataSource = clsAddress.ipList;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }
}

namespace Ese02_Socket_TCP_Server
{
    partial class frmMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpIp = new System.Windows.Forms.GroupBox();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.gpPort = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtRisultato = new System.Windows.Forms.TextBox();
            this.gpIp.SuspendLayout();
            this.gpPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // gpIp
            // 
            this.gpIp.Controls.Add(this.cmbServer);
            this.gpIp.Location = new System.Drawing.Point(35, 30);
            this.gpIp.Name = "gpIp";
            this.gpIp.Size = new System.Drawing.Size(200, 100);
            this.gpIp.TabIndex = 0;
            this.gpIp.TabStop = false;
            this.gpIp.Text = "IP";
            // 
            // cmbServer
            // 
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(7, 37);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(187, 24);
            this.cmbServer.TabIndex = 0;
            // 
            // gpPort
            // 
            this.gpPort.Controls.Add(this.numericUpDown1);
            this.gpPort.Location = new System.Drawing.Point(260, 30);
            this.gpPort.Name = "gpPort";
            this.gpPort.Size = new System.Drawing.Size(200, 100);
            this.gpPort.TabIndex = 1;
            this.gpPort.TabStop = false;
            this.gpPort.Text = "PORT";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(7, 37);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            49151,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(172, 22);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Red;
            this.btnStart.Location = new System.Drawing.Point(477, 49);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(143, 59);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = false;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Lime;
            this.btnStop.Location = new System.Drawing.Point(626, 49);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(143, 59);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = false;
            // 
            // txtRisultato
            // 
            this.txtRisultato.Location = new System.Drawing.Point(35, 137);
            this.txtRisultato.Multiline = true;
            this.txtRisultato.Name = "txtRisultato";
            this.txtRisultato.Size = new System.Drawing.Size(425, 256);
            this.txtRisultato.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtRisultato);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gpPort);
            this.Controls.Add(this.gpIp);
            this.Name = "frmMain";
            this.Text = "SERVER TCP";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gpIp.ResumeLayout(false);
            this.gpPort.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpIp;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.GroupBox gpPort;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtRisultato;
    }
}


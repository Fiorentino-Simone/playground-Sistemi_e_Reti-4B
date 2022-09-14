namespace Ese02_Socket_TCP_Client
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
            this.txtRisultato = new System.Windows.Forms.TextBox();
            this.btnConnetti = new System.Windows.Forms.Button();
            this.btnDisconetti = new System.Windows.Forms.Button();
            this.gpPort = new System.Windows.Forms.GroupBox();
            this.nupServerPort = new System.Windows.Forms.NumericUpDown();
            this.gpIp = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInvia = new System.Windows.Forms.Button();
            this.txtMessaggio = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.gpPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupServerPort)).BeginInit();
            this.gpIp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRisultato
            // 
            this.txtRisultato.Location = new System.Drawing.Point(40, 270);
            this.txtRisultato.Multiline = true;
            this.txtRisultato.Name = "txtRisultato";
            this.txtRisultato.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRisultato.Size = new System.Drawing.Size(425, 256);
            this.txtRisultato.TabIndex = 9;
            // 
            // btnConnetti
            // 
            this.btnConnetti.BackColor = System.Drawing.Color.Lime;
            this.btnConnetti.Location = new System.Drawing.Point(478, 62);
            this.btnConnetti.Name = "btnConnetti";
            this.btnConnetti.Size = new System.Drawing.Size(143, 59);
            this.btnConnetti.TabIndex = 8;
            this.btnConnetti.Text = "CONNETTI";
            this.btnConnetti.UseVisualStyleBackColor = false;
            this.btnConnetti.Click += new System.EventHandler(this.btnConnetti_Click);
            // 
            // btnDisconetti
            // 
            this.btnDisconetti.BackColor = System.Drawing.Color.Red;
            this.btnDisconetti.Location = new System.Drawing.Point(478, 141);
            this.btnDisconetti.Name = "btnDisconetti";
            this.btnDisconetti.Size = new System.Drawing.Size(143, 59);
            this.btnDisconetti.TabIndex = 7;
            this.btnDisconetti.Text = "DISCONNETTI";
            this.btnDisconetti.UseVisualStyleBackColor = false;
            this.btnDisconetti.Click += new System.EventHandler(this.btnDisconetti_Click);
            // 
            // gpPort
            // 
            this.gpPort.Controls.Add(this.nupServerPort);
            this.gpPort.Location = new System.Drawing.Point(258, 44);
            this.gpPort.Name = "gpPort";
            this.gpPort.Size = new System.Drawing.Size(200, 100);
            this.gpPort.TabIndex = 6;
            this.gpPort.TabStop = false;
            this.gpPort.Text = "PORT";
            // 
            // nupServerPort
            // 
            this.nupServerPort.Location = new System.Drawing.Point(7, 37);
            this.nupServerPort.Maximum = new decimal(new int[] {
            49151,
            0,
            0,
            0});
            this.nupServerPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nupServerPort.Name = "nupServerPort";
            this.nupServerPort.Size = new System.Drawing.Size(172, 22);
            this.nupServerPort.TabIndex = 0;
            this.nupServerPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // gpIp
            // 
            this.gpIp.Controls.Add(this.txtIp);
            this.gpIp.Location = new System.Drawing.Point(33, 44);
            this.gpIp.Name = "gpIp";
            this.gpIp.Size = new System.Drawing.Size(200, 100);
            this.gpIp.TabIndex = 5;
            this.gpIp.TabStop = false;
            this.gpIp.Text = "IP";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMessaggio);
            this.groupBox1.Controls.Add(this.btnInvia);
            this.groupBox1.Location = new System.Drawing.Point(40, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MESSAGGIO DA INVIARE";
            // 
            // btnInvia
            // 
            this.btnInvia.BackColor = System.Drawing.Color.Lime;
            this.btnInvia.Location = new System.Drawing.Point(303, 65);
            this.btnInvia.Name = "btnInvia";
            this.btnInvia.Size = new System.Drawing.Size(109, 29);
            this.btnInvia.TabIndex = 9;
            this.btnInvia.Text = "INVIA";
            this.btnInvia.UseVisualStyleBackColor = false;
            this.btnInvia.Click += new System.EventHandler(this.btnInvia_Click);
            // 
            // txtMessaggio
            // 
            this.txtMessaggio.Location = new System.Drawing.Point(7, 37);
            this.txtMessaggio.Name = "txtMessaggio";
            this.txtMessaggio.Size = new System.Drawing.Size(390, 22);
            this.txtMessaggio.TabIndex = 10;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(6, 37);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(182, 22);
            this.txtIp.TabIndex = 11;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 550);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtRisultato);
            this.Controls.Add(this.btnConnetti);
            this.Controls.Add(this.btnDisconetti);
            this.Controls.Add(this.gpPort);
            this.Controls.Add(this.gpIp);
            this.Name = "frmMain";
            this.Text = "CLIENT TCP";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gpPort.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupServerPort)).EndInit();
            this.gpIp.ResumeLayout(false);
            this.gpIp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRisultato;
        private System.Windows.Forms.Button btnConnetti;
        private System.Windows.Forms.Button btnDisconetti;
        private System.Windows.Forms.GroupBox gpPort;
        private System.Windows.Forms.NumericUpDown nupServerPort;
        private System.Windows.Forms.GroupBox gpIp;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMessaggio;
        private System.Windows.Forms.Button btnInvia;
    }
}



namespace Gara_di_Nuoto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtP1 = new System.Windows.Forms.TextBox();
            this.txtP2 = new System.Windows.Forms.TextBox();
            this.txtP3 = new System.Windows.Forms.TextBox();
            this.txtP4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPartecipanti = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblStato = new System.Windows.Forms.Label();
            this.gbFinalisti = new System.Windows.Forms.GroupBox();
            this.lblGbFinalisti = new System.Windows.Forms.Label();
            this.gbEliminati = new System.Windows.Forms.GroupBox();
            this.lblGbEliminati = new System.Windows.Forms.Label();
            this.btnAvvia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbFinalisti.SuspendLayout();
            this.gbEliminati.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 47);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(626, 630);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtP1
            // 
            this.txtP1.Location = new System.Drawing.Point(52, 15);
            this.txtP1.Margin = new System.Windows.Forms.Padding(2);
            this.txtP1.Name = "txtP1";
            this.txtP1.Size = new System.Drawing.Size(95, 20);
            this.txtP1.TabIndex = 1;
            // 
            // txtP2
            // 
            this.txtP2.Location = new System.Drawing.Point(207, 15);
            this.txtP2.Margin = new System.Windows.Forms.Padding(2);
            this.txtP2.Name = "txtP2";
            this.txtP2.Size = new System.Drawing.Size(95, 20);
            this.txtP2.TabIndex = 2;
            // 
            // txtP3
            // 
            this.txtP3.Location = new System.Drawing.Point(366, 15);
            this.txtP3.Margin = new System.Windows.Forms.Padding(2);
            this.txtP3.Name = "txtP3";
            this.txtP3.Size = new System.Drawing.Size(95, 20);
            this.txtP3.TabIndex = 3;
            // 
            // txtP4
            // 
            this.txtP4.Location = new System.Drawing.Point(520, 15);
            this.txtP4.Margin = new System.Windows.Forms.Padding(2);
            this.txtP4.Name = "txtP4";
            this.txtP4.Size = new System.Drawing.Size(95, 20);
            this.txtP4.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(659, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "PARTECIPANTI ALLA GARA:";
            // 
            // lblPartecipanti
            // 
            this.lblPartecipanti.AutoSize = true;
            this.lblPartecipanti.Location = new System.Drawing.Point(660, 72);
            this.lblPartecipanti.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPartecipanti.Name = "lblPartecipanti";
            this.lblPartecipanti.Size = new System.Drawing.Size(0, 13);
            this.lblPartecipanti.TabIndex = 6;
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(660, 327);
            this.lblTurno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(77, 13);
            this.lblTurno.TabIndex = 7;
            this.lblTurno.Text = "FASE FINALE:";
            // 
            // lblStato
            // 
            this.lblStato.AutoSize = true;
            this.lblStato.Location = new System.Drawing.Point(660, 356);
            this.lblStato.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(67, 13);
            this.lblStato.TabIndex = 8;
            this.lblStato.Text = "FINE GARA:";
            // 
            // gbFinalisti
            // 
            this.gbFinalisti.Controls.Add(this.lblGbFinalisti);
            this.gbFinalisti.Location = new System.Drawing.Point(663, 384);
            this.gbFinalisti.Margin = new System.Windows.Forms.Padding(2);
            this.gbFinalisti.Name = "gbFinalisti";
            this.gbFinalisti.Padding = new System.Windows.Forms.Padding(2);
            this.gbFinalisti.Size = new System.Drawing.Size(130, 181);
            this.gbFinalisti.TabIndex = 9;
            this.gbFinalisti.TabStop = false;
            this.gbFinalisti.Text = "BATTERIA FINALISTI";
            // 
            // lblGbFinalisti
            // 
            this.lblGbFinalisti.AutoSize = true;
            this.lblGbFinalisti.Location = new System.Drawing.Point(13, 19);
            this.lblGbFinalisti.Name = "lblGbFinalisti";
            this.lblGbFinalisti.Size = new System.Drawing.Size(0, 13);
            this.lblGbFinalisti.TabIndex = 0;
            // 
            // gbEliminati
            // 
            this.gbEliminati.Controls.Add(this.lblGbEliminati);
            this.gbEliminati.Location = new System.Drawing.Point(844, 384);
            this.gbEliminati.Margin = new System.Windows.Forms.Padding(2);
            this.gbEliminati.Name = "gbEliminati";
            this.gbEliminati.Padding = new System.Windows.Forms.Padding(2);
            this.gbEliminati.Size = new System.Drawing.Size(130, 181);
            this.gbEliminati.TabIndex = 10;
            this.gbEliminati.TabStop = false;
            this.gbEliminati.Text = "ELIMINATI";
            // 
            // lblGbEliminati
            // 
            this.lblGbEliminati.AutoSize = true;
            this.lblGbEliminati.Location = new System.Drawing.Point(5, 19);
            this.lblGbEliminati.Name = "lblGbEliminati";
            this.lblGbEliminati.Size = new System.Drawing.Size(0, 13);
            this.lblGbEliminati.TabIndex = 0;
            // 
            // btnAvvia
            // 
            this.btnAvvia.Location = new System.Drawing.Point(797, 586);
            this.btnAvvia.Margin = new System.Windows.Forms.Padding(2);
            this.btnAvvia.Name = "btnAvvia";
            this.btnAvvia.Size = new System.Drawing.Size(85, 31);
            this.btnAvvia.TabIndex = 11;
            this.btnAvvia.Text = "AVVIA";
            this.btnAvvia.UseVisualStyleBackColor = true;
            this.btnAvvia.Click += new System.EventHandler(this.btnAvvia_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 688);
            this.Controls.Add(this.btnAvvia);
            this.Controls.Add(this.gbEliminati);
            this.Controls.Add(this.gbFinalisti);
            this.Controls.Add(this.lblStato);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.lblPartecipanti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtP4);
            this.Controls.Add(this.txtP3);
            this.Controls.Add(this.txtP2);
            this.Controls.Add(this.txtP1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.Text = "GARA DI NUOVO";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbFinalisti.ResumeLayout(false);
            this.gbFinalisti.PerformLayout();
            this.gbEliminati.ResumeLayout(false);
            this.gbEliminati.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtP1;
        private System.Windows.Forms.TextBox txtP2;
        private System.Windows.Forms.TextBox txtP3;
        private System.Windows.Forms.TextBox txtP4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPartecipanti;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.GroupBox gbFinalisti;
        private System.Windows.Forms.GroupBox gbEliminati;
        private System.Windows.Forms.Button btnAvvia;
        private System.Windows.Forms.Label lblGbFinalisti;
        private System.Windows.Forms.Label lblGbEliminati;
    }
}


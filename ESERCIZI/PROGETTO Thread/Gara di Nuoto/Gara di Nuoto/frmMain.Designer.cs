
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAvvia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(627, 626);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtP1
            // 
            this.txtP1.Location = new System.Drawing.Point(31, 25);
            this.txtP1.Name = "txtP1";
            this.txtP1.Size = new System.Drawing.Size(125, 22);
            this.txtP1.TabIndex = 1;
            // 
            // txtP2
            // 
            this.txtP2.Location = new System.Drawing.Point(183, 25);
            this.txtP2.Name = "txtP2";
            this.txtP2.Size = new System.Drawing.Size(125, 22);
            this.txtP2.TabIndex = 2;
            // 
            // txtP3
            // 
            this.txtP3.Location = new System.Drawing.Point(338, 25);
            this.txtP3.Name = "txtP3";
            this.txtP3.Size = new System.Drawing.Size(125, 22);
            this.txtP3.TabIndex = 3;
            // 
            // txtP4
            // 
            this.txtP4.Location = new System.Drawing.Point(495, 25);
            this.txtP4.Name = "txtP4";
            this.txtP4.Size = new System.Drawing.Size(125, 22);
            this.txtP4.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(690, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "PARTECIPANTI ALLA GARA:";
            // 
            // lblPartecipanti
            // 
            this.lblPartecipanti.AutoSize = true;
            this.lblPartecipanti.Location = new System.Drawing.Point(695, 83);
            this.lblPartecipanti.Name = "lblPartecipanti";
            this.lblPartecipanti.Size = new System.Drawing.Size(0, 17);
            this.lblPartecipanti.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(692, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "FASE FINALE:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(692, 440);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "FINE GARA:";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(695, 472);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 223);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BATTERIA FINALISTI";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(884, 472);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 223);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ELIMINATI";
            // 
            // btnAvvia
            // 
            this.btnAvvia.Location = new System.Drawing.Point(944, 702);
            this.btnAvvia.Name = "btnAvvia";
            this.btnAvvia.Size = new System.Drawing.Size(113, 38);
            this.btnAvvia.TabIndex = 11;
            this.btnAvvia.Text = "AVVIA";
            this.btnAvvia.UseVisualStyleBackColor = true;
            this.btnAvvia.Click += new System.EventHandler(this.btnAvvia_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 752);
            this.Controls.Add(this.btnAvvia);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPartecipanti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtP4);
            this.Controls.Add(this.txtP3);
            this.Controls.Add(this.txtP2);
            this.Controls.Add(this.txtP1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmMain";
            this.Text = "GARA DI NUOVO";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAvvia;
    }
}


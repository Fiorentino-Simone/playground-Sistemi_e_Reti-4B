namespace Basket_Thread
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGiocatore1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtGiocatore2 = new System.Windows.Forms.TextBox();
            this.lblTiro = new System.Windows.Forms.Label();
            this.lblGara = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblControllo = new System.Windows.Forms.Label();
            this.btnAvviaGara = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(802, 569);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(313, 378);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(186, 181);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.ErrorImage")));
            this.pictureBox3.Location = new System.Drawing.Point(366, 250);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(73, 56);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGiocatore1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 72);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GIOCATORE 1";
            // 
            // txtGiocatore1
            // 
            this.txtGiocatore1.Location = new System.Drawing.Point(7, 31);
            this.txtGiocatore1.Name = "txtGiocatore1";
            this.txtGiocatore1.Size = new System.Drawing.Size(209, 22);
            this.txtGiocatore1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtGiocatore2);
            this.groupBox2.Location = new System.Drawing.Point(12, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 72);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GIOCATORE 2";
            // 
            // txtGiocatore2
            // 
            this.txtGiocatore2.Location = new System.Drawing.Point(7, 31);
            this.txtGiocatore2.Name = "txtGiocatore2";
            this.txtGiocatore2.Size = new System.Drawing.Size(209, 22);
            this.txtGiocatore2.TabIndex = 0;
            // 
            // lblTiro
            // 
            this.lblTiro.AutoSize = true;
            this.lblTiro.Location = new System.Drawing.Point(363, 30);
            this.lblTiro.Name = "lblTiro";
            this.lblTiro.Size = new System.Drawing.Size(53, 16);
            this.lblTiro.TabIndex = 5;
            this.lblTiro.Text = "[lblTiro]";
            // 
            // lblGara
            // 
            this.lblGara.AutoSize = true;
            this.lblGara.Location = new System.Drawing.Point(363, 49);
            this.lblGara.Name = "lblGara";
            this.lblGara.Size = new System.Drawing.Size(59, 16);
            this.lblGara.TabIndex = 6;
            this.lblGara.Text = "[lblGara]";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(491, 145);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(66, 16);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "[lblStatus]";
            // 
            // lblControllo
            // 
            this.lblControllo.AutoSize = true;
            this.lblControllo.Location = new System.Drawing.Point(494, 453);
            this.lblControllo.Name = "lblControllo";
            this.lblControllo.Size = new System.Drawing.Size(82, 16);
            this.lblControllo.TabIndex = 8;
            this.lblControllo.Text = "[lblControllo]";
            // 
            // btnAvviaGara
            // 
            this.btnAvviaGara.Location = new System.Drawing.Point(19, 159);
            this.btnAvviaGara.Name = "btnAvviaGara";
            this.btnAvviaGara.Size = new System.Drawing.Size(198, 33);
            this.btnAvviaGara.TabIndex = 9;
            this.btnAvviaGara.Text = "AVVIA GARA";
            this.btnAvviaGara.UseVisualStyleBackColor = true;
            this.btnAvviaGara.Click += new System.EventHandler(this.btnAvviaGara_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 571);
            this.Controls.Add(this.btnAvviaGara);
            this.Controls.Add(this.lblControllo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblGara);
            this.Controls.Add(this.lblTiro);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmMain";
            this.Text = "BASKET";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGiocatore1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtGiocatore2;
        private System.Windows.Forms.Label lblTiro;
        private System.Windows.Forms.Label lblGara;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblControllo;
        private System.Windows.Forms.Button btnAvviaGara;
    }
}


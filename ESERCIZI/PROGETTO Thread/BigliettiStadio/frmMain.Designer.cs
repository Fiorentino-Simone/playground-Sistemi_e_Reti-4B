namespace BigliettiStadio
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
            this.btnAvvia = new System.Windows.Forms.Button();
            this.txtPostiDisponibili = new System.Windows.Forms.TextBox();
            this.txtTotClienti = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelN = new System.Windows.Forms.Label();
            this.labelSud = new System.Windows.Forms.Label();
            this.labelE = new System.Windows.Forms.Label();
            this.labelO = new System.Windows.Forms.Label();
            this.labelPosti = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAvvia
            // 
            this.btnAvvia.Location = new System.Drawing.Point(1025, 48);
            this.btnAvvia.Margin = new System.Windows.Forms.Padding(7);
            this.btnAvvia.Name = "btnAvvia";
            this.btnAvvia.Size = new System.Drawing.Size(222, 95);
            this.btnAvvia.TabIndex = 0;
            this.btnAvvia.Text = "AVVIA ACQUISTO";
            this.btnAvvia.UseVisualStyleBackColor = true;
            this.btnAvvia.Click += new System.EventHandler(this.BtnAvvia_Click);
            // 
            // txtPostiDisponibili
            // 
            this.txtPostiDisponibili.Location = new System.Drawing.Point(1164, 277);
            this.txtPostiDisponibili.Margin = new System.Windows.Forms.Padding(7);
            this.txtPostiDisponibili.Name = "txtPostiDisponibili";
            this.txtPostiDisponibili.Size = new System.Drawing.Size(152, 35);
            this.txtPostiDisponibili.TabIndex = 1;
            this.txtPostiDisponibili.Text = "100";
            this.txtPostiDisponibili.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotClienti
            // 
            this.txtTotClienti.Location = new System.Drawing.Point(1164, 334);
            this.txtTotClienti.Margin = new System.Windows.Forms.Padding(7);
            this.txtTotClienti.Name = "txtTotClienti";
            this.txtTotClienti.Size = new System.Drawing.Size(152, 35);
            this.txtTotClienti.TabIndex = 2;
            this.txtTotClienti.Text = "70";
            this.txtTotClienti.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(975, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "POSTI DISPONIBILI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(974, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "CLIENTI:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(976, 206);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(72, 18);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "[lblStatus]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(35, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(921, 632);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.Location = new System.Drawing.Point(500, 133);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(0, 29);
            this.labelN.TabIndex = 7;
            // 
            // labelSud
            // 
            this.labelSud.AutoSize = true;
            this.labelSud.Location = new System.Drawing.Point(500, 459);
            this.labelSud.Name = "labelSud";
            this.labelSud.Size = new System.Drawing.Size(0, 29);
            this.labelSud.TabIndex = 8;
            // 
            // labelE
            // 
            this.labelE.AutoSize = true;
            this.labelE.Location = new System.Drawing.Point(701, 299);
            this.labelE.Name = "labelE";
            this.labelE.Size = new System.Drawing.Size(0, 29);
            this.labelE.TabIndex = 9;
            // 
            // labelO
            // 
            this.labelO.AutoSize = true;
            this.labelO.Location = new System.Drawing.Point(275, 299);
            this.labelO.Name = "labelO";
            this.labelO.Size = new System.Drawing.Size(0, 29);
            this.labelO.TabIndex = 10;
            // 
            // labelPosti
            // 
            this.labelPosti.AutoSize = true;
            this.labelPosti.Location = new System.Drawing.Point(835, 48);
            this.labelPosti.Name = "labelPosti";
            this.labelPosti.Size = new System.Drawing.Size(0, 29);
            this.labelPosti.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nord:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(642, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "Est:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 459);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 29);
            this.label5.TabIndex = 14;
            this.label5.Text = "Sud:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 29);
            this.label6.TabIndex = 15;
            this.label6.Text = "Ovest:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(642, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 29);
            this.label7.TabIndex = 16;
            this.label7.Text = "Biglietti Rimasti:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1010, 580);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(283, 79);
            this.button1.TabIndex = 17;
            this.button1.Text = "ATTENTATO!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 671);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelPosti);
            this.Controls.Add(this.labelO);
            this.Controls.Add(this.labelE);
            this.Controls.Add(this.labelSud);
            this.Controls.Add(this.labelN);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotClienti);
            this.Controls.Add(this.txtPostiDisponibili);
            this.Controls.Add(this.btnAvvia);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VENDITA BIGLIETTI";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAvvia;
        private System.Windows.Forms.TextBox txtPostiDisponibili;
        private System.Windows.Forms.TextBox txtTotClienti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.Label labelSud;
        private System.Windows.Forms.Label labelE;
        private System.Windows.Forms.Label labelO;
        private System.Windows.Forms.Label labelPosti;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}


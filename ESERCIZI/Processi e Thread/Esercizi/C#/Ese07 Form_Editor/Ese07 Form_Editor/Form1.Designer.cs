namespace Ese07_Form_Editor
{
    partial class Form1
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
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.lblCaratteri = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtb
            // 
            this.rtb.Location = new System.Drawing.Point(2, 42);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(796, 396);
            this.rtb.TabIndex = 0;
            this.rtb.Text = "";
            this.rtb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rtb_KeyUp);
            // 
            // lblCaratteri
            // 
            this.lblCaratteri.AutoSize = true;
            this.lblCaratteri.Location = new System.Drawing.Point(13, 23);
            this.lblCaratteri.Name = "lblCaratteri";
            this.lblCaratteri.Size = new System.Drawing.Size(52, 13);
            this.lblCaratteri.TabIndex = 1;
            this.lblCaratteri.Text = "Caratteri: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCaratteri);
            this.Controls.Add(this.rtb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.Label lblCaratteri;
    }
}


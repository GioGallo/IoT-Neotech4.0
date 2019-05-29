namespace Autobus
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
            this.components = new System.ComponentModel.Container();
            this.txtGPS = new System.Windows.Forms.TextBox();
            this.btnPartenza = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnApri = new System.Windows.Forms.Button();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.lblPersone = new System.Windows.Forms.Label();
            this.txtPersone = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtGPS
            // 
            this.txtGPS.Location = new System.Drawing.Point(12, 71);
            this.txtGPS.Multiline = true;
            this.txtGPS.Name = "txtGPS";
            this.txtGPS.ReadOnly = true;
            this.txtGPS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGPS.Size = new System.Drawing.Size(480, 454);
            this.txtGPS.TabIndex = 0;
            // 
            // btnPartenza
            // 
            this.btnPartenza.Location = new System.Drawing.Point(12, 12);
            this.btnPartenza.Name = "btnPartenza";
            this.btnPartenza.Size = new System.Drawing.Size(127, 53);
            this.btnPartenza.TabIndex = 1;
            this.btnPartenza.Text = "Partenza";
            this.btnPartenza.UseVisualStyleBackColor = true;
            this.btnPartenza.Click += new System.EventHandler(this.StartGPS);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(179, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(127, 53);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.StopGPS);
            // 
            // btnApri
            // 
            this.btnApri.Enabled = false;
            this.btnApri.Location = new System.Drawing.Point(498, 183);
            this.btnApri.Name = "btnApri";
            this.btnApri.Size = new System.Drawing.Size(107, 52);
            this.btnApri.TabIndex = 3;
            this.btnApri.Text = "Apri Porte";
            this.btnApri.UseVisualStyleBackColor = true;
            this.btnApri.Click += new System.EventHandler(this.ApriPorta);
            // 
            // btnChiudi
            // 
            this.btnChiudi.Enabled = false;
            this.btnChiudi.Location = new System.Drawing.Point(626, 183);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(107, 52);
            this.btnChiudi.TabIndex = 4;
            this.btnChiudi.Text = "Chiudi Porte";
            this.btnChiudi.UseVisualStyleBackColor = true;
            this.btnChiudi.Click += new System.EventHandler(this.ChiudiPorta);
            // 
            // lblPersone
            // 
            this.lblPersone.AutoSize = true;
            this.lblPersone.Location = new System.Drawing.Point(517, 326);
            this.lblPersone.Name = "lblPersone";
            this.lblPersone.Size = new System.Drawing.Size(115, 17);
            this.lblPersone.TabIndex = 5;
            this.lblPersone.Text = "Persone a Bordo";
            // 
            // txtPersone
            // 
            this.txtPersone.Enabled = false;
            this.txtPersone.Location = new System.Drawing.Point(638, 321);
            this.txtPersone.Name = "txtPersone";
            this.txtPersone.ReadOnly = true;
            this.txtPersone.Size = new System.Drawing.Size(100, 22);
            this.txtPersone.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 537);
            this.Controls.Add(this.txtPersone);
            this.Controls.Add(this.lblPersone);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.btnApri);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPartenza);
            this.Controls.Add(this.txtGPS);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGPS;
        private System.Windows.Forms.Button btnPartenza;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnApri;
        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.Label lblPersone;
        private System.Windows.Forms.TextBox txtPersone;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}


namespace StokTakip
{
    partial class AnaSayfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pAnaSayfa = new Panel();
            btnProje = new Button();
            StkEkle = new Button();
            btnPersonelBilgi = new Button();
            pAnaSayfa.SuspendLayout();
            SuspendLayout();
            // 
            // pAnaSayfa
            // 
            pAnaSayfa.Controls.Add(btnPersonelBilgi);
            pAnaSayfa.Controls.Add(btnProje);
            pAnaSayfa.Controls.Add(StkEkle);
            pAnaSayfa.Dock = DockStyle.Fill;
            pAnaSayfa.Location = new Point(0, 0);
            pAnaSayfa.Name = "pAnaSayfa";
            pAnaSayfa.Size = new Size(1346, 915);
            pAnaSayfa.TabIndex = 0;
            pAnaSayfa.Paint += pAnaSayfa_Paint;
            // 
            // btnProje
            // 
            btnProje.Location = new Point(410, 340);
            btnProje.Name = "btnProje";
            btnProje.Size = new Size(261, 107);
            btnProje.TabIndex = 1;
            btnProje.Text = "Proje";
            btnProje.UseVisualStyleBackColor = true;
            btnProje.Click += btnProje_Click;
            // 
            // StkEkle
            // 
            StkEkle.Location = new Point(44, 340);
            StkEkle.Name = "StkEkle";
            StkEkle.Size = new Size(230, 99);
            StkEkle.TabIndex = 0;
            StkEkle.Text = "Stok Ekle";
            StkEkle.UseVisualStyleBackColor = true;
            StkEkle.Click += StkEkle_Click;
            // 
            // btnPersonelBilgi
            // 
            btnPersonelBilgi.Location = new Point(798, 336);
            btnPersonelBilgi.Name = "btnPersonelBilgi";
            btnPersonelBilgi.Size = new Size(278, 107);
            btnPersonelBilgi.TabIndex = 2;
            btnPersonelBilgi.Text = "Personel";
            btnPersonelBilgi.UseVisualStyleBackColor = true;
            btnPersonelBilgi.Click += btnPersonelBilgi_Click;
            // 
            // AnaSayfa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1346, 915);
            Controls.Add(pAnaSayfa);
            Name = "AnaSayfa";
            Text = "AnaSayfa";
            Load += AnaSayfa_Load;
            pAnaSayfa.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pAnaSayfa;
        private Button StkEkle;
        private Button btnProje;
        private Button btnPersonelBilgi;
    }
}
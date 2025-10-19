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
            btnPersonelBilgi = new Button();
            btnSiparisDetay = new Button();
            btnProjeDetay = new Button();
            btnProje = new Button();
            StkEkle = new Button();
            pAnaSayfa.SuspendLayout();
            SuspendLayout();
            // 
            // pAnaSayfa
            // 
            pAnaSayfa.Controls.Add(btnSiparisDetay);
            pAnaSayfa.Controls.Add(btnProjeDetay);
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
            // btnPersonelBilgi
            // 
            btnPersonelBilgi.Location = new Point(1068, 569);
            btnPersonelBilgi.Name = "btnPersonelBilgi";
            btnPersonelBilgi.Size = new Size(278, 107);
            btnPersonelBilgi.TabIndex = 2;
            btnPersonelBilgi.Text = "Personel";
            btnPersonelBilgi.UseVisualStyleBackColor = true;
            btnPersonelBilgi.Click += btnPersonelBilgi_Click;
            // 
            // btnSiparisDetay
            // 
            btnSiparisDetay.Location = new Point(1068, 59);
            btnSiparisDetay.Name = "btnSiparisDetay";
            btnSiparisDetay.Size = new Size(244, 118);
            btnSiparisDetay.TabIndex = 4;
            btnSiparisDetay.Text = "Sipariş İşlemleri";
            btnSiparisDetay.UseVisualStyleBackColor = true;
            btnSiparisDetay.Click += btnSiparisDetay_Click;
            // 
            // btnProjeDetay
            // 
            btnProjeDetay.Location = new Point(720, 63);
            btnProjeDetay.Name = "btnProjeDetay";
            btnProjeDetay.Size = new Size(278, 114);
            btnProjeDetay.TabIndex = 3;
            btnProjeDetay.Text = "Proje Detayları";
            btnProjeDetay.UseVisualStyleBackColor = true;
            btnProjeDetay.Click += btnProjeDetay_Click;
            // 
            // btnProje
            // 
            btnProje.Location = new Point(356, 59);
            btnProje.Name = "btnProje";
            btnProje.Size = new Size(261, 107);
            btnProje.TabIndex = 1;
            btnProje.Text = "Proje Oluştur";
            btnProje.UseVisualStyleBackColor = true;
            btnProje.Click += btnProje_Click;
            // 
            // StkEkle
            // 
            StkEkle.Location = new Point(47, 63);
            StkEkle.Name = "StkEkle";
            StkEkle.Size = new Size(230, 99);
            StkEkle.TabIndex = 0;
            StkEkle.Text = "Stok Ekle";
            StkEkle.UseVisualStyleBackColor = true;
            StkEkle.Click += StkEkle_Click;
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
        private Button btnSiparisDetay;
        private Button btnProjeDetay;
        private Button btnPersonelBilgi;
        private Button btnProje;
        private Button StkEkle;
    }
}
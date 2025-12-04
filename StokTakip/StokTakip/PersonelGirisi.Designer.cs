namespace StokTakip
{
    partial class PersonelGirisi
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
            lblPersonelEkle = new Label();
            label1 = new Label();
            label2 = new Label();
            tBPrsnlEposta = new TextBox();
            tBPrsnlSifre = new TextBox();
            PrsnlGiris = new Button();
            label3 = new Label();
            pnlPrslEkle = new Panel();
            SuspendLayout();
            // 
            // lblPersonelEkle
            // 
            lblPersonelEkle.AutoSize = true;
            lblPersonelEkle.Font = new Font("Yu Gothic UI Semibold", 9F);
            lblPersonelEkle.Location = new Point(688, 73);
            lblPersonelEkle.Name = "lblPersonelEkle";
            lblPersonelEkle.Size = new Size(100, 20);
            lblPersonelEkle.TabIndex = 0;
            lblPersonelEkle.Text = "Personel Ekle";
            lblPersonelEkle.Click += lblPersonelEkle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI Semibold", 10F);
            label1.Location = new Point(166, 152);
            label1.Name = "label1";
            label1.Size = new Size(72, 23);
            label1.TabIndex = 1;
            label1.Text = "E-posta:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI Semibold", 10F);
            label2.Location = new Point(166, 223);
            label2.Name = "label2";
            label2.Size = new Size(50, 23);
            label2.TabIndex = 2;
            label2.Text = "Şifre:";
            // 
            // tBPrsnlEposta
            // 
            tBPrsnlEposta.Location = new Point(265, 152);
            tBPrsnlEposta.Multiline = true;
            tBPrsnlEposta.Name = "tBPrsnlEposta";
            tBPrsnlEposta.Size = new Size(160, 27);
            tBPrsnlEposta.TabIndex = 3;
            // 
            // tBPrsnlSifre
            // 
            tBPrsnlSifre.Location = new Point(265, 226);
            tBPrsnlSifre.Multiline = true;
            tBPrsnlSifre.Name = "tBPrsnlSifre";
            tBPrsnlSifre.Size = new Size(160, 27);
            tBPrsnlSifre.TabIndex = 4;
            // 
            // PrsnlGiris
            // 
            PrsnlGiris.Font = new Font("Yu Gothic UI Semibold", 9F);
            PrsnlGiris.Location = new Point(588, 329);
            PrsnlGiris.Name = "PrsnlGiris";
            PrsnlGiris.Size = new Size(117, 45);
            PrsnlGiris.TabIndex = 5;
            PrsnlGiris.Text = "Giriş Yap";
            PrsnlGiris.UseVisualStyleBackColor = true;
            PrsnlGiris.Click += PrsnlGiris_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI Semibold", 15F);
            label3.Location = new Point(265, 21);
            label3.Name = "label3";
            label3.Size = new Size(179, 35);
            label3.TabIndex = 6;
            label3.Text = "Personel Girişi";
            // 
            // pnlPrslEkle
            // 
            pnlPrslEkle.BackgroundImage = global::StokTakip.Properties.Resources.personelekle;
            pnlPrslEkle.BackgroundImageLayout = ImageLayout.None;
            pnlPrslEkle.Location = new Point(702, 13);
            pnlPrslEkle.Name = "pnlPrslEkle";
            pnlPrslEkle.Size = new Size(52, 57);
            pnlPrslEkle.TabIndex = 7;
            // 
            // PersonelGirisi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = global::StokTakip.Properties.Resources.arkaplan;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlPrslEkle);
            Controls.Add(label3);
            Controls.Add(PrsnlGiris);
            Controls.Add(tBPrsnlSifre);
            Controls.Add(tBPrsnlEposta);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblPersonelEkle);
            DoubleBuffered = true;
            Name = "PersonelGirisi";
            Text = "Personel Giriş Sayfası";
            Load += PersonelGirisi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPersonelEkle;
        private Label label1;
        private Label label2;
        private TextBox tBPrsnlEposta;
        private TextBox tBPrsnlSifre;
        private Button PrsnlGiris;
        private Label label3;
        private Panel pnlPrslEkle;
    }
}
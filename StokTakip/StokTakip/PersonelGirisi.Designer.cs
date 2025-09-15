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
            SuspendLayout();
            // 
            // lblPersonelEkle
            // 
            lblPersonelEkle.AutoSize = true;
            lblPersonelEkle.Location = new Point(661, 21);
            lblPersonelEkle.Name = "lblPersonelEkle";
            lblPersonelEkle.Size = new Size(95, 20);
            lblPersonelEkle.TabIndex = 0;
            lblPersonelEkle.Text = "Personel Ekle";
            lblPersonelEkle.Click += lblPersonelEkle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(119, 171);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 1;
            label1.Text = "Personel E-posta:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(119, 214);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 2;
            label2.Text = "Personel Sifre:";
            // 
            // tBPrsnlEposta
            // 
            tBPrsnlEposta.Location = new Point(259, 164);
            tBPrsnlEposta.Name = "tBPrsnlEposta";
            tBPrsnlEposta.Size = new Size(160, 27);
            tBPrsnlEposta.TabIndex = 3;
            // 
            // tBPrsnlSifre
            // 
            tBPrsnlSifre.Location = new Point(247, 211);
            tBPrsnlSifre.Name = "tBPrsnlSifre";
            tBPrsnlSifre.Size = new Size(172, 27);
            tBPrsnlSifre.TabIndex = 4;
            // 
            // PrsnlGiris
            // 
            PrsnlGiris.Location = new Point(588, 329);
            PrsnlGiris.Name = "PrsnlGiris";
            PrsnlGiris.Size = new Size(112, 38);
            PrsnlGiris.TabIndex = 5;
            PrsnlGiris.Text = "Giriş Yap";
            PrsnlGiris.UseVisualStyleBackColor = true;
            PrsnlGiris.Click += PrsnlGiris_Click;
            // 
            // PersonelGirisi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PrsnlGiris);
            Controls.Add(tBPrsnlSifre);
            Controls.Add(tBPrsnlEposta);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblPersonelEkle);
            Name = "PersonelGirisi";
            Text = "PersonelGirisi";
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
    }
}
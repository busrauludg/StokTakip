namespace StokTakip
{
    partial class PersonelEkle
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
            lblPrsAd = new Label();
            lblPrsSoyadı = new Label();
            lblPrsGorev = new Label();
            lblPrsSifre = new Label();
            lblSifreTekrari = new Label();
            lblPrsRol = new Label();
            tBPrsAdi = new TextBox();
            tBPrsSoyadi = new TextBox();
            tBPrsGorev = new TextBox();
            tBPrsSifre = new TextBox();
            tBSifreTekrari = new TextBox();
            rBPrsYetkili = new RadioButton();
            rBPrsPersonel = new RadioButton();
            tBYetkiliSifre = new TextBox();
            lblYetkiliSifre = new Label();
            btnPersonelKayit = new Button();
            SuspendLayout();
            // 
            // lblPrsAd
            // 
            lblPrsAd.AutoSize = true;
            lblPrsAd.Location = new Point(130, 99);
            lblPrsAd.Name = "lblPrsAd";
            lblPrsAd.Size = new Size(94, 20);
            lblPrsAd.TabIndex = 0;
            lblPrsAd.Text = "Personel Adı:";
            // 
            // lblPrsSoyadı
            // 
            lblPrsSoyadı.AutoSize = true;
            lblPrsSoyadı.Location = new Point(130, 165);
            lblPrsSoyadı.Name = "lblPrsSoyadı";
            lblPrsSoyadı.Size = new Size(116, 20);
            lblPrsSoyadı.TabIndex = 1;
            lblPrsSoyadı.Text = "Personel Soyadı:";
            // 
            // lblPrsGorev
            // 
            lblPrsGorev.AutoSize = true;
            lblPrsGorev.Location = new Point(130, 241);
            lblPrsGorev.Name = "lblPrsGorev";
            lblPrsGorev.Size = new Size(114, 20);
            lblPrsGorev.TabIndex = 2;
            lblPrsGorev.Text = "Personel Görevi:";
            // 
            // lblPrsSifre
            // 
            lblPrsSifre.AutoSize = true;
            lblPrsSifre.Location = new Point(130, 313);
            lblPrsSifre.Name = "lblPrsSifre";
            lblPrsSifre.Size = new Size(111, 20);
            lblPrsSifre.TabIndex = 3;
            lblPrsSifre.Text = "Personel Şifresi:";
            // 
            // lblSifreTekrari
            // 
            lblSifreTekrari.AutoSize = true;
            lblSifreTekrari.Location = new Point(130, 378);
            lblSifreTekrari.Name = "lblSifreTekrari";
            lblSifreTekrari.Size = new Size(90, 20);
            lblSifreTekrari.TabIndex = 4;
            lblSifreTekrari.Text = "Şifre Tekrarı:";
            // 
            // lblPrsRol
            // 
            lblPrsRol.AutoSize = true;
            lblPrsRol.Location = new Point(130, 441);
            lblPrsRol.Name = "lblPrsRol";
            lblPrsRol.Size = new Size(34, 20);
            lblPrsRol.TabIndex = 5;
            lblPrsRol.Text = "Rol:";
            // 
            // tBPrsAdi
            // 
            tBPrsAdi.Location = new Point(252, 96);
            tBPrsAdi.Name = "tBPrsAdi";
            tBPrsAdi.Size = new Size(195, 27);
            tBPrsAdi.TabIndex = 6;
            // 
            // tBPrsSoyadi
            // 
            tBPrsSoyadi.Location = new Point(252, 158);
            tBPrsSoyadi.Name = "tBPrsSoyadi";
            tBPrsSoyadi.Size = new Size(195, 27);
            tBPrsSoyadi.TabIndex = 7;
            // 
            // tBPrsGorev
            // 
            tBPrsGorev.Location = new Point(252, 234);
            tBPrsGorev.Name = "tBPrsGorev";
            tBPrsGorev.Size = new Size(195, 27);
            tBPrsGorev.TabIndex = 8;
            // 
            // tBPrsSifre
            // 
            tBPrsSifre.Location = new Point(252, 306);
            tBPrsSifre.Name = "tBPrsSifre";
            tBPrsSifre.Size = new Size(195, 27);
            tBPrsSifre.TabIndex = 9;
            // 
            // tBSifreTekrari
            // 
            tBSifreTekrari.Location = new Point(252, 371);
            tBSifreTekrari.Name = "tBSifreTekrari";
            tBSifreTekrari.Size = new Size(195, 27);
            tBSifreTekrari.TabIndex = 10;
            // 
            // rBPrsYetkili
            // 
            rBPrsYetkili.AutoSize = true;
            rBPrsYetkili.Location = new Point(195, 437);
            rBPrsYetkili.Name = "rBPrsYetkili";
            rBPrsYetkili.Size = new Size(69, 24);
            rBPrsYetkili.TabIndex = 12;
            rBPrsYetkili.TabStop = true;
            rBPrsYetkili.Text = "Yetkili";
            rBPrsYetkili.UseVisualStyleBackColor = true;
            rBPrsYetkili.CheckedChanged += rBPrsYetkili_CheckedChanged;
            // 
            // rBPrsPersonel
            // 
            rBPrsPersonel.AutoSize = true;
            rBPrsPersonel.Location = new Point(314, 437);
            rBPrsPersonel.Name = "rBPrsPersonel";
            rBPrsPersonel.Size = new Size(85, 24);
            rBPrsPersonel.TabIndex = 13;
            rBPrsPersonel.TabStop = true;
            rBPrsPersonel.Text = "Personel";
            rBPrsPersonel.UseVisualStyleBackColor = true;
            // 
            // tBYetkiliSifre
            // 
            tBYetkiliSifre.Location = new Point(252, 481);
            tBYetkiliSifre.Name = "tBYetkiliSifre";
            tBYetkiliSifre.Size = new Size(204, 27);
            tBYetkiliSifre.TabIndex = 14;
            // 
            // lblYetkiliSifre
            // 
            lblYetkiliSifre.AutoSize = true;
            lblYetkiliSifre.Location = new Point(125, 488);
            lblYetkiliSifre.Name = "lblYetkiliSifre";
            lblYetkiliSifre.Size = new Size(95, 20);
            lblYetkiliSifre.TabIndex = 15;
            lblYetkiliSifre.Text = "Yetkili Şifresi:";
            // 
            // btnPersonelKayit
            // 
            btnPersonelKayit.Location = new Point(757, 526);
            btnPersonelKayit.Name = "btnPersonelKayit";
            btnPersonelKayit.Size = new Size(128, 52);
            btnPersonelKayit.TabIndex = 16;
            btnPersonelKayit.Text = "Kaydet";
            btnPersonelKayit.UseVisualStyleBackColor = true;
            // 
            // PersonelEkle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 653);
            Controls.Add(btnPersonelKayit);
            Controls.Add(lblYetkiliSifre);
            Controls.Add(tBYetkiliSifre);
            Controls.Add(rBPrsPersonel);
            Controls.Add(rBPrsYetkili);
            Controls.Add(tBSifreTekrari);
            Controls.Add(tBPrsSifre);
            Controls.Add(tBPrsGorev);
            Controls.Add(tBPrsSoyadi);
            Controls.Add(tBPrsAdi);
            Controls.Add(lblPrsRol);
            Controls.Add(lblSifreTekrari);
            Controls.Add(lblPrsSifre);
            Controls.Add(lblPrsGorev);
            Controls.Add(lblPrsSoyadı);
            Controls.Add(lblPrsAd);
            Name = "PersonelEkle";
            Text = "PersonelEkle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPrsAd;
        private Label lblPrsSoyadı;
        private Label lblPrsGorev;
        private Label lblPrsSifre;
        private Label lblSifreTekrari;
        private Label lblPrsRol;
        private TextBox tBPrsAdi;
        private TextBox tBPrsSoyadi;
        private TextBox tBPrsGorev;
        private TextBox tBPrsSifre;
        private TextBox tBSifreTekrari;
        private CheckBox checkBox1;
        private RadioButton rBPrsYetkili;
        private RadioButton rBPrsPersonel;
        private TextBox tBYetkiliSifre;
        private Label lblYetkiliSifre;
        private Button btnPersonelKayit;
    }
}
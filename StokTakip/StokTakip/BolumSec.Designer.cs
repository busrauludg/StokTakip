namespace StokTakip
{
    partial class BolumSec
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
            label1 = new Label();
            tbCBolumSec = new TabControl();
            tabPage1 = new TabPage();
            lVMekanikListesi = new ListView();
            tabPage2 = new TabPage();
            lVlElektrikListesi = new ListView();
            tabPage3 = new TabPage();
            btnSiparisİslem = new Button();
            btnProjeDetay = new Button();
            pStokEkle = new Panel();
            btnProjeOlustur = new Button();
            btnStokEkle = new Button();
            btnPersonelİslem = new Button();
            tbCBolumSec.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(846, 28);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 2;
            label1.Text = "Ana Sayfa";
            label1.Click += label1_Click;
            // 
            // tbCBolumSec
            // 
            tbCBolumSec.Controls.Add(tabPage1);
            tbCBolumSec.Controls.Add(tabPage2);
            tbCBolumSec.Controls.Add(tabPage3);
            tbCBolumSec.Location = new Point(2, 1);
            tbCBolumSec.Name = "tbCBolumSec";
            tbCBolumSec.SelectedIndex = 0;
            tbCBolumSec.Size = new Size(1743, 958);
            tbCBolumSec.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lVMekanikListesi);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1735, 925);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Mekanik Ürün Listesi";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lVMekanikListesi
            // 
            lVMekanikListesi.Dock = DockStyle.Fill;
            lVMekanikListesi.Location = new Point(3, 3);
            lVMekanikListesi.Name = "lVMekanikListesi";
            lVMekanikListesi.Size = new Size(1729, 919);
            lVMekanikListesi.TabIndex = 1;
            lVMekanikListesi.UseCompatibleStateImageBehavior = false;
            lVMekanikListesi.DoubleClick += lVMekanikListesi_DoubleClick;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(lVlElektrikListesi);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1735, 925);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Elektrik Ürün Listesi";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // lVlElektrikListesi
            // 
            lVlElektrikListesi.Dock = DockStyle.Fill;
            lVlElektrikListesi.Location = new Point(3, 3);
            lVlElektrikListesi.Name = "lVlElektrikListesi";
            lVlElektrikListesi.Size = new Size(1729, 919);
            lVlElektrikListesi.TabIndex = 2;
            lVlElektrikListesi.UseCompatibleStateImageBehavior = false;
            lVlElektrikListesi.DoubleClick += lVlElektrikListesi_DoubleClick;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnPersonelİslem);
            tabPage3.Controls.Add(btnSiparisİslem);
            tabPage3.Controls.Add(btnProjeDetay);
            tabPage3.Controls.Add(pStokEkle);
            tabPage3.Controls.Add(btnProjeOlustur);
            tabPage3.Controls.Add(btnStokEkle);
            tabPage3.Controls.Add(label1);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1735, 925);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Ana Sayfa";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnSiparisİslem
            // 
            btnSiparisİslem.Location = new Point(442, 0);
            btnSiparisİslem.Name = "btnSiparisİslem";
            btnSiparisİslem.Size = new Size(123, 48);
            btnSiparisİslem.TabIndex = 7;
            btnSiparisİslem.Text = "Sipariş İşlemleri";
            btnSiparisİslem.UseVisualStyleBackColor = true;
            btnSiparisİslem.Click += btnSiparisİslem_Click;
            // 
            // btnProjeDetay
            // 
            btnProjeDetay.Location = new Point(305, 0);
            btnProjeDetay.Name = "btnProjeDetay";
            btnProjeDetay.Size = new Size(104, 48);
            btnProjeDetay.TabIndex = 6;
            btnProjeDetay.Text = "Proje Detayları";
            btnProjeDetay.UseVisualStyleBackColor = true;
            btnProjeDetay.Click += btnProjeDetay_Click;
            // 
            // pStokEkle
            // 
            pStokEkle.Location = new Point(0, 72);
            pStokEkle.Name = "pStokEkle";
            pStokEkle.Size = new Size(1721, 803);
            pStokEkle.TabIndex = 5;
            // 
            // btnProjeOlustur
            // 
            btnProjeOlustur.Location = new Point(168, 0);
            btnProjeOlustur.Name = "btnProjeOlustur";
            btnProjeOlustur.Size = new Size(112, 48);
            btnProjeOlustur.TabIndex = 4;
            btnProjeOlustur.Text = "Proje Oluştur";
            btnProjeOlustur.UseVisualStyleBackColor = true;
            btnProjeOlustur.Click += btnProjeOlustur_Click;
            // 
            // btnStokEkle
            // 
            btnStokEkle.Location = new Point(43, 0);
            btnStokEkle.Name = "btnStokEkle";
            btnStokEkle.Size = new Size(106, 48);
            btnStokEkle.TabIndex = 3;
            btnStokEkle.Text = "Stok Ekle";
            btnStokEkle.UseVisualStyleBackColor = true;
            btnStokEkle.Click += btnStokEkle_Click;
            // 
            // btnPersonelİslem
            // 
            btnPersonelİslem.Location = new Point(601, 0);
            btnPersonelİslem.Name = "btnPersonelİslem";
            btnPersonelİslem.Size = new Size(123, 48);
            btnPersonelİslem.TabIndex = 8;
            btnPersonelİslem.Text = "Personel";
            btnPersonelİslem.UseVisualStyleBackColor = true;
            btnPersonelİslem.Click += btnPersonelİslem_Click;
            // 
            // BolumSec
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1742, 893);
            Controls.Add(tbCBolumSec);
            Name = "BolumSec";
            Text = "Ürünler";
            Load += BolumSec_Load;
            tbCBolumSec.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private TabControl tbCBolumSec;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private ListView lVMekanikListesi;
        private ListView lVlElektrikListesi;
        private Button btnProjeOlustur;
        private Button btnStokEkle;
        private Panel pStokEkle;
        private Button btnSiparisİslem;
        private Button btnProjeDetay;
        private Button btnPersonelİslem;
    }
}
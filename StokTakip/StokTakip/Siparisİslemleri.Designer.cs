namespace StokTakip
{
    partial class Siparisİslemleri
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
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            pARA = new Panel();
            cBUrunAra = new ComboBox();
            btnUrunAra = new Button();
            label3 = new Label();
            label2 = new Label();
            lVlSiparisListesi = new ListView();
            tabPage2 = new TabPage();
            panel1 = new Panel();
            tBTpMaliyet = new TextBox();
            label1 = new Label();
            dTPSiparisTarihi = new DateTimePicker();
            label12 = new Label();
            nudMiktar = new NumericUpDown();
            label11 = new Label();
            cBSiparisAdi = new ComboBox();
            label10 = new Label();
            btnSiparisKayit = new Button();
            tBAciklama = new TextBox();
            tBSiparisiGirenPersonel = new TextBox();
            cBParaBirimi = new ComboBox();
            tBKur = new TextBox();
            tBBirimFiyat = new TextBox();
            tBSiparisVerilenFirmaAdi = new TextBox();
            label9 = new Label();
            label7 = new Label();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            cMSPrjListe = new ContextMenuStrip(components);
            silToolStripMenuItem = new ToolStripMenuItem();
            düzenleToolStripMenuItem = new ToolStripMenuItem();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            pARA.SuspendLayout();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMiktar).BeginInit();
            cMSPrjListe.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(3, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1767, 779);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(pARA);
            tabPage1.Controls.Add(lVlSiparisListesi);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1759, 746);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Sipariş Listesi ";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // pARA
            // 
            pARA.Controls.Add(cBUrunAra);
            pARA.Controls.Add(btnUrunAra);
            pARA.Controls.Add(label3);
            pARA.Controls.Add(label2);
            pARA.Location = new Point(1426, 6);
            pARA.Name = "pARA";
            pARA.Size = new Size(330, 261);
            pARA.TabIndex = 2;
            // 
            // cBUrunAra
            // 
            cBUrunAra.FormattingEnabled = true;
            cBUrunAra.Location = new Point(70, 103);
            cBUrunAra.Name = "cBUrunAra";
            cBUrunAra.Size = new Size(151, 28);
            cBUrunAra.TabIndex = 4;
            // 
            // btnUrunAra
            // 
            btnUrunAra.Location = new Point(129, 173);
            btnUrunAra.Name = "btnUrunAra";
            btnUrunAra.Size = new Size(109, 33);
            btnUrunAra.TabIndex = 3;
            btnUrunAra.Text = "Ürün Ara";
            btnUrunAra.UseVisualStyleBackColor = true;
            btnUrunAra.Click += btnUrunAra_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(16, 58);
            label3.Name = "label3";
            label3.Size = new Size(127, 23);
            label3.TabIndex = 1;
            label3.Text = "Ürün adı giriniz";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(43, 0);
            label2.Name = "label2";
            label2.Size = new Size(133, 35);
            label2.TabIndex = 0;
            label2.Text = "Sipariş Ara";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lVlSiparisListesi
            // 
            lVlSiparisListesi.Dock = DockStyle.Fill;
            lVlSiparisListesi.Location = new Point(3, 3);
            lVlSiparisListesi.Name = "lVlSiparisListesi";
            lVlSiparisListesi.Size = new Size(1753, 740);
            lVlSiparisListesi.TabIndex = 1;
            lVlSiparisListesi.UseCompatibleStateImageBehavior = false;
            lVlSiparisListesi.SelectedIndexChanged += lVlSiparisListesi_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1759, 746);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Sipariş Girişi";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(tBTpMaliyet);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dTPSiparisTarihi);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(nudMiktar);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(cBSiparisAdi);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(btnSiparisKayit);
            panel1.Controls.Add(tBAciklama);
            panel1.Controls.Add(tBSiparisiGirenPersonel);
            panel1.Controls.Add(cBParaBirimi);
            panel1.Controls.Add(tBKur);
            panel1.Controls.Add(tBBirimFiyat);
            panel1.Controls.Add(tBSiparisVerilenFirmaAdi);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1753, 740);
            panel1.TabIndex = 2;
            // 
            // tBTpMaliyet
            // 
            tBTpMaliyet.Location = new Point(640, 574);
            tBTpMaliyet.Multiline = true;
            tBTpMaliyet.Name = "tBTpMaliyet";
            tBTpMaliyet.Size = new Size(136, 27);
            tBTpMaliyet.TabIndex = 64;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(519, 581);
            label1.Name = "label1";
            label1.Size = new Size(115, 20);
            label1.TabIndex = 62;
            label1.Text = "Toplam Maliyet:";
            // 
            // dTPSiparisTarihi
            // 
            dTPSiparisTarihi.Location = new Point(186, 196);
            dTPSiparisTarihi.Name = "dTPSiparisTarihi";
            dTPSiparisTarihi.Size = new Size(242, 27);
            dTPSiparisTarihi.TabIndex = 61;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(15, 196);
            label12.Name = "label12";
            label12.Size = new Size(138, 20);
            label12.TabIndex = 60;
            label12.Text = "Sipariş verilen tarih:";
            // 
            // nudMiktar
            // 
            nudMiktar.Location = new Point(200, 128);
            nudMiktar.Name = "nudMiktar";
            nudMiktar.Size = new Size(150, 27);
            nudMiktar.TabIndex = 59;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(15, 128);
            label11.Name = "label11";
            label11.Size = new Size(147, 20);
            label11.TabIndex = 58;
            label11.Text = "Sipariş verilen miktar";
            // 
            // cBSiparisAdi
            // 
            cBSiparisAdi.FormattingEnabled = true;
            cBSiparisAdi.Location = new Point(199, 41);
            cBSiparisAdi.Name = "cBSiparisAdi";
            cBSiparisAdi.Size = new Size(151, 28);
            cBSiparisAdi.TabIndex = 57;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(15, 49);
            label10.Name = "label10";
            label10.Size = new Size(140, 20);
            label10.TabIndex = 56;
            label10.Text = "Sipariş Verilen Ürün:";
            // 
            // btnSiparisKayit
            // 
            btnSiparisKayit.Location = new Point(295, 563);
            btnSiparisKayit.Name = "btnSiparisKayit";
            btnSiparisKayit.Size = new Size(157, 49);
            btnSiparisKayit.TabIndex = 55;
            btnSiparisKayit.Text = "Siparişi Kaydet";
            btnSiparisKayit.UseVisualStyleBackColor = true;
            btnSiparisKayit.Click += btnSiparisKayit_Click;
            // 
            // tBAciklama
            // 
            tBAciklama.Location = new Point(604, 117);
            tBAciklama.Multiline = true;
            tBAciklama.Name = "tBAciklama";
            tBAciklama.Size = new Size(136, 27);
            tBAciklama.TabIndex = 54;
            // 
            // tBSiparisiGirenPersonel
            // 
            tBSiparisiGirenPersonel.Location = new Point(604, 41);
            tBSiparisiGirenPersonel.Name = "tBSiparisiGirenPersonel";
            tBSiparisiGirenPersonel.Size = new Size(136, 27);
            tBSiparisiGirenPersonel.TabIndex = 53;
            // 
            // cBParaBirimi
            // 
            cBParaBirimi.FormattingEnabled = true;
            cBParaBirimi.Location = new Point(200, 334);
            cBParaBirimi.Name = "cBParaBirimi";
            cBParaBirimi.Size = new Size(126, 28);
            cBParaBirimi.TabIndex = 52;
            // 
            // tBKur
            // 
            tBKur.Location = new Point(199, 394);
            tBKur.Name = "tBKur";
            tBKur.Size = new Size(125, 27);
            tBKur.TabIndex = 51;
            // 
            // tBBirimFiyat
            // 
            tBBirimFiyat.Location = new Point(199, 453);
            tBBirimFiyat.Name = "tBBirimFiyat";
            tBBirimFiyat.Size = new Size(125, 27);
            tBBirimFiyat.TabIndex = 50;
            // 
            // tBSiparisVerilenFirmaAdi
            // 
            tBSiparisVerilenFirmaAdi.Location = new Point(200, 267);
            tBSiparisVerilenFirmaAdi.Name = "tBSiparisVerilenFirmaAdi";
            tBSiparisVerilenFirmaAdi.Size = new Size(125, 27);
            tBSiparisVerilenFirmaAdi.TabIndex = 49;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(418, 48);
            label9.Name = "label9";
            label9.Size = new Size(154, 20);
            label9.TabIndex = 48;
            label9.Text = "Sipariş Giren Personel:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(418, 124);
            label7.Name = "label7";
            label7.Size = new Size(73, 20);
            label7.TabIndex = 47;
            label7.Text = "Açıklama:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 342);
            label8.Name = "label8";
            label8.Size = new Size(83, 20);
            label8.TabIndex = 46;
            label8.Text = "Para birimi:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 401);
            label6.Name = "label6";
            label6.Size = new Size(34, 20);
            label6.TabIndex = 45;
            label6.Text = "Kur:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 460);
            label5.Name = "label5";
            label5.Size = new Size(80, 20);
            label5.TabIndex = 44;
            label5.Text = "Birim fiyat:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 274);
            label4.Name = "label4";
            label4.Size = new Size(168, 20);
            label4.TabIndex = 43;
            label4.Text = "Sipariş verilen firma adı:";
            // 
            // cMSPrjListe
            // 
            cMSPrjListe.ImageScalingSize = new Size(20, 20);
            cMSPrjListe.Items.AddRange(new ToolStripItem[] { silToolStripMenuItem, düzenleToolStripMenuItem });
            cMSPrjListe.Name = "cMSPrjListe";
            cMSPrjListe.Size = new Size(133, 52);
            // 
            // silToolStripMenuItem
            // 
            silToolStripMenuItem.Name = "silToolStripMenuItem";
            silToolStripMenuItem.Size = new Size(132, 24);
            silToolStripMenuItem.Text = "Sil";
            // 
            // düzenleToolStripMenuItem
            // 
            düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            düzenleToolStripMenuItem.Size = new Size(132, 24);
            düzenleToolStripMenuItem.Text = "Düzenle";
            düzenleToolStripMenuItem.Click += düzenleToolStripMenuItem_Click;
            // 
            // Siparisİslemleri
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1765, 776);
            Controls.Add(tabControl1);
            Name = "Siparisİslemleri";
            Text = "Siparisİslemleri";
            Load += Siparisİslemleri_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            pARA.ResumeLayout(false);
            pARA.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMiktar).EndInit();
            cMSPrjListe.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ListView lVlSiparisListesi;
        private ContextMenuStrip cMSPrjListe;
        private ToolStripMenuItem silToolStripMenuItem;
        private ToolStripMenuItem düzenleToolStripMenuItem;
        private Panel panel1;
        private DateTimePicker dTPSiparisTarihi;
        private Label label12;
        private NumericUpDown nudMiktar;
        private Label label11;
        private ComboBox cBSiparisAdi;
        private Label label10;
        private Button btnSiparisKayit;
        private TextBox tBAciklama;
        private TextBox tBSiparisiGirenPersonel;
        private ComboBox cBParaBirimi;
        private TextBox tBKur;
        private TextBox tBBirimFiyat;
        private TextBox tBSiparisVerilenFirmaAdi;
        private Label label9;
        private Label label7;
        private Label label8;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label1;
        private TextBox tBTpMaliyet;
        private Panel pARA;
        private Label label3;
        private Label label2;
        private Button btnUrunAra;
        private ComboBox cBUrunAra;
    }
}
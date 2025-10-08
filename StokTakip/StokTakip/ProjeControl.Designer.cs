namespace StokTakip
{
    partial class ProjeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            tBProjeAdi = new TextBox();
            tBPersonelId = new TextBox();
            dTPBaslangic = new DateTimePicker();
            dTPBitisTarihi = new DateTimePicker();
            cBDurum = new ComboBox();
            btnProjeEkle = new Button();
            label7 = new Label();
            tBAciklama = new TextBox();
            gBProjeKullanilanUrunler = new GroupBox();
            btnUrunEkle = new Button();
            label8 = new Label();
            lVSecilenUrunler = new ListView();
            button1 = new Button();
            nUDMiktarSec = new NumericUpDown();
            cBUrunSec = new ComboBox();
            label10 = new Label();
            label9 = new Label();
            lblProjeEkle = new Label();
            cBProjSec = new ComboBox();
            gBProjeKullanilanUrunler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nUDMiktarSec).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(132, 17);
            label1.Name = "label1";
            label1.Size = new Size(133, 37);
            label1.TabIndex = 0;
            label1.Text = "Proje Ekle";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 87);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 1;
            label2.Text = "Proje Adi:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 139);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 2;
            label3.Text = "Başlangıc Tarihi:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 192);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 3;
            label4.Text = "Bitiş Tarihi:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 305);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 4;
            label5.Text = "Personel Id:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 357);
            label6.Name = "label6";
            label6.Size = new Size(57, 20);
            label6.TabIndex = 5;
            label6.Text = "Durum:";
            // 
            // tBProjeAdi
            // 
            tBProjeAdi.Location = new Point(157, 80);
            tBProjeAdi.Name = "tBProjeAdi";
            tBProjeAdi.Size = new Size(125, 27);
            tBProjeAdi.TabIndex = 6;
            // 
            // tBPersonelId
            // 
            tBPersonelId.Location = new Point(157, 302);
            tBPersonelId.Name = "tBPersonelId";
            tBPersonelId.Size = new Size(125, 27);
            tBPersonelId.TabIndex = 9;
            // 
            // dTPBaslangic
            // 
            dTPBaslangic.Location = new Point(157, 139);
            dTPBaslangic.Name = "dTPBaslangic";
            dTPBaslangic.Size = new Size(228, 27);
            dTPBaslangic.TabIndex = 11;
            // 
            // dTPBitisTarihi
            // 
            dTPBitisTarihi.Location = new Point(157, 187);
            dTPBitisTarihi.Name = "dTPBitisTarihi";
            dTPBitisTarihi.Size = new Size(228, 27);
            dTPBitisTarihi.TabIndex = 12;
            // 
            // cBDurum
            // 
            cBDurum.FormattingEnabled = true;
            cBDurum.Location = new Point(157, 357);
            cBDurum.Name = "cBDurum";
            cBDurum.Size = new Size(138, 28);
            cBDurum.TabIndex = 13;
            // 
            // btnProjeEkle
            // 
            btnProjeEkle.Location = new Point(318, 422);
            btnProjeEkle.Name = "btnProjeEkle";
            btnProjeEkle.Size = new Size(185, 58);
            btnProjeEkle.TabIndex = 14;
            btnProjeEkle.Text = "Proje Ekle";
            btnProjeEkle.UseVisualStyleBackColor = true;
            btnProjeEkle.Click += btnProjeEkle_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(24, 250);
            label7.Name = "label7";
            label7.Size = new Size(73, 20);
            label7.TabIndex = 15;
            label7.Text = "Açıklama:";
            // 
            // tBAciklama
            // 
            tBAciklama.Location = new Point(157, 250);
            tBAciklama.Name = "tBAciklama";
            tBAciklama.Size = new Size(125, 27);
            tBAciklama.TabIndex = 16;
            // 
            // gBProjeKullanilanUrunler
            // 
            gBProjeKullanilanUrunler.Controls.Add(btnUrunEkle);
            gBProjeKullanilanUrunler.Controls.Add(label8);
            gBProjeKullanilanUrunler.Controls.Add(lVSecilenUrunler);
            gBProjeKullanilanUrunler.Controls.Add(button1);
            gBProjeKullanilanUrunler.Controls.Add(nUDMiktarSec);
            gBProjeKullanilanUrunler.Controls.Add(cBUrunSec);
            gBProjeKullanilanUrunler.Controls.Add(label10);
            gBProjeKullanilanUrunler.Controls.Add(label9);
            gBProjeKullanilanUrunler.Controls.Add(lblProjeEkle);
            gBProjeKullanilanUrunler.Controls.Add(cBProjSec);
            gBProjeKullanilanUrunler.Location = new Point(765, 80);
            gBProjeKullanilanUrunler.Name = "gBProjeKullanilanUrunler";
            gBProjeKullanilanUrunler.Size = new Size(618, 506);
            gBProjeKullanilanUrunler.TabIndex = 17;
            gBProjeKullanilanUrunler.TabStop = false;
            gBProjeKullanilanUrunler.Text = "Proje Kullanılıcak Ürünler";
            // 
            // btnUrunEkle
            // 
            btnUrunEkle.Location = new Point(392, 357);
            btnUrunEkle.Name = "btnUrunEkle";
            btnUrunEkle.Size = new Size(176, 29);
            btnUrunEkle.TabIndex = 20;
            btnUrunEkle.Text = "Ürünler Eklendi";
            btnUrunEkle.UseVisualStyleBackColor = true;
            btnUrunEkle.Click += btnUrunEkle_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 174);
            label8.Name = "label8";
            label8.Size = new Size(111, 20);
            label8.TabIndex = 19;
            label8.Text = "Seçilen Ürünler:";
            // 
            // lVSecilenUrunler
            // 
            lVSecilenUrunler.Location = new Point(96, 204);
            lVSecilenUrunler.Name = "lVSecilenUrunler";
            lVSecilenUrunler.Size = new Size(272, 247);
            lVSecilenUrunler.TabIndex = 18;
            lVSecilenUrunler.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            button1.Location = new Point(437, 170);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "Ürün ekle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // nUDMiktarSec
            // 
            nUDMiktarSec.Location = new Point(381, 110);
            nUDMiktarSec.Name = "nUDMiktarSec";
            nUDMiktarSec.Size = new Size(150, 27);
            nUDMiktarSec.TabIndex = 5;
            // 
            // cBUrunSec
            // 
            cBUrunSec.FormattingEnabled = true;
            cBUrunSec.Location = new Point(97, 109);
            cBUrunSec.Name = "cBUrunSec";
            cBUrunSec.Size = new Size(170, 28);
            cBUrunSec.TabIndex = 4;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(338, 86);
            label10.Name = "label10";
            label10.Size = new Size(130, 20);
            label10.TabIndex = 3;
            label10.Text = "Ürün Sayısı Belirle:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(17, 94);
            label9.Name = "label9";
            label9.Size = new Size(74, 20);
            label9.TabIndex = 2;
            label9.Text = "Ürün Seç :";
            // 
            // lblProjeEkle
            // 
            lblProjeEkle.AutoSize = true;
            lblProjeEkle.Location = new Point(17, 34);
            lblProjeEkle.Name = "lblProjeEkle";
            lblProjeEkle.Size = new Size(77, 20);
            lblProjeEkle.TabIndex = 1;
            lblProjeEkle.Text = "Proje Seç :";
            // 
            // cBProjSec
            // 
            cBProjSec.FormattingEnabled = true;
            cBProjSec.Location = new Point(96, 31);
            cBProjSec.Name = "cBProjSec";
            cBProjSec.Size = new Size(170, 28);
            cBProjSec.TabIndex = 0;
            // 
            // ProjeControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gBProjeKullanilanUrunler);
            Controls.Add(tBAciklama);
            Controls.Add(label7);
            Controls.Add(btnProjeEkle);
            Controls.Add(cBDurum);
            Controls.Add(dTPBitisTarihi);
            Controls.Add(dTPBaslangic);
            Controls.Add(tBPersonelId);
            Controls.Add(tBProjeAdi);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ProjeControl";
            Size = new Size(1480, 686);
            Load += ProjeControl_Load;
            gBProjeKullanilanUrunler.ResumeLayout(false);
            gBProjeKullanilanUrunler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nUDMiktarSec).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox tBProjeAdi;
        private TextBox tBPersonelId;
        private DateTimePicker dTPBaslangic;
        private DateTimePicker dTPBitisTarihi;
        private ComboBox cBDurum;
        private Button btnProjeEkle;
        private Label label7;
        private TextBox tBAciklama;
        private GroupBox gBProjeKullanilanUrunler;
        private ComboBox cBUrunSec;
        private Label label10;
        private Label label9;
        private Label lblProjeEkle;
        private ComboBox cBProjSec;
        private ListView lVSecilenUrunler;
        private Button button1;
        private NumericUpDown nUDMiktarSec;
        private Label label8;
        private Button btnUrunEkle;
    }
}

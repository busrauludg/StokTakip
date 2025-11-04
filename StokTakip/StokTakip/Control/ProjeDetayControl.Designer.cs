namespace StokTakip
{
    partial class ProjeDetayControl
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
            components = new System.ComponentModel.Container();
            lVlPrjListele = new ListView();
            pDetay = new Panel();
            tBToplamMaliyet = new TextBox();
            label9 = new Label();
            lVlKullanilanUrunler = new ListView();
            label8 = new Label();
            cBPrjDurum = new ComboBox();
            dTPBitisT = new DateTimePicker();
            dTPPrjBaslingicT = new DateTimePicker();
            tBPrjAciklama = new TextBox();
            tBPrjPersonel = new TextBox();
            tBProjeAdi = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnBasla = new Button();
            btnBitir = new Button();
            cMSPrjeİslem = new ContextMenuStrip(components);
            silToolStripMenuItem = new ToolStripMenuItem();
            pDetay.SuspendLayout();
            cMSPrjeİslem.SuspendLayout();
            SuspendLayout();
            // 
            // lVlPrjListele
            // 
            lVlPrjListele.Location = new Point(14, 21);
            lVlPrjListele.Name = "lVlPrjListele";
            lVlPrjListele.Size = new Size(578, 436);
            lVlPrjListele.TabIndex = 0;
            lVlPrjListele.UseCompatibleStateImageBehavior = false;
            lVlPrjListele.View = View.Details;
            lVlPrjListele.SelectedIndexChanged += lVlPrjListele_SelectedIndexChanged;
            // 
            // pDetay
            // 
            pDetay.Controls.Add(tBToplamMaliyet);
            pDetay.Controls.Add(label9);
            pDetay.Controls.Add(lVlKullanilanUrunler);
            pDetay.Controls.Add(label8);
            pDetay.Controls.Add(cBPrjDurum);
            pDetay.Controls.Add(dTPBitisT);
            pDetay.Controls.Add(dTPPrjBaslingicT);
            pDetay.Controls.Add(tBPrjAciklama);
            pDetay.Controls.Add(tBPrjPersonel);
            pDetay.Controls.Add(tBProjeAdi);
            pDetay.Controls.Add(label7);
            pDetay.Controls.Add(label6);
            pDetay.Controls.Add(label5);
            pDetay.Controls.Add(label4);
            pDetay.Controls.Add(label3);
            pDetay.Controls.Add(label2);
            pDetay.Location = new Point(694, 61);
            pDetay.Name = "pDetay";
            pDetay.Size = new Size(536, 925);
            pDetay.TabIndex = 1;
            // 
            // tBToplamMaliyet
            // 
            tBToplamMaliyet.Location = new Point(191, 726);
            tBToplamMaliyet.Name = "tBToplamMaliyet";
            tBToplamMaliyet.Size = new Size(125, 27);
            tBToplamMaliyet.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(70, 726);
            label9.Name = "label9";
            label9.Size = new Size(115, 20);
            label9.TabIndex = 14;
            label9.Text = "Toplam Maliyet:";
            // 
            // lVlKullanilanUrunler
            // 
            lVlKullanilanUrunler.Location = new Point(203, 433);
            lVlKullanilanUrunler.Name = "lVlKullanilanUrunler";
            lVlKullanilanUrunler.Size = new Size(301, 257);
            lVlKullanilanUrunler.TabIndex = 13;
            lVlKullanilanUrunler.UseCompatibleStateImageBehavior = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 433);
            label8.Name = "label8";
            label8.Size = new Size(180, 20);
            label8.TabIndex = 12;
            label8.Text = "Projede Kulanılan Ürünler:";
            // 
            // cBPrjDurum
            // 
            cBPrjDurum.FormattingEnabled = true;
            cBPrjDurum.Location = new Point(151, 353);
            cBPrjDurum.Name = "cBPrjDurum";
            cBPrjDurum.Size = new Size(151, 28);
            cBPrjDurum.TabIndex = 11;
            // 
            // dTPBitisT
            // 
            dTPBitisT.Location = new Point(154, 163);
            dTPBitisT.Name = "dTPBitisT";
            dTPBitisT.Size = new Size(250, 27);
            dTPBitisT.TabIndex = 10;
            // 
            // dTPPrjBaslingicT
            // 
            dTPPrjBaslingicT.Location = new Point(165, 90);
            dTPPrjBaslingicT.Name = "dTPPrjBaslingicT";
            dTPPrjBaslingicT.Size = new Size(250, 27);
            dTPPrjBaslingicT.TabIndex = 9;
            // 
            // tBPrjAciklama
            // 
            tBPrjAciklama.Location = new Point(154, 298);
            tBPrjAciklama.Name = "tBPrjAciklama";
            tBPrjAciklama.Size = new Size(125, 27);
            tBPrjAciklama.TabIndex = 8;
            // 
            // tBPrjPersonel
            // 
            tBPrjPersonel.Location = new Point(154, 231);
            tBPrjPersonel.Name = "tBPrjPersonel";
            tBPrjPersonel.Size = new Size(125, 27);
            tBPrjPersonel.TabIndex = 7;
            // 
            // tBProjeAdi
            // 
            tBProjeAdi.Location = new Point(154, 19);
            tBProjeAdi.Name = "tBProjeAdi";
            tBProjeAdi.Size = new Size(125, 27);
            tBProjeAdi.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 361);
            label7.Name = "label7";
            label7.Size = new Size(57, 20);
            label7.TabIndex = 5;
            label7.Text = "Durum:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 301);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 4;
            label6.Text = "Açıklama:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 238);
            label5.Name = "label5";
            label5.Size = new Size(109, 20);
            label5.TabIndex = 3;
            label5.Text = "Proje Personeli:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 170);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 2;
            label4.Text = "Bitiş Tarihi:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 96);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 1;
            label3.Text = "Başlangıç Tarihi:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 26);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 0;
            label2.Text = "Proje Adı:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(897, 21);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 0;
            label1.Text = "Proj Detayları";
            // 
            // btnBasla
            // 
            btnBasla.Location = new Point(285, 609);
            btnBasla.Name = "btnBasla";
            btnBasla.Size = new Size(94, 29);
            btnBasla.TabIndex = 2;
            btnBasla.Text = "Başla";
            btnBasla.UseVisualStyleBackColor = true;
            btnBasla.Click += btnBasla_Click;
            // 
            // btnBitir
            // 
            btnBitir.Location = new Point(465, 609);
            btnBitir.Name = "btnBitir";
            btnBitir.Size = new Size(94, 29);
            btnBitir.TabIndex = 3;
            btnBitir.Text = "Bitir";
            btnBitir.UseVisualStyleBackColor = true;
            btnBitir.Click += btnBitir_Click;
            // 
            // cMSPrjeİslem
            // 
            cMSPrjeİslem.ImageScalingSize = new Size(20, 20);
            cMSPrjeİslem.Items.AddRange(new ToolStripItem[] { silToolStripMenuItem });
            cMSPrjeİslem.Name = "cMSPrjeİslem";
            cMSPrjeİslem.Size = new Size(95, 28);
            // 
            // silToolStripMenuItem
            // 
            silToolStripMenuItem.Name = "silToolStripMenuItem";
            silToolStripMenuItem.Size = new Size(94, 24);
            silToolStripMenuItem.Text = "Sil";
            silToolStripMenuItem.Click += silToolStripMenuItem_Click;
            // 
            // ProjeDetayControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnBitir);
            Controls.Add(btnBasla);
            Controls.Add(label1);
            Controls.Add(pDetay);
            Controls.Add(lVlPrjListele);
            Name = "ProjeDetayControl";
            Size = new Size(1279, 961);
            Load += ProjeDetayControl_Load;
            pDetay.ResumeLayout(false);
            pDetay.PerformLayout();
            cMSPrjeİslem.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lVlPrjListele;
        private Panel pDetay;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dTPBitisT;
        private DateTimePicker dTPPrjBaslingicT;
        private TextBox tBPrjAciklama;
        private TextBox tBPrjPersonel;
        private TextBox tBProjeAdi;
        private ComboBox cBPrjDurum;
        private ListView lVlKullanilanUrunler;
        private Label label8;
        private Label label9;
        private TextBox tBToplamMaliyet;
        private Button btnBasla;
        private Button btnBitir;
        private ContextMenuStrip cMSPrjeİslem;
        private ToolStripMenuItem silToolStripMenuItem;
    }
}

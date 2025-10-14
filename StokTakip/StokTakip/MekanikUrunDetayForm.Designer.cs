namespace StokTakip
{
    partial class MekanikUrunDetayForm
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
            dGVMknStkDurum = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            txtMAciklama = new TextBox();
            txtMPersonelAdi = new TextBox();
            txtMGrupAdi = new TextBox();
            txtMFirmaAdi = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label12 = new Label();
            label13 = new Label();
            txtMMaxStok = new TextBox();
            txtMMinStok = new TextBox();
            txtMDepoAdresi = new TextBox();
            txtMStokBirimi = new TextBox();
            txtMFirmaSiparisKodu = new TextBox();
            txtMStokKodu = new TextBox();
            panel2 = new Panel();
            dTPMekanik = new DateTimePicker();
            txtMSprsAciklama = new TextBox();
            txtMCari = new TextBox();
            txtMMiktar = new TextBox();
            label16 = new Label();
            label14 = new Label();
            label17 = new Label();
            label18 = new Label();
            pBMekanikResim = new PictureBox();
            label19 = new Label();
            label20 = new Label();
            lVAktifProje = new ListView();
            button1 = new Button();
            button2 = new Button();
            label15 = new Label();
            txtMGlnMktr = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dGVMknStkDurum).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pBMekanikResim).BeginInit();
            SuspendLayout();
            // 
            // dGVMknStkDurum
            // 
            dGVMknStkDurum.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVMknStkDurum.Location = new Point(516, 342);
            dGVMknStkDurum.Name = "dGVMknStkDurum";
            dGVMknStkDurum.RowHeadersWidth = 51;
            dGVMknStkDurum.Size = new Size(669, 74);
            dGVMknStkDurum.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 3;
            label1.Text = "Stok Karti";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(546, 310);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 4;
            label2.Text = "Stok Durumu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(564, 14);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 5;
            label3.Text = "SatınAlma";
            // 
            // panel1
            // 
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtMAciklama);
            panel1.Controls.Add(txtMPersonelAdi);
            panel1.Controls.Add(txtMGrupAdi);
            panel1.Controls.Add(txtMFirmaAdi);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(txtMMaxStok);
            panel1.Controls.Add(txtMMinStok);
            panel1.Controls.Add(txtMDepoAdresi);
            panel1.Controls.Add(txtMStokBirimi);
            panel1.Controls.Add(txtMFirmaSiparisKodu);
            panel1.Controls.Add(txtMStokKodu);
            panel1.Location = new Point(12, 45);
            panel1.Name = "panel1";
            panel1.Size = new Size(481, 532);
            panel1.TabIndex = 6;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(23, 476);
            label11.Name = "label11";
            label11.Size = new Size(73, 20);
            label11.TabIndex = 22;
            label11.Text = "Acıklama:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(20, 424);
            label10.Name = "label10";
            label10.Size = new Size(94, 20);
            label10.TabIndex = 21;
            label10.Text = "Personel Adı:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(23, 369);
            label9.Name = "label9";
            label9.Size = new Size(76, 20);
            label9.TabIndex = 20;
            label9.Text = "Firma Adı:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 314);
            label8.Name = "label8";
            label8.Size = new Size(71, 20);
            label8.TabIndex = 19;
            label8.Text = "Grup Adı:";
            // 
            // txtMAciklama
            // 
            txtMAciklama.Location = new Point(210, 476);
            txtMAciklama.Name = "txtMAciklama";
            txtMAciklama.Size = new Size(125, 27);
            txtMAciklama.TabIndex = 18;
            // 
            // txtMPersonelAdi
            // 
            txtMPersonelAdi.Location = new Point(210, 424);
            txtMPersonelAdi.Name = "txtMPersonelAdi";
            txtMPersonelAdi.Size = new Size(125, 27);
            txtMPersonelAdi.TabIndex = 17;
            // 
            // txtMGrupAdi
            // 
            txtMGrupAdi.Location = new Point(210, 314);
            txtMGrupAdi.Name = "txtMGrupAdi";
            txtMGrupAdi.Size = new Size(125, 27);
            txtMGrupAdi.TabIndex = 16;
            // 
            // txtMFirmaAdi
            // 
            txtMFirmaAdi.Location = new Point(210, 369);
            txtMFirmaAdi.Name = "txtMFirmaAdi";
            txtMFirmaAdi.Size = new Size(125, 27);
            txtMFirmaAdi.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 262);
            label7.Name = "label7";
            label7.Size = new Size(73, 20);
            label7.TabIndex = 14;
            label7.Text = "Max Stok:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 209);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 13;
            label6.Text = "Min Stok:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 159);
            label5.Name = "label5";
            label5.Size = new Size(95, 20);
            label5.TabIndex = 12;
            label5.Text = "Depo Adresi:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 112);
            label4.Name = "label4";
            label4.Size = new Size(81, 20);
            label4.TabIndex = 11;
            label4.Text = "Stok Birimi";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(21, 67);
            label12.Name = "label12";
            label12.Size = new Size(88, 20);
            label12.TabIndex = 10;
            label12.Text = "Firma Kodu:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(21, 21);
            label13.Name = "label13";
            label13.Size = new Size(80, 20);
            label13.TabIndex = 9;
            label13.Text = "Stok Kodu:";
            // 
            // txtMMaxStok
            // 
            txtMMaxStok.Location = new Point(210, 262);
            txtMMaxStok.Name = "txtMMaxStok";
            txtMMaxStok.Size = new Size(125, 27);
            txtMMaxStok.TabIndex = 8;
            // 
            // txtMMinStok
            // 
            txtMMinStok.Location = new Point(210, 209);
            txtMMinStok.Name = "txtMMinStok";
            txtMMinStok.Size = new Size(125, 27);
            txtMMinStok.TabIndex = 7;
            // 
            // txtMDepoAdresi
            // 
            txtMDepoAdresi.Location = new Point(210, 159);
            txtMDepoAdresi.Name = "txtMDepoAdresi";
            txtMDepoAdresi.Size = new Size(125, 27);
            txtMDepoAdresi.TabIndex = 6;
            // 
            // txtMStokBirimi
            // 
            txtMStokBirimi.Location = new Point(210, 109);
            txtMStokBirimi.Name = "txtMStokBirimi";
            txtMStokBirimi.Size = new Size(125, 27);
            txtMStokBirimi.TabIndex = 5;
            // 
            // txtMFirmaSiparisKodu
            // 
            txtMFirmaSiparisKodu.Location = new Point(210, 60);
            txtMFirmaSiparisKodu.Name = "txtMFirmaSiparisKodu";
            txtMFirmaSiparisKodu.Size = new Size(125, 27);
            txtMFirmaSiparisKodu.TabIndex = 4;
            // 
            // txtMStokKodu
            // 
            txtMStokKodu.Location = new Point(210, 18);
            txtMStokKodu.Name = "txtMStokKodu";
            txtMStokKodu.Size = new Size(125, 27);
            txtMStokKodu.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(dTPMekanik);
            panel2.Controls.Add(txtMSprsAciklama);
            panel2.Controls.Add(txtMGlnMktr);
            panel2.Controls.Add(txtMCari);
            panel2.Controls.Add(txtMMiktar);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(label18);
            panel2.Location = new Point(541, 45);
            panel2.Name = "panel2";
            panel2.Size = new Size(481, 219);
            panel2.TabIndex = 7;
            // 
            // dTPMekanik
            // 
            dTPMekanik.Location = new Point(210, 13);
            dTPMekanik.Name = "dTPMekanik";
            dTPMekanik.Size = new Size(189, 27);
            dTPMekanik.TabIndex = 9;
            // 
            // txtMSprsAciklama
            // 
            txtMSprsAciklama.Location = new Point(219, 166);
            txtMSprsAciklama.Name = "txtMSprsAciklama";
            txtMSprsAciklama.Size = new Size(125, 27);
            txtMSprsAciklama.TabIndex = 8;
            // 
            // txtMCari
            // 
            txtMCari.Location = new Point(219, 88);
            txtMCari.Name = "txtMCari";
            txtMCari.Size = new Size(125, 27);
            txtMCari.TabIndex = 6;
            // 
            // txtMMiktar
            // 
            txtMMiktar.Location = new Point(219, 49);
            txtMMiktar.Name = "txtMMiktar";
            txtMMiktar.Size = new Size(125, 27);
            txtMMiktar.TabIndex = 5;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(20, 166);
            label16.Name = "label16";
            label16.Size = new Size(121, 20);
            label16.TabIndex = 4;
            label16.Text = "Sipariş Açıklama:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(20, 91);
            label14.Name = "label14";
            label14.Size = new Size(65, 20);
            label14.TabIndex = 2;
            label14.Text = "Cari Adi:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(20, 56);
            label17.Name = "label17";
            label17.Size = new Size(54, 20);
            label17.TabIndex = 1;
            label17.Text = "Miktar:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(20, 20);
            label18.Name = "label18";
            label18.Size = new Size(95, 20);
            label18.TabIndex = 0;
            label18.Text = "Sipariş Tarihi:";
            // 
            // pBMekanikResim
            // 
            pBMekanikResim.Location = new Point(1121, 50);
            pBMekanikResim.Name = "pBMekanikResim";
            pBMekanikResim.Size = new Size(232, 231);
            pBMekanikResim.TabIndex = 8;
            pBMekanikResim.TabStop = false;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(1103, 14);
            label19.Name = "label19";
            label19.Size = new Size(49, 20);
            label19.TabIndex = 9;
            label19.Text = "Resim";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(1263, 325);
            label20.Name = "label20";
            label20.Size = new Size(146, 20);
            label20.TabIndex = 10;
            label20.Text = "Aktif Proje İhtiyacları";
            // 
            // lVAktifProje
            // 
            lVAktifProje.Location = new Point(1263, 368);
            lVAktifProje.Name = "lVAktifProje";
            lVAktifProje.Size = new Size(438, 283);
            lVAktifProje.TabIndex = 12;
            lVAktifProje.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            button1.Location = new Point(622, 531);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 13;
            button1.Text = "Stok Arttır";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(836, 531);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 14;
            button2.Text = "Stok Cıkışı";
            button2.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(20, 127);
            label15.Name = "label15";
            label15.Size = new Size(96, 20);
            label15.TabIndex = 3;
            label15.Text = "Gelen Miktar:";
            // 
            // txtMGlnMktr
            // 
            txtMGlnMktr.Location = new Point(219, 127);
            txtMGlnMktr.Name = "txtMGlnMktr";
            txtMGlnMktr.Size = new Size(125, 27);
            txtMGlnMktr.TabIndex = 7;
            // 
            // MekanikUrunDetayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1739, 663);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(lVAktifProje);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(pBMekanikResim);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dGVMknStkDurum);
            Name = "MekanikUrunDetayForm";
            Text = "MekanikForm";
            Load += MekanikForm_Load;
            ((System.ComponentModel.ISupportInitialize)dGVMknStkDurum).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pBMekanikResim).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dGVMknStkDurum;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextBox txtMAciklama;
        private TextBox txtMPersonelAdi;
        private TextBox txtMGrupAdi;
        private TextBox txtMFirmaAdi;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label12;
        private Label label13;
        private TextBox txtMMaxStok;
        private TextBox txtMMinStok;
        private TextBox txtMDepoAdresi;
        private TextBox txtMStokBirimi;
        private TextBox txtMFirmaSiparisKodu;
        private TextBox txtMStokKodu;
        private Panel panel2;
        private DateTimePicker dTPMekanik;
        private TextBox txtMSprsAciklama;
        private TextBox txtMCari;
        private TextBox txtMMiktar;
        private Label label16;
        private Label label14;
        private Label label17;
        private Label label18;
        private PictureBox pBMekanikResim;
        private Label label19;
        private Label label20;
        private ListView lVAktifProje;
        private Button button1;
        private Button button2;
        private TextBox txtMGlnMktr;
        private Label label15;
    }
}
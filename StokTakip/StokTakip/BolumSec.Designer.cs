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
            tbCBolumSec.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(421, 351);
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
            tbCBolumSec.Size = new Size(796, 654);
            tbCBolumSec.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lVMekanikListesi);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(788, 621);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Mekanik Ürün Listesi";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lVMekanikListesi
            // 
            lVMekanikListesi.Dock = DockStyle.Fill;
            lVMekanikListesi.Location = new Point(3, 3);
            lVMekanikListesi.Name = "lVMekanikListesi";
            lVMekanikListesi.Size = new Size(782, 615);
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
            tabPage2.Size = new Size(788, 621);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Elektrik Ürün Listesi";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // lVlElektrikListesi
            // 
            lVlElektrikListesi.Dock = DockStyle.Fill;
            lVlElektrikListesi.Location = new Point(3, 3);
            lVlElektrikListesi.Name = "lVlElektrikListesi";
            lVlElektrikListesi.Size = new Size(782, 615);
            lVlElektrikListesi.TabIndex = 2;
            lVlElektrikListesi.UseCompatibleStateImageBehavior = false;
            lVlElektrikListesi.DoubleClick += lVlElektrikListesi_DoubleClick;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label1);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(788, 621);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Ana Sayfa";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // BolumSec
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 714);
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
    }
}
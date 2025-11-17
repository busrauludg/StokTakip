namespace StokTakip
{
    partial class YetkiliSifreForm
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
            lblYetkiliSifreGiris = new Label();
            tBYetkiliGirisSifre = new TextBox();
            btnPerKaydet = new Button();
            tBMevcutYetkili = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblYetkiliSifreGiris
            // 
            lblYetkiliSifreGiris.AutoSize = true;
            lblYetkiliSifreGiris.Location = new Point(165, 242);
            lblYetkiliSifreGiris.Name = "lblYetkiliSifreGiris";
            lblYetkiliSifreGiris.Size = new Size(116, 20);
            lblYetkiliSifreGiris.TabIndex = 0;
            lblYetkiliSifreGiris.Text = "Yeni Yetkili Şifre:";
            // 
            // tBYetkiliGirisSifre
            // 
            tBYetkiliGirisSifre.Location = new Point(308, 239);
            tBYetkiliGirisSifre.Name = "tBYetkiliGirisSifre";
            tBYetkiliGirisSifre.Size = new Size(178, 27);
            tBYetkiliGirisSifre.TabIndex = 1;
            // 
            // btnPerKaydet
            // 
            btnPerKaydet.Location = new Point(475, 314);
            btnPerKaydet.Name = "btnPerKaydet";
            btnPerKaydet.Size = new Size(82, 34);
            btnPerKaydet.TabIndex = 2;
            btnPerKaydet.Text = "Kaydet";
            btnPerKaydet.UseVisualStyleBackColor = true;
            btnPerKaydet.Click += btnPerKaydet_Click;
            // 
            // tBMevcutYetkili
            // 
            tBMevcutYetkili.Location = new Point(308, 157);
            tBMevcutYetkili.Name = "tBMevcutYetkili";
            tBMevcutYetkili.Size = new Size(178, 27);
            tBMevcutYetkili.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(165, 164);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 3;
            label1.Text = "Mevcut Yetkili Şifre:";
            // 
            // YetkiliSifreForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tBMevcutYetkili);
            Controls.Add(label1);
            Controls.Add(btnPerKaydet);
            Controls.Add(tBYetkiliGirisSifre);
            Controls.Add(lblYetkiliSifreGiris);
            Name = "YetkiliSifreForm";
            Text = "YetkiliSifreForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblYetkiliSifreGiris;
        private TextBox tBYetkiliGirisSifre;
        private Button btnPerKaydet;
        private TextBox tBMevcutYetkili;
        private Label label1;
    }
}
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
            SuspendLayout();
            // 
            // lblYetkiliSifreGiris
            // 
            lblYetkiliSifreGiris.AutoSize = true;
            lblYetkiliSifreGiris.Location = new Point(147, 180);
            lblYetkiliSifreGiris.Name = "lblYetkiliSifreGiris";
            lblYetkiliSifreGiris.Size = new Size(85, 20);
            lblYetkiliSifreGiris.TabIndex = 0;
            lblYetkiliSifreGiris.Text = "Yetkili Şifre:";
            // 
            // tBYetkiliGirisSifre
            // 
            tBYetkiliGirisSifre.Location = new Point(238, 173);
            tBYetkiliGirisSifre.Name = "tBYetkiliGirisSifre";
            tBYetkiliGirisSifre.Size = new Size(178, 27);
            tBYetkiliGirisSifre.TabIndex = 1;
            // 
            // btnPerKaydet
            // 
            btnPerKaydet.Location = new Point(457, 252);
            btnPerKaydet.Name = "btnPerKaydet";
            btnPerKaydet.Size = new Size(82, 34);
            btnPerKaydet.TabIndex = 2;
            btnPerKaydet.Text = "Kaydet";
            btnPerKaydet.UseVisualStyleBackColor = true;
            btnPerKaydet.Click += btnPerKaydet_Click;
            // 
            // YetkiliSifreForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
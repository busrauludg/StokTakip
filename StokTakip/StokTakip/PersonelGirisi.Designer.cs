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
            // PersonelGirisi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPersonelEkle);
            Name = "PersonelGirisi";
            Text = "PersonelGirisi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPersonelEkle;
    }
}
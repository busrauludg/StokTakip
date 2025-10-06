namespace StokTakip
{
    partial class AnaSayfa
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
            pAnaSayfa = new Panel();
            StkEkle = new Button();
            pAnaSayfa.SuspendLayout();
            SuspendLayout();
            // 
            // pAnaSayfa
            // 
            pAnaSayfa.Controls.Add(StkEkle);
            pAnaSayfa.Dock = DockStyle.Fill;
            pAnaSayfa.Location = new Point(0, 0);
            pAnaSayfa.Name = "pAnaSayfa";
            pAnaSayfa.Size = new Size(1346, 915);
            pAnaSayfa.TabIndex = 0;
            // 
            // StkEkle
            // 
            StkEkle.Location = new Point(139, 372);
            StkEkle.Name = "StkEkle";
            StkEkle.Size = new Size(230, 99);
            StkEkle.TabIndex = 0;
            StkEkle.Text = "Stok Ekle";
            StkEkle.UseVisualStyleBackColor = true;
            StkEkle.Click += StkEkle_Click;
            // 
            // AnaSayfa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1346, 915);
            Controls.Add(pAnaSayfa);
            Name = "AnaSayfa";
            Text = "AnaSayfa";
            Load += AnaSayfa_Load;
            pAnaSayfa.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pAnaSayfa;
        private Button StkEkle;
    }
}
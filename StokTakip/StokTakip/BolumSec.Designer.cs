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
            BtnMekanik = new Button();
            BtnElektirik = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // BtnMekanik
            // 
            BtnMekanik.Location = new Point(116, 142);
            BtnMekanik.Name = "BtnMekanik";
            BtnMekanik.Size = new Size(178, 115);
            BtnMekanik.TabIndex = 0;
            BtnMekanik.Text = "Mekanik";
            BtnMekanik.UseVisualStyleBackColor = true;
            BtnMekanik.Click += BtnMekanik_Click;
            // 
            // BtnElektirik
            // 
            BtnElektirik.Location = new Point(441, 142);
            BtnElektirik.Name = "BtnElektirik";
            BtnElektirik.Size = new Size(178, 115);
            BtnElektirik.TabIndex = 1;
            BtnElektirik.Text = "Elektirik";
            BtnElektirik.UseVisualStyleBackColor = true;
            BtnElektirik.Click += BtnElektirik_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(686, 26);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 2;
            label1.Text = "Ana Sayfa";
            label1.Click += label1_Click;
            // 
            // BolumSec
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(BtnElektirik);
            Controls.Add(BtnMekanik);
            Name = "BolumSec";
            Text = "BolumSec";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnMekanik;
        private Button BtnElektirik;
        private Label label1;
    }
}
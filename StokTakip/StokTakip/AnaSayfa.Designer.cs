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
            stokUserControl1 = new StokUserControl();
            SuspendLayout();
            // 
            // stokUserControl1
            // 
            stokUserControl1.Location = new Point(12, -4);
            stokUserControl1.Name = "stokUserControl1";
            stokUserControl1.Size = new Size(1509, 1022);
            stokUserControl1.TabIndex = 0;
            // 
            // AnaSayfa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1346, 915);
            Controls.Add(stokUserControl1);
            Name = "AnaSayfa";
            Text = "AnaSayfa";
            Load += AnaSayfa_Load;
            ResumeLayout(false);
        }

        #endregion

        private StokUserControl stokUserControl1;
    }
}
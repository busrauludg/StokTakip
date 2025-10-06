namespace StokTakip
{
    partial class MekanikUrunListesiForm
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
            dGVMekanikListesi = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dGVMekanikListesi).BeginInit();
            SuspendLayout();
            // 
            // dGVMekanikListesi
            // 
            dGVMekanikListesi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVMekanikListesi.Dock = DockStyle.Fill;
            dGVMekanikListesi.Location = new Point(0, 0);
            dGVMekanikListesi.Name = "dGVMekanikListesi";
            dGVMekanikListesi.RowHeadersWidth = 51;
            dGVMekanikListesi.Size = new Size(800, 450);
            dGVMekanikListesi.TabIndex = 0;
            dGVMekanikListesi.CellClick += dGVMekanikListesi_CellContentClick;
            // 
            // MekanikUrunListesiForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dGVMekanikListesi);
            Name = "MekanikUrunListesiForm";
            Text = "MekanikUrunListesiForm";
            Load += MekanikUrunListesiForm_Load;
            ((System.ComponentModel.ISupportInitialize)dGVMekanikListesi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dGVMekanikListesi;
    }
}
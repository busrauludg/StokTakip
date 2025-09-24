namespace StokTakip
{
    partial class ElektrikUrunListesiForm
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
            dGVElektrikListesi = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dGVElektrikListesi).BeginInit();
            SuspendLayout();
            // 
            // dGVElektrikListesi
            // 
            dGVElektrikListesi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVElektrikListesi.Location = new Point(63, 29);
            dGVElektrikListesi.Name = "dGVElektrikListesi";
            dGVElektrikListesi.RowHeadersWidth = 51;
            dGVElektrikListesi.Size = new Size(325, 219);
            dGVElektrikListesi.TabIndex = 0;
            dGVElektrikListesi.CellClick += dGVElektrikListesi_CellClick;
            // 
            // ElektrikUrunListesiForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dGVElektrikListesi);
            Name = "ElektrikUrunListesiForm";
            Text = "ElektrikUrunListesiForm";
            Load += ElektrikUrunListesiForm_Load;
            ((System.ComponentModel.ISupportInitialize)dGVElektrikListesi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dGVElektrikListesi;
    }
}
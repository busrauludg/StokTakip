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
            dGVMekanik = new DataGridView();
            dGVMknStkDurum = new DataGridView();
            dGVSatinAlMekanik = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dGVMekanik).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dGVMknStkDurum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dGVSatinAlMekanik).BeginInit();
            SuspendLayout();
            // 
            // dGVMekanik
            // 
            dGVMekanik.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVMekanik.Location = new Point(0, 0);
            dGVMekanik.Name = "dGVMekanik";
            dGVMekanik.RowHeadersWidth = 51;
            dGVMekanik.Size = new Size(1334, 132);
            dGVMekanik.TabIndex = 0;
            // 
            // dGVMknStkDurum
            // 
            dGVMknStkDurum.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVMknStkDurum.Location = new Point(12, 210);
            dGVMknStkDurum.Name = "dGVMknStkDurum";
            dGVMknStkDurum.RowHeadersWidth = 51;
            dGVMknStkDurum.Size = new Size(310, 192);
            dGVMknStkDurum.TabIndex = 1;
            // 
            // dGVSatinAlMekanik
            // 
            dGVSatinAlMekanik.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVSatinAlMekanik.Location = new Point(530, 210);
            dGVSatinAlMekanik.Name = "dGVSatinAlMekanik";
            dGVSatinAlMekanik.RowHeadersWidth = 51;
            dGVSatinAlMekanik.Size = new Size(300, 188);
            dGVSatinAlMekanik.TabIndex = 2;
            // 
            // MekanikUrunDetayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1739, 663);
            Controls.Add(dGVSatinAlMekanik);
            Controls.Add(dGVMknStkDurum);
            Controls.Add(dGVMekanik);
            Name = "MekanikUrunDetayForm";
            Text = "MekanikForm";
            Load += MekanikForm_Load;
            ((System.ComponentModel.ISupportInitialize)dGVMekanik).EndInit();
            ((System.ComponentModel.ISupportInitialize)dGVMknStkDurum).EndInit();
            ((System.ComponentModel.ISupportInitialize)dGVSatinAlMekanik).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dGVMekanik;
        private DataGridView dGVMknStkDurum;
        private DataGridView dGVSatinAlMekanik;
    }
}
namespace StokTakip
{
    partial class MekanikForm
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
            ((System.ComponentModel.ISupportInitialize)dGVMekanik).BeginInit();
            SuspendLayout();
            // 
            // dGVMekanik
            // 
            dGVMekanik.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVMekanik.Dock = DockStyle.Fill;
            dGVMekanik.Location = new Point(0, 0);
            dGVMekanik.Name = "dGVMekanik";
            dGVMekanik.RowHeadersWidth = 51;
            dGVMekanik.Size = new Size(1154, 594);
            dGVMekanik.TabIndex = 0;
            // 
            // MekanikForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1154, 594);
            Controls.Add(dGVMekanik);
            Name = "MekanikForm";
            Text = "MekanikForm";
            Load += MekanikForm_Load;
            ((System.ComponentModel.ISupportInitialize)dGVMekanik).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dGVMekanik;
    }
}
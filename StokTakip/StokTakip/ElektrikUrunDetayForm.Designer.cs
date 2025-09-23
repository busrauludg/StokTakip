namespace StokTakip
{
    partial class ElektrikUrunDetayForm
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
            dGVElektrik = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dGVElektrik).BeginInit();
            SuspendLayout();
            // 
            // dGVElektrik
            // 
            dGVElektrik.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVElektrik.Dock = DockStyle.Fill;
            dGVElektrik.Location = new Point(0, 0);
            dGVElektrik.Name = "dGVElektrik";
            dGVElektrik.RowHeadersWidth = 51;
            dGVElektrik.Size = new Size(1313, 640);
            dGVElektrik.TabIndex = 0;
            // 
            // ElektrikForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1313, 640);
            Controls.Add(dGVElektrik);
            Name = "ElektrikForm";
            Text = "ElektrikForm";
            Load += ElektrikForm_Load;
            ((System.ComponentModel.ISupportInitialize)dGVElektrik).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dGVElektrik;
    }
}
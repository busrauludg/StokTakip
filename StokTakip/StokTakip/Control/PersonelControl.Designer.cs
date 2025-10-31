namespace StokTakip
{
    partial class PersonelControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lVlPersonel = new ListView();
            cmsPersonel = new ContextMenuStrip(components);
            silToolStripMenuItem = new ToolStripMenuItem();
            düzenleToolStripMenuItem = new ToolStripMenuItem();
            pnlDuzenle = new Panel();
            cBRol = new ComboBox();
            btnDuzen = new Button();
            tBTelNo = new TextBox();
            tBGorev = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmsPersonel.SuspendLayout();
            pnlDuzenle.SuspendLayout();
            SuspendLayout();
            // 
            // lVlPersonel
            // 
            lVlPersonel.Dock = DockStyle.Fill;
            lVlPersonel.FullRowSelect = true;
            lVlPersonel.GridLines = true;
            lVlPersonel.Location = new Point(0, 0);
            lVlPersonel.Name = "lVlPersonel";
            lVlPersonel.Size = new Size(1102, 635);
            lVlPersonel.TabIndex = 0;
            lVlPersonel.UseCompatibleStateImageBehavior = false;
            lVlPersonel.View = View.Details;
            // 
            // cmsPersonel
            // 
            cmsPersonel.ImageScalingSize = new Size(20, 20);
            cmsPersonel.Items.AddRange(new ToolStripItem[] { silToolStripMenuItem, düzenleToolStripMenuItem });
            cmsPersonel.Name = "contextMenuStrip1";
            cmsPersonel.Size = new Size(133, 52);
            // 
            // silToolStripMenuItem
            // 
            silToolStripMenuItem.Name = "silToolStripMenuItem";
            silToolStripMenuItem.Size = new Size(132, 24);
            silToolStripMenuItem.Text = "Sil ";
            silToolStripMenuItem.Click += silToolStripMenuItem_Click;
            // 
            // düzenleToolStripMenuItem
            // 
            düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            düzenleToolStripMenuItem.Size = new Size(132, 24);
            düzenleToolStripMenuItem.Text = "Düzenle";
            düzenleToolStripMenuItem.Click += düzenleToolStripMenuItem_Click;
            // 
            // pnlDuzenle
            // 
            pnlDuzenle.Controls.Add(cBRol);
            pnlDuzenle.Controls.Add(btnDuzen);
            pnlDuzenle.Controls.Add(tBTelNo);
            pnlDuzenle.Controls.Add(tBGorev);
            pnlDuzenle.Controls.Add(label3);
            pnlDuzenle.Controls.Add(label2);
            pnlDuzenle.Controls.Add(label1);
            pnlDuzenle.Location = new Point(926, 3);
            pnlDuzenle.Name = "pnlDuzenle";
            pnlDuzenle.Size = new Size(281, 299);
            pnlDuzenle.TabIndex = 1;
            // 
            // cBRol
            // 
            cBRol.FormattingEnabled = true;
            cBRol.Items.AddRange(new object[] { "Yetkili", "Personel" });
            cBRol.Location = new Point(85, 83);
            cBRol.Name = "cBRol";
            cBRol.Size = new Size(151, 28);
            cBRol.TabIndex = 7;
            // 
            // btnDuzen
            // 
            btnDuzen.Location = new Point(59, 222);
            btnDuzen.Name = "btnDuzen";
            btnDuzen.Size = new Size(94, 29);
            btnDuzen.TabIndex = 6;
            btnDuzen.Text = "Düzenle";
            btnDuzen.UseVisualStyleBackColor = true;
            btnDuzen.Click += btnDuzen_Click;
            // 
            // tBTelNo
            // 
            tBTelNo.Location = new Point(137, 138);
            tBTelNo.Name = "tBTelNo";
            tBTelNo.Size = new Size(125, 27);
            tBTelNo.TabIndex = 5;
            // 
            // tBGorev
            // 
            tBGorev.Location = new Point(82, 27);
            tBGorev.Name = "tBGorev";
            tBGorev.Size = new Size(125, 27);
            tBGorev.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 145);
            label3.Name = "label3";
            label3.Size = new Size(128, 20);
            label3.TabIndex = 2;
            label3.Text = "Telefon Numarası:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 88);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 1;
            label2.Text = "Rol:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 34);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 0;
            label1.Text = "Görev:";
            // 
            // PersonelControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlDuzenle);
            Controls.Add(lVlPersonel);
            Name = "PersonelControl";
            Size = new Size(1102, 635);
            Load += PersonelControl_Load;
            cmsPersonel.ResumeLayout(false);
            pnlDuzenle.ResumeLayout(false);
            pnlDuzenle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListView lVlPersonel;
        private ContextMenuStrip cmsPersonel;
        private ToolStripMenuItem silToolStripMenuItem;
        private ToolStripMenuItem düzenleToolStripMenuItem;
        private Panel pnlDuzenle;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tBGorev;
        private TextBox tBTelNo;
        private Button btnDuzen;
        private ComboBox cBRol;
    }
}

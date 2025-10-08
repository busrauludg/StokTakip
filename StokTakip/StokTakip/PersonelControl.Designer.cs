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
            cmsPersonel.SuspendLayout();
            SuspendLayout();
            // 
            // lVlPersonel
            // 
            lVlPersonel.Dock = DockStyle.Fill;
            lVlPersonel.FullRowSelect = true;
            lVlPersonel.GridLines = true;
            lVlPersonel.Location = new Point(0, 0);
            lVlPersonel.Name = "lVlPersonel";
            lVlPersonel.Size = new Size(809, 503);
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
            cmsPersonel.Click += cmsPersonel_Click;
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
            // PersonelControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lVlPersonel);
            Name = "PersonelControl";
            Size = new Size(809, 503);
            Load += PersonelControl_Load;
            cmsPersonel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView lVlPersonel;
        private ContextMenuStrip cmsPersonel;
        private ToolStripMenuItem silToolStripMenuItem;
        private ToolStripMenuItem düzenleToolStripMenuItem;
    }
}

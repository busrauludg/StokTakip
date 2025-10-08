using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
        }



        private void StkEkle_Click(object sender, EventArgs e)
        {
            pAnaSayfa.Controls.Clear();
            StokUserControl uc = new StokUserControl();
            uc.Dock = DockStyle.Fill;                  // paneli doldur
            pAnaSayfa.Controls.Add(uc);
        }

        private void btnProje_Click(object sender, EventArgs e)
        {
            pAnaSayfa.Controls.Clear();
            ProjeControl uc = new ProjeControl();
            uc.Dock = DockStyle.Fill;                  // paneli doldur
            pAnaSayfa.Controls.Add(uc);
        }

        private void pAnaSayfa_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPersonelBilgi_Click(object sender, EventArgs e)
        {
            pAnaSayfa.Controls.Clear();
            PersonelControl pr = new PersonelControl();
            pr.Dock = DockStyle.Fill;
            pAnaSayfa.Controls.Add(pr);
        }
    }
}

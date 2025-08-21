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
    public partial class PersonelEkle : Form
    {
        public PersonelEkle()
        {
            InitializeComponent();
            // Form açılır açılmaz yetkili şifre alanını gizle
            tBYetkiliSifre.Visible = false;
            lblYetkiliSifre.Visible = false;
        }

        private void rBPrsYetkili_CheckedChanged(object sender, EventArgs e)
        {
            tBYetkiliSifre.Visible= rBPrsYetkili.Checked;
            lblYetkiliSifre.Visible = rBPrsYetkili.Checked;
        
        }
    }
}

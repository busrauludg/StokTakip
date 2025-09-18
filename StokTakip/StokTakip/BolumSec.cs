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
    public partial class BolumSec : Form
    {
        public BolumSec()
        {
            InitializeComponent();
        }

        private void BtnMekanik_Click(object sender, EventArgs e)
        {
            MekanikForm mekanikForm = new MekanikForm();
            mekanikForm.ShowDialog();
        }

        private void BtnElektirik_Click(object sender, EventArgs e)
        {
            ElektrikForm elektrikForm = new ElektrikForm();
            elektrikForm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayf=new AnaSayfa();
            anaSayf.ShowDialog();
        }
    }
}

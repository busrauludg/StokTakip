using StokTakip.StokTakip.Data;
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
    public partial class MekanikForm : Form
    {
        public MekanikForm()
        {
            InitializeComponent();
        }

        private void MekanikForm_Load(object sender, EventArgs e)
        {
            using (var mekanik = new StokTakipContext())
            {
                var mekanikUrunler = mekanik.StokKartis
                    .Where(u => u.GrupId == 2)
                    .ToList();

                dGVMekanik.DataSource = mekanikUrunler;
            }
        }
    }
}

using StokTakip.Services;
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
    public partial class MekanikUrunDetayForm : Form
    {
        private MekanikServices mekanikServices;
       
        public MekanikUrunDetayForm()
        {
            InitializeComponent();
            mekanikServices = new MekanikServices(new StokTakipContext());
           
        }

        private void MekanikForm_Load(object sender, EventArgs e)
        {
            var liste = mekanikServices.GetStokKartiListesi();
            dGVMekanik.DataSource = liste;
        }
    }
}

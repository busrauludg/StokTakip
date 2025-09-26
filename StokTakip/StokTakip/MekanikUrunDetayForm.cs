using StokTakip.Models;
using StokTakip.Services;
using StokTakip.StokTakip.Data;
using StokTakip.ViewModels;
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
        private readonly StokKartiViewModel _secilenUrun;
       private readonly StokDurumuViewModel _durum;//(constructor tanımla )
        private readonly SatinAlmaSiparisleriViewModel _alim;

       
        public MekanikUrunDetayForm(StokKartiViewModel secilenUrun, 
            StokDurumuViewModel durum,SatinAlmaSiparisleriViewModel alim)
        {
            InitializeComponent();
            _secilenUrun = secilenUrun;
            _durum = durum;
            _alim = alim;
        }

        private void MekanikForm_Load(object sender, EventArgs e)
        {
         
            if(_secilenUrun != null)
            {
                var detaylar= new List<StokKartiViewModel> { _secilenUrun};
                dGVMekanik.DataSource=detaylar;
            }
            if (_durum != null)
            {
                var stdurum = new List<StokDurumuViewModel> { _durum };
                dGVMknStkDurum.DataSource=stdurum;

            }
            if(_alim != null)
            {
                var siparisalim=new List<SatinAlmaSiparisleriViewModel> { _alim };
                dGVSatinAlMekanik.DataSource=siparisalim;
            }
        }
    }
}

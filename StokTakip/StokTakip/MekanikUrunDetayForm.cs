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
            StokDurumuViewModel durum, SatinAlmaSiparisleriViewModel alim)
        {
            InitializeComponent();
            _secilenUrun = secilenUrun;
            _durum = durum;
            _alim = alim;
        }

        private void MekanikForm_Load(object sender, EventArgs e)
        {


            if (_secilenUrun != null)
            {
                txtMStokKodu.Text = _secilenUrun.StokKodu;
                txtMFirmaSiparisKodu.Text = _secilenUrun.FirmaKodu;
                txtMStokBirimi.Text = _secilenUrun.StokBirimi;
                txtMDepoAdresi.Text = _secilenUrun.DepoAdresi;
                txtMMinStok.Text = _secilenUrun.MinStok.ToString();
                txtMMaxStok.Text = _secilenUrun.MaxStok.ToString();
                txtMGrupAdi.Text = _secilenUrun.GrupAdi;
                txtMFirmaAdi.Text = _secilenUrun.FirmaAdi;
                txtMPersonelAdi.Text = _secilenUrun.PersonelAdi;
                txtMAciklama.Text = _secilenUrun.Aciklama;
            }
            //satınalma tablosu
            if (_alim != null)//adını değiştir 
            {

                dTPMekanik.Value = _alim.SiparisTarihi;           // DateTimePicker için Value kullan
                txtMMiktar.Text = _alim.Miktar.ToString();
                txtMCari.Text = _alim.CariAdi;
                txtMGlnMktr.Text = _alim.GelenMiktar?.ToString() ?? ""; // nullable int için
                txtMSprsAciklama.Text = _alim.Aciklama;
            }
            //stokdurumu tablosu olucak
            if (_durum != null)
            {
                var mdurum = new List<StokDurumuViewModel> { _durum };
                dGVMknStkDurum.DataSource = mdurum;
            }
            //picturebox
            if (_secilenUrun != null)
            {
                // diğer alanlar
                if (File.Exists(_secilenUrun.ResimYolu))
                {
                    pBMekanikResim.Image = Image.FromFile(_secilenUrun.ResimYolu);
                    pBMekanikResim.SizeMode = PictureBoxSizeMode.Zoom; // buraya
                }
            }


        }
    }
}

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
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class ElektrikUrunDetayForm : Form
    {
        private StokKartiViewModel _secilenUrun;
        private SatinAlmaSiparisleriViewModel _sipAlim;
        private StokDurumuViewModel _stokDurum;

        public ElektrikUrunDetayForm(StokKartiViewModel secilenUrun,
            SatinAlmaSiparisleriViewModel sipAlim,
            StokDurumuViewModel stokDurum)
        {
            InitializeComponent();
            _secilenUrun = secilenUrun;
            _sipAlim = sipAlim;
            _stokDurum=stokDurum;
        }

        private void ElektrikForm_Load(object sender, EventArgs e)
        {
            if (_secilenUrun != null)
            {
                txtStokKodu.Text = _secilenUrun.StokKodu;
                txtFirmaSiparisKodu.Text = _secilenUrun.FirmaKodu;
                txtStokBirimi.Text = _secilenUrun.StokBirimi;
                txtDepoAdresi.Text = _secilenUrun.DepoAdresi;
                txtMinStok.Text = _secilenUrun.MinStok.ToString();
                txtMaxStok.Text = _secilenUrun.MaxStok.ToString();
                txtGrupAdi.Text = _secilenUrun.GrupAdi;
                txtFirmaAdi.Text = _secilenUrun.FirmaAdi;
                txtPersonelAdi.Text = _secilenUrun.PersonelAdi;
                txtAciklama.Text = _secilenUrun.Aciklama;
            }
            if (_sipAlim != null)
            {

                dTPElektrik.Value = _sipAlim.SiparisTarihi;           // DateTimePicker için Value kullan
                txtMiktar.Text = _sipAlim.Miktar.ToString();
                txtCari.Text = _sipAlim.CariAdi;
                txtGlnMktr.Text = _sipAlim.GelenMiktar?.ToString() ?? ""; // nullable int için
                txtSprsAciklama.Text = _sipAlim.Aciklama;
            }
            if(_stokDurum!=null)
            {
                var stkdurum=new List<StokDurumuViewModel> { _stokDurum};
                dGVMekStokDurum.DataSource = stkdurum;
            }
            if(_secilenUrun!=null)
            {
                // diğer alanlar
                if (File.Exists(_secilenUrun.ResimYolu))
                {
                    pBElektrikResim.Image = Image.FromFile(_secilenUrun.ResimYolu);
                    pBElektrikResim.SizeMode = PictureBoxSizeMode.Zoom; // buraya
                }
            }
            lVAktifProje.View = View.Details;
            lVAktifProje.Columns.Add("Ürün Adı", 150);
            lVAktifProje.Columns.Add("Miktar", 70);
            if (_secilenUrun != null)
            {
                using (var context = new StokTakipContext())
                {
                    var liste = context.ProjedeKullanilanUrunlers
                        .Where(p => p.StokKartiId == _secilenUrun.StokKartiId) // seçilen ürün
                        .Select(p => new
                        {
                            p.Proje.ProjeAdi,
                            p.Miktar
                        }).ToList();

                    lVAktifProje.Items.Clear();
                    foreach (var item in liste)
                    {
                        var lvi = new ListViewItem(item.ProjeAdi);
                        lvi.SubItems.Add(item.Miktar.ToString());
                        lVAktifProje.Items.Add(lvi);
                    }
                }

            }

        }
    }
}

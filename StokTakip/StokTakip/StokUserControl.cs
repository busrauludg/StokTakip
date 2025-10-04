using StokTakip.Data;
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
    public partial class StokUserControl : UserControl
    {
        private readonly StokEkleServices _stokEkleServices;
        public StokUserControl()
        {
            InitializeComponent();
            // DbContext ve repository oluştur
            var context = new StokTakipContext();
            var repository = new AnaSayfaRepository(context);

            // Service'i repository ile başlat
            _stokEkleServices = new StokEkleServices(repository);
        }

        private void nUDMinStok_ValueChanged(object sender, EventArgs e)
        {
            nUDMinStok.Maximum = 10000;

        }

        private void nUDMaxStok_ValueChanged(object sender, EventArgs e)
        {
            nUDMaxStok.Maximum = 10000;
        }

        private void nUDSMiktar_ValueChanged(object sender, EventArgs e)
        {
            nUDSMiktar.Maximum = 10000;
        }

        private void nUDHareketM_ValueChanged(object sender, EventArgs e)
        {
            nUDHareketM.Maximum = 10000;
        }

        private void nUDSerbestM_ValueChanged(object sender, EventArgs e)
        {
            nUDSerbestM.Maximum = 10000;
        }

        private void nUDKM_ValueChanged(object sender, EventArgs e)
        {
            nUDKM.Maximum = 10000;
        }



        private void StokUserControl_Load(object sender, EventArgs e)
        {

        }
        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            //int personelId = 0;
            //int.TryParse(tBPersonelId.Text, out personelId);

            //int projeId = 0;
            //int.TryParse(tBProjeId.Text, out projeId);

            //var kaydet = new StokEkleViewModel
            //{//stokkarti
            //    UrunAdi = tBUrunAdi.Text,
            //    StokKodu = tBStokKodu.Text,
            //    GrupId = rBElektrik.Checked ? 1 : 2,
            //   // GrupAdi = rBElektrik.Checked ? "Elektrik" : "Mekanik",
            //    StokBirimi = tBStokBirimi.Text,
            //    MinStok = (int)nUDMinStok.Value,
            //    MaxStok = (int)nUDMaxStok.Value,
            //    StokMiktari = (int)nUDSMiktar.Value,
            //    DepoAdresi = tBDepoAdresi.Text,
            //    ResimYolu = tBResimYolu.Text,
            //    KayitTarihi = DateTime.Now,
            //    FirmaAdi = tBFirmaAdi.Text,
            //    FirmaKodu = tBFirmaKodu.Text,
            //    PersonelId = tBPersonelId,
            //    Aciklama = tBAciklama.Text,

            //    //stok durumu
            //    DepoAdi = tBDepoAdi.Text,
            //    SerbestMiktar = (int)nUDSerbestM.Value,
            //    KaliteMiktar = (int)nUDKM.Value,
            //    BlokeMiktar = tBBlokeM.Text,

            //    //StokHarekti
            //   // ProjeAdi = tBProjeId.Text,
            //    ProjeId=tBProjeId,
            //    Tip = rBTip.Checked ? "Girdi" : "Cikti",
            //    Miktar = (int)nUDHareketM.Value,
            //    Tarih = DateTime.Now,
            //    sHAciklama = tBShAciklama.Text
            //};
            //_stokEkleServices.StokEkle(kaydet);

            int personelId = 0;
            int.TryParse(tBPersonelId.Text, out personelId);

            int projeId = 0;
            int.TryParse(tBProjeId.Text, out projeId);

            var kaydet = new StokEkleViewModel
            {
                UrunAdi = tBUrunAdi.Text,
                StokKodu = tBStokKodu.Text,
                GrupId = rBElektrik.Checked ? 1 : 2,
                StokBirimi = tBStokBirimi.Text,
                MinStok = (int)nUDMinStok.Value,
                MaxStok = (int)nUDMaxStok.Value,
                StokMiktari = (int)nUDSMiktar.Value,
                DepoAdresi = tBDepoAdresi.Text,
                ResimYolu = tBResimYolu.Text,
                KayitTarihi = DateTime.Now,
                FirmaAdi = tBFirmaAdi.Text,
                FirmaKodu = tBFirmaKodu.Text,
                PersonelId = personelId,
                Aciklama = tBAciklama.Text,

                DepoAdi = tBDepoAdi.Text,
                SerbestMiktar = (int)nUDSerbestM.Value,
                KaliteMiktar = (int)nUDKM.Value,
                BlokeMiktar = tBBlokeM.Text,

                ProjeId = projeId,
                Tip = rBTip.Checked ? "Girdi" : "Cikti",
                Miktar = (int)nUDHareketM.Value,
                Tarih = DateTime.Now,
                sHAciklama = tBShAciklama.Text
            };
            _stokEkleServices.StokEkle(kaydet);

        }
    }
}

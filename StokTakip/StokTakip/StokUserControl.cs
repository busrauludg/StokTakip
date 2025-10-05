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

       
        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            int personelId = 0;
            int.TryParse(tBPersonelId.Text, out personelId);

            int projeId = 0;
            int.TryParse(tBProjeId.Text, out projeId);

            int prsonelIdSh;
            int.TryParse(tBSHPersonelId.Text, out prsonelIdSh);


            int satinalmaMiktari = 0;
            int.TryParse(tBStnAlMiktar.Text, out satinalmaMiktari);

            int gelenMiktar = 0;
            int.TryParse(tBStnAlmaGelen.Text, out gelenMiktar);

            int birimFiyat = 0;
            int.TryParse(tBStnAlmaBirim.Text, out birimFiyat);

            int kur = 0;
            int.TryParse(tBStnAlmaKur.Text, out kur);


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
                PersonelIdSh= prsonelIdSh,
                Tip = rBTip.Checked ? "Girdi" : "Cikti",
                Miktar = (int)nUDHareketM.Value,
                Tarih = DateTime.Now,
                sHAciklama = tBShAciklama.Text,

                //Satın Alma
                //StokKaritId= tBSKId.Text,// bunu hatası stokekle ile aynı yerde ekliyoruz buun stokkartınıeklerkenıd de ekliyor ama bu satınalmayıda aynı tabloda eklemem lazım napıcaz
                SiparisTarihi = DateTime.Now,
                StnAlmaMiktar = satinalmaMiktari, //int parse yap
                CariAdi = tBStnAlmaCari.Text,
                GelenMiktar = gelenMiktar,
                BirimFiyat = birimFiyat,
                Kur = kur,
                ParaBirimi = tBStnAlmaParaBirm.Text,
                StnAlmaAciklama = tBStnAlmaAciklama.Text,
                StnAlmaPersonelId = personelId,


            };
            try
            {
                _stokEkleServices.StokEkle(kaydet);
                MessageBox.Show("Kayıt başarılı!");
            }
            catch
            {
                MessageBox.Show("Kayıt sırasında bir hata oluştu!");
            }


        }
    }
}

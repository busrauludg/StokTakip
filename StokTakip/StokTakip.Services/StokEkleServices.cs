using StokTakip.Data;
using StokTakip.Models;
using StokTakip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Services
{
    public class StokEkleServices
    {
        private readonly AnaSayfaRepository _anasayfa;
        public StokEkleServices(AnaSayfaRepository anasayfa)
        {
            _anasayfa = anasayfa;
        }
        public void StokEkle(StokEkleViewModel eklemodel)
        {
            var stokEkle = new StokKarti
            {
                //stokkarti
                UrunAdi = eklemodel.UrunAdi,
                StokKodu = eklemodel.StokKodu,
                GrupId = eklemodel.GrupId,
                //GrupAdi = eklemodel.GrupAdi,
                StokBirimi = eklemodel.StokBirimi,
                MinStok = eklemodel.MinStok,
                MaxStok = eklemodel.MaxStok,
                StokMiktari = eklemodel.StokMiktari,
                DepoAdresi = eklemodel.DepoAdresi,
                ResimYolu = eklemodel.ResimYolu,
                KayitTarihi = DateTime.Now,
                FirmaAdi = eklemodel.FirmaAdi,
                FirmaKodu = eklemodel.FirmaKodu,
                PersonelId = eklemodel.PersonelId,
                Aciklama = eklemodel.Aciklama,
            };
            var stokDurum = new StokDurumu
            {
                DepoAdi = eklemodel.DepoAdi,
                SerbestMiktar = (int)eklemodel.SerbestMiktar,
               // KaliteMiktar = (int)eklemodel.KaliteMiktar,
                BlokeMiktar = eklemodel.BlokeMiktar,
            };

            //28.10
            //var stokHareketi = new StokHareketi
            //{
            //    //StokHarekti
            //    ProjeId = eklemodel.ProjeId,
            //    Tip = eklemodel.Tip,
            //    Miktar = eklemodel.Miktar,
            //    Tarih = DateTime.Now,
            //    Aciklama = eklemodel.sHAciklama
            //};
            var satinAlma = new SatinAlma
            {
                //sol taraftakiler entetiy(model)alanlar
                SiparisTarihi = DateTime.Now,
                Miktar = eklemodel.StnAlmaMiktar, //int parse yap
                CariAdi = eklemodel.CariAdi,
                GelenMiktar = eklemodel.GelenMiktar,
                BirimFiyat = eklemodel.BirimFiyat,
                Kur = eklemodel.Kur,
                ParaBirimi = eklemodel.ParaBirimi,
                Aciklama = eklemodel.Aciklama,
                ToplamMaliyet=eklemodel.ToplamMaliyet,
                PersonelId = eklemodel.PersonelId,
            };
          //  stokHareketi.PersonelId = eklemodel.PersonelIdSh;//kendi stokharekiti tablosunda normal personelıd oldugu için hata alıyor 
            _anasayfa.StokEkle(stokEkle, stokDurum,  satinAlma);
        }
        //public List<Proje> GetProjeler()
        //{
        //    return _anasayfa.GetProjeler(); // AnaSayfaRepository içinde Projeleri çeken metod
        //}

    }
}

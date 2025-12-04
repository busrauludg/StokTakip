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
                UrunAdi = eklemodel.UrunAdi,
                StokKodu = eklemodel.StokKodu,
                GrupId = eklemodel.GrupId,
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
                BlokeMiktar = eklemodel.BlokeMiktar,
            };
            var satinAlma = new SatinAlma
            {
                SiparisTarihi = DateTime.Now,
                Miktar = eklemodel.StnAlmaMiktar, 
                CariAdi = eklemodel.CariAdi,
                GelenMiktar = eklemodel.GelenMiktar,
                BirimFiyat = eklemodel.BirimFiyat,
                Kur = eklemodel.Kur,
                ParaBirimi = eklemodel.ParaBirimi,
                Aciklama = eklemodel.Aciklama,
                ToplamMaliyet=eklemodel.ToplamMaliyet,
                PersonelId = eklemodel.PersonelId,
            };
            _anasayfa.StokEkle(stokEkle, stokDurum,  satinAlma);
        }
        

    }
}

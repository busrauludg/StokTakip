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
                KaliteMiktar = (int)eklemodel.KaliteMiktar,
                BlokeMiktar = eklemodel.BlokeMiktar,
            };

            var stokHareketi = new StokHareketi
            {
                //StokHarekti
                //ProjeAdi = eklemodel.ProjeAdi,
                ProjeId = eklemodel.ProjeId,
                Tip = eklemodel.Tip,
                Miktar = eklemodel.Miktar,
                Tarih = DateTime.Now,
                Aciklama = eklemodel.sHAciklama
            };
            _anasayfa.StokEkle(stokEkle, stokDurum, stokHareketi);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using StokTakip.StokTakip.Data;
using StokTakip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Services
{
    public class ElektrikServices
    {
        private readonly StokTakipContext _context;
        public ElektrikServices(StokTakipContext context)
        {
            _context = context;
        }
        public List<StokKartiViewModel>GetStokKartiElektrik()
        {
            var liste=_context.StokKartis
                .Include(u=>u.Grup)
                .Include(u=>u.Personel)
                .Where(u=>u.GrupId==1)
                .Select(u => new StokKartiViewModel
                {
                    StokKartiId=u.StokKartiId,
                    UrunAdi = u.UrunAdi,
                    StokKodu = u.StokKodu,
                    GrupAdi = u.Grup.GrupAdi,
                    MinStok = u.MinStok,
                    MaxStok = u.MaxStok,
                    DepoAdresi = u.DepoAdresi,
                    ResimYolu = u.ResimYolu,
                    Aciklama = u.Aciklama,
                    KayitTarihi = u.KayitTarihi,
                    FirmaAdi = u.FirmaAdi,
                    FirmaKodu = u.FirmaKodu,
                    StokMiktari = u.StokMiktari,//22.09.20250
                    StokBirimi = u.StokBirimi,
                    PersonelAdi = u.Personel.Ad
                })
             .ToList();
            return liste;
        }
        public SatinAlmaSiparisleriViewModel GetSatinAlmaElektrik(int StokKartId)
        {
            return _context.SatinAlmas
                .Where(s => s.StokKartiId == StokKartId)
                .Select(s => new SatinAlmaSiparisleriViewModel
                {
                    StokKartId = s.StokKartiId,
                    SiparisTarihi = s.SiparisTarihi,
                    Miktar = s.Miktar,
                    CariAdi = s.CariAdi,
                    GelenMiktar = s.GelenMiktar,
                    Aciklama = s.Aciklama
                })
                .FirstOrDefault();

        }
        public StokDurumuViewModel GetStokDurumElektrik(int stokKartId)//mekanikten kopyaladım
        {
            return _context.StokDurumus
                .Where(s => s.StokKartiId == stokKartId)
                .Select(s => new StokDurumuViewModel
                {
                    StokKartId = s.StokKartiId,
                    DepoAdi = s.DepoAdi,
                    SerbestMiktar = s.SerbestMiktar,
                   // KaliteMiktar = s.KaliteMiktar,
                    BlokeMiktar = s.BlokeMiktar.ToString()
                })
                .FirstOrDefault();
        }

    }
}

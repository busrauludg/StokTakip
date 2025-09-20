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
                    StokBirimi = u.StokBirimi,
                    PersonelAdi = u.Personel.Ad
                })
             .ToList();
            return liste;
        }

    }
}

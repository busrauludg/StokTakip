using Microsoft.EntityFrameworkCore;
using StokTakip.Models;
using StokTakip.StokTakip.Data;
using StokTakip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Services
{
    public class MekanikServices
    {
        private readonly StokTakipContext _context;//direk veritabanına bağladık repositr ihtiyac yok
        public MekanikServices(StokTakipContext context)
        {
            _context = context;
        }
        public List<StokKartiViewModel>GetStokKartiListesi()
        {
                var liste = _context.StokKartis
             .Include(u => u.Grup)
             .Include(u => u.Personel)
             .Where(u => u.GrupId == 2) // sabit mekanik grubu
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
                 StokMiktari=u.StokMiktari,//22.09.20250
                 StokBirimi = u.StokBirimi,
                 PersonelAdi = u.Personel.Ad
             })
             .ToList();

            return liste;
        }

    }
}

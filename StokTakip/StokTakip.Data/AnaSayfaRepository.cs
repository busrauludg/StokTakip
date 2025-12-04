using StokTakip.Models;
using StokTakip.StokTakip.Data;
using StokTakip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data
{
    public class AnaSayfaRepository
    {
        private readonly StokTakipContext _context;
        public AnaSayfaRepository(StokTakipContext context) => _context = context;
        
        public void StokEkle(StokKarti stokKarti,StokDurumu stokDurumu,SatinAlma satinAlma)
        {
            _context.StokKartis.Add(stokKarti);
            _context.SaveChanges();

            satinAlma.StokKartiId = stokKarti.StokKartiId;
            _context.SatinAlmas.Add(satinAlma);

            stokDurumu.StokKartiId = stokKarti.StokKartiId;

            _context.StokDurumus.Add(stokDurumu);
            _context.SaveChanges();

        }
        public void ProjeEkle(Proje proje)
        {
            _context.Add(proje);
            _context.SaveChanges();
        }
    }
}

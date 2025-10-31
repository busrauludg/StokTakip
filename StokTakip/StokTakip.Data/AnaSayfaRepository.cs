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
        
        public void StokEkle(StokKarti stokKarti,StokDurumu stokDurumu,SatinAlma satinAlma)//StokHareketi stokHareketi)
        {
            // 1. StokKarti kaydet
            _context.StokKartis.Add(stokKarti);
            _context.SaveChanges(); // Burada stokKarti.StokKartiId oluşur

            // 2. SatinAlma'ya ID ver
            satinAlma.StokKartiId = stokKarti.StokKartiId;
            _context.SatinAlmas.Add(satinAlma);

            // 3. Diğer tablolar
          //  stokHareketi.StokKartiId = stokKarti.StokKartiId;
            stokDurumu.StokKartiId = stokKarti.StokKartiId;

          //  _context.StokHareketis.Add(stokHareketi);
            _context.StokDurumus.Add(stokDurumu);
            _context.SaveChanges();

        }
        public void ProjeEkle(Proje proje)
        {
            _context.Add(proje);
            _context.SaveChanges();
        }

        ////28.10 stokeklede combobax proje secimi için yapıyorum 
        //public List<Proje> GetProjeler()
        //{
        //    return _context.Projes.ToList();
        //}

    }
}

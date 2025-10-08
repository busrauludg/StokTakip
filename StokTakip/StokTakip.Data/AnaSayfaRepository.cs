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
        
        public void StokEkle(StokKarti stokKarti,StokDurumu stokDurumu,StokHareketi stokHareketi,SatinAlma satinAlma)
        {
            // 1. StokKarti kaydet
            _context.StokKartis.Add(stokKarti);
            _context.SaveChanges(); // Burada stokKarti.StokKartiId oluşur

            // 2. SatinAlma'ya ID ver
            satinAlma.StokKartiId = stokKarti.StokKartiId;
            _context.SatinAlmas.Add(satinAlma);

            // 3. Diğer tablolar
            stokHareketi.StokKartiId = stokKarti.StokKartiId;
            stokDurumu.StokKartiId = stokKarti.StokKartiId;

            _context.StokHareketis.Add(stokHareketi);
            _context.StokDurumus.Add(stokDurumu);
            _context.SaveChanges();

        }
        public void ProjeEkle(Proje proje)
        {
            _context.Add(proje);
            _context.SaveChanges();
        }
        //public void ProjeKullanilanUrunEkle(ProjedeKullanilanUrunler aktifPrjEkle)
        //{
        //    _context.ProjedeKullanilanUrunlers.Add(aktifPrjEkle);
        //    _context.SaveChanges();
        ////}
        //public void ProjeKullanilanUrunEkle(ProjedeKullanilanUrunler projeKullanilan)
        //{
        //    _context.ProjedeKullanilanUrunlers.Add(projeKullanilan);
        //    _context.SaveChanges();
        //}

    }
}

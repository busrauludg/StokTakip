using StokTakip.Models;
using StokTakip.StokTakip.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data
{
    public class PersonelRepository 
    {
        private readonly StokTakipContext _context;
        public PersonelRepository(StokTakipContext context) => _context = context;

        public Personel? GetByEposta(string eposta) =>
            _context.Personels.FirstOrDefault(p => p.Eposta == eposta);

        public Personel? GetBySifre(string sifre) =>
            _context.Personels.FirstOrDefault(p => p.Sifre == sifre);

        //13.09 servicste boş bir referances var ve bu metotun amacı Veritabanındaki YetkiliSifre değerini gösterecek veya okuyacak kod, senin repository’de yazdığın getter metodu.
        public string? GetSistemYetkiliSifre() =>
            _context.Personels.FirstOrDefault(p => p.Rol)?.YetkiliSifre;
        //11.09.2025
        //12.09 gerek yok denildi 
        //13.09 serviceste boş bir referances var 
        public Personel? GetYetkiliSifre(string yetkiliSifre) =>
            _context.Personels.FirstOrDefault(p => p.YetkiliSifre == yetkiliSifre);

        public void PrsnlKydt(Personel p)
        {
            _context.Personels.Add(p);
            _context.SaveChanges();

        }
        //15.10.2025
        public Personel? GetByRol()
        {
            return _context.Personels.FirstOrDefault(p => p.Rol == true);
        }

        public void YetkiliEkle(Personel p)
        {
            _context.SaveChanges(); // sadece güncellenen personeli kaydet
        }

        //}
        //15.09.20025 personel giriş için 
        public bool PersonelVarMi(string eposta,string sifre)
        {
            return _context.Personels.Any(p=>p.Eposta==eposta && p.Sifre==sifre);
        }

        public string? GetYetkiliSifreHash()
        {
            return _context.Personels
                           .Where(p => p.YetkiliSifre != null)
                           .Select(p => p.YetkiliSifre)
                           .FirstOrDefault();
        }

    }
}

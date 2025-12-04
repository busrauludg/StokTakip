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

    
        public void PrsnlKydt(Personel p)
        {
            _context.Personels.Add(p);
            _context.SaveChanges();

        }
        public bool PersonelVarMi(string eposta,string sifre)
        {
            return _context.Personels.Any(p=>p.Eposta==eposta && p.Sifre==sifre);
        }

        public string? GetYetkiliSifreHash()
        {
            return _context.Personels
                           .Where(p => p.YetkiliSifre1 != null)
                           .Select(p => p.YetkiliSifre1)
                           .FirstOrDefault();
        }

    }
}

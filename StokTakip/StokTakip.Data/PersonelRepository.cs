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
     
        public void Add(Personel p)
        {
            _context.Add(p);
            _context.SaveChanges();
        }
    }
}

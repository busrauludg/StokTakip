using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Dto
{
    public class PersonelDto
    {
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public string Gorev { get; set; } = null!;
        public string Telefon { get; set; } = null!;
        public string? Eposta { get; set; }
        public string Sifre { get; set; } = null!;
        public string SifreTekrari { get; set; } = null!;
        public bool Rol { get; set; }
        public string? YetkiliSifre1 { get; set; }
    }
    
}

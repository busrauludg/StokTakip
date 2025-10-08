using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.ViewModels
{
    public class ProjeEkleViewModel
    {
        public int ProjeId { get; set; }
        public string ProjeAdi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Aciklama { get; set; }
        public int PersonelId { get; set; }//burda ıd değil ad olsun istiyorum 
        public bool Durum { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.ViewModels
{
    public class StokKartiViewModel
    {
        public int StokKartiId { get; set; }
        public string UrunAdi { get; set; }
        public string StokKodu { get; set; }
        public string GrupAdi { get; set; }
        public string StokBirimi { get; set; }
        public int MinStok { get; set; }
        public int MaxStok { get; set; }
        public string DepoAdresi { get; set; }
        public string ResimYolu { get; set; }
        public string Aciklama { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string FirmaKodu { get; set; }
        public int StokMiktari { get; set; }
        public string FirmaAdi { get; set; }   
        public string PersonelAdi { get; set; }  
    }
}

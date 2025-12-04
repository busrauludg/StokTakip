using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.ViewModels
{
    public class SatinAlmaSiparisleriViewModel
    {
        public int StokKartId { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public int Miktar { get; set; }
        public string CariAdi { get; set; }
        public int GelenMiktar { get; set; }
        public decimal ToplamMaliyet { get; set; }
        public string Aciklama { get; set; }


    }
}

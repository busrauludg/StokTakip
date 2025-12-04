using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.ViewModels
{
    public class StokEkleViewModel
    {
        public string UrunAdi { get; set; }
        public string StokKodu { get; set; }
        public int GrupId { get; set; }
        public string StokBirimi { get; set; }
        public int MinStok { get; set; }
        public int MaxStok { get; set; }
        public int StokMiktari { get; set; }
        public string DepoAdresi { get; set; }
        public string ResimYolu { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string FirmaAdi { get; set; }
        public string FirmaKodu { get; set; }
        public int PersonelId { get; set; }
        public string Aciklama { get; set; }

        public string DepoAdi { get; set; }
        public int SerbestMiktar { get; set; }
        public string BlokeMiktar { get; set; }

        public DateTime SiparisTarihi { get; set; }
        public int StnAlmaMiktar { get; set; }
        public string CariAdi { get; set; }
        public int GelenMiktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Kur { get; set; }
        public string ParaBirimi { get; set; }
        public decimal ToplamMaliyet { get; set; }
        public string StnAlmaAciklama { get; set; }
        public int StnAlmaPersonelId { get; set; }
    }
}
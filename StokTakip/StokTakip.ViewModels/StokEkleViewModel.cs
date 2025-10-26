using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.ViewModels
{
    public class StokEkleViewModel
    {
        //Stok Kartı 02.10.2025
        public string UrunAdi { get; set; }
        public string StokKodu { get; set; }
        public int GrupId { get; set; }
       // public string GrupAdi { get; set; }
        public string StokBirimi { get; set; }
        public int MinStok { get; set; }
        public int MaxStok { get; set; }
        public int StokMiktari { get; set; }
        public string DepoAdresi { get; set; }
        public string ResimYolu { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string FirmaAdi { get; set; }
        public string FirmaKodu { get; set; }
       // public string PersonelAdi { get; set; }
        public int PersonelId { get; set; }
        public string Aciklama { get; set; }

        //Stok durumu 
        public string DepoAdi { get; set; }
        public int SerbestMiktar { get; set; }
        //public int KaliteMiktar { get; set; }
        public string BlokeMiktar { get; set; }

        //Stok Hareket
        public int PersonelIdSh { get; set; }
        public int ProjeId { get; set; }
        public string ProjeAdi { get; set; }
        public string Tip { get; set; }
        public int Miktar { get; set; }
        public DateTime Tarih { get; set; }
        public string sHAciklama { get; set; }


        //Satin Alma 
        //public int StokKartiId { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public int StnAlmaMiktar { get; set; }
        public string CariAdi { get; set; }
        public int GelenMiktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Kur { get; set; }
        public string ParaBirimi { get; set; }
        //23.10
        public decimal ToplamMaliyet { get; set; }
        public string StnAlmaAciklama { get; set; }
        public int StnAlmaPersonelId { get; set; }
    }
}

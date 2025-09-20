using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.ViewModels
{
    public class StokKartiViewModel
    {
        //Uı ile uyumlu olmak zorunda dto yada veritabanı ile değil 
     
        public string UrunAdi { get; set; }
        public string StokKodu { get; set; }
        public string GrupAdi { get; set; }//içinde bulundugu grup yazsın grupıd değil düzelt
        public string StokBirimi { get; set; }
        public int MinStok { get; set; }
        public int MaxStok { get; set; }
        public string DepoAdresi { get; set; }
        public string ResimYolu { get; set; }
        public string Aciklama { get; set; }
        public DateTime KayitTarihi { get; set; }//bu veritabanınad böyle olmaaybilir
        public string FirmaKodu { get; set; }
        public int StokMiktari { get; set; }
        // ID’lerden gelen ilişkili isimler (UI’de gösterilecek)
        public string FirmaAdi { get; set; }       // FirmaKodu yerine firma adı
        public string PersonelAdi { get; set; }    // PersonelId yerine personel adı
    }
}

using System;
using System.Collections.Generic;

namespace StokTakip.Models;

public partial class SatinAlma
{
    public int SiparisId { get; set; }

    public int StokKartiId { get; set; }

    public DateTime SiparisTarihi { get; set; }

    public int Miktar { get; set; }

    public string CariAdi { get; set; }//bu

    public int GelenMiktar { get; set; }//bu

    public decimal BirimFiyat { get; set; }//bu

    public decimal Kur { get; set; }//bu

    public string ParaBirimi { get; set; }//bu

    public string? Aciklama { get; set; }
    public decimal ToplamMaliyet { get; set; }

    public int? PersonelId { get; set; }

    public virtual Personel? Personel { get; set; }

    public virtual StokKarti StokKarti { get; set; } = null!;
}

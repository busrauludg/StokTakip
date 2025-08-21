using System;
using System.Collections.Generic;

namespace StokTakip.Models;

public partial class SatinAlma
{
    public int SiparisId { get; set; }

    public int StokKartiId { get; set; }

    public DateTime SiparisTarihi { get; set; }

    public int Miktar { get; set; }

    public string? CariAdi { get; set; }

    public int? GelenMiktar { get; set; }

    public decimal? BirimFiyat { get; set; }

    public decimal? Kur { get; set; }

    public string? ParaBirimi { get; set; }

    public string? Aciklama { get; set; }

    public int? PersonelId { get; set; }

    public virtual Personel? Personel { get; set; }

    public virtual StokKarti StokKarti { get; set; } = null!;
}

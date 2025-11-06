using System;
using System.Collections.Generic;

namespace StokTakip.Models;

public partial class StokKarti
{
    public int StokKartiId { get; set; }

    public string UrunAdi { get; set; } = null!;

    public string StokKodu { get; set; } = null!;

    public int GrupId { get; set; }

    public string StokBirimi { get; set; } = null!;

    public int MinStok { get; set; }

    public int MaxStok { get; set; }

    public string DepoAdresi { get; set; } = null!;

    public string? ResimYolu { get; set; }

    public string? Aciklama { get; set; }

    public DateTime KayitTarihi { get; set; }

    public string? FirmaKodu { get; set; }

    public string FirmaAdi { get; set; } = null!;

    public int PersonelId { get; set; }
    //18.09
    public int StokMiktari { get; set; }
    public bool AktifMi { get; set; } = true;

    public virtual Gruplar Grup { get; set; } = null!;

    //19.09 db kolon olarak eklenmez personel ile navigasyon üzerinden iletişim kuruar
    public virtual Personel Personel { get; set; } = null!;
   
    public virtual ICollection<ProjedeKullanilanUrunler> ProjedeKullanilanUrunlers { get; set; } = new List<ProjedeKullanilanUrunler>();

    public virtual ICollection<SatinAlma> SatinAlmas { get; set; } = new List<SatinAlma>();

    public virtual ICollection<StokDurumu> StokDurumus { get; set; } = new List<StokDurumu>();

    public virtual ICollection<StokHareketi> StokHareketis { get; set; } = new List<StokHareketi>();
}

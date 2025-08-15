using System;
using System.Collections.Generic;

namespace StokTakip.Models;

public partial class Personel
{
    public int PersonelId { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public string Gorev { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public string? Eposta { get; set; }

    public string Sifre { get; set; } = null!;

    public DateTime KayitTarihi { get; set; }

    public virtual ICollection<Proje> Projes { get; set; } = new List<Proje>();

    public virtual ICollection<SatinAlma> SatinAlmas { get; set; } = new List<SatinAlma>();

    public virtual ICollection<StokHareketi> StokHareketis { get; set; } = new List<StokHareketi>();
}

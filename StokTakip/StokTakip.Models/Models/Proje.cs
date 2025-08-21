using System;
using System.Collections.Generic;

namespace StokTakip.Models;

public partial class Proje
{
    public int ProjeId { get; set; }

    public string ProjeAdi { get; set; } = null!;

    public DateTime BaslangicTarihi { get; set; }

    public DateTime BitisTarihi { get; set; }

    public int PersonelId { get; set; }

    public string? Aciklama { get; set; }

    public bool Durum { get; set; }

    public virtual Personel Personel { get; set; } = null!;

    public virtual ICollection<ProjedeKullanilanUrunler> ProjedeKullanilanUrunlers { get; set; } = new List<ProjedeKullanilanUrunler>();

    public virtual Rapor? Rapor { get; set; }
}

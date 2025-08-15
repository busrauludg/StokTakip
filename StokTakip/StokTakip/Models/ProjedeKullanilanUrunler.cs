using System;
using System.Collections.Generic;

namespace StokTakip.Models;

public partial class ProjedeKullanilanUrunler
{
    public int KullanilanUrunId { get; set; }

    public int ProjeId { get; set; }

    public int StokKartiId { get; set; }

    public int Miktar { get; set; }

    public decimal Maliyet { get; set; }

    public virtual Proje Proje { get; set; } = null!;

    public virtual StokKarti StokKarti { get; set; } = null!;
}

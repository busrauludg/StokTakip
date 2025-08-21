using System;
using System.Collections.Generic;

namespace StokTakip.Models;

public partial class StokHareketi
{
    public int HareketId { get; set; }

    public int StokKartiId { get; set; }

    public int PersonelId { get; set; }

    public int ProjeId { get; set; }

    public string Tip { get; set; } = null!;

    public int Miktar { get; set; }

    public DateTime Tarih { get; set; }

    public string? Aciklama { get; set; }

    public virtual Personel Personel { get; set; } = null!;

    public virtual StokKarti StokKarti { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace StokTakip.Models;

public partial class Rapor
{
    public int RaporId { get; set; }

    public int ProjeId { get; set; }

    public DateTime BaslangicTarihi { get; set; }

    public DateTime BitisTarihi { get; set; }

    public int PersonelId { get; set; }

    public decimal HarcananTutar { get; set; }

    public decimal GelenTutar { get; set; }

    public decimal KullanilanMaliyet { get; set; }

    public string? ProjeAciklama { get; set; }

    public virtual Proje RaporNavigation { get; set; } = null!;
}

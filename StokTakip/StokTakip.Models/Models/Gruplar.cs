using System;
using System.Collections.Generic;

namespace StokTakip.Models;

public partial class Gruplar
{
    public int GrupId { get; set; }

    public string GrupAdi { get; set; } = null!;

    public virtual ICollection<StokKarti> StokKartis { get; set; } = new List<StokKarti>();
}

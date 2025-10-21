using System;
using System.Collections.Generic;

namespace StokTakip.Models;

public partial class StokDurumu
{
    public int DurumId { get; set; }

    public int StokKartiId { get; set; }

    public string DepoAdi { get; set; } = null!;

    public int SerbestMiktar { get; set; }

   // public int KaliteMiktar { get; set; }

    public string BlokeMiktar { get; set; } = null!;

    public virtual StokKarti StokKarti { get; set; } = null!;
}

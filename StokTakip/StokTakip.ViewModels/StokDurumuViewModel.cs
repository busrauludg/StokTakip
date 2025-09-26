using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.ViewModels
{
    public class StokDurumuViewModel
    {
        public int StokKartId { get; set; }
        public string DepoAdi { get; set; }
        public int SerbestMiktar { get; set; }
        public int KaliteMiktar { get; set; }
        public string BlokeMiktar { get; set; }
    }
}

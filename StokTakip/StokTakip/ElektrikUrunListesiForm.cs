using StokTakip.StokTakip.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class ElektrikUrunListesiForm : Form
    {
        private readonly StokTakipContext _context;
        public ElektrikUrunListesiForm()
        {
            InitializeComponent();
            _context = new StokTakipContext();
        }

        private void ElektrikUrunListesiForm_Load(object sender, EventArgs e)
        {
            //dGVElektrikListesi.AutoGenerateColumns=true;
            //var urunler=_context.StokKartis
            //    .Where(u=>u.GrupId==1)
            //    .Select(u=>u.UrunAdi)
            //    .ToList();

            //dGVElektrikListesi.DataSource=urunler;   böyle yapaınca lengeth diye bir uzunluk geldi mesela laptop yerine 6 geldi

            dGVElektrikListesi.AutoGenerateColumns = true;
            var urunler = _context.StokKartis
                .Where(u => u.GrupId == 1)
                .Select(u => new {
                    ÜrünListesi = u.UrunAdi +"("+u.StokMiktari + ")"
                })
                .ToList();

            dGVElektrikListesi.DataSource = urunler;
        }
    }
}

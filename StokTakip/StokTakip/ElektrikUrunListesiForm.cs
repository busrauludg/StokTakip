using StokTakip.Models;
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
            dGVElektrikListesi.AutoGenerateColumns = true;
            var urunler = _context.StokKartis
                .Where(u => u.GrupId == 1)
                .ToList();

            dGVElektrikListesi.DataSource = urunler;
            //eğer columlar urunadi ve stokmiktari değilse gösterme dedik
            foreach(DataGridViewColumn col in dGVElektrikListesi.Columns)
            {
                if(col.Name !="UrunAdi"&&col.Name!="StokMiktari")
                    col.Visible=false;
            }
            dGVElektrikListesi.Columns["UrunAdi"].HeaderText = "Ürün Adı";
            dGVElektrikListesi.Columns["StokMiktari"].HeaderText = "Stok Miktarı";
        }

        private void dGVElektrikListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0)
            {
                StokKarti secilen = (StokKarti)dGVElektrikListesi.Rows[e.RowIndex].DataBoundItem;
                ElektrikUrunDetayForm elektrikdform = new ElektrikUrunDetayForm();
                elektrikdform.SecilenUrun=secilen;
                elektrikdform.ShowDialog();
            }
        }
    }
}

using StokTakip.Models;
using StokTakip.Services;
using StokTakip.StokTakip.Data;
using StokTakip.ViewModels;
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
{///gercek proje
    public partial class MekanikUrunListesiForm : Form
    {
        private readonly StokTakipContext _context;
        private readonly MekanikServices _services;
      
        public MekanikUrunListesiForm()
        {
            InitializeComponent();
            _context = new StokTakipContext();
            _services = new MekanikServices(_context);
          
        }

        private void MekanikUrunListesiForm_Load(object sender, EventArgs e)
        {

            var urunler = _services.GetStokKartiListesi();
            dGVMekanikListesi.DataSource = urunler;

          
            // Sadece istediğin sütunları göster, diğerlerini gizle
            foreach (DataGridViewColumn col in dGVMekanikListesi.Columns)
            {
                if (col.Name != "UrunAdi" && col.Name != "StokMiktari")
                    col.Visible = false;
            }

            // Başlıkları özelleştir
            dGVMekanikListesi.Columns["UrunAdi"].HeaderText = "Ürün Adı";
            dGVMekanikListesi.Columns["StokMiktari"].HeaderText = "Stok Miktarı";

        }

        private void dGVMekanikListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    StokKarti secilen = (StokKarti)dGVMekanikListesi.Rows[e.RowIndex].DataBoundItem;
            //    MekanikUrunDetayForm detayForm = new MekanikUrunDetayForm();
            //    detayForm.SecilenUrun= secilen;              
            //    detayForm.ShowDialog();
            //}
            if(e.RowIndex >=0)
            {
                StokKartiViewModel secilen=(StokKartiViewModel)dGVMekanikListesi.Rows[e.RowIndex].DataBoundItem;

               StokDurumuViewModel durum = _services.GetStokDurumMekanik(secilen.StokKartiId);

                SatinAlmaSiparisleriViewModel alim = _services.GetSatinAlmaMekanik(secilen.StokKartiId);

                MekanikUrunDetayForm detayForm=new MekanikUrunDetayForm(secilen,durum,alim);
                detayForm.ShowDialog();

            }

        }
    }
}

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
    public partial class MekanikUrunListesiForm : Form
    {
        private readonly StokTakipContext _context;
        public MekanikUrunListesiForm()
        {
            InitializeComponent();
            _context = new StokTakipContext();
        }

        private void MekanikUrunListesiForm_Load(object sender, EventArgs e)
        {
            dGVMekanikListesi.AutoGenerateColumns = true;
            var urunler = _context.StokKartis
                .Where(u => u.GrupId == 2)
                //.Select(u => new
                //{
                   
                //    ÜrünListesi = u.UrunAdi + "  (" + u.StokMiktari + ")"
                //})
                .ToList();

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
            if (e.RowIndex >= 0)
            {
                StokKarti secilen = (StokKarti)dGVMekanikListesi.Rows[e.RowIndex].DataBoundItem;
                MekanikUrunDetayForm detayForm = new MekanikUrunDetayForm();
                detayForm.SecilenUrun= secilen;              
                detayForm.ShowDialog();
            }
                
          
        }
    }
}

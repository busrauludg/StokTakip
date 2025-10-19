using StokTakip.Helpers;
using StokTakip.Services;
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
    public partial class BolumSec : Form
    {
        private readonly StokTakipContext _context;
        private readonly MekanikServices _services;
        private readonly ElektrikServices _elektrikServices;
        public BolumSec()
        {
            InitializeComponent();
            _context = new StokTakipContext();
            _services = new MekanikServices(_context);
            _elektrikServices = new ElektrikServices(_context);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayf = new AnaSayfa();
            anaSayf.ShowDialog();
        }

        private void BolumSec_Load(object sender, EventArgs e)
        {
            // Önce ListView ayarları (tek sefer yapılmalı, örn. form load'ta)
            tbCBolumSec.Dock = DockStyle.Fill;
            lVMekanikListesi.View = View.Details;
            lVMekanikListesi.FullRowSelect = true;
            lVMekanikListesi.GridLines = true;

            lVMekanikListesi.Columns.Clear();
            lVMekanikListesi.Columns.Add("Sıra No", 70);
            lVMekanikListesi.Columns.Add("Ürün Adı", 150);
            lVMekanikListesi.Columns.Add("Stok Miktarı", 100);

            // Verileri doldur
            var urunler = _services.GetStokKartiListesi();
            lVMekanikListesi.Items.Clear();

            int mekanikSira = 1;
            foreach (var urun in urunler)
            {
                var lvItem = new ListViewItem(mekanikSira.ToString()); // 🔹 Sıra No
                lvItem.SubItems.Add(urun.UrunAdi);             // Ürün Adı
                lvItem.SubItems.Add(urun.StokMiktari.ToString()); // Stok Miktarı
                lVMekanikListesi.Items.Add(lvItem);
                mekanikSira++;
            }

            //elektirik alanı

            lVlElektrikListesi.View = View.Details;
            lVlElektrikListesi.FullRowSelect = true;
            lVlElektrikListesi.GridLines = true;

            lVlElektrikListesi.Columns.Clear();
            lVlElektrikListesi.Columns.Add("Sıra No", 70);
            lVlElektrikListesi.Columns.Add("Ürün Adı", 150);
            lVlElektrikListesi.Columns.Add("Stok Miktarı", 100);

            // Verileri doldur
            var urunlers = _elektrikServices.GetStokKartiElektrik();
            lVlElektrikListesi.Items.Clear();

            int elektrikSira = 1;
            foreach (var urun in urunlers)
            {
                var lvItem = new ListViewItem(elektrikSira.ToString());  // 🔹 Sıra No
                lvItem.SubItems.Add(urun.UrunAdi);// Ürün Adı
                lvItem.SubItems.Add(urun.StokMiktari.ToString()); // Stok Miktarı
                lVlElektrikListesi.Items.Add(lvItem);
                elektrikSira++;
            }

            //yetkili işlemleri
           // btnPersonelBilgi.Visible = YetkiliKontrol.Rol;//yetkili yoksa gözükmein değilse 

        }

        private void lVMekanikListesi_DoubleClick(object sender, EventArgs e)
        {
            if (lVMekanikListesi.SelectedItems.Count > 0)
            {
                var secilenItem = lVMekanikListesi.SelectedItems[0];
                string urunAdi = secilenItem.SubItems[1].Text;

                // Seçilen ürünü veritabanından bul
                var secilenUrun = _services.GetStokKartiListesi()
                    .FirstOrDefault(u => u.UrunAdi == urunAdi);

                if (secilenUrun != null)
                {
                    var durum = _services.GetStokDurumMekanik(secilenUrun.StokKartiId);
                    var alim = _services.GetSatinAlmaMekanik(secilenUrun.StokKartiId);

                    // Detay formunu aç
                    MekanikUrunDetayForm detayForm = new MekanikUrunDetayForm(secilenUrun, durum, alim);
                    detayForm.ShowDialog();
                }
            }
        }

        private void lVlElektrikListesi_DoubleClick(object sender, EventArgs e)
        {
            if (lVlElektrikListesi.SelectedItems.Count > 0)
            {
                var secilenElItem = lVlElektrikListesi.SelectedItems[0];
                string urunAdi = secilenElItem.SubItems[1].Text;

                var secilenUrun = _elektrikServices.GetStokKartiElektrik()
                    .FirstOrDefault(u => u.UrunAdi == urunAdi);

                if (secilenUrun != null)
                {
                    var durum = _elektrikServices.GetStokDurumElektrik(secilenUrun.StokKartiId);
                    var alim = _elektrikServices.GetSatinAlmaElektrik(secilenUrun.StokKartiId);

                    // Detay formunu aç
                    MekanikUrunDetayForm detayForm = new MekanikUrunDetayForm(secilenUrun, durum, alim);
                    detayForm.ShowDialog();
                }
            }
        }

      
    }
}

using Microsoft.EntityFrameworkCore;
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
    public partial class ProjeDetayControl : UserControl
    {
        public ProjeDetayControl()
        {
            InitializeComponent();
        }
        //bu projede temel olarak sol alandaki list view tıklayınca sağ tarfta ki detay sayfası doluyor ve aşağıda toplam maliyeti gözükücek yani bu basit bir rapor gibi
        private void ProjeDetayControl_Load(object sender, EventArgs e)
        {
            // Durum combobox doldur
            cBPrjDurum.Items.Clear();
            cBPrjDurum.Items.Add("Aktif");
            cBPrjDurum.Items.Add("Pasif");

            // Projeler listview ayarları
            lVlPrjListele.View = View.Details;
            lVlPrjListele.FullRowSelect = true;
            lVlPrjListele.GridLines = true;
            lVlPrjListele.Columns.Clear();
            lVlPrjListele.Columns.Add("Sıra", 50); // Proje sırası
            lVlPrjListele.Columns.Add("Proje Adı", 200);

            // Kullanılan ürünler listview ayarları
            lVlKullanilanUrunler.View = View.Details;
            lVlKullanilanUrunler.FullRowSelect = true;
            lVlKullanilanUrunler.GridLines = true;
            lVlKullanilanUrunler.Columns.Clear();
            lVlKullanilanUrunler.Columns.Add("Ürün Adı", 150);
            lVlKullanilanUrunler.Columns.Add("Kullanılan Miktar", 100);

            using (var context = new StokTakipContext())
            {
                var projeler = context.Projes.ToList();
                lVlPrjListele.Items.Clear();

                int sıra = 1;
                foreach (var proje in projeler)
                {
                    ListViewItem item = new ListViewItem(sıra.ToString()); // sıra numarası göster
                    item.SubItems.Add(proje.ProjeAdi);
                    item.Tag = proje.ProjeId; // ID’yi arka planda tut
                    lVlPrjListele.Items.Add(item);
                    sıra++;
                }
            }
        }

        private void lVlPrjListele_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lVlPrjListele.SelectedItems.Count == 0) return;

            int projeId = (int)lVlPrjListele.SelectedItems[0].Tag;

            using (var context = new StokTakipContext())
            {
                var proje = context.Projes
                                   .Include(p => p.Personel)
                                   .FirstOrDefault(p => p.ProjeId == projeId);

                if (proje != null)
                {
                    tBProjeAdi.Text = proje.ProjeAdi;
                    dTPPrjBaslingicT.Text = proje.BaslangicTarihi.ToString("dd.MM.yyyy");
                    dTPBitisT.Text = proje.BitisTarihi.ToString("dd.MM.yyyy");
                    tBPrjPersonel.Text = proje.Personel.Ad;
                    tBPrjAciklama.Text = proje.Aciklama;
                    cBPrjDurum.SelectedItem = proje.Durum ? "Aktif" : "Pasif";

                    // Kullanılan ürünleri listele
                    lVlKullanilanUrunler.Items.Clear();
                    var urunler = context.ProjedeKullanilanUrunlers
                                         .Include(pu => pu.StokKarti) // navigation property ile
                                         .Where(pu => pu.ProjeId == projeId)
                                         .ToList();

                    foreach (var pu in urunler)
                    {
                        var item = new ListViewItem(pu.StokKarti.UrunAdi);
                        item.SubItems.Add(pu.Miktar.ToString());
                        lVlKullanilanUrunler.Items.Add(item);
                    }
                }
            }

        }
    }
}

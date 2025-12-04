using Microsoft.EntityFrameworkCore;
using StokTakip.Data.Migrations;
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
        private void ProjeDetayControl_Load(object sender, EventArgs e)
        {
          
            cBPrjDurum.Items.Clear();
            cBPrjDurum.Items.Add("Aktif");
            cBPrjDurum.Items.Add("Pasif");

            lVlPrjListele.View = View.Details;
            lVlPrjListele.FullRowSelect = true;
            lVlPrjListele.GridLines = true;
            lVlPrjListele.Columns.Clear();
            lVlPrjListele.Columns.Add("Sıra", 50);
            lVlPrjListele.Columns.Add("Proje Adı", 200);
            lVlPrjListele.Columns.Add("Durum", 200);

            lVlKullanilanUrunler.View = View.Details;
            lVlKullanilanUrunler.FullRowSelect = true;
            lVlKullanilanUrunler.GridLines = true;
            lVlKullanilanUrunler.Columns.Clear();
            lVlKullanilanUrunler.Columns.Add("Ürün Adı", 150);
            lVlKullanilanUrunler.Columns.Add("Kullanılan Miktar", 100);

            using (var context = new StokTakipContext())
            {
                var projeler = context.Projes
                   .Where(p => p.PasifMi==true) 
                   .OrderBy(p => p.ProjeAdi)
                   .ToList();


                lVlPrjListele.Items.Clear();

                int sıra = 1;
                foreach (var proje in projeler)
                {
                    ListViewItem item = new ListViewItem(sıra.ToString()); 
                    item.SubItems.Add(proje.ProjeAdi);
                    item.Tag = proje.ProjeId; 
                    item.SubItems.Add(proje.Durum? "Aktif" : "Pasif");
                    lVlPrjListele.Items.Add(item);
                    sıra++;
                }
            }
          
            lVlPrjListele.ContextMenuStrip = cMSPrjeİslem;

           
            lVlPrjListele.MouseDown += lVlPrjListele_MouseDown;

       
            silToolStripMenuItem.Click -= silToolStripMenuItem_Click;
            silToolStripMenuItem.Click += silToolStripMenuItem_Click;

         
            AyarlaBugunTarihleri();
        }
        private void AyarlaBugunTarihleri()
        {
            dTPPrjBaslingicT.MinDate = DateTime.Today;
            dTPPrjBaslingicT.Value = DateTime.Today;

            dTPBitisT.MinDate = DateTime.Today;
            dTPBitisT.Value = DateTime.Today;
        }


        private bool isLoading = false;

        private void lVlPrjListele_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return; 
            isLoading = true;

            try
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
                        tBProjeAdi.ReadOnly = true;
                        tBPrjPersonel.ReadOnly = true;
                        tBPrjAciklama.ReadOnly = true;
                        tBToplamMaliyet.ReadOnly = true;

                        cBPrjDurum.Enabled = false;

                        tBProjeAdi.Text = proje.ProjeAdi;
                        tBPrjPersonel.Text = proje.Personel.Ad;
                        tBPrjAciklama.Text = proje.Aciklama;
                        cBPrjDurum.SelectedItem = proje.Durum ? "Aktif" : "Pasif";

                     
                        DurumKontrol(proje);

                        lVlKullanilanUrunler.Items.Clear();
                        var urunler = context.ProjedeKullanilanUrunlers
                                             .Include(pu => pu.StokKarti)
                                             .Where(pu => pu.ProjeId == projeId)
                                             .ToList();

                        decimal toplamMaliyet = 0;

                        foreach (var pu in urunler)
                        {
                           
                            var item = new ListViewItem(pu.StokKarti.UrunAdi);
                            item.SubItems.Add(pu.Miktar.ToString());
                            lVlKullanilanUrunler.Items.Add(item);

                       
                            var satinAlma = context.SatinAlmas
                                .FirstOrDefault(sa => sa.StokKartiId == pu.StokKartiId);

                            decimal birimFiyat = satinAlma?.BirimFiyat ?? 0;
                            decimal kur = satinAlma?.Kur ?? 1;
                            decimal miktar = pu.Miktar;

                          
                            decimal urunMaliyeti = birimFiyat * kur * miktar;

                          
                            pu.Maliyet = urunMaliyeti;

                           
                            context.Entry(pu).State = EntityState.Modified;

                            toplamMaliyet += urunMaliyeti;
                        }
                        context.SaveChanges();

                      
                        tBToplamMaliyet.Text = toplamMaliyet.ToString("N2");
                    }
                }
            }
            finally
            {
                isLoading = false;
            }

        }

        private void DurumKontrol(Proje proje)
        {
            if (proje == null) return;
            if (proje.Durum)
            {
                btnBasla.Enabled = false;
                btnBitir.Enabled = true;
                pDetay.Enabled = true;
            }
            else
            {  
                btnBasla.Enabled = true;
                btnBitir.Enabled = false;
                pDetay.Enabled = false;
            }

        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            if (lVlPrjListele.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen bir proje seçin");
                return;
            }
            int projeId = (int)lVlPrjListele.SelectedItems[0].Tag;
            using (var context = new StokTakipContext())
            {
                var proje = context.Projes.FirstOrDefault(p => p.ProjeId == projeId);
                if (proje != null)
                {
                    proje.Durum = true; 
                    context.SaveChanges();

                    MessageBox.Show("✅ Proje başlatıldı.");

                    DurumKontrol(proje); 
                }
            }
        }

        private void btnBitir_Click(object sender, EventArgs e)
        {
            if (lVlPrjListele.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen bir proje seçin.");
                return;
            }

            int projeId = (int)lVlPrjListele.SelectedItems[0].Tag;

            using (var context = new StokTakipContext())
            {
                var proje = context.Projes.FirstOrDefault(p => p.ProjeId == projeId);

                if (proje != null)
                {
                    proje.Durum = false; 

                    var urunler = context.ProjedeKullanilanUrunlers
                                         .Where(pu => pu.ProjeId == projeId)
                                         .ToList();

                    decimal toplamMaliyet = urunler.Sum(pu => pu.Maliyet);

                    context.SaveChanges();

                    MessageBox.Show($"🟢 Proje tamamlandı.\nToplam Maliyet: {toplamMaliyet:N2} TL");

                    DurumKontrol(proje); 
                }
            }
        }

        private void lVlPrjListele_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = lVlPrjListele.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    lVlPrjListele.SelectedItems.Clear();
                    item.Selected = true;
                    item.Focused = true;
                }
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lVlPrjListele.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir proje seçin.");
                return;
            }

            int projeId = (int)lVlPrjListele.SelectedItems[0].Tag;

            using (var context = new StokTakipContext())
            {
                var proje = context.Projes.FirstOrDefault(p => p.ProjeId == projeId);
                if (proje == null)
                {
                    MessageBox.Show("Proje bulunamadı.");
                    return;
                }
                if (proje.Durum)
                {
                    MessageBox.Show("Aktif projeler pasif hale getirilmeden değiştirilemez!",
                                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var sonuc = MessageBox.Show($"{proje.ProjeAdi} adlı projeyi silmek istediğinize emin misiniz?",
                                            "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    proje.PasifMi =false;
                    context.SaveChanges();

                    lVlPrjListele.Items.Remove(lVlPrjListele.SelectedItems[0]);

                    MessageBox.Show("Proje başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}


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
            lVlPrjListele.Columns.Add("Durum", 200);//durum için

            // Kullanılan ürünler listview ayarları
            lVlKullanilanUrunler.View = View.Details;
            lVlKullanilanUrunler.FullRowSelect = true;
            lVlKullanilanUrunler.GridLines = true;
            lVlKullanilanUrunler.Columns.Clear();
            lVlKullanilanUrunler.Columns.Add("Ürün Adı", 150);
            lVlKullanilanUrunler.Columns.Add("Kullanılan Miktar", 100);

            using (var context = new StokTakipContext())
            {
                var projeler = context.Projes
                   .Where(p => p.PasifMi==true) // sadece PasifMi = true olanları getir
                   .OrderBy(p => p.ProjeAdi)
                   .ToList();


                lVlPrjListele.Items.Clear();

                int sıra = 1;
                foreach (var proje in projeler)
                {
                    ListViewItem item = new ListViewItem(sıra.ToString()); // sıra numarası göster
                    item.SubItems.Add(proje.ProjeAdi);
                    item.Tag = proje.ProjeId; // ID’yi arka planda tut
                    item.SubItems.Add(proje.Durum? "Aktif" : "Pasif");
                    lVlPrjListele.Items.Add(item);
                    sıra++;
                }
            }
            // Menüyü bağla
            lVlPrjListele.ContextMenuStrip = cMSPrjeİslem;

            // Sağ tıklanan item seçilsin
            lVlPrjListele.MouseDown += lVlPrjListele_MouseDown;

            // Menü tıklama olayı bağla (ek olarak)
            //silToolStripMenuItem.Click += silToolStripMenuItem_Click;


            // Önce varsa eski event kaldır, sonra ekle
            silToolStripMenuItem.Click -= silToolStripMenuItem_Click;
            silToolStripMenuItem.Click += silToolStripMenuItem_Click;

            // 🔹 Tarih kontrollerini sadece Load'da ayarlıyoruz
            AyarlaBugunTarihleri();
        }
        private void AyarlaBugunTarihleri()
        {
            // Başlangıç tarihi
            dTPPrjBaslingicT.MinDate = DateTime.Today;
           // dTPPrjBaslingicT.MaxDate = DateTime.Today;
            dTPPrjBaslingicT.Value = DateTime.Today;
           // dTPPrjBaslingicT.ShowUpDown = true; // Takvim açılmaz, sadece bugünü seçebilir

            // Bitiş tarihi
            dTPBitisT.MinDate = DateTime.Today;
          //  dTPBitisT.MaxDate = DateTime.Today;
            dTPBitisT.Value = DateTime.Today;
           // dTPBitisT.ShowUpDown = true;
        }


        private bool isLoading = false;

        private void lVlPrjListele_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return; // event tekrar tetiklenirse çık
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
                        // Proje detaylarını yüklerken textbox'ları readonly yap
                        tBProjeAdi.ReadOnly = true;
                        tBPrjPersonel.ReadOnly = true;
                        tBPrjAciklama.ReadOnly = true;
                        tBToplamMaliyet.ReadOnly = true;

                        // ComboBox tamamen kilitlensin
                        cBPrjDurum.Enabled = false;

                        tBProjeAdi.Text = proje.ProjeAdi;
                        tBPrjPersonel.Text = proje.Personel.Ad;
                        tBPrjAciklama.Text = proje.Aciklama;
                        cBPrjDurum.SelectedItem = proje.Durum ? "Aktif" : "Pasif";

                        //// 🔹 Duruma göre butonları ayarla
                        //if(proje.Durum)
                        //{
                        //    btnBasla.Enabled = false; //aktifse başla pasif olur
                        //    btnBitir.Enabled = true; //bitir aktif olur
                        //    pDetay.Enabled = true;  //panel aktif
                        //}
                        //else
                        //{
                        //    btnBasla.Enabled = true;    // pasifse başla aktif olur
                        //    btnBitir.Enabled = false;   // bitir pasif olur
                        //    pDetay.Enabled = false;     // panel pasif
                        //}

                        //// 🔹 Eğer proje pasifse işlem yapma
                        //if(!proje.Durum)
                        //{
                        //    lVlKullanilanUrunler.Items.Clear();
                        //    tBToplamMaliyet.Text= "0.00";
                        //    return;
                        //}

                        DurumKontrol(proje);

                        // 🔹 Kullanılan ürünleri listele
                        lVlKullanilanUrunler.Items.Clear();
                        var urunler = context.ProjedeKullanilanUrunlers
                                             .Include(pu => pu.StokKarti)
                                             .Where(pu => pu.ProjeId == projeId)
                                             .ToList();

                        decimal toplamMaliyet = 0;

                        foreach (var pu in urunler)
                        {
                            // Ürünleri listeye ekle
                            var item = new ListViewItem(pu.StokKarti.UrunAdi);
                            item.SubItems.Add(pu.Miktar.ToString());
                            lVlKullanilanUrunler.Items.Add(item);

                            // Satın alma bilgilerini getir
                            var satinAlma = context.SatinAlmas
                                .FirstOrDefault(sa => sa.StokKartiId == pu.StokKartiId);

                            decimal birimFiyat = satinAlma?.BirimFiyat ?? 0;
                            decimal kur = satinAlma?.Kur ?? 1;
                            decimal miktar = pu.Miktar;

                            // Ürün maliyeti hesapla
                            decimal urunMaliyeti = birimFiyat * kur * miktar;

                            // 🔹 Maliyeti tabloya kaydet
                            pu.Maliyet = urunMaliyeti;

                            // 🔹 EF'e bu nesnenin değiştiğini bildir
                            context.Entry(pu).State = EntityState.Modified;

                            toplamMaliyet += urunMaliyeti;
                        }

                        // 🔹 Veritabanına değişiklikleri kaydet
                        context.SaveChanges();

                        // 🔹 Toplam maliyeti textbox’a yaz
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
                // 🔹 Eğer proje aktifse
                btnBasla.Enabled = false;
                btnBitir.Enabled = true;
                pDetay.Enabled = true;
            }
            else
            {  // 🔹 Eğer proje pasifse
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
                    proje.Durum = true; // Aktif yap
                    context.SaveChanges();

                    MessageBox.Show("✅ Proje başlatıldı.");

                    DurumKontrol(proje); // Butonları güncelle
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
                    proje.Durum = false; // Pasif yap

                    // Toplam maliyeti hesapla
                    var urunler = context.ProjedeKullanilanUrunlers
                                         .Where(pu => pu.ProjeId == projeId)
                                         .ToList();

                    decimal toplamMaliyet = urunler.Sum(pu => pu.Maliyet);

                    context.SaveChanges();

                    MessageBox.Show($"🟢 Proje tamamlandı.\nToplam Maliyet: {toplamMaliyet:N2} TL");

                    DurumKontrol(proje); // Butonları güncelle
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

                // 🔹 Aktif proje kontrolü
                if (proje.Durum)
                {
                    MessageBox.Show("Aktif projeler pasif hale getirilmeden değiştirilemez!",
                                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Emin misiniz sorusu
                var sonuc = MessageBox.Show($"{proje.ProjeAdi} adlı projeyi silmek istediğinize emin misiniz?",
                                            "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    // ❌ Silme yerine PasifMi = true
                    proje.PasifMi =false;//bu aslında false olucak cünkü ben önceden veritabanında bir mantık hatası yapmışım onu cözdüm şimdi 
                    context.SaveChanges();

                    // ListView'den kaldır
                    lVlPrjListele.Items.Remove(lVlPrjListele.SelectedItems[0]);

                    MessageBox.Show("Proje başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}


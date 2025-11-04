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
            // Menüyü bağla
            lVlPrjListele.ContextMenuStrip = cMSPrjeİslem;

            // Sağ tıklanan item seçilsin
            lVlPrjListele.MouseDown += lVlPrjListele_MouseDown;

            // Menü tıklama olayı bağla (ek olarak)
            silToolStripMenuItem.Click += silToolStripMenuItem_Click;

        }

        //private void lVlPrjListele_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (lVlPrjListele.SelectedItems.Count == 0) return;

        //    //int projeId = (int)lVlPrjListele.SelectedItems[0].Tag;

        //    //using (var context = new StokTakipContext())
        //    //{
        //    //    var proje = context.Projes
        //    //                       .Include(p => p.Personel)
        //    //                       .FirstOrDefault(p => p.ProjeId == projeId);

        //    //    if (proje != null)
        //    //    {
        //    //        tBProjeAdi.Text = proje.ProjeAdi;
        //    //        dTPPrjBaslingicT.Text = proje.BaslangicTarihi.ToString("dd.MM.yyyy");
        //    //        dTPBitisT.Text = proje.BitisTarihi.ToString("dd.MM.yyyy");
        //    //        tBPrjPersonel.Text = proje.Personel.Ad;
        //    //        tBPrjAciklama.Text = proje.Aciklama;
        //    //        cBPrjDurum.SelectedItem = proje.Durum ? "Aktif" : "Pasif";

        //    //        // Kullanılan ürünleri listele
        //    //        lVlKullanilanUrunler.Items.Clear();
        //    //        var urunler = context.ProjedeKullanilanUrunlers
        //    //                             .Include(pu => pu.StokKarti)
        //    //                             .Where(pu => pu.ProjeId == projeId)
        //    //                             .ToList();

        //    //        decimal toplamMaliyet = 0;

        //    //        foreach (var pu in urunler)
        //    //        {
        //    //            // Ürün adı ve miktarı sadece UI'ya eklenecek
        //    //            var item = new ListViewItem(pu.StokKarti.UrunAdi);
        //    //            item.SubItems.Add(pu.Miktar.ToString());
        //    //            lVlKullanilanUrunler.Items.Add(item);

        //    //            // Satın alma tablosundan birim fiyat ve kur değerlerini al
        //    //            var satinAlma = context.SatinAlmas
        //    //                .FirstOrDefault(sa => sa.StokKartiId == pu.StokKartiId);

        //    //            decimal birimFiyat = satinAlma?.BirimFiyat ?? 0;
        //    //            decimal kur = satinAlma?.Kur ?? 1;
        //    //            decimal miktar = pu.Miktar;

        //    //            // Ürün toplam maliyeti
        //    //            decimal urunMaliyeti = birimFiyat * kur * miktar;

        //    //            // 🔹 Maliyeti tabloya yaz
        //    //            pu.Maliyet = urunMaliyeti;

        //    //            toplamMaliyet += urunMaliyeti;
        //    //        }

        //    //        // 🔹 Veritabanına değişiklikleri kaydet
        //    //        context.SaveChanges();

        //    //        // 🔹 Toplam maliyeti textbox’a yaz
        //    //        tBToplamMaliyet.Text = toplamMaliyet.ToString("N2");
        //    //    }
        //    //}


        //    if (lVlPrjListele.SelectedItems.Count == 0) return;

        //    int projeId = (int)lVlPrjListele.SelectedItems[0].Tag;

        //    using (var context = new StokTakipContext())
        //    {
        //        var proje = context.Projes
        //                           .Include(p => p.Personel)
        //                           .FirstOrDefault(p => p.ProjeId == projeId);

        //        if (proje != null)
        //        {
        //            // 🔹 Proje bilgilerini doldur
        //            tBProjeAdi.Text = proje.ProjeAdi;
        //            dTPPrjBaslingicT.Text = proje.BaslangicTarihi.ToString("dd.MM.yyyy");
        //            dTPBitisT.Text = proje.BitisTarihi.ToString("dd.MM.yyyy");
        //            tBPrjPersonel.Text = proje.Personel.Ad;
        //            tBPrjAciklama.Text = proje.Aciklama;
        //            cBPrjDurum.SelectedItem = proje.Durum ? "Aktif" : "Pasif";

        //            // 🔹 Kullanılan ürünleri getir
        //            lVlKullanilanUrunler.Items.Clear();
        //            var urunler = context.ProjedeKullanilanUrunlers
        //                                 .Include(pu => pu.StokKarti)
        //                                 .Where(pu => pu.ProjeId == projeId)
        //                                 .ToList();

        //            decimal toplamMaliyet = 0;

        //            foreach (var pu in urunler)
        //            {
        //                // Ürünleri listview'e ekle
        //                var item = new ListViewItem(pu.StokKarti.UrunAdi);
        //                item.SubItems.Add(pu.Miktar.ToString());
        //                lVlKullanilanUrunler.Items.Add(item);

        //                // Satın alma verilerini al
        //                var satinAlma = context.SatinAlmas
        //                    .FirstOrDefault(sa => sa.StokKartiId == pu.StokKartiId);

        //                decimal birimFiyat = satinAlma?.BirimFiyat ?? 0;
        //                decimal kur = satinAlma?.Kur ?? 1;
        //                decimal miktar = pu.Miktar;

        //                // Ürün maliyeti hesapla
        //                decimal urunMaliyeti = birimFiyat * kur * miktar;
        //                toplamMaliyet += urunMaliyeti;
        //            }

        //            // 🔹 Toplam maliyeti textbox'a yaz
        //            tBToplamMaliyet.Text = toplamMaliyet.ToString("N2");

        //            // 🔹 Toplam maliyeti veritabanındaki Maliyet sütununa kaydet
        //            foreach (var pu in urunler)
        //            {
        //                pu.Maliyet = toplamMaliyet;
        //            }

        //            // 🔹 Değişiklikleri kaydet
        //            context.SaveChanges();
        //        }
        //    }

        //}
        //private bool isLoading = false;

        //private void lVlPrjListele_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (isLoading) return; // event tekrar tetiklenirse çık
        //    isLoading = true;

        //    try
        //    {
        //        if (lVlPrjListele.SelectedItems.Count == 0) return;

        //        int projeId = (int)lVlPrjListele.SelectedItems[0].Tag;

        //        using (var context = new StokTakipContext())
        //        {
        //            var proje = context.Projes
        //                               .Include(p => p.Personel)
        //                               .FirstOrDefault(p => p.ProjeId == projeId);

        //            if (proje != null)
        //            {
        //                // 🔹 Proje bilgilerini UI'ya yaz
        //                tBProjeAdi.Text = proje.ProjeAdi;
        //                dTPPrjBaslingicT.Text = proje.BaslangicTarihi.ToString("dd.MM.yyyy");
        //                dTPBitisT.Text = proje.BitisTarihi.ToString("dd.MM.yyyy");
        //                tBPrjPersonel.Text = proje.Personel.Ad;
        //                tBPrjAciklama.Text = proje.Aciklama;
        //                cBPrjDurum.SelectedItem = proje.Durum ? "Aktif" : "Pasif";

        //                // 🔹 Kullanılan ürünleri listele
        //                lVlKullanilanUrunler.Items.Clear();
        //                var urunler = context.ProjedeKullanilanUrunlers
        //                                     .Include(pu => pu.StokKarti)
        //                                     .Where(pu => pu.ProjeId == projeId)
        //                                     .ToList();

        //                decimal toplamMaliyet = 0;

        //                foreach (var pu in urunler)
        //                {
        //                    // Ürünleri listele
        //                    var item = new ListViewItem(pu.StokKarti.UrunAdi);
        //                    item.SubItems.Add(pu.Miktar.ToString());
        //                    lVlKullanilanUrunler.Items.Add(item);

        //                    // Satın alma bilgilerini çek
        //                    var satinAlma = context.SatinAlmas
        //                        .FirstOrDefault(sa => sa.StokKartiId == pu.StokKartiId);

        //                    decimal birimFiyat = satinAlma?.BirimFiyat ?? 0;
        //                    decimal kur = satinAlma?.Kur ?? 1;
        //                    decimal miktar = pu.Miktar;

        //                    // Ürün maliyeti (her ürün için ayrı)
        //                    decimal urunMaliyeti = birimFiyat * kur * miktar;

        //                    // 🔹 Her ürünün kendi maliyetini tabloya yaz
        //                    pu.Maliyet = urunMaliyeti;

        //                    toplamMaliyet += urunMaliyeti;
        //                }

        //                // 🔹 Toplam maliyeti textbox’a yaz
        //                tBToplamMaliyet.Text = toplamMaliyet.ToString("N2");

        //                // 🔹 Veritabanına değişiklikleri kaydet
        //                context.SaveChanges();
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        isLoading = false; // tekrar çalışmasına izin ver
        //    }
        //}

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
                        // 🔹 Proje bilgilerini doldur
                        tBProjeAdi.Text = proje.ProjeAdi;
                        dTPPrjBaslingicT.Text = proje.BaslangicTarihi.ToString("dd.MM.yyyy");
                        dTPBitisT.Text = proje.BitisTarihi.ToString("dd.MM.yyyy");
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
                    MessageBox.Show("Aktif projeler silinemez! Lütfen önce projeyi pasif hale getirin.",
                                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Emin misiniz sorusu
                var sonuc = MessageBox.Show($"{proje.ProjeAdi} adlı projeyi silmek istediğinize emin misiniz?",
                                            "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    context.Projes.Remove(proje);
                    context.SaveChanges();

                    // ListView'den de kaldır
                    lVlPrjListele.Items.Remove(lVlPrjListele.SelectedItems[0]);

                    MessageBox.Show("Proje başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}


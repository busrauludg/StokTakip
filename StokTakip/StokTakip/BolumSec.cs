using StokTakip.Helpers;
using StokTakip.Models;
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
            btnPersonelİslem.Visible = YetkiliKontrol.Rol;//yetkili yoksa gözükmein değilse 


            lVlElektrikListesi.ContextMenuStrip = cMSSagTik;

            lVMekanikListesi.ContextMenuStrip = cMSSagTik;
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
                    var stokDurum = _elektrikServices.GetStokDurumElektrik(secilenUrun.StokKartiId);
                    var sipAlim = _elektrikServices.GetSatinAlmaElektrik(secilenUrun.StokKartiId);

                    // Detay formunu aç
                    ElektrikUrunDetayForm detayForm = new ElektrikUrunDetayForm(secilenUrun, sipAlim, stokDurum);
                    detayForm.ShowDialog();

                }
            }
        }

        private void btnStokEkle_Click(object sender, EventArgs e)
        {


            // Paneli temizle
            pStokEkle.Controls.Clear();

            // UserControl oluştur
            var sc = new StokUserControl();
            sc.Dock = DockStyle.Fill;


            // Geri event
            sc.GeriClick += (s, ev) =>
            {
                pStokEkle.Controls.Clear(); // UserControl’ü kaldır
            };

            // Panel içine ekle
            pStokEkle.Controls.Add(sc);

        }

        private void btnProjeOlustur_Click(object sender, EventArgs e)
        {
            pStokEkle.Controls.Clear();
            ProjeControl uc = new ProjeControl();
            uc.Dock = DockStyle.Fill;                  // paneli doldur
            pStokEkle.Controls.Add(uc);
        }

        private void btnProjeDetay_Click(object sender, EventArgs e)
        {
            pStokEkle.Controls.Clear();
            ProjeDetayControl pd = new ProjeDetayControl();
            pd.Dock = DockStyle.Fill;
            pStokEkle.Controls.Add(pd);
        }

        private void btnSiparisİslem_Click(object sender, EventArgs e)
        {
            Siparisİslemleri spfrm = new Siparisİslemleri();
            spfrm.ShowDialog();
        }

        private void btnPersonelİslem_Click(object sender, EventArgs e)
        {

            pStokEkle.Controls.Clear();
            PersonelControl pr = new PersonelControl();
            pr.Dock = DockStyle.Fill;
            pStokEkle.Controls.Add(pr);
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //ListView aktifListe = cMSSagTik.SourceControl as ListView;

            //if (aktifListe != null && aktifListe.SelectedItems.Count > 0)
            //{
            //    var secilen = aktifListe.SelectedItems[0];

            //    // Silme onayı
            //    DialogResult onay = MessageBox.Show(
            //        "Bu ürünü listeden kaldırmak istediğinize emin misiniz?",
            //        "Silme Onayı",
            //        MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Warning
            //    );

            //    if (onay == DialogResult.Yes)
            //    {
            //        // Sadece ListView'den sil (veritabanına dokunmadan)
            //        aktifListe.Items.Remove(secilen);

            //        MessageBox.Show("Ürün listeden kaldırıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Silme işlemi iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            //ListView aktifListe = cMSSagTik.SourceControl as ListView;

            //if (aktifListe != null && aktifListe.SelectedItems.Count > 0)
            //{
            //    var secilen = aktifListe.SelectedItems[0];
            //    int urunId = Convert.ToInt32(secilen.SubItems[0].Text);

            //    // Silme onayı
            //    DialogResult onay = MessageBox.Show(
            //        "Bu ürünü kalıcı olarak silmek istediğinize emin misiniz?",
            //        "Silme Onayı",
            //        MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Warning
            //    );

            //    if (onay == DialogResult.Yes)
            //    {
            //        using (var db = new StokTakipContext())
            //        {
            //            // Önce bağlı SatinAlma kayıtlarını sil
            //            var satinAlmalar = db.SatinAlmas.Where(x => x.StokKartiId == urunId).ToList();
            //            db.SatinAlmas.RemoveRange(satinAlmalar);

            //            // Sonra ürünü sil
            //            var urun = db.StokKartis.FirstOrDefault(x => x.StokKartiId == urunId);
            //            if (urun != null)
            //            {
            //                db.StokKartis.Remove(urun);
            //            }

            //            db.SaveChanges();
            //        }

            //        // ListView'den de kaldır
            //        aktifListe.Items.Remove(secilen);
            //        MessageBox.Show("Ürün ve bağlı kayıtları veritabanından silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Silme işlemi iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            //ListView aktifListe = cMSSagTik.SourceControl as ListView;

            //if (aktifListe != null && aktifListe.SelectedItems.Count > 0)
            //{
            //    var secilen = aktifListe.SelectedItems[0];
            //    int urunId = Convert.ToInt32(secilen.SubItems[0].Text);

            //    // Silme onayı
            //    DialogResult onay = MessageBox.Show(
            //        "Bu ürünü ve bağlı tüm kayıtlarını kalıcı olarak silmek istediğinize emin misiniz?",
            //        "Silme Onayı",
            //        MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Warning
            //    );

            //    if (onay == DialogResult.Yes)
            //    {
            //        using (var db = new StokTakipContext())
            //        {
            //            // 1. SatinAlma kayıtlarını sil
            //            var satinAlmalar = db.SatinAlmas.Where(x => x.StokKartiId == urunId).ToList();
            //            db.SatinAlmas.RemoveRange(satinAlmalar);

            //            // 2. ProjedeKullanilanUrunler kayıtlarını sil
            //            var projedeKullanilan = db.ProjedeKullanilanUrunlers.Where(p => p.StokKartiId == urunId).ToList();
            //            db.ProjedeKullanilanUrunlers.RemoveRange(projedeKullanilan);

            //            // 3. Ana StokKartis kaydını sil
            //            var urun = db.StokKartis.FirstOrDefault(x => x.StokKartiId == urunId);
            //            if (urun != null)
            //            {
            //                db.StokKartis.Remove(urun);
            //            }

            //            db.SaveChanges();
            //        }

            //        // ListView'den de kaldır
            //        aktifListe.Items.Remove(secilen);
            //        MessageBox.Show("Ürün ve bağlı tüm kayıtları veritabanından silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Silme işlemi iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}


           


        }

    }
}



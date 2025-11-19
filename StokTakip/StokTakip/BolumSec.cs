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

        // Sınıf seviyesi değişkenler
        private IEnumerable<StokKarti> mekanikUrunler;
        private IEnumerable<StokKarti> elektrikUrunler;
        public BolumSec()
        {
            InitializeComponent();
            _context = new StokTakipContext();
            _services = new MekanikServices(_context);
            _elektrikServices = new ElektrikServices(_context);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BolumSec_Load(object sender, EventArgs e)
        {
            //MEKANİK ALANI
            // Önce ListView ayarları (tek sefer yapılmalı, örn. form load'ta)
            tbCBolumSec.Dock = DockStyle.Fill;
            lVMekanikListesi.View = View.Details;
            lVMekanikListesi.FullRowSelect = true;
            lVMekanikListesi.GridLines = true;

            lVMekanikListesi.Columns.Clear();
            lVMekanikListesi.Columns.Add("Sıra No", 70);
            // lVMekanikListesi.Columns.Add("Id",0);//pasif yapmak için
            lVMekanikListesi.Columns.Add("Ürün Adı", 150);
            lVMekanikListesi.Columns.Add("Kullanılabilir Miktar", 150);

            var urunler = _services.GetStokKartiListesi();
            lVMekanikListesi.Items.Clear();

            int mekanikSira = 1;
            foreach (var urun in urunler)
            {
                // Ürüne ait stok durumunu al
                var stokDurum = _services.GetStokDurumMekanik(urun.StokKartiId);
                var serbestMiktar = stokDurum?.SerbestMiktar ?? 0;

                var lvItem = new ListViewItem(mekanikSira.ToString());
                lvItem.SubItems.Add(urun.UrunAdi);                     // Ürün Adı
                lvItem.SubItems.Add(serbestMiktar.ToString());         // Stok Miktarı

                lvItem.Tag = urun.StokKartiId; // ❗ ID'yi Tag'de sakla
                lVMekanikListesi.Items.Add(lvItem);
                mekanikSira++;
            }


            // Verileri doldur
            //var urunler = _services.GetStokKartiListesi();
            //lVMekanikListesi.Items.Clear();

            //int mekanikSira = 1;
            //foreach (var urun in urunler)
            //{

            //    var lvItem = new ListViewItem(mekanikSira.ToString()); // 🔹 Sıra No
            //    lvItem.SubItems.Add(urun.UrunAdi);             // Ürün Adı
            //    //lvItem.SubItems.Add(serbestMiktar.ToString()); // Stok Miktarı
            //    lVMekanikListesi.Items.Add(lvItem);
            //    mekanikSira++;
            //}


            //ELEKTRİK ALANI
            //elektirik alanı

            lVlElektrikListesi.View = View.Details;
            lVlElektrikListesi.FullRowSelect = true;
            lVlElektrikListesi.GridLines = true;

            lVlElektrikListesi.Columns.Clear();
            lVlElektrikListesi.Columns.Add("Sıra No", 70);
            lVlElektrikListesi.Columns.Add("Ürün Adı", 150);
            lVlElektrikListesi.Columns.Add("Kullanılabir Miktar", 120);

            // Verileri doldur
            var urunlers = _elektrikServices.GetStokKartiElektrik();
            lVlElektrikListesi.Items.Clear();

            int elektrikSira = 1;
            foreach (var urun in urunlers)
            {
                var stokDurum = _elektrikServices.GetStokDurumElektrik(urun.StokKartiId);
                var serbestMiktar = stokDurum?.SerbestMiktar ?? 0;

                var lvItem = new ListViewItem(elektrikSira.ToString());  // 🔹 Sıra No
                lvItem.SubItems.Add(urun.UrunAdi);// Ürün Adı
                lvItem.SubItems.Add(serbestMiktar.ToString()); // Stok Miktarı

                lvItem.Tag = urun.StokKartiId; // ❗ ID'yi Tag'de sakla
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
            ListView aktifListe = cMSSagTik.SourceControl as ListView;

            if (aktifListe != null && aktifListe.SelectedItems.Count > 0)
            {
                var secilen = aktifListe.SelectedItems[0];
                //  string urunAdi = secilen.SubItems[1].Text; // Ürün adını al
                //int urunId = Convert.ToInt32(secilen.SubItems[0].Text); // ID al

                int urunId = (int)secilen.Tag; // ❗ Tag üzerinden doğru ID al


                DialogResult onay = MessageBox.Show(
                    "Bu ürünü silmek istediğinize emin misiniz?",
                    "Ürünü Sil Et",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (onay == DialogResult.Yes)
                {
                    using (var db = new StokTakipContext())
                    {
                        // var urun = db.StokKartis.FirstOrDefault(x => x.UrunAdi == urunAdi);
                        var urun = db.StokKartis.FirstOrDefault(x => x.StokKartiId == urunId);

                        if (urun != null)
                        {
                            urun.AktifMi = false; // ❗ Soft delete işlemi
                            db.SaveChanges();
                        }
                    }

                    // ListView'den kaldır
                    aktifListe.Items.Remove(secilen);
                    MessageBox.Show("Ürün silindi. Artık listede görünmeyecek.",
                        "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void lVMekanikListesi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cMSSagTik_Opening(object sender, CancelEventArgs e)
        {

        }
        private void ListeDoldur<T>(ListView listView, IEnumerable<T> urunler, Func<T, int?> serbestMiktarFunc)
        {
            listView.Items.Clear();
            int sira = 1;

            foreach (var urun in urunler)
            {
                var serbestMiktar = serbestMiktarFunc(urun) ?? 0;

                var lvItem = new ListViewItem(sira.ToString());
                lvItem.SubItems.Add((urun as dynamic).UrunAdi);
                lvItem.SubItems.Add(serbestMiktar.ToString());

                lvItem.Tag = (urun as dynamic).StokKartiId;
                listView.Items.Add(lvItem);

                sira++;
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            // Mekanik listeyi güncelle
            var mekanikUrunler = _services.GetStokKartiListesi();
            ListeDoldur(lVMekanikListesi, mekanikUrunler, u => _services.GetStokDurumMekanik(u.StokKartiId)?.SerbestMiktar);

            // Elektrik listeyi güncelle
            var elektrikUrunler = _elektrikServices.GetStokKartiElektrik();
            ListeDoldur(lVlElektrikListesi, elektrikUrunler, u => _elektrikServices.GetStokDurumElektrik(u.StokKartiId)?.SerbestMiktar);

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}



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
    public partial class Siparisİslemleri : Form
    {
        private ListViewItem secilenItem = null;
        private ListViewItem.ListViewSubItem secilenSubItem = null;

        public Siparisİslemleri()
        {
            InitializeComponent();
        }



        private void Siparisİslemleri_Load(object sender, EventArgs e)
        {
            //formla eşit olsun 
            tabControl1.Dock = DockStyle.Fill;

            // ListView ayarları
            lVlSiparisListesi.View = View.Details;
            lVlSiparisListesi.FullRowSelect = true;
            lVlSiparisListesi.GridLines = true;
            lVlSiparisListesi.Columns.Clear();

            lVlSiparisListesi.Columns.Add("Sipariş Tarihi", 120);
            lVlSiparisListesi.Columns.Add("Sipariş Verilen Firma", 150);
            lVlSiparisListesi.Columns.Add("Ürün", 150);
            lVlSiparisListesi.Columns.Add("Sipariş Edilen Miktar", 95);
            lVlSiparisListesi.Columns.Add("Gelen Miktar", 85);
            lVlSiparisListesi.Columns.Add("Birim Fiyat", 100);
            lVlSiparisListesi.Columns.Add("Kur", 80);
            lVlSiparisListesi.Columns.Add("Para Birimi", 80);
            lVlSiparisListesi.Columns.Add("Personel", 120);
            lVlSiparisListesi.Columns.Add("Durum", 100);//otomatik
            lVlSiparisListesi.Columns.Add("Grup Adı", 100);//grup adı

            lVlSiparisListesi.ContextMenuStrip = cMSPrjListe;
            lVlSiparisListesi.MouseUp += lVlSiparisListesi_MouseUp;

            // Verileri çek ve ekle
            using (var context = new StokTakipContext())
            {
                var siparisler = context.SatinAlmas
                                        .Include(s => s.Personel)
                                        .ToList();

                lVlSiparisListesi.Items.Clear();

                foreach (var s in siparisler)
                {


                    var urun = context.StokKartis.Find(s.StokKartiId);

                    // Ürünün grup adını al
                    string grupAd = "";
                    if (urun != null && urun.GrupId != null)
                    {
                        var grup = context.Gruplars.Find(urun.GrupId);
                        grupAd = grup?.GrupAdi ?? "";
                    }

                    ListViewItem item = new ListViewItem(s.SiparisTarihi.ToString("dd.MM.yyyy"));
                    item.SubItems.Add(s.CariAdi);
                    item.SubItems.Add(urun?.UrunAdi ?? ""); // Ürün adı yoksa boş göster
                    item.SubItems.Add(s.Miktar.ToString());
                    item.SubItems.Add(s.GelenMiktar.ToString());//10.10 neden ekledik
                    item.SubItems.Add(s.BirimFiyat.ToString());
                    item.SubItems.Add(s.Kur.ToString());
                    item.SubItems.Add(s.ParaBirimi);
                    var personel = context.Personels.Find(s.PersonelId);
                    item.SubItems.Add(personel?.Ad ?? "");


                    // DURUM - veritabanına eklemeden sadece UI için
                    // ---------- DURUM HESAPLAMA EKLENDİ ----------
                    string durum;
                    if (s.GelenMiktar == 0) durum = "Beklemede";
                    else if (s.GelenMiktar >= s.Miktar) durum = "Geldi";
                    else durum = "Kısmi Geldi";
                    item.SubItems.Add(durum); // sadece ListView’de görünecek

                    // Grup adı eklendi
                    item.SubItems.Add(grupAd);//bunu gruptan sonra yaptık cünkü iki veri karışıyordu 



                    // BURASI EKLENDİ: Her satıra sipariş ID'yi Tag olarak ata
                    item.Tag = s.SiparisId;

                    lVlSiparisListesi.Items.Add(item);
                }
            }

            using (var liste = new StokTakipContext())
            {
                var urunler = liste.StokKartis
                                 .Select(u => new { u.StokKartiId, u.UrunAdi })
                                 .ToList();

                cBSiparisAdi.DisplayMember = "UrunAdi";
                cBSiparisAdi.ValueMember = "StokKartiId";
                cBSiparisAdi.DataSource = urunler;

                // Otomatik tamamlama özelliği
                cBSiparisAdi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cBSiparisAdi.AutoCompleteSource = AutoCompleteSource.ListItems;
            }

            //sipariş girişi 
            // Para birimi comboBox(sipariş girişi)
            cBParaBirimi.Items.AddRange(new string[] { "Dolar", "TL", "Euro" });

            cBParaBirimi.SelectedIndex = 0;

            // TL seçilirse kur textbox pasif, diğerlerinde aktif
            cBParaBirimi.SelectedIndexChanged += (s, ev) =>
            {
                if (cBParaBirimi.SelectedItem?.ToString() == "TL")
                {
                    tBKur.Text = "1";
                    tBKur.Enabled = false;
                }
                else
                {
                    tBKur.Text = "";
                    tBKur.Enabled = true;
                }
            };


        }
        private void lVlSiparisListesi_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = lVlSiparisListesi.HitTest(e.Location);
                if (hit.Item != null && hit.SubItem != null)
                {
                    secilenItem = hit.Item;
                    secilenSubItem = hit.SubItem;

                    int gelenMiktarIndex = 4; // Gelen Miktar sütunu index         OTOMATİK YAPPP
                    if (hit.Item.SubItems.IndexOf(hit.SubItem) == gelenMiktarIndex)
                    {
                        cMSPrjListe.Show(lVlSiparisListesi, e.Location);
                    }
                }
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (secilenItem == null || secilenSubItem == null) return;

            TextBox txtEdit = new TextBox();
            // ListView ile uyumlu konum
            Rectangle rect = secilenSubItem.Bounds;
            txtEdit.SetBounds(rect.X, rect.Y, rect.Width, rect.Height);
            txtEdit.Text = secilenSubItem.Text;

            // Sadece textbox'ı kaldırmak için Leave
            txtEdit.Leave += (s, ev) => { lVlSiparisListesi.Controls.Remove(txtEdit); };

            // Enter basıldığında SubItem ve veritabanı güncelle
            txtEdit.PreviewKeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {


                    // UI güncelle
                    secilenSubItem.Text = txtEdit.Text;
                    lVlSiparisListesi.Controls.Remove(txtEdit);

                    // Veritabanı güncelle
                    if (secilenItem.Tag != null && int.TryParse(secilenItem.Tag.ToString(), out int siparisId))
                    {
                        using (var ctx = new StokTakipContext())
                        {
                            var siparis = ctx.SatinAlmas.FirstOrDefault(s => s.SiparisId == siparisId);
                            if (siparis != null && int.TryParse(txtEdit.Text, out int gelenMiktar))
                            {
                                siparis.GelenMiktar = gelenMiktar;
                                ctx.SaveChanges();


                                // ---------- DURUM GÜNCELLEME EKLENDİ ----------
                                string durum;
                                if (gelenMiktar == 0) durum = "Beklemede";
                                else if (gelenMiktar >= siparis.Miktar) durum = "Geldi";
                                else durum = "Kısmi Geldi";
                                secilenItem.SubItems[9].Text = durum; // 9 = Durum sütunu index
                                                                      // -------------------------------------------

                                MessageBox.Show("Güncelleme başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                    // BURASI EKLENDİ: Durum otomatik (veritabanına dokunmadan sadece ListView’de güncelliyor)
                    int siparisMiktar = int.Parse(secilenItem.SubItems[3].Text); // 3: Sipariş Edilen Miktar
                    string yeniDurum;
                    if (int.TryParse(secilenSubItem.Text, out int gelenMiktar2))
                    {
                        if (gelenMiktar2 == 0) yeniDurum = "Beklemede";
                        else if (gelenMiktar2 >= siparisMiktar) yeniDurum = "Geldi";
                        else yeniDurum = "Kısmi Geldi";

                        if (secilenItem.SubItems.Count < 11)
                            secilenItem.SubItems.Add(yeniDurum);
                        else
                            secilenItem.SubItems[10].Text = yeniDurum;
                    }
                }
            };

            lVlSiparisListesi.Controls.Add(txtEdit);
            txtEdit.Focus();
        }

        //private void btnSiparisKayit_Click(object sender, EventArgs e)
        //{
        //    // 1) Ürün seçili mi kontrol et
        //    if (cBSiparisAdi.SelectedValue == null)
        //    {
        //        MessageBox.Show("Lütfen bir ürün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    // 2) Seçilen StokKartiId'yi al (güvenli)
        //    if (!int.TryParse(cBSiparisAdi.SelectedValue.ToString(), out int secilenStokKartiId))
        //    {
        //        MessageBox.Show("Seçilen ürünün ID'si okunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    // 3) Diğer alanlardan değerleri al / parse et
        //    int miktar = (int)nudMiktar.Value;
        //    decimal birimFiyat = decimal.TryParse(tBBirimFiyat.Text, out var bf) ? bf : 0m;
        //    decimal kur = decimal.TryParse(tBKur.Text, out var k) ? k : 1m;
        //    string paraBirimi = cBParaBirimi.SelectedItem?.ToString() ?? "TL";
        //    //int personelId = int.TryParse(tBPersonelId.Text, out var pid) ? pid : 0; // ya da varsayılan chat personel ıd değil ad gelicek onu ada cevircez 

        //    int personelId = 0;
        //    using (var prsnl = new StokTakipContext())
        //    {
        //        var personel = prsnl.Personels.FirstOrDefault(p => p.Ad == tBSiparisiGirenPersonel.Text);
        //        if (personel != null)
        //            personelId = personel.PersonelId;
        //        else
        //        {
        //            MessageBox.Show("Girilen personel bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //    }


        //    // 4) Yeni SatinAlma nesnesini oluşturup DB'ye ekle
        //    using (var ctx = new StokTakipContext())
        //    {
        //        var yeniSiparis = new SatinAlma
        //        {
        //            SiparisTarihi = dTPSiparisTarihi.Value,
        //            CariAdi = tBSiparisVerilenFirmaAdi.Text,
        //            StokKartiId = secilenStokKartiId,
        //            Miktar = miktar,
        //            GelenMiktar = 0, // ilk etapta 0
        //            BirimFiyat = birimFiyat,
        //            Kur = kur,
        //            ParaBirimi = paraBirimi,
        //            PersonelId = personelId,
        //            Aciklama = tBAciklama.Text
        //        };

        //        ctx.SatinAlmas.Add(yeniSiparis);
        //        ctx.SaveChanges();
        //    }

        //    // 5) Listeyi yenile (metodun varsa çağır) ve isteğe bağlı kullanıcıya bilgi ver
        //    // RefreshSiparisList();
        //    MessageBox.Show("Sipariş kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    // isteğe bağlı: liste sekmesine geç
        //    // tabControl1.SelectedTab = tpListe;
        //}

        private void btnSiparisKayit_Click(object sender, EventArgs e)
        {
            // Ürün seçimi kontrolü
            if (cBSiparisAdi.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir ürün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cBSiparisAdi.SelectedValue.ToString(), out int secilenStokKartiId))
            {
                MessageBox.Show("Seçilen ürünün ID'si okunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Miktar ve birim fiyat
            int miktar = (int)nudMiktar.Value;
            decimal birimFiyat = decimal.TryParse(tBBirimFiyat.Text, out var bf) ? bf : 0m;

            // Kur kontrolü: TL ise 1, diğerleri textbox'tan
            decimal kur = 1m;
            if (cBParaBirimi.SelectedItem?.ToString() != "TL")
            {
                if (!decimal.TryParse(tBKur.Text, out kur) || kur <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir kur değeri girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string paraBirimi = cBParaBirimi.SelectedItem?.ToString() ?? "TL";

            // Personel kontrolü
            int personelId = 0;
            using (var prsnl = new StokTakipContext())
            {
                var personel = prsnl.Personels.FirstOrDefault(p => p.Ad == tBSiparisiGirenPersonel.Text);
                if (personel != null)
                    personelId = personel.PersonelId;
                else
                {
                    MessageBox.Show("Girilen personel bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Toplam maliyet hesaplama
            decimal toplamMaliyet = miktar * birimFiyat * kur;

            // Veritabanına ekle
            using (var ctx = new StokTakipContext())
            {
                var yeniSiparis = new SatinAlma
                {
                    SiparisTarihi = dTPSiparisTarihi.Value,
                    CariAdi = tBSiparisVerilenFirmaAdi.Text,
                    StokKartiId = secilenStokKartiId,
                    Miktar = miktar,
                    GelenMiktar = 0,
                    BirimFiyat = birimFiyat,
                    Kur = kur,
                    ParaBirimi = paraBirimi,
                    PersonelId = personelId,
                    Aciklama = tBAciklama.Text,
                    ToplamMaliyet=toplamMaliyet
                };

                ctx.SatinAlmas.Add(yeniSiparis);
                ctx.SaveChanges();
            }

            // TextBox'a yaz ve kullanıcıya bilgi ver
            tBTpMaliyet.Text = toplamMaliyet.ToString("N2");
            MessageBox.Show($"Sipariş kaydedildi!\nToplam maliyet: {toplamMaliyet:N2} {paraBirimi}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void lVlSiparisListesi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


}

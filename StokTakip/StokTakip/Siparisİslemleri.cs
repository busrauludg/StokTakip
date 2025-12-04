using Microsoft.EntityFrameworkCore;
using StokTakip.Helpers;
using StokTakip.Models;
using StokTakip.StokTakip.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            tabControl1.Dock = DockStyle.Fill;

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
            lVlSiparisListesi.Columns.Add("Durum", 100);
            lVlSiparisListesi.Columns.Add("Grup Adı", 100);

            lVlSiparisListesi.ContextMenuStrip = cMSPrjListe;
            lVlSiparisListesi.MouseUp += lVlSiparisListesi_MouseUp;

            lVlSiparisListesi.Dock = DockStyle.Fill;
            using (var context = new StokTakipContext())
            {
                var siparisler = context.SatinAlmas
                   .Include(s => s.Personel)
                   .ToList() // önce siparişleri al
                   .Where(s => context.StokKartis.Any(u => u.StokKartiId == s.StokKartiId)) // aktif ürün varsa al
                   .OrderByDescending(s => s.SiparisTarihi)
                   .ThenByDescending(s => s.SiparisId)
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
                    item.SubItems.Add(urun?.UrunAdi ?? ""); 
                    item.SubItems.Add(s.Miktar.ToString());
                    item.SubItems.Add(s.GelenMiktar.ToString());
                    item.SubItems.Add(s.BirimFiyat.ToString());
                    item.SubItems.Add(s.Kur.ToString());
                    item.SubItems.Add(s.ParaBirimi);
                    var personel = context.Personels.Find(s.PersonelId);
                    item.SubItems.Add(personel?.Ad ?? "");

                    string durum;
                    if (s.GelenMiktar == 0) durum = "Beklemede";
                    else if (s.GelenMiktar >= s.Miktar) durum = "Geldi";
                    else durum = "Kısmi Geldi";
                    item.SubItems.Add(durum); 

                    item.SubItems.Add(grupAd);

                    item.Tag = s.SiparisId;

                    if (s.GelenMiktar >= s.Miktar)
                    {
                        item.ForeColor = Color.Gray;
                        item.Font = new Font(lVlSiparisListesi.Font, FontStyle.Italic);

                        lVlSiparisListesi.Items.Add(item);
                    }
                    else
                    {
                        item.ForeColor = Color.Black;
                        item.Font = lVlSiparisListesi.Font;

                        lVlSiparisListesi.Items.Add(item);
                    }
                    tBSiparisiGirenPersonel.ReadOnly = true;

                    tBSiparisiGirenPersonel.Text = GirisYapanKullanici.Ad;
                }

                using (var liste = new StokTakipContext())
                {
                    var urunler = liste.StokKartis
                                     .Select(u => new { u.StokKartiId, u.UrunAdi })
                                     .ToList();

                    cBSiparisAdi.DisplayMember = "UrunAdi";
                    cBSiparisAdi.ValueMember = "StokKartiId";
                    cBSiparisAdi.DataSource = urunler;

                    cBSiparisAdi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cBSiparisAdi.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
                cBParaBirimi.Items.AddRange(new string[] { "Dolar", "TL", "Euro" });

                cBParaBirimi.SelectedIndex = 0;
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
                tBKur.KeyPress += (s, e) =>
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                    {
                        e.Handled = true;
                        return;
                    }
                    if (e.KeyChar == ',' && tBKur.Text.Contains(',')) e.Handled = true;
                };
                tBKur.Leave += (s, e) =>
                {
                    string text = tBKur.Text.Replace('.', ',');
                    if (string.IsNullOrWhiteSpace(text)) return;

                    if (!Regex.IsMatch(text, @"^\d{1,3}(,\d{1,2})?$"))
                    {
                        MessageBox.Show("Kur 0–999,99 arası olmalı. Lütfen kontrol edin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tBKur.Focus();
                        return;
                    }
                };
                tBBirimFiyat.KeyPress += (s, e) =>
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                        e.Handled = true;

                    if (e.KeyChar == ',' && tBBirimFiyat.Text.Contains(',')) e.Handled = true;
                };
                tBBirimFiyat.Leave += (s, e) =>
                {
                    string text = tBBirimFiyat.Text.Replace('.', ',');
                    if (string.IsNullOrWhiteSpace(text)) return;

                    if (!Regex.IsMatch(text, @"^\d{1,3}(,\d{1,2})?$"))
                    {
                        MessageBox.Show("Birim Fiyat 0–999,99 arası olmalı. Lütfen kontrol edin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tBBirimFiyat.Focus();
                        return;
                    }
                };

            }

            using (var liste = new StokTakipContext())
            {
                var urunler = liste.SatinAlmas
                                   .Include(s => s.StokKarti)
                                   .Select(s => s.StokKarti)
                                   .Where(u => u != null)
                                   .Distinct()
                                   .Select(u => new { u.StokKartiId, u.UrunAdi })
                                   .ToList();

                cBUrunAra.DisplayMember = "UrunAdi";
                cBUrunAra.ValueMember = "StokKartiId";
                cBUrunAra.DataSource = urunler;

                cBUrunAra.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cBUrunAra.AutoCompleteSource = AutoCompleteSource.ListItems;
            }


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

                    int gelenMiktarIndex = 4; 
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
            Rectangle rect = secilenSubItem.Bounds;
            txtEdit.SetBounds(rect.X, rect.Y, rect.Width, rect.Height);
            txtEdit.Text = secilenSubItem.Text;

            txtEdit.Leave += (s, ev) => { lVlSiparisListesi.Controls.Remove(txtEdit); };

            txtEdit.PreviewKeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    secilenSubItem.Text = txtEdit.Text;
                    lVlSiparisListesi.Controls.Remove(txtEdit);

                    if (secilenItem.Tag != null && int.TryParse(secilenItem.Tag.ToString(), out int siparisId))
                    {
                        using (var ctx = new StokTakipContext())
                        {
                            var siparis = ctx.SatinAlmas.FirstOrDefault(s => s.SiparisId == siparisId);
                            if (siparis != null && int.TryParse(txtEdit.Text, out int gelenMiktar))
                            {
                                siparis.GelenMiktar = gelenMiktar;
                                ctx.SaveChanges();
                                string durum;
                                if (gelenMiktar == 0) durum = "Beklemede";
                                else if (gelenMiktar >= siparis.Miktar) durum = "Geldi";
                                else durum = "Kısmi Geldi";
                                secilenItem.SubItems[9].Text = durum; 

                                MessageBox.Show("Güncelleme başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                    int siparisMiktar = int.Parse(secilenItem.SubItems[3].Text);
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

        private void btnSiparisKayit_Click(object sender, EventArgs e)
        {
            if (cBSiparisAdi.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir ürün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cBSiparisAdi.SelectedValue.ToString(), out int secilenStokKartiId))
            {
                MessageBox.Show("Seçilen ürün bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int miktar = (int)nudMiktar.Value;
            decimal birimFiyat = decimal.TryParse(tBBirimFiyat.Text, out var bf) ? bf : 0m;

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
            decimal toplamMaliyet = miktar * birimFiyat * kur;
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
                    ToplamMaliyet = toplamMaliyet
                };

                ctx.SatinAlmas.Add(yeniSiparis);
                ctx.SaveChanges();
            }
            tBTpMaliyet.Text = toplamMaliyet.ToString("N2");
            MessageBox.Show($"Sipariş kaydedildi!\nToplam maliyet: {toplamMaliyet:N2} {paraBirimi}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUrunAra_Click_1(object sender, EventArgs e)
        {
            if (cBUrunAra.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir ürün seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int secilenUrunId = Convert.ToInt32(cBUrunAra.SelectedValue);

            using (var ctx = new StokTakipContext())
            {
                var siparisler = ctx.SatinAlmas
                    .Include(s => s.Personel)
                    .Include(s => s.StokKarti)
                    .Where(s => s.StokKartiId == secilenUrunId)
                    .OrderBy(s => s.GelenMiktar >= s.Miktar ? 1 : 0) 
                    .ThenBy(s => s.SiparisTarihi) 
                    .ToList();

                lVlSiparisListesi.Items.Clear();

                foreach (var s in siparisler)
                {
                    var urun = s.StokKarti;
                    string grupAd = "";
                    if (urun?.GrupId != null)
                    {
                        var grup = ctx.Gruplars.Find(urun.GrupId);
                        grupAd = grup?.GrupAdi ?? "";
                    }

                    ListViewItem item = new ListViewItem(s.SiparisTarihi.ToString("dd.MM.yyyy"));
                    item.SubItems.Add(s.CariAdi);
                    item.SubItems.Add(urun?.UrunAdi ?? "");
                    item.SubItems.Add(s.Miktar.ToString());
                    item.SubItems.Add(s.GelenMiktar.ToString());
                    item.SubItems.Add(s.BirimFiyat.ToString());
                    item.SubItems.Add(s.Kur.ToString());
                    item.SubItems.Add(s.ParaBirimi);
                    item.SubItems.Add(s.Personel?.Ad ?? "");

                    string durum = s.GelenMiktar == 0 ? "Beklemede" :
                                   (s.GelenMiktar >= s.Miktar ? "Geldi" : "Kısmi Geldi");
                    item.SubItems.Add(durum);
                    item.SubItems.Add(grupAd);

                    item.Tag = s.SiparisId;
                    if (s.GelenMiktar >= s.Miktar)
                    {
                        item.ForeColor = Color.Gray;
                        item.Font = new Font(lVlSiparisListesi.Font, FontStyle.Italic);
                    }
                    else
                    {
                        item.ForeColor = Color.Black;
                        item.Font = new Font(lVlSiparisListesi.Font, FontStyle.Regular);
                    }
                    lVlSiparisListesi.Items.Add(item);

                }

                if (siparisler.Count == 0)
                    MessageBox.Show("Bu ürüne ait sipariş bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

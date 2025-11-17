using StokTakip.Helpers;
using StokTakip.Models;
using StokTakip.Services;
using StokTakip.StokTakip.Data;
using StokTakip.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class ElektrikUrunDetayForm : Form
    {
        private StokKartiViewModel _secilenUrun;
        private SatinAlmaSiparisleriViewModel _sipAlim;
        private StokDurumuViewModel _stokDurum;


        public ElektrikUrunDetayForm(StokKartiViewModel secilenUrun,
                              SatinAlmaSiparisleriViewModel sipAlim,
                              StokDurumuViewModel stokDurum)
        {
            InitializeComponent();
            _secilenUrun = secilenUrun;
            _sipAlim = sipAlim;
            _stokDurum = stokDurum;

        }

        private void ElektrikForm_Load(object sender, EventArgs e)
        {
            if (_secilenUrun != null)
            {
                txtStokKodu.Text = _secilenUrun.StokKodu;
                txtFirmaSiparisKodu.Text = _secilenUrun.FirmaKodu;
                txtStokBirimi.Text = _secilenUrun.StokBirimi;
                txtDepoAdresi.Text = _secilenUrun.DepoAdresi;
                txtMinStok.Text = _secilenUrun.MinStok.ToString();
                txtMaxStok.Text = _secilenUrun.MaxStok.ToString();
                tBElStokMiktari.Text = _secilenUrun.StokMiktari.ToString();
                txtGrupAdi.Text = _secilenUrun.GrupAdi;
                txtFirmaAdi.Text = _secilenUrun.FirmaAdi;
                txtPersonelAdi.Text = _secilenUrun.PersonelAdi;
                txtAciklama.Text = _secilenUrun.Aciklama;
            }
            //if (_sipAlim != null)
            //{

            //    dTPElektrik.Value = _sipAlim.SiparisTarihi;           // DateTimePicker için Value kullan
            //    txtMiktar.Text = _sipAlim.Miktar.ToString();
            //    txtCari.Text = _sipAlim.CariAdi;
            //    txtGlnMktr.Text = _sipAlim.GelenMiktar.ToString() ?? ""; // nullable int için
            //    // Burada toplam maliyeti veritabanından çek
            //    using (var context = new StokTakipContext())
            //    {
            //        var sipAlimDb = context.SatinAlmas
            //            .Where(a => a.StokKartiId == _secilenUrun.StokKartiId)
            //            .OrderByDescending(a => a.SiparisId) // 🔹 En son girilen siparişi alır
            //            .FirstOrDefault();

            //        if (sipAlimDb != null)
            //        {
            //            tBToplmTutar.Text = sipAlimDb.ToplamMaliyet.ToString("N2");
            //        }
            //    }
            //    txtSprsAciklama.Text = _sipAlim.Aciklama;
            //}
            using (var context = new StokTakipContext())
            {
                var sipAlimDb = context.SatinAlmas
                    .Where(a => a.StokKartiId == _secilenUrun.StokKartiId)
                    .OrderByDescending(a => a.SiparisId)
                    .FirstOrDefault();

                if (sipAlimDb != null)
                {
                    dTPElektrik.Value = sipAlimDb.SiparisTarihi;
                    txtMiktar.Text = sipAlimDb.Miktar.ToString();
                    txtCari.Text = sipAlimDb.CariAdi;
                    txtGlnMktr.Text = sipAlimDb.GelenMiktar.ToString() ?? "";
                    tBToplmTutar.Text = sipAlimDb.ToplamMaliyet.ToString("N2");
                    txtSprsAciklama.Text = sipAlimDb.Aciklama;
                }
            }

            if (_stokDurum != null)
            {
                var stkdurum = new List<StokDurumuViewModel> { _stokDurum };
                dGVElStokDurum.DataSource = stkdurum;

                // kolon adını DataSource atandıktan sonra kullan
                dGVElStokDurum.Columns["StokKartId"].Visible = false;
                dGVElStokDurum.Columns["DepoAdi"].HeaderText = "Depo Adı";
                dGVElStokDurum.Columns["SerbestMiktar"].HeaderText = "Kullanılabilir Miktar";
                dGVElStokDurum.Columns["BlokeMiktar"].HeaderText = "Kullanılan Miktar";
            }
            if (_secilenUrun != null)
            {
                // diğer alanlar
                if (File.Exists(_secilenUrun.ResimYolu))
                {
                    pBElektrikResim.Image = Image.FromFile(_secilenUrun.ResimYolu);
                    pBElektrikResim.SizeMode = PictureBoxSizeMode.Zoom; // buraya
                }
            }
            lVAktifProje.View = View.Details;
            lVAktifProje.Columns.Add("Ürün Adı", 150);
            lVAktifProje.Columns.Add("Miktar", 70);
            lVAktifProje.Columns.Add("Durum", 70);
            if (_secilenUrun != null)
            {
                using (var context = new StokTakipContext())
                {
                      var liste = context.ProjedeKullanilanUrunlers
                     .Where(p => p.StokKartiId == _secilenUrun.StokKartiId && p.Proje.Durum)
                     .Select(p => new
                     {
                         p.Proje.ProjeAdi,
                         p.Miktar,
                         Durum = p.Proje.Durum ? "Aktif" : "Pasif"
                     })
                     .ToList();


                    lVAktifProje.Items.Clear();
                    foreach (var item in liste)
                    {
                        var lvi = new ListViewItem(item.ProjeAdi);
                        lvi.SubItems.Add(item.Miktar.ToString());
                        lvi.SubItems.Add(item.Durum);
                        lVAktifProje.Items.Add(lvi);
                    }
                }

            }
            pStokCikis.Visible = false;
            pStokArtir.Visible = false;

            btnStokCik.Enabled = YetkiliKontrol.Rol;
            btnStokArttir.Enabled = YetkiliKontrol.Rol;
           
            //proje sec
            using (var context =new StokTakipContext())
            {
                var projeler=context.Projes
                    .OrderBy(p=>p.ProjeAdi)
                    .ToList();
                cBPProjeSec.DataSource = projeler;
                cBPProjeSec.DisplayMember = "ProjeAdi";
                cBPProjeSec.ValueMember = "ProjeId";
                cBPProjeSec.SelectedIndex = -1;
            }
        }


        private void btnStokCik_Click(object sender, EventArgs e)
        {

            pStokCikis.Visible = true;

        }

        private void btnStokArttir_Click(object sender, EventArgs e)
        {
            pStokArtir.Visible = true;
        }

        private void btnStokCikisi_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tBCikicakMiktar.Text, out int cikisMiktari) || cikisMiktari <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir miktar girin.");
                return;
            }

            var secilenStok = _stokDurum; // ViewModel üzerinden
            if (secilenStok == null)
            {
                MessageBox.Show("Stok seçili değil.");
                return;
            }

            // Kullanılabilir miktarı düş
            int yeniKullanilabilir = secilenStok.SerbestMiktar - cikisMiktari;

            if (yeniKullanilabilir < 0)
            {
                MessageBox.Show("Stok yetersiz!");
                return;
            }

            // Min stok kontrolü
            if (yeniKullanilabilir < _secilenUrun.MinStok)
            {
                MessageBox.Show("Uyarı: Minimum stok seviyesinin altına düşüyorsunuz!");
                //return;
            }

            // Max stok kontrolü
            if (yeniKullanilabilir > _secilenUrun.MaxStok)
            {
                MessageBox.Show("Uyarı: Maksimum stok seviyesini aşıyorsunuz!");
                return;
            }

            // ViewModel'i güncelle
            secilenStok.SerbestMiktar = yeniKullanilabilir;

            // Veritabanına kaydet
            using (var context = new StokTakipContext())
            {
                var dbStok = context.StokDurumus
                    .FirstOrDefault(s => s.StokKartiId == secilenStok.StokKartId);

                if (dbStok != null)
                {
                    dbStok.SerbestMiktar = secilenStok.SerbestMiktar;
                }

                // 🔹 PROJEYE MİKTAR EKLEME İŞLEMİ 🔹
                if (cBPProjeSec.SelectedValue != null)
                {
                    int projeId = Convert.ToInt32(cBPProjeSec.SelectedValue);
                    var projeUrun = context.ProjedeKullanilanUrunlers
                        .FirstOrDefault(p => p.ProjeId == projeId && p.StokKartiId == dbStok.StokKartiId);

                    if (projeUrun != null)
                    {
                        // Proje zaten bu üründen kullanıyorsa miktarı artır
                        projeUrun.Miktar += cikisMiktari;
                    }
                    else
                    {
                        // Proje bu ürünü ilk kez kullanıyorsa ekle
                        context.ProjedeKullanilanUrunlers.Add(new ProjedeKullanilanUrunler
                        {
                            ProjeId = projeId,
                            StokKartiId = dbStok.StokKartiId,
                            Miktar = cikisMiktari
                        });
                    }
                }

                context.SaveChanges();
            }

            // DataGrid’i güncelle
            dGVElStokDurum.DataSource = null;
            dGVElStokDurum.DataSource = new List<StokDurumuViewModel> { secilenStok };
            dGVElStokDurum.Columns["StokKartId"].Visible = false;
            dGVElStokDurum.Columns["DepoAdi"].HeaderText = "Depo Adı";
            dGVElStokDurum.Columns["SerbestMiktar"].HeaderText = "Kullanılabilir Miktar";
            dGVElStokDurum.Columns["BlokeMiktar"].HeaderText = "Kullanılan Miktar";

            MessageBox.Show("Stok çıkışı ve proje güncellemesi başarılı!");

        }



        private void btnStokArtir_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(tBStkArtir.Text, out decimal gelenMiktar) || gelenMiktar <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir miktar girin.");
                return;
            }

            using (var context = new StokTakipContext())
            {
                int urunId = _secilenUrun.StokKartiId;

                // 1️⃣ Seçili ürüne ait satın alma kaydı bulunur
                //var satinAlma = context.SatinAlmas.FirstOrDefault(x => x.StokKartiId == urunId);

               var satinAlma = context.SatinAlmas
                  .Where(x => x.StokKartiId == urunId)
                  .OrderByDescending(x => x.SiparisTarihi)
                   .FirstOrDefault();

                if (satinAlma == null)
                {
                    MessageBox.Show("Bu ürüne ait satın alma kaydı bulunamadı.");
                    return;
                }

                // 2️⃣ Ürün kartı
                var stokKarti = context.StokKartis.FirstOrDefault(x => x.StokKartiId == urunId);
                if (stokKarti == null)
                {
                    MessageBox.Show("Ürün bulunamadı.");
                    return;
                }

                // 3️⃣ Stok durumu
                var stokDurumu = context.StokDurumus.FirstOrDefault(x => x.StokKartiId == urunId);
                if (stokDurumu == null)
                {
                    MessageBox.Show("Stok durumu bulunamadı.");
                    return;
                }

                // 4️⃣ Sipariş kontrolü — gelen miktar sipariş miktarını aşamaz
                if (satinAlma.GelenMiktar + gelenMiktar > satinAlma.Miktar)
                {
                    MessageBox.Show($"Gelen miktar sipariş verilen miktarı aşamaz! (Sipariş: {satinAlma.Miktar}, Gelen: {satinAlma.GelenMiktar})");
                    return;
                }

                // 5️⃣ Stok hesaplama
                decimal blokeMiktar = 0;
                decimal.TryParse(stokDurumu.BlokeMiktar, out blokeMiktar);

                decimal yeniKullanilabilir = stokDurumu.SerbestMiktar + gelenMiktar;
                decimal toplamStok = yeniKullanilabilir + blokeMiktar;

                // 6️⃣ Maksimum stok kontrolü
                if (toplamStok > stokKarti.MaxStok)
                {
                    var result = MessageBox.Show(
                        $"Maksimum stok seviyesini geçmek üzeresiniz ({stokKarti.MaxStok}).\nYine de kaydetmek istiyor musunuz?",
                        "Uyarı",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("İşlem iptal edildi.");
                        return;
                    }
                }

                // 7️⃣ Güncellemeler
                stokDurumu.SerbestMiktar = (int)yeniKullanilabilir;
                stokKarti.StokMiktari = (int)toplamStok;
                satinAlma.GelenMiktar += (int)gelenMiktar;

                // 8️⃣ Değişiklikleri kaydet
                context.SaveChanges();

                MessageBox.Show("Stok başarıyla güncellendi!");
            }
        }


        private void lVAktifProje_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}


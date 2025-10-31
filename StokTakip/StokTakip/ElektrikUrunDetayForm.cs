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
            if (_sipAlim != null)
            {

                dTPElektrik.Value = _sipAlim.SiparisTarihi;           // DateTimePicker için Value kullan
                txtMiktar.Text = _sipAlim.Miktar.ToString();
                txtCari.Text = _sipAlim.CariAdi;
                txtGlnMktr.Text = _sipAlim.GelenMiktar.ToString() ?? ""; // nullable int için
                // Burada toplam maliyeti veritabanından çek
                using (var context = new StokTakipContext())
                {
                    var sipAlimDb = context.SatinAlmas
                        .FirstOrDefault(a => a.StokKartiId == _secilenUrun.StokKartiId);

                    if (sipAlimDb != null)
                    {
                        tBToplmTutar.Text = sipAlimDb.ToplamMaliyet.ToString("N2");
                    }
                }
                txtSprsAciklama.Text = _sipAlim.Aciklama;
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

            //if (!int.TryParse(tBStkArtir.Text, out int artisMiktari) || artisMiktari <= 0)
            //{
            //    MessageBox.Show("Lütfen geçerli bir miktar girin.");
            //    return;
            //}

            //using (var context = new StokTakipContext())
            //{
            //    var satinAlma = context.SatinAlmas
            //        .FirstOrDefault(x => x.StokKartiId == _secilenUrun.StokKartiId);
            //    if (satinAlma != null)
            //    {
            //        satinAlma.GelenMiktar += artisMiktari;
            //    }

            //    var stokDurum = context.StokDurumus
            //        .FirstOrDefault(x => x.StokKartiId == _secilenUrun.StokKartiId);
            //    if (stokDurum != null)
            //    {
            //        stokDurum.SerbestMiktar += artisMiktari;
            //    }

            //    context.SaveChanges();
            //}

            //MessageBox.Show("Stok başarıyla artırıldı!");

            //// UI'da durum güncellemesi sadece Form üzerinden
            //ElektrikForm_Load(null, null);

            if (!int.TryParse(tBStkArtir.Text, out int artisMiktari) || artisMiktari <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir miktar girin.");
                return;
            }

            // Max stok kontrolü
            int yeniStok = _secilenUrun.StokMiktari + artisMiktari;
            if (yeniStok > _secilenUrun.MaxStok)
            {
                MessageBox.Show($"Uyarı: Maksimum stok miktarı {_secilenUrun.MaxStok}. Şu an stok: {_secilenUrun.StokMiktari}, girilen miktar: {artisMiktari}");
                return; // Uyarı verip işlemi durduruyor
            }

            using (var context = new StokTakipContext())
            {
                var satinAlma = context.SatinAlmas
                    .FirstOrDefault(x => x.StokKartiId == _secilenUrun.StokKartiId);
                if (satinAlma != null)
                {
                    //satinAlma.GelenMiktar = (satinAlma.GelenMiktar ?? 0) + artisMiktari;
                    satinAlma.GelenMiktar += artisMiktari;

                }

                var stokDurum = context.StokDurumus
                    .FirstOrDefault(x => x.StokKartiId == _secilenUrun.StokKartiId);
                if (stokDurum != null)
                {
                    stokDurum.SerbestMiktar += artisMiktari;
                }

                context.SaveChanges();
            }

            MessageBox.Show("Stok başarıyla artırıldı!");

            // UI'da durum güncellemesi sadece Form üzerinden
            ElektrikForm_Load(null, null);

        }

        private void lVAktifProje_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}


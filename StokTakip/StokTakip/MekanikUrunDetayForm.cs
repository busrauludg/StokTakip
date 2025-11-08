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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class MekanikUrunDetayForm : Form
    {
        private readonly StokKartiViewModel _secilenUrun;
        private readonly StokDurumuViewModel _durum;//(constructor tanımla )
        private readonly SatinAlmaSiparisleriViewModel _alim;


        public MekanikUrunDetayForm(StokKartiViewModel secilenUrun,
            StokDurumuViewModel durum,
            SatinAlmaSiparisleriViewModel alim)
        {
            InitializeComponent();
            _secilenUrun = secilenUrun;
            _durum = durum;
            _alim = alim;
        }

        private void MekanikForm_Load(object sender, EventArgs e)
        {


            if (_secilenUrun != null)
            {
                txtMStokKodu.Text = _secilenUrun.StokKodu;
                txtMFirmaSiparisKodu.Text = _secilenUrun.FirmaKodu;
                txtMStokBirimi.Text = _secilenUrun.StokBirimi;
                txtMDepoAdresi.Text = _secilenUrun.DepoAdresi;
                txtMMinStok.Text = _secilenUrun.MinStok.ToString();
                txtMMaxStok.Text = _secilenUrun.MaxStok.ToString();
                tBMStokMiktari.Text = _secilenUrun.StokMiktari.ToString();
                txtMGrupAdi.Text = _secilenUrun.GrupAdi;
                txtMFirmaAdi.Text = _secilenUrun.FirmaAdi;
                txtMPersonelAdi.Text = _secilenUrun.PersonelAdi;
                txtMAciklama.Text = _secilenUrun.Aciklama;

            }
            //satınalma tablosu
            //if (_alim != null)//adını değiştir 
            //{

            //    dTPMekanik.Value = _alim.SiparisTarihi;           // DateTimePicker için Value kullan
            //    txtMMiktar.Text = _alim.Miktar.ToString();
            //    txtMCari.Text = _alim.CariAdi;
            //    txtMGlnMktr.Text = _alim.GelenMiktar.ToString() ?? ""; // nullable int için
            //                                                            // Burada toplam maliyeti veritabanından çek
            //    using (var context = new StokTakipContext())
            //    {
            //        var alimDb = context.SatinAlmas
            //            .FirstOrDefault(a => a.StokKartiId == _secilenUrun.StokKartiId);

            //        if (alimDb != null)
            //        {
            //            tBMekTopTutar.Text = alimDb.ToplamMaliyet.ToString("N2");
            //        }
            //    }
            //    txtMSprsAciklama.Text = _alim.Aciklama;

            //}
            using (var context = new StokTakipContext())
            {
                var sipAlimDb = context.SatinAlmas
                    .Where(a => a.StokKartiId == _secilenUrun.StokKartiId)
                    .OrderByDescending(a => a.SiparisId)
                    .FirstOrDefault();

                if (sipAlimDb != null)
                {
                    dTPMekanik.Value = sipAlimDb.SiparisTarihi;
                    txtMMiktar.Text = sipAlimDb.Miktar.ToString();
                    txtMCari.Text = sipAlimDb.CariAdi;
                    txtMGlnMktr.Text = sipAlimDb.GelenMiktar.ToString() ?? "";
                    tBMekTopTutar.Text = sipAlimDb.ToplamMaliyet.ToString("N2");
                    txtMSprsAciklama.Text = sipAlimDb.Aciklama;
                }
            }

            //stokdurumu tablosu olucak
            if (_durum != null)
            {
                var mdurum = new List<StokDurumuViewModel> { _durum };
                dGVMknStkDurum.DataSource = mdurum;

                // 👇 Başlıkları burada değiştir
                // kolon adını DataSource atandıktan sonra kullan
                dGVMknStkDurum.Columns["StokKartId"].Visible = false;
                dGVMknStkDurum.Columns["DepoAdi"].HeaderText = "Depo Adı";
                dGVMknStkDurum.Columns["SerbestMiktar"].HeaderText = "Kullanılabilir Miktar";
                dGVMknStkDurum.Columns["BlokeMiktar"].HeaderText = "Kullanılan Miktar";
            }
            //picturebox
            if (_secilenUrun != null)
            {
                // diğer alanlar
                if (File.Exists(_secilenUrun.ResimYolu))
                {
                    pBMekanikResim.Image = Image.FromFile(_secilenUrun.ResimYolu);
                    pBMekanikResim.SizeMode = PictureBoxSizeMode.Zoom; // buraya
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
                    //var liste = context.ProjedeKullanilanUrunlers
                    //    .Where(p => p.StokKartiId == _secilenUrun.StokKartiId) // seçilen ürün
                    //    .Select(p => new
                    //    {
                    //        p.Proje.ProjeAdi,
                    //        p.Miktar,
                    //        //p.Proje.Durum,
                    //        Durum = p.Proje.Durum ? "Aktif" : "Pasif"  // 👈 burada
                    //    }).ToList();

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

            pMStokCikis.Visible = false;
            pMStokArtir.Visible = false;

            btnStokCikis.Enabled = YetkiliKontrol.Rol;
            btnMSArtirPanel.Enabled = YetkiliKontrol.Rol;



            //proje sec
            using (var context = new StokTakipContext())
            {
                var projeler = context.Projes
                    .OrderBy(p => p.ProjeAdi)
                    .ToList();
                cBPMProjeSec.DataSource = projeler;
                cBPMProjeSec.DisplayMember = "ProjeAdi";
                cBPMProjeSec.ValueMember = "ProjeId";
                cBPMProjeSec.SelectedIndex = -1;
            }



        }

        private void btnStokCikis_Click(object sender, EventArgs e)
        {
            pMStokCikis.Visible = true;
        }
        private void btnMSArtirPanel_Click(object sender, EventArgs e)
        {
            pMStokArtir.Visible = true;
        }


        private void btnMStokCikisi_Click(object sender, EventArgs e)
        {
            //    // Girilen miktarı al
            //    if (!int.TryParse(tBMCikicakMiktar.Text, out int cikisMiktari) || cikisMiktari <= 0)
            //    {
            //        MessageBox.Show("Lütfen geçerli bir miktar girin.");
            //        return;
            //    }

            //    var secilenStok = _durum; // ViewModel üzerinden
            //    if (secilenStok == null)
            //    {
            //        MessageBox.Show("Stok seçili değil.");
            //        return;
            //    }

            //    // Kullanılabilir miktarı düş
            //    int yeniKullanilabilir = secilenStok.SerbestMiktar - cikisMiktari;

            //    // Min stok kontrolü
            //    if (yeniKullanilabilir < _secilenUrun.MinStok)
            //    {
            //        MessageBox.Show("Uyarı: Minimum stok seviyesinin altına düşüyorsunuz!");
            //        //return;
            //    }

            //    // Max stok kontrolü
            //    if (yeniKullanilabilir > _secilenUrun.MaxStok)
            //    {
            //        MessageBox.Show("Uyarı: Maksimum stok seviyesini aşıyorsunuz!");
            //        return;
            //    }

            //    // ViewModel'i güncelle
            //    secilenStok.SerbestMiktar = yeniKullanilabilir;

            //    // Veritabanına kaydet
            //    using (var context = new StokTakipContext())
            //    {
            //        var dbStok = context.StokDurumus
            //            .FirstOrDefault(s => s.StokKartiId == secilenStok.StokKartId); // DurumId yerine StokKartId
            //        if (dbStok != null)
            //        {
            //            dbStok.SerbestMiktar = secilenStok.SerbestMiktar;
            //            context.SaveChanges();
            //        }
            //    }


            //    // DataGrid’i güncelle
            //    dGVMknStkDurum.DataSource = null;
            //    dGVMknStkDurum.DataSource = new List<StokDurumuViewModel> { secilenStok };
            //    // kolon adını DataSource atandıktan sonra kullan
            //    dGVMknStkDurum.Columns["StokKartId"].Visible = false;
            //    dGVMknStkDurum.Columns["DepoAdi"].HeaderText = "Depo Adı";
            //    dGVMknStkDurum.Columns["SerbestMiktar"].HeaderText = "Kullanılabilir Miktar";
            //    dGVMknStkDurum.Columns["BlokeMiktar"].HeaderText = "Kullanılan Miktar";

            //    MessageBox.Show("Stok çıkışı başarılı!");
            // Girilen miktarı al
            if (!int.TryParse(tBMCikicakMiktar.Text, out int cikisMiktari) || cikisMiktari <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir miktar girin.");
                return;
            }

            var secilenStok = _durum; // ViewModel üzerinden
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
                if (cBPMProjeSec.SelectedValue != null)
                {
                    int projeId = Convert.ToInt32(cBPMProjeSec.SelectedValue);
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
            dGVMknStkDurum.DataSource = null;
            dGVMknStkDurum.DataSource = new List<StokDurumuViewModel> { secilenStok };
            dGVMknStkDurum.Columns["StokKartId"].Visible = false;
            dGVMknStkDurum.Columns["DepoAdi"].HeaderText = "Depo Adı";
            dGVMknStkDurum.Columns["SerbestMiktar"].HeaderText = "Kullanılabilir Miktar";
            dGVMknStkDurum.Columns["BlokeMiktar"].HeaderText = "Kullanılan Miktar";

            MessageBox.Show("Stok çıkışı ve proje güncellemesi başarılı!");
        }

        //private void btnMStokArttir_Click(object sender, EventArgs e)
        //{
        //    //    if (!int.TryParse(tBMArtirMiktar.Text, out int artisMiktari) || artisMiktari <= 0)
        //    //    {
        //    //        MessageBox.Show("Lütfen geçerli bir miktar girin.");
        //    //        return;
        //    //    }

        //    //    using (var context = new StokTakipContext())
        //    //    {
        //    //        var satinAlma = context.SatinAlmas
        //    //            .FirstOrDefault(x => x.StokKartiId == _secilenUrun.StokKartiId);
        //    //        if (satinAlma != null)
        //    //        {
        //    //            satinAlma.GelenMiktar = (satinAlma.GelenMiktar ?? 0) + artisMiktari;
        //    //        }

        //    //        var stokDurum = context.StokDurumus
        //    //            .FirstOrDefault(x => x.StokKartiId == _secilenUrun.StokKartiId);
        //    //        if (stokDurum != null)
        //    //        {
        //    //            stokDurum.SerbestMiktar += artisMiktari;
        //    //        }

        //    //        context.SaveChanges();
        //    //    }

        //    //    MessageBox.Show("Stok başarıyla artırıldı!");

        //    //    // UI'da durum güncellemesi sadece Form üzerinden
        //    //    MekanikForm_Load(null, null);

        //    if (!int.TryParse(tBMArtirMiktar.Text, out int artisMiktari) || artisMiktari <= 0)
        //    {
        //        MessageBox.Show("Lütfen geçerli bir miktar girin.");
        //        return;
        //    }

        //    // Max stok kontrolü
        //    int yeniStok = _secilenUrun.StokMiktari + artisMiktari;
        //    if (yeniStok > _secilenUrun.MaxStok)
        //    {
        //        MessageBox.Show($"Uyarı: Maksimum stok miktarı {_secilenUrun.MaxStok}. Şu an stok: {_secilenUrun.StokMiktari}, girilen miktar: {artisMiktari}");
        //        return; // Uyarı verip işlemi durduruyor
        //    }

        //    using (var context = new StokTakipContext())
        //    {
        //        var satinAlma = context.SatinAlmas
        //            .FirstOrDefault(x => x.StokKartiId == _secilenUrun.StokKartiId);
        //        if (satinAlma != null)
        //        {
        //            //satinAlma.GelenMiktar = (satinAlma.GelenMiktar ?? 0) + artisMiktari;
        //            satinAlma.GelenMiktar += artisMiktari;

        //        }

        //        var stokDurum = context.StokDurumus
        //            .FirstOrDefault(x => x.StokKartiId == _secilenUrun.StokKartiId);
        //        if (stokDurum != null)
        //        {
        //            stokDurum.SerbestMiktar += artisMiktari;
        //        }

        //        context.SaveChanges();
        //    }

        //    MessageBox.Show("Stok başarıyla artırıldı!");

        //    // UI'da durum güncellemesi sadece Form üzerinden
        //    MekanikForm_Load(null, null);

        //}




        //private void btnMStokArttir_Click(object sender, EventArgs e)
        //{
        //    if (!int.TryParse(tBMArtirMiktar.Text, out int artisMiktari) || artisMiktari <= 0)
        //    {
        //        MessageBox.Show("Lütfen geçerli bir miktar girin.");
        //        return;
        //    }

        //    using (var context = new StokTakipContext())
        //    {
        //        var satinAlma = context.SatinAlmas
        //            .FirstOrDefault(x => x.StokKartiId == _secilenUrun.StokKartiId);

        //        if (satinAlma == null)
        //        {
        //            MessageBox.Show("Bu ürüne ait satınalma kaydı bulunamadı!");
        //            return;
        //        }

        //        int mevcutGelen = satinAlma.GelenMiktar;
        //        //burda sürekli hata alıyorum
        //        if (mevcutGelen >= satinAlma.Miktar)
        //        {
        //            MessageBox.Show("Bu ürünün tüm siparişi sisteme girilmiş. Yeni giriş yapılamaz.");
        //            return;
        //        }
        //        //burası elektirikte bjyle değil
        //        int toplam = mevcutGelen + artisMiktari;

        //        if (toplam > satinAlma.Miktar)
        //        {
        //            MessageBox.Show($"Girilen miktar fazla! Satınalma miktarı: {satinAlma.Miktar}, " +
        //                             $"şu ana kadar gelen: {mevcutGelen}, " +
        //                             $"eklenmek istenen: {artisMiktari}");
        //            return;
        //        }

        //        // 🔹 Maksimum stok kontrolü
        //        int yeniStok = _secilenUrun.StokMiktari + artisMiktari;
        //        if (yeniStok > _secilenUrun.MaxStok)
        //        {
        //            MessageBox.Show($"Uyarı: Maksimum stok miktarı {_secilenUrun.MaxStok}. " +
        //                            $"Şu an stok: {_secilenUrun.StokMiktari}, girilen miktar: {artisMiktari}");
        //            return;
        //        }

        //        // 🔹 Değerleri güncelle
        //        satinAlma.GelenMiktar = toplam;

        //        // 🔹 Stok durumunu al
        //        if (_durum != null)
        //        {
        //            _durum.SerbestMiktar += artisMiktari;
        //        }

        //        //// 🔹 Kullanılabilir (serbest) miktar azaldıysa ve stokta yer varsa giriş yapılabilir
        //        //if (stokDurum.SerbestMiktar < _secilenUrun.MaxStok)
        //        //{
        //        //    int fark = _secilenUrun.MaxStok - stoktaMevcut;

        //        //    // Eğer fark kadar yer varsa o kadar giriş yapılabilir
        //        //    if (fark > 0 && yeniStok > _secilenUrun.MaxStok)
        //        //    {
        //        //        artisMiktari = fark;
        //        //        yeniStok = _secilenUrun.MaxStok;
        //        //        MessageBox.Show($"Maksimum stok kapasitesine ulaşıldı. Sadece {fark} adet giriş yapıldı, kalan miktar eklenmedi.");
        //        //    }

        //        //    // 🔹 Serbest miktar azaldıysa, ekleme yapılabilir
        //        //    if (stokDurum.SerbestMiktar < _secilenUrun.StokMiktari)
        //        //    {
        //        //        int telafi = _secilenUrun.StokMiktari - stokDurum.SerbestMiktar;
        //        //        stokDurum.SerbestMiktar += telafi;
        //        //    }
        //        //}
        //        //else if (yeniStok > _secilenUrun.MaxStok)
        //        //{
        //        //    int fark = _secilenUrun.MaxStok - stoktaMevcut;
        //        //    if (fark <= 0)
        //        //    {
        //        //        MessageBox.Show($"Stok zaten maksimum seviyede ({_secilenUrun.MaxStok}). Yeni giriş yapılamaz.");
        //        //        return;
        //        //    }

        //        //    artisMiktari = fark;
        //        //    yeniStok = _secilenUrun.MaxStok;
        //        //    MessageBox.Show($"Maksimum stok kapasitesine ulaşıldı. Sadece {fark} adet giriş yapıldı, kalan miktar eklenmedi.");
        //        //}

        //        //// 🔹 Değerleri güncelle
        //        //satinAlma.GelenMiktar = mevcutGelen + artisMiktari;
        //        //stokDurum.SerbestMiktar += artisMiktari;
        //        //_secilenUrun.StokMiktari = yeniStok;

        //        context.SaveChanges();
        //    }

        //    MessageBox.Show("Stok başarıyla artırıldı!");
        //    MekanikForm_Load(null, null);
        //}


        //private void btnMStokArttir_Click(object sender, EventArgs e)
        //{
        //    if (!int.TryParse(tBMArtirMiktar.Text, out int artisMiktari) || artisMiktari <= 0)
        //    {
        //        MessageBox.Show("Lütfen geçerli bir miktar girin.");
        //        return;
        //    }

        //    using (var context = new StokTakipContext())
        //    {
        //        // 🔹 1. Satınalma kaydını al
        //        var satinAlma = context.SatinAlmas
        //            .FirstOrDefault(x => x.StokKartiId == _secilenUrun.StokKartiId);

        //        if (satinAlma == null)
        //        {
        //            MessageBox.Show("Bu ürüne ait satınalma kaydı bulunamadı!");
        //            return;
        //        }

        //        int mevcutGelen = satinAlma.GelenMiktar;

        //        // 🔹 2. Yeni gelen miktar toplamı
        //        int toplam = mevcutGelen + artisMiktari;

        //        // 🔹 3. Satınalma miktarını geçmesin
        //        if (toplam > satinAlma.Miktar)
        //        {
        //            MessageBox.Show($"Girilen miktar fazla! Satınalma miktarı: {satinAlma.Miktar}, " +
        //                            $"şu ana kadar gelen: {mevcutGelen}, " +
        //                            $"eklenmek istenen: {artisMiktari}");
        //            return;
        //        }

        //        // 🔹 4. Maksimum stok kontrolü
        //        int yeniStok = _secilenUrun.StokMiktari + artisMiktari;
        //        if (yeniStok > _secilenUrun.MaxStok)
        //        {
        //            MessageBox.Show($"Uyarı: Maksimum stok miktarı {_secilenUrun.MaxStok}. " +
        //                            $"Şu an stok: {_secilenUrun.StokMiktari}, girilen miktar: {artisMiktari}");
        //            return;
        //        }

        //        // 🔹 5. Satınalma güncelle
        //        satinAlma.GelenMiktar = toplam;

        //        // 🔹 6. Stok durumunu güncelle
        //        var stokDurum = context.StokDurumus
        //            .FirstOrDefault(s => s.StokKartiId == _secilenUrun.StokKartiId);

        //        if (stokDurum != null)
        //        {
        //            stokDurum.SerbestMiktar += artisMiktari;  // kullanılabilir miktar artar
        //                                                      // Kullanılamaz (bloke) miktar sabit kalır
        //        }

        //        // 🔹 7. Stok kartındaki toplam miktarı da artır
        //        var stokKart = context.StokKartis
        //            .FirstOrDefault(s => s.StokKartiId == _secilenUrun.StokKartiId);

        //        if (stokKart != null)
        //        {
        //            stokKart.StokMiktari += artisMiktari;
        //        }

        //        // 🔹 8. Kaydet
        //        context.SaveChanges();
        //    }

        //    MessageBox.Show("Stok başarıyla artırıldı!");
        //    MekanikForm_Load(null, null);
        //}


        private void btnMStokArttir_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tBMArtirMiktar.Text, out int artisMiktari) || artisMiktari <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir miktar girin.");
                return;
            }

            using (var context = new StokTakipContext())
            {
                int urunId = _secilenUrun.StokKartiId;

                var satinAlma = context.SatinAlmas
                    .Where(x => x.StokKartiId == urunId)
                    .OrderByDescending(x => x.SiparisTarihi)
                    .FirstOrDefault();

                if (satinAlma == null)
                {
                    MessageBox.Show("Bu ürüne ait satınalma kaydı bulunamadı!");
                    return;
                }

                var stokDurum = context.StokDurumus.FirstOrDefault(x => x.StokKartiId == urunId);
                var stokKarti = context.StokKartis.FirstOrDefault(x => x.StokKartiId == urunId);

                if (stokDurum == null || stokKarti == null)
                {
                    MessageBox.Show("Stok bilgileri bulunamadı!");
                    return;
                }

                // 🔹 1. Satınalma kontrolü
                if (satinAlma.GelenMiktar + artisMiktari > satinAlma.Miktar)
                {
                    MessageBox.Show($"Gelen miktar sipariş verilen miktarı aşamaz! (Sipariş: {satinAlma.Miktar}, Gelen: {satinAlma.GelenMiktar})");
                    return;
                }

                // 🔹 2. Maksimum stok kontrolü
                int yeniStok = stokKarti.StokMiktari + artisMiktari;

                if (yeniStok >= _secilenUrun.MaxStok - 3 && yeniStok < _secilenUrun.MaxStok)
                {
                    MessageBox.Show("Uyarı: Maksimum stoğa 3-4 ürün kaldı!");
                }

                if (yeniStok > _secilenUrun.MaxStok)
                {
                    var onay = MessageBox.Show(
                        $"Maksimum stoğu ({_secilenUrun.MaxStok}) aşıyorsunuz. Yine de eklemek istiyor musunuz?",
                        "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (onay == DialogResult.No)
                        return;
                }

                // 🔹 3. Güncellemeler
                satinAlma.GelenMiktar += artisMiktari;
                stokDurum.SerbestMiktar += artisMiktari;
                stokKarti.StokMiktari += artisMiktari;

                context.SaveChanges();
            }

            MessageBox.Show("Stok başarıyla artırıldı!");
            MekanikForm_Load(null, null);
        }


    }
}


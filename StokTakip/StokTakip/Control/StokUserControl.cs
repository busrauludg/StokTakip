using StokTakip.Data;
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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class StokUserControl : UserControl
    {
        private readonly StokEkleServices _stokEkleServices;

        public event EventHandler GeriClick;
        // Panel içindeki hesaplama sonucunu saklamak için field ✅
        private decimal _hesaplananToplamMaliyet = 0;

        public StokUserControl()
        {
            InitializeComponent();
            // DbContext ve repository oluştur
            var context = new StokTakipContext();
            var repository = new AnaSayfaRepository(context);

            // Service'i repository ile başlat
            _stokEkleServices = new StokEkleServices(repository);
        }

        // ✅ Yeni metot: toplam maliyeti hesaplayan
        public decimal HesaplaToplamMaliyet(int miktar, decimal birimFiyat, decimal kur)
        {
            return miktar * birimFiyat * kur;
        }
        private void nUDMinStok_ValueChanged(object sender, EventArgs e)
        {
            nUDMinStok.Maximum = 10000;

        }

        private void nUDMaxStok_ValueChanged(object sender, EventArgs e)
        {
            nUDMaxStok.Maximum = 10000;
        }

        private void nUDSMiktar_ValueChanged(object sender, EventArgs e)
        {
            nUDSMiktar.Maximum = 10000;
        }

        //private void nUDHareketM_ValueChanged(object sender, EventArgs e)
        //{
        //    nUDHareketM.Maximum = 10000;
        //}

        private void nUDSerbestM_ValueChanged(object sender, EventArgs e)
        {
            nUDSerbestM.Maximum = 10000;
        }


        private void btnHesapla_Click(object sender, EventArgs e)
        {
            // Miktar
            if (!int.TryParse(tBStnAlMiktar.Text.ToString(), out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir miktar girin.");
                return;
            }

            // Birim fiyat
            if (!decimal.TryParse(tBStnAlmaBirim.Text, out decimal birimFiyat) || birimFiyat <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir birim fiyat girin.");
                return;
            }

            // Kur
            decimal kur = 1; // default TL
            if (cBParaBirimi.SelectedItem.ToString() != "TL")
            {
                if (!decimal.TryParse(tBStnAlmaKur.Text, out kur) || kur <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir kur değeri girin.");
                    return;
                }
            }

            ////// Toplam hesaplama
            //decimal toplamFiyat = miktar * birimFiyat * kur;
            //tBTopTutar.Text = toplamFiyat.ToString("N2");/*cBParaBirimi.SelectedItem.ToString();*/

            // 🔹 Metodu kullanarak hesaplama
            _hesaplananToplamMaliyet = HesaplaToplamMaliyet(miktar, birimFiyat, kur);
            tBTopTutar.Text = _hesaplananToplamMaliyet.ToString("N2");


        }
        private void StokUserControl_Load(object sender, EventArgs e)
        {
            // Para birimi comboBox'ını doldur
            cBParaBirimi.Items.Add("TL");
            cBParaBirimi.Items.Add("USD");
            cBParaBirimi.Items.Add("EUR");
            cBParaBirimi.SelectedIndex = 0; // default TL

            // Para birimi seçimi değiştiğinde kur textbox kontrolü
            cBParaBirimi.SelectedIndexChanged += (s, ev) =>
            {
                if (cBParaBirimi.SelectedItem.ToString() == "TL")
                {
                    tBStnAlmaKur.Text = "1";
                    tBStnAlmaKur.Enabled = false;
                }
                else
                {
                    tBStnAlmaKur.Text = "";
                    tBStnAlmaKur.Enabled = true;
                }
            };

            //// Giriş yapan personelin adı otomatik doldurulsun
            //tBPersonelId.Text = GirisYapanKullanici.Ad;
            //tBStnAlmaPersonelId.Text = GirisYapanKullanici.Ad;


            // Giriş yapan personelin adı otomatik doldurulsun
            tBPersonelId.Text = GirisYapanKullanici.Ad;
            tBStnAlmaPersonelId.Text = GirisYapanKullanici.Ad;

            // Kullanıcı adı artık değiştirilemez olsun
            tBPersonelId.ReadOnly = true;
            tBStnAlmaPersonelId.ReadOnly = true;

            //cBProjeSec.DataSource = _stokEkleServices.GetProjeler();
            //cBProjeSec.DisplayMember = "ProjeAdi";
            //cBProjeSec.ValueMember = "ProjeId";


        }
        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            // int projeId = cBProjeSec.SelectedValue != null ? (int)cBProjeSec.SelectedValue : 0;


            // sonra kaydet.ViewModel içinde ata

            //int personelId = 0;
            //int.TryParse(tBPersonelId.Text, out personelId);

            // Personel ID bulma

            // Zorunlu alan kontrolü
            List<string> eksikAlanlar = new List<string>();

            if (string.IsNullOrWhiteSpace(tBUrunAdi.Text)) eksikAlanlar.Add("Ürün Adı");
            if (string.IsNullOrWhiteSpace(tBStokKodu.Text)) eksikAlanlar.Add("Stok Kodu");
            if (!rBElektrik.Checked && !rBMekanik.Checked) eksikAlanlar.Add("Grup Seçimi");
            if (string.IsNullOrWhiteSpace(tBStokBirimi.Text)) eksikAlanlar.Add("Stok Birimi");
            if (string.IsNullOrWhiteSpace(tBFirmaAdi.Text)) eksikAlanlar.Add("Firma Adı");
            if (string.IsNullOrWhiteSpace(tBFirmaKodu.Text)) eksikAlanlar.Add("Firma Kodu");

            //if (string.IsNullOrWhiteSpace(tBStnAlmaCari.Text)) eksikAlanlar.Add("Cari Adı");
            if (string.IsNullOrWhiteSpace(tBStnAlMiktar.Text)) eksikAlanlar.Add("Satın Alma Miktarı");
            if (string.IsNullOrWhiteSpace(cBParaBirimi.Text)) eksikAlanlar.Add("Para Birimi");
            if (string.IsNullOrWhiteSpace(tBStnAlmaBirim.Text)) eksikAlanlar.Add("Birim Fiyat");
            if (string.IsNullOrWhiteSpace(tBStnAlmaKur.Text)) eksikAlanlar.Add("Kur");


            if (string.IsNullOrWhiteSpace(tBDepoAdi.Text)) eksikAlanlar.Add("Depo Adı");
            if (string.IsNullOrWhiteSpace(tBDepoAdresi.Text)) eksikAlanlar.Add("Depo Adresi");
            if (string.IsNullOrWhiteSpace(tBStnAlmaCari.Text)) eksikAlanlar.Add("Cari Adı");
            if (string.IsNullOrWhiteSpace(cBParaBirimi.Text)) eksikAlanlar.Add("Para Birimi");

            if (eksikAlanlar.Count > 0)
            {
                string mesaj = "Aşağıdaki alanlar boş bırakılamaz:\n\n" +
                               string.Join("\n", eksikAlanlar);
                MessageBox.Show(mesaj, "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Satın Alma Miktarı (tam sayı)
            if (!int.TryParse(tBStnAlMiktar.Text, out int satinalmaMiktari) || satinalmaMiktari <= 0)
            {
                MessageBox.Show("Satın Alma Miktarı için sadece pozitif tam sayı girin!");
                return;
            }

            //// Birim Fiyat (decimal, virgül kabul)
            //if (!decimal.TryParse(tBStnAlmaBirim.Text, NumberStyles.Number, CultureInfo.GetCultureInfo("tr-TR"), out decimal birimFiyat) || birimFiyat <= 0)
            //{
            //    MessageBox.Show("Birim Fiyat için geçerli bir sayı girin (örn: 12,50)!");
            //    return;
            //}

            //// Kur (decimal, virgül kabul)
            //if (!decimal.TryParse(tBStnAlmaKur.Text, NumberStyles.Number, CultureInfo.GetCultureInfo("tr-TR"), out decimal kur) || kur <= 0)
            //{
            //    MessageBox.Show("Kur için geçerli bir sayı girin (örn: 1,25)!");
            //    return;
            //}


            string birimText = tBStnAlmaBirim.Text.Trim();

            // Nokta varsa direkt reddet
            if (birimText.Contains("."))
            {
                MessageBox.Show("Birim fiyat '.' değil ',' ile yazılmalı!");
                return;
            }

            // Virgülden önceki ve sonraki kısımları ayırıyoruz
            string[] parts = birimText.Split(',');

            // Tam sayı kısmı > 3 hane ise reddet
            if (parts[0].Length == 0 || parts[0].Length > 3)
            {
                MessageBox.Show("Birim fiyat 0 ile 999 arasında olmalı!");
                return;
            }

            // Virgülden sonra fazlalık varsa reddet
            if (parts.Length == 2 && parts[1].Length > 2)
            {
                MessageBox.Show("Virgülden sonra en fazla 2 basamak olabilir!");
                return;
            }

            // 2'den fazla virgül varsa reddet
            if (parts.Length > 2)
            {
                MessageBox.Show("Geçersiz sayı formatı!");
                return;
            }

            // Artık güvenle parse edebiliriz
            decimal birimFiyat = decimal.Parse(birimText.Replace(',', '.'),
                                               CultureInfo.InvariantCulture);


            string kurText = tBStnAlmaKur.Text.Trim();

            if (kurText.Contains("."))
            {
                MessageBox.Show("Kur '.' değil ',' ile yazılmalı!");
                return;
            }

            string[] p = kurText.Split(',');

            if (p[0].Length == 0 || p[0].Length > 3)
            {
                MessageBox.Show("Kur 0 ile 999 arasında olmalı!");
                return;
            }

            if (p.Length == 2 && p[1].Length > 2)
            {
                MessageBox.Show("Virgülden sonra en fazla 2 basamak olabilir!");
                return;
            }

            if (p.Length > 2)
            {
                MessageBox.Show("Geçersiz sayı formatı!");
                return;
            }

            decimal kur = decimal.Parse(kurText.Replace(',', '.'),
                                         CultureInfo.InvariantCulture);




            // Diğer validasyonlar
            int minStok = (int)nUDMinStok.Value;
            int maxStok = (int)nUDMaxStok.Value;
            int stokMiktari = (int)nUDSMiktar.Value;
            int serbestMiktar = (int)nUDSerbestM.Value;
            int blokeMiktar = 0;
            int.TryParse(tBBlokeM.Text, out blokeMiktar);

            if (minStok > maxStok)
            {
                MessageBox.Show("Minimum stok, maksimum stoktan büyük olamaz!");
                return;
            }

            if (stokMiktari < minStok || stokMiktari > maxStok)
            {
                MessageBox.Show("Stok miktarı min ve max stok aralığında olmalıdır!");
                return;
            }

            if (serbestMiktar + blokeMiktar > stokMiktari)
            {
                MessageBox.Show("Kullanılabilir ve kullanılan miktarın toplamı stok miktarını aşamaz!");
                return;
            }

            int personelId = 0;
            using (var context = new StokTakipContext())
            {
                //var personel = context.Personels
                //    .FirstOrDefault(p => p.Ad == tBPersonelId.Text.Trim()
                //             || p.Ad == tBStnAlmaPersonelId.Text.Trim());
                //if (personel != null)
                //    personelId = personel.PersonelId;
                //else
                //{
                //    MessageBox.Show("Girilen ada ait personel bulunamadı!");
                //    return;
                //}


                var personel = context.Personels
                     .FirstOrDefault(p => p.Ad == GirisYapanKullanici.Ad);
                if (personel != null)
                    personelId = personel.PersonelId;
                else
                {
                    MessageBox.Show("Giriş yapan kullanıcı veritabanında bulunamadı!");
                    return;
                }
            }
            int satinalmaMiktariK = 0;
            int.TryParse(tBStnAlMiktar.Text, out satinalmaMiktari);


            int birimFiyatK = 0;
            int.TryParse(tBStnAlmaBirim.Text, out birimFiyatK);

            int kurK = 0;
            int.TryParse(tBStnAlmaKur.Text, out kurK);

            decimal toplamMaliyet = 0;
            decimal.TryParse(tBTopTutar.Text, out toplamMaliyet);

            // ViewModel oluşturma kodundan hemen önce kontrol geliyor

            using (var context = new StokTakipContext())
            {
                string stokKodu = tBStokKodu.Text.Trim();

                bool urunZatenVarMi = context.StokKartis
                    .Any(x => x.StokKodu == stokKodu);

                if (urunZatenVarMi)
                {
                    MessageBox.Show(
                        "Bu stok koduna sahip ürün zaten sistemde kayıtlı!\n\n" +
                        "Aynı ürünü tekrar ekleyemezsiniz.",
                        "Hata",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            var kaydet = new StokEkleViewModel
            {
                UrunAdi = tBUrunAdi.Text,
                StokKodu = tBStokKodu.Text,
                GrupId = rBElektrik.Checked ? 1 : 2,
                StokBirimi = tBStokBirimi.Text,
                MinStok = (int)nUDMinStok.Value,
                MaxStok = (int)nUDMaxStok.Value,
                StokMiktari = (int)nUDSMiktar.Value,
                DepoAdresi = tBDepoAdresi.Text,
                ResimYolu = tBResimYolu.Text,
                KayitTarihi = DateTime.Now,
                FirmaAdi = tBFirmaAdi.Text,
                FirmaKodu = tBFirmaKodu.Text,
                PersonelId = personelId,
                Aciklama = tBAciklama.Text,

                DepoAdi = tBDepoAdi.Text,
                SerbestMiktar = (int)nUDSerbestM.Value,
                BlokeMiktar = tBBlokeM.Text,

                //stok hareketi 
                //ProjeId = projeId,
                //PersonelIdSh = prsonelIdSh,
                //Tip = rBTip.Checked ? "Girdi" : "Cikti",
                //Miktar = (int)nUDHareketM.Value,
                //Tarih = DateTime.Now,
                //sHAciklama = tBShAciklama.Text,

                //Satın Alma
                //StokKaritId= tBSKId.Text,// bunu hatası stokekle ile aynı yerde ekliyoruz buun stokkartınıeklerkenıd de ekliyor ama bu satınalmayıda aynı tabloda eklemem lazım napıcaz
                SiparisTarihi = DateTime.Now,
                StnAlmaMiktar = satinalmaMiktari, //int parse yap
                CariAdi = tBStnAlmaCari.Text,
                BirimFiyat = birimFiyat,
                Kur = kur,
                ToplamMaliyet = toplamMaliyet, // Panel içinden alınan değer ✅
                ParaBirimi = cBParaBirimi.Text,
                StnAlmaAciklama = tBStnAlmaAciklama.Text,
                StnAlmaPersonelId = personelId,


            };
            try
            {
                _stokEkleServices.StokEkle(kaydet);
                MessageBox.Show("Kayıt başarılı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.InnerException?.Message ?? ex.Message);
            }


        }

        private void btnGozAta_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tBResimYolu.Text = ofd.FileName;
                // PictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }


        private void btnGeri_Click(object sender, EventArgs e)
        {

            GeriClick?.Invoke(this, EventArgs.Empty);
        }
    }
}


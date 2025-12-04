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

        private decimal _hesaplananToplamMaliyet = 0;

        public StokUserControl()
        {
            InitializeComponent();
            var context = new StokTakipContext();
            var repository = new AnaSayfaRepository(context);

            _stokEkleServices = new StokEkleServices(repository);
        }

        public decimal HesaplaToplamMaliyet(int miktar, decimal birimFiyat, decimal kur)
        {
            return miktar * birimFiyat * kur;
        }
      
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tBStnAlMiktar.Text.ToString(), out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir miktar girin.");
                return;
            }

            if (!decimal.TryParse(tBStnAlmaBirim.Text, out decimal birimFiyat) || birimFiyat <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir birim fiyat girin.");
                return;
            }

            decimal kur = 1;
            if (cBParaBirimi.SelectedItem.ToString() != "TL")
            {
                if (!decimal.TryParse(tBStnAlmaKur.Text, out kur) || kur <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir kur değeri girin.");
                    return;
                }
            }

            _hesaplananToplamMaliyet = HesaplaToplamMaliyet(miktar, birimFiyat, kur);
            tBTopTutar.Text = _hesaplananToplamMaliyet.ToString("N2");

        }
        private void StokUserControl_Load(object sender, EventArgs e)
        {
            cBParaBirimi.Items.Add("TL");
            cBParaBirimi.Items.Add("USD");
            cBParaBirimi.Items.Add("EUR");
            cBParaBirimi.SelectedIndex = -1;

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

            tBPersonelId.Text = GirisYapanKullanici.Ad;
            tBStnAlmaPersonelId.Text = GirisYapanKullanici.Ad;

            tBPersonelId.ReadOnly = true;
            tBStnAlmaPersonelId.ReadOnly = true;

        }
        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            List<string> eksikAlanlar = new List<string>();

            if (string.IsNullOrWhiteSpace(tBUrunAdi.Text)) eksikAlanlar.Add("Ürün Adı");
            if (string.IsNullOrWhiteSpace(tBStokKodu.Text)) eksikAlanlar.Add("Stok Kodu");
            if (!rBElektrik.Checked && !rBMekanik.Checked) eksikAlanlar.Add("Grup Seçimi");
            if (string.IsNullOrWhiteSpace(tBStokBirimi.Text)) eksikAlanlar.Add("Stok Birimi");
            if (string.IsNullOrWhiteSpace(tBFirmaAdi.Text)) eksikAlanlar.Add("Firma Adı");
            if (string.IsNullOrWhiteSpace(tBFirmaKodu.Text)) eksikAlanlar.Add("Firma Kodu");

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

            if (!int.TryParse(tBStnAlMiktar.Text, out int satinalmaMiktari) || satinalmaMiktari <= 0)
            {
                MessageBox.Show("Satın Alma Miktarı için sadece pozitif tam sayı girin!");
                return;
            }

            string birimText = tBStnAlmaBirim.Text.Trim();

            if (birimText.Contains("."))
            {
                MessageBox.Show("Birim fiyat '.' değil ',' ile yazılmalı!");
                return;
            }

            string[] parts = birimText.Split(',');

            if (parts[0].Length == 0 || parts[0].Length > 3)
            {
                MessageBox.Show("Birim fiyat 0 ile 999 arasında olmalı!");
                return;
            }

            if (parts.Length == 2 && parts[1].Length > 2)
            {
                MessageBox.Show("Virgülden sonra en fazla 2 basamak olabilir!");
                return;
            }

            if (parts.Length > 2)
            {
                MessageBox.Show("Geçersiz sayı formatı!");
                return;
            }

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
                SiparisTarihi = DateTime.Now,
                StnAlmaMiktar = satinalmaMiktari,
                CariAdi = tBStnAlmaCari.Text,
                BirimFiyat = birimFiyat,
                Kur = kur,
                ToplamMaliyet = toplamMaliyet, 
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

            int maxDeger = 10000;
            nUDMinStok.Maximum = maxDeger;
            nUDMaxStok.Maximum = maxDeger;
            nUDSMiktar.Maximum = maxDeger;
            nUDSerbestM.Maximum = maxDeger;

        }

        private void btnGozAta_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tBResimYolu.Text = ofd.FileName;
            }
        }


        private void btnGeri_Click(object sender, EventArgs e)
        {

            GeriClick?.Invoke(this, EventArgs.Empty);
        }
    }
}


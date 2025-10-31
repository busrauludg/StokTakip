using StokTakip.Data;
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

            //// Toplam hesaplama
            decimal toplamFiyat = miktar * birimFiyat * kur;
            tBTopTutar.Text = toplamFiyat.ToString("N2");/*cBParaBirimi.SelectedItem.ToString();*/

  

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
                var personel = context.Personels
                    .FirstOrDefault(p => p.Ad == tBPersonelId.Text.Trim()
                             || p.Ad == tBStnAlmaPersonelId.Text.Trim());
                if (personel != null)
                    personelId = personel.PersonelId;
                else
                {
                    MessageBox.Show("Girilen ada ait personel bulunamadı!");
                    return;
                }
            }
            int satinalmaMiktari = 0;
            int.TryParse(tBStnAlMiktar.Text, out satinalmaMiktari);


            int birimFiyat = 0;
            int.TryParse(tBStnAlmaBirim.Text, out birimFiyat);

            int kur = 0;
            int.TryParse(tBStnAlmaKur.Text, out kur);

            decimal toplamMaliyet = 0;
            decimal.TryParse(tBTopTutar.Text, out toplamMaliyet);



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


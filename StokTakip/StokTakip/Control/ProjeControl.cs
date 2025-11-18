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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace StokTakip
{
    //sol tarafta proje ekleme işlemi yapılırken sağ tarafta projeyi veritabanından cekip projeye ürün ekle kısmı ile
    //stokdetay sayfasına veri ekleniyor akitf proje ihtiyacı kısmı 
    public partial class ProjeControl : UserControl
    {
        private readonly ProjeServices _projeServices;
        public ProjeControl()
        {
            InitializeComponent();
            var context = new StokTakipContext();
            var repository = new AnaSayfaRepository(context);
            _projeServices = new ProjeServices(repository);
        }

        private void btnProjeEkle_Click(object sender, EventArgs e)
        {
            //int personelId = 0;


            //using (var context = new StokTakipContext())
            //{
            //    var personel = context.Personels.
            //        FirstOrDefault(p => p.Ad == tBPersonelId.Text.Trim());
            //    if (personel != null)
            //        personelId = personel.PersonelId;
            //    else
            //    {
            //        MessageBox.Show("Girilen ada ait personel bulunamadı!");
            //        return;
            //    }
            //}


            //var projeEkle = new ProjeEkleViewModel
            //{
            //    ProjeAdi = tBProjeAdi.Text,
            //    //BaslangicTarihi = DateTime.Now,
            //   // BitisTarihi = dTPBitisTarihi.Value,

            //    BaslangicTarihi=dTPBaslangic.MinDate = DateTime.Today, // Bugünden önce seçilemez
            //    BitisTarihi=dTPBitisTarihi.MinDate = DateTime.Today.AddDays(1), // Bitiş başlangıçtan en az 1 gün sonra olmalı

            //    PersonelId = personelId,
            //    Durum = cBDurum.SelectedItem.ToString() == "Aktif",
            //    Aciklama = tBAciklama.Text,

            //};
            //try
            //{
            //    _projeServices.ProjeEkle(projeEkle);
            //    MessageBox.Show("Proje Ekleme");
            //}
            //catch
            //{
            //    MessageBox.Show("Kayit ekleme başarısız oldu");
            //}


            int personelId = 0;

            using (var context = new StokTakipContext())
            {
                var personel = context.Personels.
                    FirstOrDefault(p => p.Ad == tBPersonelId.Text.Trim());
                if (personel != null)
                    personelId = personel.PersonelId;
                else
                {
                    MessageBox.Show("Girilen ada ait personel bulunamadı!");
                    return;
                }
            }

            // ⬇⬇⬇ EKLENECEK YER BURASI ⬇⬇⬇
            using (var context = new StokTakipContext())
            {
                bool projeVarMi = context.Projes
                    .Any(p => p.ProjeAdi.ToLower() == tBProjeAdi.Text.Trim().ToLower());

                if (projeVarMi)
                {
                    MessageBox.Show("Bu proje adı zaten mevcut! Lütfen farklı bir proje adı girin.");
                    return;
                }
            }
            // ⬆⬆⬆ EKLENECEK YER BURASI ⬆⬆⬆


            // ✔ Kontrolden sonra proje ekleme işlemi
            var projeEkle = new ProjeEkleViewModel
            {
                ProjeAdi = tBProjeAdi.Text,

                BaslangicTarihi = dTPBaslangic.MinDate = DateTime.Today,
                BitisTarihi = dTPBitisTarihi.MinDate = DateTime.Today.AddDays(1),

                PersonelId = personelId,
                Durum = cBDurum.SelectedItem.ToString() == "Aktif",
                Aciklama = tBAciklama.Text,
            };

            try
            {
                _projeServices.ProjeEkle(projeEkle);
                MessageBox.Show("Proje başarıyla eklendi!");
            }
            catch
            {
                MessageBox.Show("Kayıt ekleme başarısız oldu");
            }
        }

        private void ProjeControl_Load(object sender, EventArgs e)
        {
            cBDurum.Items.AddRange(new string[] { "Aktif", "Pasif" });

            // Tarihler için MinDate
            dTPBaslangic.MinDate = DateTime.Today;
            dTPBitisTarihi.MinDate = DateTime.Today.AddDays(1);

            // 👇 Personel textbox sadece okunabilir ve değeri atanıyor
            tBPersonelId.ReadOnly = true;
            tBPersonelId.Text = GirisYapanKullanici.Ad;

            using (var context = new StokTakipContext())
            {
                cBProjSec.DataSource = context.Projes
                      .Where(p => p.PasifMi) // sadece PasifMi = true olanlar
                      .OrderBy(p => p.ProjeAdi)
                      .ToList();
                cBProjSec.DisplayMember = "ProjeAdi";
                cBProjSec.ValueMember = "ProjeId";
                cBProjSec.SelectedIndex = -1;

                //cBProjSec.DisplayMember = "ProjeAdi";
                //cBProjSec.ValueMember = "ProjeId";
                //cBProjSec.SelectedIndex = -1;

                //// Projeleri getir
                //cBProjSec.DataSource = context.Projes.ToList();
                //cBProjSec.DisplayMember = "ProjeAdi";
                //cBProjSec.ValueMember = "ProjeId";

                // Ürünleri getir
                //cBUrunSec.DataSource = context.StokKartis.ToList();
                //cBUrunSec.DisplayMember = "UrunAdi";
                //cBUrunSec.ValueMember = "StokKartiId";

                cBUrunSec.DataSource = context.StokKartis
                               .Where(u => u.AktifMi) // sadece aktif ürünler
                               .ToList();
                cBUrunSec.DisplayMember = "UrunAdi";
                cBUrunSec.ValueMember = "StokKartiId";
                cBUrunSec.SelectedIndex = -1;

                cBProjSec.SelectedIndex = -1;
               // cBUrunSec.SelectedIndex = -1;


                lVSecilenUrunler.View = View.Details;
                lVSecilenUrunler.Columns.Add("Ürün Adı", 150);
                lVSecilenUrunler.Columns.Add("Miktar", 70);


            }
            ProjeSecComboDoldur();

        }
       


        private void btnUrunEkleListe_Click(object sender, EventArgs e)
        {
            //if (cBProjSec.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Lütfen bir proje seçin!");
            //    return;
            //}

            //int stokId = (int)cBUrunSec.SelectedValue;
            //int secilenMiktar = (int)nUDMiktarSec.Value;
            ////5.11
            //int projeId = (int)cBProjSec.SelectedValue;

            //using (var context = new StokTakipContext())
            //{
            //    var stok = context.StokDurumus.FirstOrDefault(s => s.StokKartiId == stokId);
            //    var stokKart = context.StokKartis.FirstOrDefault(sk => sk.StokKartiId == stokId);

            //    if (stok == null || stokKart == null)
            //    {
            //        MessageBox.Show("Seçilen ürün stokta bulunamadı!");
            //        return;
            //    }

            //    // Liste üzerindeki toplam miktarı kontrol et
            //    int listeToplam = 0;
            //    ListViewItem mevcutItem = null;//5.11
            //    foreach (ListViewItem i in lVSecilenUrunler.Items)
            //    {
            //        //    if ((int)i.Tag == stokId)
            //        //        listeToplam += int.Parse(i.SubItems[1].Text);

            //        var tagData = (Tuple<int, int>)i.Tag;
            //        int tagStokId = tagData.Item1;
            //        int tagProjeId = tagData.Item2;

            //        if (tagStokId == stokId && tagProjeId == projeId)
            //        {
            //            mevcutItem = i;
            //            listeToplam += int.Parse(i.SubItems[1].Text);
            //        }
            //    }

            //    int kalanMiktar = stok.SerbestMiktar - listeToplam;
            //    if (secilenMiktar > kalanMiktar)
            //    {
            //        MessageBox.Show($"Girilen miktar, kalan kullanılabilir miktardan fazla! Kalan: {kalanMiktar}");
            //        return;
            //    }
            //    if (mevcutItem != null)
            //    {
            //        int mevcutMiktar = int.Parse(mevcutItem.SubItems[1].Text);
            //        mevcutItem.SubItems[1].Text = (mevcutMiktar + secilenMiktar).ToString();
            //    }
            //    else
            //    {
            //        // Listeye ekle
            //        ListViewItem item = new ListViewItem(cBUrunSec.Text);
            //            item.SubItems.Add(secilenMiktar.ToString());
            //            item.Tag = stokId;
            //            lVSecilenUrunler.Items.Add(item);


            //    }


            //    // 🔹 Kalan miktarı ve min stok uyarısı
            //    int yeniKalan = kalanMiktar - secilenMiktar;
            //    string mesaj = $"{cBUrunSec.Text} için kalan miktar: {yeniKalan}";
            //    if (yeniKalan < stokKart.MinStok)
            //    {
            //        mesaj += $"\n⚠ Uyarı: Minimum stoğun altına düştü! (MinStok: {stokKart.MinStok})";
            //    }

            //    MessageBox.Show(mesaj);
            //}

            if (cBProjSec.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir proje seçin!");
                return;
            }

            int stokId = (int)cBUrunSec.SelectedValue;
            int secilenMiktar = (int)nUDMiktarSec.Value;
            int projeId = (int)cBProjSec.SelectedValue;

            using (var context = new StokTakipContext())
            {
                var stok = context.StokDurumus.FirstOrDefault(s => s.StokKartiId == stokId);
                var stokKart = context.StokKartis.FirstOrDefault(sk => sk.StokKartiId == stokId);

                if (stok == null || stokKart == null)
                {
                    MessageBox.Show("Seçilen ürün stokta bulunamadı!");
                    return;
                }

                // Liste üzerindeki toplam miktarı kontrol et
                int listeToplam = 0;
                ListViewItem mevcutItem = null;

                foreach (ListViewItem i in lVSecilenUrunler.Items)
                {
                    var tagData = i.Tag as Tuple<int, int>;
                    if (tagData != null)
                    {
                        int tagStokId = tagData.Item1;
                        int tagProjeId = tagData.Item2;

                        if (tagStokId == stokId && tagProjeId == projeId)
                        {
                            mevcutItem = i;
                            listeToplam += int.Parse(i.SubItems[1].Text);
                        }
                    }
                }

                int kalanMiktar = stok.SerbestMiktar - listeToplam;
                if (secilenMiktar > kalanMiktar)
                {
                    MessageBox.Show($"Girilen miktar, kalan kullanılabilir miktardan fazla! Kalan: {kalanMiktar}");
                    return;
                }

                if (mevcutItem != null)
                {
                    int mevcutMiktar = int.Parse(mevcutItem.SubItems[1].Text);
                    mevcutItem.SubItems[1].Text = (mevcutMiktar + secilenMiktar).ToString();
                }
                else
                {
                    // Listeye ekle
                    ListViewItem item = new ListViewItem(cBUrunSec.Text);
                    item.SubItems.Add(secilenMiktar.ToString());

                    // 🔹 Kalıcı çözüm: Tag'i tuple olarak saklıyoruz
                    item.Tag = Tuple.Create(stokId, projeId);

                    lVSecilenUrunler.Items.Add(item);
                }

                // Kalan miktar ve minimum stok uyarısı
                int yeniKalan = kalanMiktar - secilenMiktar;
                string mesaj = $"{cBUrunSec.Text} için kalan miktar: {yeniKalan}";
                if (yeniKalan < stokKart.MinStok)
                {
                    mesaj += $"\n⚠ Uyarı: Minimum stoğun altına düştü! (MinStok: {stokKart.MinStok})";
                }

                MessageBox.Show(mesaj);
            }



        }

 
        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
           

            if (cBProjSec.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir proje seçin!");
                return;
            }

            try
            {
                using (var context = new StokTakipContext())
                {
                    int projeId = (int)cBProjSec.SelectedValue;

                    foreach (ListViewItem item in lVSecilenUrunler.Items)
                    {
                        // 🔹 Tuple kullanımı
                        var tagData = item.Tag as Tuple<int, int>;
                        if (tagData == null)
                            continue; // tuple değilse atla (güvenlik için)

                        int stokId = tagData.Item1;

                        int miktar = int.Parse(item.SubItems[1].Text);

                        // ❗ Mevcut kayıt kontrolü
                        var mevcut = context.ProjedeKullanilanUrunlers
                                            .FirstOrDefault(p => p.ProjeId == projeId && p.StokKartiId == stokId);

                        if (mevcut != null)
                        {
                            // Var olan miktara ekle
                            mevcut.Miktar += miktar;
                        }
                        else
                        {
                            // Yoksa yeni kayıt ekle
                            var entity = new ProjedeKullanilanUrunler
                            {
                                ProjeId = projeId,
                                StokKartiId = stokId,
                                Miktar = miktar
                            };
                            context.ProjedeKullanilanUrunlers.Add(entity);
                        }

                        // Stok güncellemesi
                        var stok = context.StokDurumus.FirstOrDefault(s => s.StokKartiId == stokId);
                        var stokKart = context.StokKartis.FirstOrDefault(sk => sk.StokKartiId == stokId);

                        if (stok != null && stokKart != null)
                        {
                            int mevcutBloke = 0;
                            int.TryParse(stok.BlokeMiktar, out mevcutBloke);
                            mevcutBloke += miktar;
                            stok.BlokeMiktar = mevcutBloke.ToString();
                            stok.SerbestMiktar -= miktar;
                        }
                    }

                    context.SaveChanges();
                }

                MessageBox.Show("Kayıt başarılı!");
                lVSecilenUrunler.Items.Clear(); // Listeyi temizle
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }



        }


        private void ProjeSecComboDoldur()
        {
            using (var context = new StokTakipContext())
            {
                //    var aktifProjeler = context.Projes
                //                                .Where(p => p.Durum) // sadece aktif olanlar
                //                                .OrderBy(p => p.ProjeAdi)
                //                                .ToList();

                var aktifProjeler = context.Projes
                            .Where(p => p.Durum && p.PasifMi) // Durum = true ve PasifMi = true olanlar
                            .OrderBy(p => p.ProjeAdi)
                            .ToList();


                cBProjSec.DataSource = aktifProjeler;
                cBProjSec.DisplayMember = "ProjeAdi"; // combobox'ta gözükecek
                cBProjSec.ValueMember = "ProjeId";     // seçilen değerin ID'si
                cBProjSec.SelectedIndex = -1;          // başta boş seçili olsun
            }
        }



    }
}

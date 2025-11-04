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


            var projeEkle = new ProjeEkleViewModel
            {
                ProjeAdi = tBProjeAdi.Text,
                BaslangicTarihi = DateTime.Now,
                BitisTarihi = dTPBitisTarihi.Value,
                PersonelId = personelId,
                Durum = cBDurum.SelectedItem.ToString() == "Aktif",
                Aciklama = tBAciklama.Text,

            };
            try
            {
                _projeServices.ProjeEkle(projeEkle);
                MessageBox.Show("Proje Ekleme");
            }
            catch
            {
                MessageBox.Show("Kayit ekleme başarısız oldu");
            }
        }

        private void ProjeControl_Load(object sender, EventArgs e)
        {
            cBDurum.Items.AddRange(new string[] { "Aktif", "Pasif" });
            using (var context = new StokTakipContext())
            {
                // Projeleri getir
                cBProjSec.DataSource = context.Projes.ToList();
                cBProjSec.DisplayMember = "ProjeAdi";
                cBProjSec.ValueMember = "ProjeId";

                // Ürünleri getir
                cBUrunSec.DataSource = context.StokKartis.ToList();
                cBUrunSec.DisplayMember = "UrunAdi";
                cBUrunSec.ValueMember = "StokKartiId";

                cBProjSec.SelectedIndex = -1;
                cBUrunSec.SelectedIndex = -1;


                lVSecilenUrunler.View = View.Details;
                lVSecilenUrunler.Columns.Add("Ürün Adı", 150);
                lVSecilenUrunler.Columns.Add("Miktar", 70);


            }
            ProjeSecComboDoldur();

        }
        //private void btnUrunEkle_Click(object sender, EventArgs e)
        //{
        //    if (cBProjSec.SelectedIndex == -1)
        //    {
        //        MessageBox.Show("Lütfen bir proje seçin!");
        //        return;
        //    }

        //    try
        //    {
        //        using (var context = new StokTakipContext())
        //        {
        //            int projeId = (int)cBProjSec.SelectedValue;

        //            foreach (ListViewItem item in lVSecilenUrunler.Items)
        //            {
        //                int stokId = (int)item.Tag;
        //                int miktar = int.Parse(item.SubItems[1].Text);

        //                // Veritabanına ekle
        //                var entity = new ProjedeKullanilanUrunler
        //                {
        //                    ProjeId = projeId,
        //                    StokKartiId = stokId,
        //                    Miktar = miktar
        //                };
        //                context.ProjedeKullanilanUrunlers.Add(entity);

        //                // Stok güncellemesi
        //                var stok = context.StokDurumus.FirstOrDefault(s => s.StokKartiId == stokId);
        //                if (stok != null)
        //                {
        //                    int mevcutBloke = 0;
        //                    int.TryParse(stok.BlokeMiktar, out mevcutBloke);
        //                    mevcutBloke += miktar;
        //                    stok.BlokeMiktar = mevcutBloke.ToString();
        //                    stok.SerbestMiktar -= miktar;
        //                }
        //            }

        //            context.SaveChanges();

        //            //// Kaydedilen ürünlerin kalan miktarını göster
        //            //foreach (ListViewItem item in lVSecilenUrunler.Items)
        //            //{
        //            //    int stokId = (int)item.Tag;
        //            //    var stok = context.StokDurumus.FirstOrDefault(s => s.StokKartiId == stokId);
        //            //    if (stok != null)
        //            //    {
        //            //        MessageBox.Show($"{item.Text} için kalan miktar: {stok.SerbestMiktar}");
        //            //    }
        //            //}
        //        }

        //        MessageBox.Show("Kayıt başarılı!");
        //        lVSecilenUrunler.Items.Clear(); // Listeyi temizle
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hata oluştu: " + ex.Message);
        //    }


        //}

        //private void btnUrunEkleListe_Click(object sender, EventArgs e)
        //{

        //    if (cBProjSec.SelectedIndex == -1)
        //    {
        //        MessageBox.Show("Lütfen bir proje seçin!");
        //        return;
        //    }

        //    int stokId = (int)cBUrunSec.SelectedValue;
        //    int secilenMiktar = (int)nUDMiktarSec.Value;

        //    using (var context = new StokTakipContext())
        //    {
        //        var stok = context.StokDurumus.FirstOrDefault(s => s.StokKartiId == stokId);
        //        if (stok == null)
        //        {
        //            MessageBox.Show("Seçilen ürün stokta bulunamadı!");
        //            return;
        //        }

        //        // Liste üzerinde aynı ürünün toplamını kontrol et
        //        int listeToplam = 0;
        //        foreach (ListViewItem i in lVSecilenUrunler.Items)
        //        {
        //            if ((int)i.Tag == stokId)
        //                listeToplam += int.Parse(i.SubItems[1].Text);
        //        }

        //        int kalanMiktar = stok.SerbestMiktar - listeToplam;
        //        if (secilenMiktar > kalanMiktar)
        //        {
        //            MessageBox.Show($"Girilen miktar, kalan kullanılabilir miktardan fazla! Kalan: {kalanMiktar}");
        //            return;
        //        }

        //        // Listeye ekle
        //        ListViewItem item = new ListViewItem(cBUrunSec.Text);
        //        item.SubItems.Add(secilenMiktar.ToString());
        //        item.Tag = stokId;
        //        lVSecilenUrunler.Items.Add(item);

        //        // Kalan miktarı göster
        //        MessageBox.Show($"{cBUrunSec.Text} için kalan miktar: {kalanMiktar - secilenMiktar}");
        //    }


        //}


        private void btnUrunEkleListe_Click(object sender, EventArgs e)
        {
            if (cBProjSec.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir proje seçin!");
                return;
            }

            int stokId = (int)cBUrunSec.SelectedValue;
            int secilenMiktar = (int)nUDMiktarSec.Value;

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
                foreach (ListViewItem i in lVSecilenUrunler.Items)
                {
                    if ((int)i.Tag == stokId)
                        listeToplam += int.Parse(i.SubItems[1].Text);
                }

                int kalanMiktar = stok.SerbestMiktar - listeToplam;
                if (secilenMiktar > kalanMiktar)
                {
                    MessageBox.Show($"Girilen miktar, kalan kullanılabilir miktardan fazla! Kalan: {kalanMiktar}");
                    return;
                }

                // Listeye ekle
                ListViewItem item = new ListViewItem(cBUrunSec.Text);
                item.SubItems.Add(secilenMiktar.ToString());
                item.Tag = stokId;
                lVSecilenUrunler.Items.Add(item);

                // 🔹 Kalan miktarı ve min stok uyarısı
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
                        int stokId = (int)item.Tag;
                        int miktar = int.Parse(item.SubItems[1].Text);

                        var entity = new ProjedeKullanilanUrunler
                        {
                            ProjeId = projeId,
                            StokKartiId = stokId,
                            Miktar = miktar
                        };
                        context.ProjedeKullanilanUrunlers.Add(entity);

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

                            // 🔹 Kalan miktar ve min stok kontrolü
                            string mesaj = $"{item.Text} için kalan miktar: {stok.SerbestMiktar}";
                            if (stok.SerbestMiktar < stokKart.MinStok)
                            {
                                mesaj += $"\n⚠ Uyarı: Minimum stoğun altına düştü! (MinStok: {stokKart.MinStok})";
                            }
                            MessageBox.Show(mesaj);
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
                var aktifProjeler = context.Projes
                                            .Where(p => p.Durum) // sadece aktif olanlar
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

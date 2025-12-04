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

            dTPBaslangic.MinDate = DateTime.Today;
            dTPBitisTarihi.MinDate = DateTime.Today.AddDays(1);

            tBPersonelId.ReadOnly = true;
            tBPersonelId.Text = GirisYapanKullanici.Ad;

            using (var context = new StokTakipContext())
            {
                cBProjSec.DataSource = context.Projes
                      .Where(p => p.PasifMi)
                      .OrderBy(p => p.ProjeAdi)
                      .ToList();
                cBProjSec.DisplayMember = "ProjeAdi";
                cBProjSec.ValueMember = "ProjeId";
                cBProjSec.SelectedIndex = -1;

                cBUrunSec.DataSource = context.StokKartis
                               .Where(u => u.AktifMi)
                               .ToList();
                cBUrunSec.DisplayMember = "UrunAdi";
                cBUrunSec.ValueMember = "StokKartiId";
                cBUrunSec.SelectedIndex = -1;

                cBProjSec.SelectedIndex = -1;

                lVSecilenUrunler.View = View.Details;
                lVSecilenUrunler.Columns.Add("Ürün Adı", 150);
                lVSecilenUrunler.Columns.Add("Miktar", 70);


            }
            ProjeSecComboDoldur();

        }
        private void ProjeSecComboDoldur()
        {
            using (var context = new StokTakipContext())
            {
                var aktifProjeler = context.Projes
                            .Where(p => p.Durum && p.PasifMi) 
                            .OrderBy(p => p.ProjeAdi)
                            .ToList();


                cBProjSec.DataSource = aktifProjeler;
                cBProjSec.DisplayMember = "ProjeAdi"; 
                cBProjSec.ValueMember = "ProjeId";     
                cBProjSec.SelectedIndex = -1;          
            }
        }

        private void btnUrunEkleListe_Click(object sender, EventArgs e)
        {
           
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
                   
                    ListViewItem item = new ListViewItem(cBUrunSec.Text);
                    item.SubItems.Add(secilenMiktar.ToString());

                   
                    item.Tag = Tuple.Create(stokId, projeId);

                    lVSecilenUrunler.Items.Add(item);
                }

                
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
                     
                        var tagData = item.Tag as Tuple<int, int>;
                        if (tagData == null)
                            continue; 

                        int stokId = tagData.Item1;

                        int miktar = int.Parse(item.SubItems[1].Text);

                   
                        var mevcut = context.ProjedeKullanilanUrunlers
                                            .FirstOrDefault(p => p.ProjeId == projeId && p.StokKartiId == stokId);

                        if (mevcut != null)
                        {
                            
                            mevcut.Miktar += miktar;
                        }
                        else
                        {
                           
                            var entity = new ProjedeKullanilanUrunler
                            {
                                ProjeId = projeId,
                                StokKartiId = stokId,
                                Miktar = miktar
                            };
                            context.ProjedeKullanilanUrunlers.Add(entity);
                        }

                       
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
                lVSecilenUrunler.Items.Clear(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

    }
}

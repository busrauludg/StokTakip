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
            int.TryParse(tBPersonelId.Text, out personelId);
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

        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new StokTakipContext())
                {
                    int projeId = (int)cBProjSec.SelectedValue;

                    foreach (ListViewItem item in lVSecilenUrunler.Items)
                    {
                        var entity = new ProjedeKullanilanUrunler
                        {
                            ProjeId = projeId,
                            StokKartiId = (int)item.Tag,
                            Miktar = int.Parse(item.SubItems[1].Text)
                            // Maliyet vs. diğer alanlar buraya
                        };

                        context.ProjedeKullanilanUrunlers.Add(entity);
                    }

                    context.SaveChanges();
                }

                MessageBox.Show("Kayıt başarılı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }


            //int miktar = 0;
            //int.TryParse(nUDMiktarSec.Text, out miktar);
            //var aktifProjeUrun = new AktifProjeİhtiyaclari
            //{
            //    ProjeAdi = cBProjSec.Text,
            //    UrunAdi = cBUrunSec.Text,
            //    Miktar = miktar,
            //};
            //try
            //{
            //    _projeServices.ProjeKullanilanEkle(aktifProjeUrun);
            //    MessageBox.Show("Kayıt başarılı!");

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}

            //int miktar = (int)nUDMiktarSec.Value;

            //var aktifProjeKullanilan = new AktifProjeİhtiyaclari
            //{
            //    ProjeId = (int)cBProjSec.SelectedValue,
            //    StokKartiId = (int)cBUrunSec.SelectedValue,
            //    Miktar = miktar
            //};

            //_projeServices.EkleAktifProjeIhtiyaci(projeKullanilan);
            //MessageBox.Show("Ürün eklendi!");

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            // ListView satırları
            ListViewItem item = new ListViewItem(cBUrunSec.Text); // Ürün adı
            item.SubItems.Add(nUDMiktarSec.Value.ToString());      // Miktar
            item.Tag = cBUrunSec.SelectedValue;                    // StokKartiId sakla
            lVSecilenUrunler.Items.Add(item);
        }
    }
}

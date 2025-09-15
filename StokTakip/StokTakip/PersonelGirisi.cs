using StokTakip.Data;
using StokTakip.Services;
using StokTakip.StokTakip.Data;
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
    public partial class PersonelGirisi : Form
    {
        public PersonelGirisi()
        {
            InitializeComponent();
        }

        private void lblPersonelEkle_Click(object sender, EventArgs e)
        {
            using (var form = new PersonelEkle())
            {
                form.ShowDialog();
            }
        }

        private void PrsnlGiris_Click(object sender, EventArgs e)
        {
            string pEposta= tBPrsnlEposta.Text;
            string pSifre= tBPrsnlSifre.Text;

            PersonelRepository prepo = new PersonelRepository(new StokTakipContext());
            PersonelServices pservices = new PersonelServices(prepo);

            bool prsnlGirisBasarili= pservices.PrsnlGirisKontrol(pEposta, pSifre);

            if (prsnlGirisBasarili)
            {
                var bolumForm = new BolumSec();
                bolumForm.ShowDialog();
                this.Hide();
            }
            else
            {
                // Giriş başarısız → kullanıcıya mesaj göster ve PersonelEkle formuna yönlendir
                MessageBox.Show("E-posta veya şifre bulunamadı. Personel ekle sayfasına yönlendiriliyorsunuz.");

                var ekleForm = new PersonelEkle();
                ekleForm.Show();
                this.Hide();
            }

        }
    }
}

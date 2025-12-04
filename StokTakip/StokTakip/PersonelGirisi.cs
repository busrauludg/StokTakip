using StokTakip.Data;
using StokTakip.Helpers;
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
using StokTakip.Properties;


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
            string pEposta = tBPrsnlEposta.Text;
            string pSifre = tBPrsnlSifre.Text;

           
            if (string.IsNullOrWhiteSpace(tBPrsnlEposta.Text) || string.IsNullOrWhiteSpace(tBPrsnlSifre.Text))
            {
                MessageBox.Show("Eposta ve sifre boş bırakılamaz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        
            PersonelRepository prepo = new PersonelRepository(new StokTakipContext());
            PersonelServices pservices = new PersonelServices(prepo);

            bool prsnlGirisBasarili = pservices.PrsnlGirisKontrol(pEposta, pSifre);

            if (prsnlGirisBasarili)
            {
                
                var girisYapanKullanici = pservices.GetByEposta(pEposta);
                YetkiliKontrol.Rol = girisYapanKullanici.Rol; // Rolü sakla
                GirisYapanKullanici.Ad = girisYapanKullanici.Ad;//adı al 


                var bolumForm = new BolumSec();
                bolumForm.ShowDialog();
                this.Hide();

            }

            else
            {
               
                MessageBox.Show("E-posta veya şifre bulunamadı.Şifre ve epostanızı kontrol ediniz.");

            }

        }

        private void PersonelGirisi_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }
    }
}

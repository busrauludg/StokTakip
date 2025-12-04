using Humanizer;
using StokTakip.Data;
using StokTakip.Helpers;
using StokTakip.Services;
using StokTakip.StokTakip.Data;
using StokTakip.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class PersonelEkle : Form
    {
        private readonly PersonelServices _personelService;

        public PersonelEkle()
        {
            InitializeComponent();
            tBYetkiliSifre.Visible = false;
            lblYetkiliSifre.Visible = false;

            _personelService = new PersonelServices(new PersonelRepository(new StokTakipContext()));

        }
        private void rBPrsYetkili_CheckedChanged(object sender, EventArgs e)
        {
            tBYetkiliSifre.Visible = rBPrsYetkili.Checked;
            lblYetkiliSifre.Visible = rBPrsYetkili.Checked;
        }
      
        private void lblYetkiliSifre_Click(object sender, EventArgs e)
        {
            if (!rBPrsYetkili.Checked)
            {
                MessageBox.Show("Önce Rol: Yetkili seçin.");
                return;
            }

            YetkiliSifreForm yetkiliForm = new YetkiliSifreForm();
            yetkiliForm.ShowDialog();
        }
        private void btnPersonelKayit_Click(object sender, EventArgs e)
        {

            bool rolYetkili = rBPrsYetkili.Checked;
            string girdiSifre = tBYetkiliSifre.Text;

            if (rolYetkili)
            {
                string? dbHash = _personelService.GetYetkiliSifreHash();
                if (dbHash == null)
                {
                    MessageBox.Show("Sistem yetkili şifresi belirlenmemiş.");
                    return;
                }
                if (HashHelper.HashSha256(girdiSifre) != dbHash)
                {
                    MessageBox.Show("Yetkili şifre yanlış, personel yetkili olarak eklenemez.");
                    return;
                }

            }

            var dto = new PersonelDto
            {
                Ad = tBPrsAdi.Text,
                Soyad = tBPrsSoyadi.Text,
                Gorev = tBPrsGorev.Text,
                Telefon = tBPrsTelNo.Text,
                Eposta = tBPrsEposta.Text,
                Sifre = tBPrsSifre.Text,
                SifreTekrari = tBSifreTekrari.Text,
                Rol = rBPrsYetkili.Checked
            };
            try
            {

               
                if (_personelService.GetByEposta(dto.Eposta!) != null)
                {
                    MessageBox.Show("Bu e-posta zaten kayıtlı.");
                    return;
                }

               
                if (_personelService.GetBySifre(dto.Sifre) != null)
                {
                    MessageBox.Show("Bu şifre zaten kullanımda.");
                    return;
                }

              
                if (rBPrsYetkili.Checked)
                {
                    if (string.IsNullOrWhiteSpace(tBYetkiliSifre.Text))
                    {
                        MessageBox.Show("Yetkili şifresi boş olamaz!");
                        return;
                    }

                }

               
                _personelService.PrsnlEkle(dto);
                MessageBox.Show("Personel başarıyla eklendi.");

            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    "Personel eklerken hata oluştu:\n" + ex.Message,
                    "Uyarı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

    }
}

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
    public partial class PersonelEkle : Form
    {
        private string? _yetkiliSifrePlain = null;
        private readonly PersonelServices _personelService;
        public PersonelEkle()
        {
            InitializeComponent();
            // Form açılır açılmaz yetkili şifre alanını gizle
            tBYetkiliSifre.Visible = false;
            lblYetkiliSifre.Visible = false;

            // Service örneği
            _personelService = new PersonelServices(new PersonelRepository(new StokTakipContext()));

        }

        private void rBPrsYetkili_CheckedChanged(object sender, EventArgs e)
        {
            tBYetkiliSifre.Visible = rBPrsYetkili.Checked;
            lblYetkiliSifre.Visible = rBPrsYetkili.Checked;

        }

        private void btnPersonelKayit_Click(object sender, EventArgs e)
        {
            var dto = new PersonelDto
            {
                Ad = tBPrsAdi.Text,
                Soyad = tBPrsSoyadi.Text,
                Gorev = tBPrsGorev.Text,
                Telefon = tBPrsTelNo.Text,
                Eposta = tBPrsEposta.Text,
                Sifre = tBPrsSifre.Text,
                Rol = rBPrsYetkili.Checked,
                YetkiliSifre = rBPrsYetkili.Checked ? _yetkiliSifrePlain : null
            };

            if (dto.Rol && string.IsNullOrWhiteSpace(dto.YetkiliSifre))
            {
                MessageBox.Show("Yetkili için şifre belirleyin.");
                return;
            }

            _personelService.Create(dto);
            MessageBox.Show("Personel başarıyla eklendi.");
        }

        private void lblYetkiliSİfre_Click(object sender, EventArgs e)
        {
        
            if (!rBPrsYetkili.Checked)
            {
                MessageBox.Show("Önce Rol: Yetkili seçin.");
                return;
            }

            using var dlg = new YetkiliSifreForm();
            if (dlg.ShowDialog() == DialogResult.OK)
                _yetkiliSifrePlain = dlg.Sifre;
        }

    }
}

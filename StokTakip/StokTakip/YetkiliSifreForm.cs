using Humanizer;
using Microsoft.EntityFrameworkCore;
using StokTakip.Data;
using StokTakip.Helpers;
using StokTakip.Models;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class YetkiliSifreForm : Form
    {
        private readonly PersonelServices _yetkiliServices;

        public YetkiliSifreForm()
        {
            InitializeComponent();

            _yetkiliServices = new PersonelServices(new PersonelRepository(new StokTakipContext()));
        }

        
        private void YetkiliSifreForm_Load(object sender, EventArgs e)
        {
            var mevcutHash = _yetkiliServices.GetYetkiliSifreHash();

            
            if (string.IsNullOrEmpty(mevcutHash))
            {
                
                tBMevcutYetkili.Visible = false;
                lblMevcutSifre.Visible = false;
            }
            else
            {
                
                tBMevcutYetkili.Visible = true;
                lblMevcutSifre.Visible = true;
            }
        }

        private void btnPerKaydet_Click(object sender, EventArgs e)
        {
            string mevcutSifre = tBMevcutYetkili.Text;
            string yeniSifre = tBYetkiliGirisSifre.Text;

            if (string.IsNullOrEmpty(yeniSifre) || yeniSifre.Length < 6)
            {
                MessageBox.Show("Şifre en az 6 karakter olmalıdır!");
                return;
            }

            try
            {
                var mevcutHash = _yetkiliServices.GetYetkiliSifreHash();

                
                if (string.IsNullOrEmpty(mevcutHash))
                {
                   
                    var dto = new PersonelDto
                    {
                        YetkiliSifre1 = HashHelper.HashSha256(yeniSifre)
                    };

                    _yetkiliServices.YetkiliOlustur(dto);
                    MessageBox.Show("İlk yetkili şifre başarıyla oluşturuldu.");
                    this.Close();
                    return;
                }

               
                if (HashHelper.HashSha256(mevcutSifre) != mevcutHash)
                {
                    MessageBox.Show("Mevcut şifre doğru değil!");
                    return;
                }

               
                var dto2 = new PersonelDto
                {
                    YetkiliSifre1 = HashHelper.HashSha256(yeniSifre)
                };

                _yetkiliServices.YetkiliOlustur(dto2);
                MessageBox.Show("Yetkili şifre başarıyla güncellendi.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message +
                               (ex.InnerException != null ? " | İç hata: " + ex.InnerException.Message : ""));
            }
        }


    }
}

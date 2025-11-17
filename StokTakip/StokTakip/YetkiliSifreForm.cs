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
        
        //12.09.2025 cuma enjecte ettim 
        public YetkiliSifreForm()
        {
            InitializeComponent();
            
            _yetkiliServices = new PersonelServices(new PersonelRepository(new StokTakipContext()));
        }

        private void btnPerKaydet_Click(object sender, EventArgs e)
        {
            string mevcutSifre = tBMevcutYetkili.Text;
            string sifre=tBYetkiliGirisSifre.Text;
            if (string.IsNullOrEmpty(sifre) || sifre.Length < 6)
            {
                MessageBox.Show("Şifre en az 6 karakterli olmalıdır");
                return;
            }
            try
            {
                // Mevcut şifreyi kontrol et
                var mevcutHash = _yetkiliServices.GetYetkiliSifreHash();
                if (mevcutHash != HashHelper.HashSha256(mevcutSifre))
                {
                    MessageBox.Show("Mevcut şifre doğru değil.");
                    return;
                }
                var dto2 = new PersonelDto
                { 
                  YetkiliSifre1 = HashHelper.HashSha256(sifre),
                };

                _yetkiliServices.YetkiliOlustur(dto2/*dto*/); // void metod çağır

                 MessageBox.Show("Yetkili şifre başarıyla kaydedildi.");
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

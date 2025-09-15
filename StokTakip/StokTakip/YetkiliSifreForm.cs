using Humanizer;
using Microsoft.EntityFrameworkCore;
using StokTakip.Data;
using StokTakip.Helpers;
using StokTakip.Models;
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
            string sifre=tBYetkiliGirisSifre.Text;
            if (string.IsNullOrEmpty(sifre) || sifre.Length < 6)
            {
                MessageBox.Show("Şifre en az 6 karakterli olmalıdır");
                return;
            }
            try
            {
                var dto2 = new PersonelDto
                { 
                  YetkiliSifre = HashHelper.HashSha256(sifre),
                };

                _yetkiliServices.YetkiliOlustur(dto2); // void metod çağır
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

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

        //private void btnPerKaydet_Click(object sender, EventArgs e)
        //{
        //    string mevcutSifre = tBMevcutYetkili.Text;
        //    string sifre = tBYetkiliGirisSifre.Text;
        //    if (string.IsNullOrEmpty(sifre) || sifre.Length < 6)
        //    {
        //        MessageBox.Show("Şifre en az 6 karakterli olmalıdır");
        //        return;
        //    }
        //    try
        //    {
        //        // Mevcut şifreyi kontrol et
        //        var mevcutHash = _yetkiliServices.GetYetkiliSifreHash();
        //        if (mevcutHash != HashHelper.HashSha256(mevcutSifre))
        //        {
        //            MessageBox.Show("Mevcut şifre doğru değil.");
        //            return;
        //        }
        //        var dto2 = new PersonelDto
        //        {
        //            YetkiliSifre1 = HashHelper.HashSha256(sifre),
        //        };

        //        _yetkiliServices.YetkiliOlustur(dto2/*dto*/); // void metod çağır

        //        MessageBox.Show("Yetkili şifre başarıyla kaydedildi.");
        //        this.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hata oluştu: " + ex.Message +
        //                       (ex.InnerException != null ? " | İç hata: " + ex.InnerException.Message : ""));
        //    }


        //}

        private void YetkiliSifreForm_Load(object sender, EventArgs e)
        {
            var mevcutHash = _yetkiliServices.GetYetkiliSifreHash();

            // Eğer şifre yoksa (ilk kurulum)
            if (string.IsNullOrEmpty(mevcutHash))
            {
                // Mevcut şifre alanını gizle
                tBMevcutYetkili.Visible = false;
                lblMevcutSifre.Visible = false;
            }
            else
            {
                // Şifre varsa göster
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

                // Eğer daha önce hiç şifre yoksa (NULL veya boş ise):
                if (string.IsNullOrEmpty(mevcutHash))
                {
                    // Direkt yeni şifre kaydedilir
                    var dto = new PersonelDto
                    {
                        YetkiliSifre1 = HashHelper.HashSha256(yeniSifre)
                    };

                    _yetkiliServices.YetkiliOlustur(dto);
                    MessageBox.Show("İlk yetkili şifre başarıyla oluşturuldu.");
                    this.Close();
                    return;
                }

                // Eğer mevcut şifre varsa, önce doğru eski şifre girildi mi kontrol edilir:
                if (HashHelper.HashSha256(mevcutSifre) != mevcutHash)
                {
                    MessageBox.Show("Mevcut şifre doğru değil!");
                    return;
                }

                // Mevcut şifre doğru → yeni şifre kaydedilir
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

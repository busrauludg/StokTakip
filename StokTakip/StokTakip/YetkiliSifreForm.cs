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
        public string? Sifre=>tBYetkiliGirisSifre.Text;
        public YetkiliSifreForm()
        {
            InitializeComponent();
        }

        private void btnPerKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tBYetkiliGirisSifre.Text) || tBYetkiliGirisSifre.Text.Length < 6)
            { MessageBox.Show("Şifre en az 6 karakter olmalı."); return; }
            if (tBYetkiliGirisSifre.Text != tBYetkiliGirisSifre.Text)
            { MessageBox.Show("Şifreler uyuşmuyor."); return; }
            DialogResult = DialogResult.OK;
        }
    }
}

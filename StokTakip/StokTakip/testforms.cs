//using StokTakip.Models;
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
    public partial class testforms : Form
    {
        public testforms()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    using (var context = new StokTakipContext())
        //    {
        //        var personel = context.Personels.ToList();
        //        MessageBox.Show($"Toplam kişi sayısı:{personel.Count}");
        //    }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        //    using (var context = new StokTakipContext())
        //    {
        //        var pekle = new Personel { Ad = "Büşra", Soyad = "Uludağ", Gorev = "Pc mühendis", Telefon = "024576935", Eposta = "bus@gmail.com", Sifre = "45136" };
        //        context.Personels.Add(pekle);
        //        context.SaveChanges();
        //        MessageBox.Show("Personel EKlendi");
        //    }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        //    using (var context = new StokTakipContext())
        //    {
        //        var personel = context.Personels.FirstOrDefault();
        //        if (personel != null)
        //        {
        //            personel.Ad = "Beril";
        //            context.SaveChanges();
        //            MessageBox.Show("Ad güncellendi");
        //        }
        //    }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        //    using(var context=new StokTakipContext())
        //    {
        //        var personel=context.Personels.FirstOrDefault(p => p.PersonelId == 3);
        //        if (personel != null)
        //        {
        //            context.Personels.Remove(personel);
        //            context.SaveChanges();
        //            MessageBox.Show("Personel Silindi");
        //        }
        //    }
        }
    }
}

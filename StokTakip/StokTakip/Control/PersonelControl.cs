using StokTakip.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StokTakip
{
    public partial class PersonelControl : UserControl
    {
        public PersonelControl()
        {
            InitializeComponent();
        }

        private void PersonelControl_Load(object sender, EventArgs e)
        {
            lVlPersonel.Columns.Add("PersonelId", 0); // gizli ID sütunu
            lVlPersonel.Columns.Add("Personel Adı", 150);
            lVlPersonel.Columns.Add("Personel Soyad", 150);
            lVlPersonel.Columns.Add("Personel Görev", 150);
            lVlPersonel.Columns.Add("Personel Rolu", 150);
            lVlPersonel.Columns.Add("Personel Telefon Numarası", 150);

            using (var context = new StokTakipContext())
            {
                var personeller = context.Personels
                    .Select(p => new { p.PersonelId, p.Ad, p.Soyad, p.Gorev, p.Rol, p.Telefon })
                    .ToList();

                lVlPersonel.Items.Clear();

                foreach (var p in personeller)
                {
                    var detay = new ListViewItem(p.PersonelId.ToString());
                    detay.SubItems.Add(p.Ad);
                    detay.SubItems.Add(p.Soyad);
                    detay.SubItems.Add(p.Gorev);
                    detay.SubItems.Add(p.Rol ? "Yetkili" : "Personel");
                    detay.SubItems.Add(p.Telefon);


                    lVlPersonel.Items.Add(detay);
                }
                lVlPersonel.ContextMenuStrip = cmsPersonel;
            }

            lVlPersonel.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    var item = lVlPersonel.GetItemAt(e.X, e.Y);
                    if (item != null)
                        item.Selected = true;
                }
            };
            pnlDuzenle.Visible = false;

        }

        //silme tuşu 
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (lVlPersonel.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show("Bu personeli silmek istediğinizden emin misiniz?",
                                             "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int personelId = int.Parse(lVlPersonel.SelectedItems[0].Text);
                    using (var context = new StokTakipContext())
                    {
                        var pers = context.Personels.Find(personelId);
                        if (pers != null)
                        {
                            context.Personels.Remove(pers);
                            context.SaveChanges();
                        }
                    }
                    lVlPersonel.Items.Remove(lVlPersonel.SelectedItems[0]);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir personel seçin!");
            }
        }

        private int seciliPersonelId; // global değişken
        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lVlPersonel.SelectedItems.Count > 0)
            {
                seciliPersonelId = int.Parse(lVlPersonel.SelectedItems[0].Text);

                using (var context = new StokTakipContext())
                {
                    var personel = context.Personels.Find(seciliPersonelId);
                    if (personel != null)
                    {
                        personel.Gorev = tBGorev.Text;
                       // Rol için combobox seçimi
                        cBRol.SelectedItem = personel.Rol ? "Yetkili" : "Personel";
                        personel.Telefon = tBTelNo.Text;// eğer sütun varsa
                        pnlDuzenle.Visible = true;
                    }
                }
            }
        }

        private void btnDuzen_Click(object sender, EventArgs e)
        {
           
            using (var context = new StokTakipContext())
            {
                var personel = context.Personels.Find(seciliPersonelId);
                if (personel != null)
                {
                    personel.Gorev = tBGorev.Text;
                    personel.Telefon = tBTelNo.Text;
                    personel.Rol = (cBRol.SelectedItem.ToString() == "Yetkili"); // doğru bool ataması

                    context.SaveChanges();
                    MessageBox.Show("Personel bilgileri güncellendi.");

                    // Tabloyu tekrar yüklemek yerine sadece seçili öğeyi güncelle
                    var item = lVlPersonel.SelectedItems[0];
                    item.SubItems[3].Text = personel.Gorev;   // Gorev sütunu
                    item.SubItems[4].Text = personel.Rol ? "Yetkili" : "Personel"; // Rol sütunu
                    item.SubItems[5].Text = personel.Telefon; // Telefon sütunu
                }
            }

            pnlDuzenle.Visible = false;
      

        //        using(var context = new StokTakipContext())
        //{
        //            var personel = context.Personels.Find(seciliPersonelId);
        //            if (personel != null)
        //            {
        //                personel.Gorev = tBGorev.Text;
        //                personel.Telefon = tBTelNo.Text;

        //                // ComboBox’tan gelen değere göre bool ata
        //                personel.Rol = (cBRol.SelectedItem.ToString() == "");

        //                context.SaveChanges();
        //                MessageBox.Show("Personel bilgileri güncellendi.");
        //            }
        //        }

        //        pnlDuzenle.Visible = false;
        //        PersonelControl_Load(null, null);
    }
}
}

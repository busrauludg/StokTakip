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

            using (var context = new StokTakipContext())
            {
                var personeller = context.Personels
                    .Select(p => new { p.PersonelId, p.Ad, p.Soyad, p.Gorev, p.Rol })
                    .ToList();

                lVlPersonel.Items.Clear();

                foreach (var p in personeller)
                {
                    var detay = new ListViewItem(p.PersonelId.ToString());
                    detay.SubItems.Add(p.Ad);
                    detay.SubItems.Add(p.Soyad);
                    detay.SubItems.Add(p.Gorev);
                    detay.SubItems.Add(p.Rol ? "Yetkili" : "Personel");


                    lVlPersonel.Items.Add(detay);
                }
                lVlPersonel.ContextMenuStrip = cmsPersonel;
            }


        }

        private void cmsPersonel_Click(object sender, EventArgs e)
        {

        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Seçili ListViewItem al
            if (lVlPersonel.SelectedItems.Count > 0)
            {
                int personelId = int.Parse(lVlPersonel.SelectedItems[0].Text);
                // EF ile silme işlemi
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lVlPersonel.SelectedItems.Count > 0)
            {
                int personelId = int.Parse(lVlPersonel.SelectedItems[0].Text);
                // EF ile düzenleme işlemi veya form açma
            }
        }
    }
}

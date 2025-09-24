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
    public partial class MekanikUrunDetayForm : Form
    {
        private MekanikServices mekanikServices;
        private readonly StokTakipContext _context;

        public StokKarti SecilenUrun { get; set; }
        public MekanikUrunDetayForm()
        {
            InitializeComponent();
            mekanikServices = new MekanikServices(new StokTakipContext());
           _context = new StokTakipContext();
        }

        private void MekanikForm_Load(object sender, EventArgs e)
        {
         
            if(SecilenUrun != null)
            {
                var detaylar=_context.StokKartis
                    .Where(s=>s.StokKartiId == SecilenUrun.StokKartiId)
                    .ToList();
                dGVMekanik.DataSource=detaylar;
            }
        }
    }
}

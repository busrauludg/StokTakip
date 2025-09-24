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
    public partial class ElektrikUrunDetayForm : Form
    {
        private ElektrikServices elektrikServices;
        private readonly StokTakipContext _context;
        public StokKarti SecilenUrun { get; set; }
        public ElektrikUrunDetayForm()
        {
            InitializeComponent();
            elektrikServices = new ElektrikServices(new StokTakipContext());
            _context= new StokTakipContext();       
        }

        private void ElektrikForm_Load(object sender, EventArgs e)
        {
           if(SecilenUrun != null)
            {
                var detaylar=_context.StokKartis
                    .Where(s=>s.StokKartiId==SecilenUrun.StokKartiId)
                    .ToList();
                dGVElektrik.DataSource= detaylar;
            }
        }
    }
}

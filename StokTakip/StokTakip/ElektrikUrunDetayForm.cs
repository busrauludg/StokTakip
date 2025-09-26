using StokTakip.Models;
using StokTakip.Services;
using StokTakip.StokTakip.Data;
using StokTakip.ViewModels;
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
        private StokKartiViewModel _secilenUrun;
       
        public ElektrikUrunDetayForm(StokKartiViewModel secilenUrun)
        {
            InitializeComponent();
           _secilenUrun = secilenUrun;    
        }

        private void ElektrikForm_Load(object sender, EventArgs e)
        {
           if(_secilenUrun != null)
           {
                var detaylar=new List<StokKartiViewModel> {_secilenUrun };
                dGVElektrik.DataSource= detaylar;
           }
        }
    }
}

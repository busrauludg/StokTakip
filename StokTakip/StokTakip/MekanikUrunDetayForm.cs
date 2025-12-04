using StokTakip.Helpers;
using StokTakip.Models;
using StokTakip.StokTakip.Data;
using StokTakip.ViewModels;

namespace StokTakip
{
    public partial class MekanikUrunDetayForm : Form
    {
        private readonly StokKartiViewModel _secilenUrun;
        private readonly StokDurumuViewModel _durum;
        private readonly SatinAlmaSiparisleriViewModel _alim;

        public MekanikUrunDetayForm(StokKartiViewModel secilenUrun,
            StokDurumuViewModel durum,
            SatinAlmaSiparisleriViewModel alim)
        {
            InitializeComponent();
            _secilenUrun = secilenUrun;
            _durum = durum;
            _alim = alim;
        }

        private void MekanikForm_Load(object sender, EventArgs e)
        {
            if (_secilenUrun != null)
            {
                txtMStokKodu.Text = _secilenUrun.StokKodu;
                txtMFirmaSiparisKodu.Text = _secilenUrun.FirmaKodu;
                txtMStokBirimi.Text = _secilenUrun.StokBirimi;
                txtMDepoAdresi.Text = _secilenUrun.DepoAdresi;
                txtMMinStok.Text = _secilenUrun.MinStok.ToString();
                txtMMaxStok.Text = _secilenUrun.MaxStok.ToString();
                tBMStokMiktari.Text = _secilenUrun.StokMiktari.ToString();
                txtMGrupAdi.Text = _secilenUrun.GrupAdi;
                txtMFirmaAdi.Text = _secilenUrun.FirmaAdi;
                txtMPersonelAdi.Text = _secilenUrun.PersonelAdi;
                txtMAciklama.Text = _secilenUrun.Aciklama;

                if (File.Exists(_secilenUrun.ResimYolu))
                {
                    pBMekanikResim.Image = Image.FromFile(_secilenUrun.ResimYolu);
                    pBMekanikResim.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            using (var context = new StokTakipContext())
            {
                var sipAlimDb = context.SatinAlmas
                    .Where(a => a.StokKartiId == _secilenUrun.StokKartiId)
                    .OrderByDescending(a => a.SiparisId)
                    .FirstOrDefault();

                if (sipAlimDb != null)
                {
                    dTPMekanik.Value = sipAlimDb.SiparisTarihi;
                    txtMMiktar.Text = sipAlimDb.Miktar.ToString();
                    txtMCari.Text = sipAlimDb.CariAdi ?? "";
                    txtMGlnMktr.Text = sipAlimDb.GelenMiktar.ToString();
                    tBMekTopTutar.Text = sipAlimDb.ToplamMaliyet.ToString("N2");
                    txtMSprsAciklama.Text = sipAlimDb.Aciklama ?? "";
                }
            }
            if (_durum != null)
            {
                dGVMknStkDurum.DataSource = new List<StokDurumuViewModel> { _durum };
                if (dGVMknStkDurum.Columns["StokKartId"] != null)
                    dGVMknStkDurum.Columns["StokKartId"].Visible = false;
                dGVMknStkDurum.Columns["DepoAdi"].HeaderText = "Depo Adı";
                dGVMknStkDurum.Columns["SerbestMiktar"].HeaderText = "Kullanılabilir Miktar";
                dGVMknStkDurum.Columns["BlokeMiktar"].HeaderText = "Kullanılan Miktar";
            }
            lVAktifProje.View = View.Details;
            lVAktifProje.Columns.Add("Ürün Adı", 150);
            lVAktifProje.Columns.Add("Miktar", 70);
            lVAktifProje.Columns.Add("Durum", 70);

            if (_secilenUrun != null)
            {
                using (var context = new StokTakipContext())
                {
                    var liste = context.ProjedeKullanilanUrunlers
                        .Where(p => p.StokKartiId == _secilenUrun.StokKartiId && p.Proje.Durum)
                        .Select(p => new
                        {
                            p.Proje.ProjeAdi,
                            p.Miktar,
                            Durum = p.Proje.Durum ? "Aktif" : "Pasif"
                        })
                        .ToList();

                    lVAktifProje.Items.Clear();
                    foreach (var item in liste)
                    {
                        var lvi = new ListViewItem(item.ProjeAdi);
                        lvi.SubItems.Add(item.Miktar.ToString());
                        lvi.SubItems.Add(item.Durum);
                        lVAktifProje.Items.Add(lvi);
                    }
                }
            }

            pMStokCikis.Visible = false;
            pMStokArtir.Visible = false;
            btnStokCikis.Enabled = YetkiliKontrol.Rol;
            btnMSArtirPanel.Enabled = YetkiliKontrol.Rol;

            using (var context = new StokTakipContext())
            {
                var projeler = context.Projes.OrderBy(p => p.ProjeAdi).ToList();
                cBPMProjeSec.DataSource = projeler;
                cBPMProjeSec.DisplayMember = "ProjeAdi";
                cBPMProjeSec.ValueMember = "ProjeId";
                cBPMProjeSec.SelectedIndex = -1;
            }
        }
        private void btnStokCikis_Click(object sender, EventArgs e)
        {
            pMStokCikis.Visible = true;
        }
        private void btnMSArtirPanel_Click(object sender, EventArgs e)
        {
            pMStokArtir.Visible = true;
        }
        private void btnMStokCikisi_Click(object sender, EventArgs e)
        {
           
            if (!int.TryParse(tBMCikicakMiktar.Text, out int cikisMiktari) || cikisMiktari <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir miktar girin.");
                return;
            }
            if (_durum == null) return;
            int yeniUrun = _durum.SerbestMiktar - cikisMiktari;
            if (yeniUrun < 0)
            {
                MessageBox.Show("Stok yetersiz!");
                return;
            }

            _durum.SerbestMiktar = yeniUrun;
            int blokeMiktar = 0;
            int.TryParse(_durum.BlokeMiktar, out blokeMiktar);
            blokeMiktar += cikisMiktari;
            _durum.BlokeMiktar = blokeMiktar.ToString();

            using (var context = new StokTakipContext())
            {
                var dbStok = context.StokDurumus
                    .FirstOrDefault(s => s.StokKartiId == _durum.StokKartId);

                if (dbStok != null)
                {
                    dbStok.SerbestMiktar = _durum.SerbestMiktar;
                    dbStok.BlokeMiktar = _durum.BlokeMiktar;
                }
                if (cBPMProjeSec.SelectedValue != null)
                {
                    int projeId = Convert.ToInt32(cBPMProjeSec.SelectedValue);
                    var projeUrun = context.ProjedeKullanilanUrunlers
                        .FirstOrDefault(p => p.ProjeId == projeId && p.StokKartiId == _durum.StokKartId);

                    if (projeUrun != null)
                    {
                        projeUrun.Miktar += cikisMiktari;
                    }
                    else
                    {
                        context.ProjedeKullanilanUrunlers.Add(new ProjedeKullanilanUrunler
                        {
                            ProjeId = projeId,
                            StokKartiId = _durum.StokKartId,
                            Miktar = cikisMiktari
                        });
                    }
                }

                context.SaveChanges();
            }
            dGVMknStkDurum.DataSource = null;
            dGVMknStkDurum.DataSource = new List<StokDurumuViewModel> { _durum };
            dGVMknStkDurum.DataSource = null;
            dGVMknStkDurum.DataSource = new List<StokDurumuViewModel> { _durum };

            if (dGVMknStkDurum.Columns["StokKartId"] != null)
                dGVMknStkDurum.Columns["StokKartId"].Visible = false;

            dGVMknStkDurum.Columns["DepoAdi"].HeaderText = "Depo Adı";
            dGVMknStkDurum.Columns["SerbestMiktar"].HeaderText = "Kullanılabilir Miktar";
            dGVMknStkDurum.Columns["BlokeMiktar"].HeaderText = "Kullanılan Miktar";

            MessageBox.Show("Stok çıkışı başarılı!");
        }
        private void btnMStokArttir_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tBMArtirMiktar.Text, out int gelenMiktar) || gelenMiktar <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir miktar girin.");
                return;
            }

            using (var context = new StokTakipContext())
            {
                int urunId = _secilenUrun.StokKartiId;

                var satinAlma = context.SatinAlmas
                    .Where(x => x.StokKartiId == urunId)
                    .OrderByDescending(x => x.SiparisTarihi)
                    .FirstOrDefault();

                if (satinAlma == null)
                {
                    MessageBox.Show("Bu ürüne ait satınalma kaydı bulunamadı!");
                    return;
                }

                var stokDurum = context.StokDurumus.FirstOrDefault(x => x.StokKartiId == urunId);
                var stokKarti = context.StokKartis.FirstOrDefault(x => x.StokKartiId == urunId);

                if (stokDurum == null || stokKarti == null)
                {
                    MessageBox.Show("Stok bilgileri bulunamadı!");
                    return;
                }

                if (satinAlma.GelenMiktar + gelenMiktar > satinAlma.Miktar)
                {
                    MessageBox.Show($"Gelen miktar sipariş verilen miktarı aşamaz! (Sipariş: {satinAlma.Miktar}, Gelen: {satinAlma.GelenMiktar})");
                    return;
                }

                decimal.TryParse(stokDurum.BlokeMiktar, out decimal blokeMiktar);
                decimal yeniSerbest = stokDurum.SerbestMiktar + gelenMiktar;
                decimal toplamStok = yeniSerbest + blokeMiktar;

                if (toplamStok > stokKarti.MaxStok)
                {
                    var result = MessageBox.Show(
                        $"Maksimum stok seviyesini geçmek üzeresiniz ({stokKarti.MaxStok}).\nYine de kaydetmek istiyor musunuz?",
                        "Uyarı",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("İşlem iptal edildi.");
                        return;
                    }
                }
                else if (toplamStok >= stokKarti.MaxStok - 3)
                {
                    MessageBox.Show("Uyarı: Maksimum stoğa 3-4 ürün kaldı!");
                }

                stokDurum.SerbestMiktar = (int)yeniSerbest;
                stokKarti.StokMiktari = (int)toplamStok;
                satinAlma.GelenMiktar += (int)gelenMiktar;

                context.SaveChanges();
            }

            MessageBox.Show("Stok başarıyla artırıldı!");
            MekanikForm_Load(null, null);
        }
    }
}

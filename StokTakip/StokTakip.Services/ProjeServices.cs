using StokTakip.Data;
using StokTakip.Models;
using StokTakip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Services
{
    public class ProjeServices
    {
        private readonly AnaSayfaRepository _projeEkle;
        public ProjeServices(AnaSayfaRepository projeEkle)
        {
            _projeEkle = projeEkle;
        }
        public void ProjeEkle(ProjeEkleViewModel projeModel)
        {
            var prjEkle = new Proje
            {
                ProjeAdi= projeModel.ProjeAdi,
                BaslangicTarihi=projeModel.BaslangicTarihi,
                BitisTarihi=projeModel.BitisTarihi,
                PersonelId=projeModel.PersonelId,
                Durum=projeModel.Durum,
                Aciklama=projeModel.Aciklama
            };
            _projeEkle.ProjeEkle(prjEkle);
        }
        //public void ProjeKullanilanEkle(AktifProjeİhtiyaclari projeUrunEkle)
        //{
        //    var prjUrunEkle = new ProjedeKullanilanUrunler
        //    {
        //        ProjeId= projeUrunEkle.ProjeId,
        //        StokKartiId=projeUrunEkle.StokKartiId,
        //        Miktar=projeUrunEkle.Miktar,

        //    };
        //    _projeEkle.ProjeKullanilanUrunEkle(prjUrunEkle);
        //}
        
    }
}

using Humanizer;
using StokTakip.Data;
using StokTakip.Helpers;
using StokTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakip.Dto;
using StokTakip.Validations;

namespace StokTakip.Services
{
    public class PersonelServices
    {
        private readonly PersonelRepository _services;
        public PersonelServices(PersonelRepository repository) => _services = repository;

        public Personel? GetByEposta(string eposta) => _services.GetByEposta(eposta);

        public Personel? GetBySifre(string sifre) => _services.GetBySifre(sifre);
        //11.09.2025 persemeb deneme
        //public Personel? GetYetkiliSifre(string yetkiliSifre) => _services.GetYetkiliSifre(yetkiliSifre);

        //public string? GetSistemYetkiliSifre() => _services.GetSistemYetkiliSifre();

        public void PrsnlEkle(PersonelDto dto)
        {
            var errors=PersonelValidator.Validate(dto);
            if (errors.Any())
                throw new InvalidOperationException(string.Join("\n",errors));
            
            var entity = new Personel() 
            {
                
                Ad = dto.Ad,
                Soyad = dto.Soyad,
                Gorev = dto.Gorev,
                Telefon = dto.Telefon,
                Eposta = dto.Eposta,
                Sifre = dto.Sifre, // normal personel şifresi ilerde buraya hashhelper yapılıcak 
                Rol = dto.Rol,
                YetkiliSifre =  null
            };
            _services.PrsnlKydt(entity);
        }
        //11.09.2025persembe
        public void YetkiliOlustur(PersonelDto dto2)
        {
            var yetkili = new Personel()
            {
                YetkiliSifre = dto2.YetkiliSifre,
            };
            _services.YetkiliEkle(yetkili);
        }
        public bool PrsnlGirisKontrol(string eposta,string sifre)=>
             _services.PersonelVarMi(eposta, sifre);
        

        public string? GetYetkiliSifreHash()=>
         _services.GetYetkiliSifreHash();
        




    }
}

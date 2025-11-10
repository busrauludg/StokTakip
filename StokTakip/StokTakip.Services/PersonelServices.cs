using Humanizer;
using StokTakip.Data;
using StokTakip.Dto;
using StokTakip.Helpers;
using StokTakip.Models;
using StokTakip.StokTakip.Data;
using StokTakip.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                YetkiliSifre1 =  null
            };
            _services.PrsnlKydt(entity);
        }


        public void YetkiliOlustur(PersonelDto dto)
        {
            //// Rol = true olan personeli bul
            //var personel = _services.GetByRol(); // Repo'da bu metodu oluştur: Rol = true döndürsün

            //if (personel != null)
            //{
            //    personel.YetkiliSifre1 = dto.YetkiliSifre1; // Hashlenmiş şifreyi ata
            //    _services.YetkiliEkle(personel); // Repo'da save işlemi
            //}
            //// Manuel girilen yetkili şifresini ata 10.11
            //personel.YetkiliSifre1 = dto.YetkiliSifre1;
            //_services.YetkiliEkle(personel); // veritabanına kaydet

            using (var context = new StokTakipContext())
            {
                // Tüm personelleri al
                var personeller = context.Personels.ToList();

                // Hepsine şifreyi ata
                foreach (var p in personeller)
                {
                    p.YetkiliSifre1 = dto.YetkiliSifre1;
                }

                // Değişiklikleri kaydet
                context.SaveChanges();
            }
        }

        public bool PrsnlGirisKontrol(string eposta,string sifre)=>
             _services.PersonelVarMi(eposta, sifre);
        

        public string? GetYetkiliSifreHash()=>
         _services.GetYetkiliSifreHash();
        




    }
}

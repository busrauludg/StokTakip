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
                Sifre = dto.Sifre, 
                Rol = dto.Rol,
                YetkiliSifre1 =  null
            };
            _services.PrsnlKydt(entity);
        }


        public void YetkiliOlustur(PersonelDto dto)
        {
            

            using (var context = new StokTakipContext())
            {
       
                var personeller = context.Personels.ToList();

              
                foreach (var p in personeller)
                {
                    p.YetkiliSifre1 = dto.YetkiliSifre1;
                }

             
                context.SaveChanges();
            }
        }

        public bool PrsnlGirisKontrol(string eposta,string sifre)=>
             _services.PersonelVarMi(eposta, sifre);
        

        public string? GetYetkiliSifreHash()=>
         _services.GetYetkiliSifreHash();
        




    }
}

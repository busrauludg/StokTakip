using StokTakip.Data;
using StokTakip.Helpers;
using StokTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Services
{
    public class PersonelDto
    {
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public string Gorev { get; set; } = null!;
        public string Telefon { get; set; } = null!;
        public string? Eposta { get; set; }
        public string Sifre { get; set; } = null!;
        public bool Rol { get; set; }
        public string? YetkiliSifre { get; set; }
    }
    public class PersonelServices
    {
        private readonly PersonelRepository _repository;
        public PersonelServices(PersonelRepository repository)=>_repository = repository;

        public void Create(PersonelDto dto)
        {
            var entity = new Personel()
            {
                Ad = dto.Ad,
                Soyad = dto.Soyad,
                Gorev = dto.Gorev,
                Telefon = dto.Telefon,
                Eposta = dto.Eposta,
                Sifre = dto.Sifre,
                Rol = dto.Rol,
                YetkiliSifre = dto.Rol && !string.IsNullOrWhiteSpace(dto.YetkiliSifre)
                    ? HashHelper.HashSha256(dto.YetkiliSifre)
                    : null
            };
            _repository.Add(entity);
        }
        
    }
}

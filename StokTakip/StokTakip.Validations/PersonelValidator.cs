using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StokTakip.Dto;


namespace StokTakip.Validations
{
    public static class PersonelValidator
    {
        public static List<string> Validate(PersonelDto dto)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.Ad))
                errors.Add("Ad boş bırakılamaz.");
            if (string.IsNullOrWhiteSpace(dto.Soyad))
                errors.Add("Soyad boş bırakılamaz.");

            if (string.IsNullOrWhiteSpace(dto.Telefon) || !System.Text.RegularExpressions.Regex.IsMatch(dto.Telefon, @"^0\d{10}$"))
                errors.Add("Telefon numarası 11 haneli ve 0 ile başlamalıdır.");

            if (string.IsNullOrWhiteSpace(dto.Eposta) || !dto.Eposta.Contains("@"))
                errors.Add("Geçerli bir e-posta giriniz.");
            else
            {
                var domain = dto.Eposta.Split('@').Last();
                if (domain.ToLower() != "gmail.com")
                    errors.Add("E-posta sadece gmail.com olabilir.");
            }

            if (string.IsNullOrWhiteSpace(dto.Sifre) || dto.Sifre.Length < 6)
                errors.Add("Şifre en az 6 karakter olmalıdır.");
            if (dto.Sifre.Length < 6)
                errors.Add("Şifre en az 6 karakter olmalı.");
            if (!dto.Sifre.Any(char.IsUpper))
                errors.Add("Şifre en az 1 büyük harf içermeli.");
            if (!dto.Sifre.Any(ch => "!@#$%^&*+-/".Contains(ch)))
                errors.Add("Şifre en az 1 özel karakter içermeli.");


            if (dto.Sifre != dto.SifreTekrari)
                errors.Add("Şifre ve şifre tekrarı eşleşmiyor.");

            return errors;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Helpers
{
    public class HashHelper
    {
      
        //public static string HashSha256(string input)
        //{
        //    using var sha = SHA256.Create();
        //    var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        //    return Convert.ToHexString(bytes);
        //}

        //12.09.2025

        public static string HashSha256(string text)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(text);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}

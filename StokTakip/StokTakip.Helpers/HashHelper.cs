using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
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
        public static string HashSha256(string input)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToHexString(bytes);
        }
    }
}

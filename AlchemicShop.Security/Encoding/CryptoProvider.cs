using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace AlchemicShop.Security.Encoding
{
    public static class CryptoProvider
    {
        public static string GetMD5Hash(string p)
        {
            p += "s@lt";
            MD5CryptoServiceProvider mD5Crypto = new MD5CryptoServiceProvider();
            byte[] hashCode = mD5Crypto.ComputeHash(UTF8Encoding.Default.GetBytes(p));
            return BitConverter.ToString(hashCode).ToLower().Replace("-","");
        }
    }
}

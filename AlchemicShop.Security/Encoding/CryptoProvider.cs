using System;
using System.Security.Cryptography;
using System.Text;

namespace AlchemicShop.Security.Encoding
{
    public static class CryptoProvider
    {
        public static string GetMD5Hash(string p)
        {
            p += "s@lt";
            var mD5Crypto = new MD5CryptoServiceProvider();
            byte[] hashCode = mD5Crypto.ComputeHash(UTF8Encoding.Default.GetBytes(p));
            return BitConverter.ToString(hashCode).ToLower().Replace("-", "");
        }
    }
}

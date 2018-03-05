using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Nicholas.Smart.Materials.Business
{
    public class NicholasEncrypt
    {
        public static string DecryptString(string strText, string key)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(key));
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            provider.Key = buffer;
            provider.Mode = CipherMode.ECB;
            byte[] inputBuffer = Convert.FromBase64String(strText);
            return Encoding.ASCII.GetString(provider.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
        }

        public static string DecryptUTF8String(string strText, string key)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(key));
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            provider.Key = buffer;
            provider.Mode = CipherMode.ECB;
            byte[] inputBuffer = Convert.FromBase64String(strText);
            return Encoding.UTF8.GetString(provider.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
        }

        public static string EncryptString(string strText, string key)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(key));
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            provider.Key = buffer;
            provider.Mode = CipherMode.ECB;
            byte[] bytes = Encoding.ASCII.GetBytes(strText);
            string str = Convert.ToBase64String(provider.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
            provider = null;
            return str;
        }

        public static string EncryptUTF8String(string strText, string key)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(key));
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            provider.Key = buffer;
            provider.Mode = CipherMode.ECB;
            byte[] bytes = Encoding.UTF8.GetBytes(strText);
            string str = Convert.ToBase64String(provider.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
            provider = null;
            return str;
        }
    }
}

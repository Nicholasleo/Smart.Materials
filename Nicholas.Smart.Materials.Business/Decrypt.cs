using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace Nicholas.Smart.Materials.Business
{
    /// <summary>
    /// 解密
    /// </summary>
    public class Decryption
    {
        public Decryption()
        {
        }

        /// <summary>
        /// 获取文件内容——字符串
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>文件内容</returns>
        public string GetString(string path)
        {
            return this.DeserializeFile(path);
        }

        /// <summary>
        /// 反序列化文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>文件内容</returns>
        private string DeserializeFile(string path)
        {
            string str = "";

            if (!File.Exists(path))
            {
                throw new Exception("文件不存在!");
            }

            IFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                str = (string)binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
            }

            return str;
        }

        public string DecryptString(string data, string key)
        {
            string str = string.Empty;

            if (string.IsNullOrEmpty(data))
            {
                throw new Exception("数据为空");
            }

            MemoryStream ms = new MemoryStream();
            byte[] myKey = Encoding.UTF8.GetBytes(key);
            byte[] myIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

            DES myProvider = new DESCryptoServiceProvider();
            CryptoStream cs = new CryptoStream(ms, myProvider.CreateDecryptor(myKey, myIV), CryptoStreamMode.Write);

            try
            {
                byte[] bs = Convert.FromBase64String(data);
                cs.Write(bs, 0, bs.Length);
                cs.FlushFinalBlock();
                str = Encoding.UTF8.GetString(ms.ToArray());
            }
            finally
            {
                cs.Close();
                ms.Close();
            }
            return str;
        }
    }
}

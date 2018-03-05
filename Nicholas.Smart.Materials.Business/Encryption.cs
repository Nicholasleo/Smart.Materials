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
    /// 加密
    /// </summary>
    public class Encryption
    {
        /// <summary>
        /// 生成证书文件
        /// </summary>
        /// <param name="data">注册信息</param>
        /// <param name="fileName">证书文件路径</param>
        /// <param name="key"></param>
        public void GenerateFile(string data, string fileName, string key)
        {
            string str = this.EncryptString(data, key);
            this.SerializeFile(str, fileName);
        }

        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="data">数据字符串</param>
        /// <param name="path">文件路径</param>
        private void SerializeFile(string data, string path)
        {
            IFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            if (data != null)
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    binaryFormatter.Serialize(fileStream, data);
                    fileStream.Close();
                }
            }
        }

        public string EncryptString(string data, string key)
        {
            string str = string.Empty;

            if (string.IsNullOrEmpty(data))
            {
                return str;
            }

            MemoryStream ms = new MemoryStream();
            byte[] myKey = Encoding.UTF8.GetBytes(key);
            byte[] myIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

            DES myProvider = new DESCryptoServiceProvider();
            CryptoStream cs = new CryptoStream(ms, myProvider.CreateEncryptor(myKey, myIV), CryptoStreamMode.Write);

            try
            {
                byte[] bs = Encoding.UTF8.GetBytes(data);
                cs.Write(bs, 0, bs.Length);
                cs.FlushFinalBlock();
                str = Convert.ToBase64String(ms.ToArray());
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

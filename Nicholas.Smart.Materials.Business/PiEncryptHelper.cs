using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Nicholas.Smart.Materials
{
    public static class PiEncryptHelper
    {
        [DllImport("PiEncrypt.dll")]
        private static extern int PiGetFileEncState(string pszFullFileName);
        [DllImport("PiEncrypt.dll")]
        private static extern bool PiEncryptFile(string pszFullFileName, ref int nFailCode, bool NeedDog);
        [DllImport("PiEncrypt.dll")]
        private static extern bool PiDecryptFile(string pszFullFileName, ref int nFailCode, bool NeedDog);
        [DllImport("PiEncrypt.dll")]
        private static extern bool PiSetDefKeyVer(long nKeyVer);
        [DllImport("PiEncrypt.dll")]
        private static extern uint PiIsMemEnc(byte[] pMem, int nLen);
        [DllImport("PiEncrypt.dll")]
        private static extern uint PiDecFileInMem(byte[] pSourceFileMem, int Sourcelen, byte[] pDesFileMem, ref int DecMemLen, ref int failcode);
        [DllImport("PiEncrypt.dll")]
        private static extern uint PiEncFileInMem(byte[] pSourceFileMem, int Sourcelen, byte[] pEncFileMem, ref int EncMemLen, ref int failcode);
        [DllImport("PiEncrypt.dll")]
        private static extern uint PiEncFileInMemByKeyID(byte[] pSourceFileMem, int Sourcelen, byte[] pEncFileMem, ref int EncMemLen, ref int failcode, int nKeyID);
        [DllImport("PiEncrypt.dll")]
        private static extern bool PiGetDefKeyVer(ref long nKeyVer);
        [DllImport("PiEncrypt.dll")]
        private static extern bool PiEncryptFileByKeyID(string pszFullFileName, ref int nFailCode, int nKeyId, bool NeedDog);
        [DllImport("PiEncrypt.dll")]
        private static extern int PiGetFileEncStateAndID(string pszFullFileName, ref int nKeyID);
        [DllImport("PiEncrypt.dll")]
        private static extern uint PiIsMemEnc(byte[] pMem, int nLen, ref int nKeyID);
        static PiEncryptHelper()
        {
            KeyVer = 1;
            OuterKeyVer = 5;
        }
        //以下为公开函数
        public static int KeyVer;
        public static int OuterKeyVer;
        /// <summary>
        /// 判断文件是否加密
        /// </summary>
        /// <param name="strFullFileName">文件路径</param>
        /// <param name="nKeyID">返回密钥ID</param>
        /// <returns></returns>
        public static bool IsFileEnc(string strFullFileName, ref int nKeyID)
        {
            // int nRet = PiGetFileEncState(strFullFileName);
            int nRet = PiGetFileEncStateAndID(strFullFileName, ref nKeyID);
            if (nRet == 1)  //表示加密
            {
                return true;
            }
            else
            {
                nKeyID = 0;
                return false;
            }
        }
        /// <summary>
        /// 加密文件(内部的),会使用KeyVer所指定的密钥
        /// </summary>
        /// <param name="strFullFileName">文件路径</param>
        /// <returns></returns>
        public static bool EncFile(string strFullFileName)
        {
            int nFailCode = 0;
            //if (PiEncryptFile(strFullFileName, ref nFailCode, false))
            if (PiEncryptFileByKeyID(strFullFileName, ref nFailCode, KeyVer, false))
            {
                return true;
            }
            else
                return false;

        }
        /// <summary>
        /// 加密文件(外发的),会使用OuterKeyVer所指定的密钥
        /// </summary>
        /// <param name="strFullFileName">文件路径</param>
        /// <returns></returns>
        public static bool EncOuterFile(string strFullFileName)
        {
            int nFailCode = 0;
            if (PiEncryptFileByKeyID(strFullFileName, ref nFailCode, OuterKeyVer, false))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 解密文件,可解密内部的或外发的密钥所加密的文件
        /// </summary>
        /// <param name="strFullFileName">文件路径</param>
        /// <returns></returns>
        public static bool DecFile(string strFullFileName)
        {
            int nFailCode = 0;
            if (PiDecryptFile(strFullFileName, ref nFailCode, false))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 判断内存文件流是否加密
        /// </summary>
        /// <param name="pMem">内存流</param>
        /// <param name="nLen">长度</param>
        /// <param name="nKeyID">返回加密的密钥ID</param>
        /// <returns></returns>
        public static bool IsMemEnc(byte[] pMem, int nLen, ref int nKeyID)
        {
            uint nRet = PiIsMemEnc(pMem, nLen, ref nKeyID);
            if (nRet == 1)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 加密文件流(内部的),(加密的流会比未加密流长512B)
        /// </summary>
        /// <param name="pSourceFileMem">未加密的流</param>
        /// <param name="Sourcelen">流长度</param>
        /// <param name="pEncFileMem">返回加密的流</param>
        /// <param name="EncMemLen">返回加密流的长度</param>
        /// <returns></returns>
        public static bool EncFileInMem(byte[] pSourceFileMem, int Sourcelen, byte[] pEncFileMem, ref int EncMemLen)
        {
            int nFailCode = 0;
            uint nRet = PiEncFileInMemByKeyID(pSourceFileMem, Sourcelen, pEncFileMem, ref  EncMemLen, ref nFailCode, KeyVer);
            if (nRet == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 加密文件流(外发的),(加密的流会比未加密流长512B)
        /// </summary>
        /// <param name="pSourceFileMem">未加密的流</param>
        /// <param name="Sourcelen">流长度</param>
        /// <param name="pEncFileMem">返回加密的流</param>
        /// <param name="EncMemLen">返回加密流的长度</param>
        /// <returns></returns>
        public static bool EncOuterFileInMem(byte[] pSourceFileMem, int Sourcelen, byte[] pEncFileMem, ref int EncMemLen)
        {
            int nFailCode = 0;
            uint nRet = PiEncFileInMemByKeyID(pSourceFileMem, Sourcelen, pEncFileMem, ref  EncMemLen, ref nFailCode, OuterKeyVer);
            if (nRet == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 解密文件流,可解内部的或外发的流
        /// </summary>
        /// <param name="pSourceFileMem">加密的流</param>
        /// <param name="Sourcelen">流长度</param>
        /// <param name="pDecFileMen">返回未加密的流</param>
        /// <param name="DecMemLen">返回未加密流的长度</param>
        /// <returns></returns>
        public static bool DecFileInMem(byte[] pSourceFileMem, int Sourcelen, byte[] pDecFileMen, ref int DecMemLen)
        {
            int nFailCode = 0;
            uint nRet = PiDecFileInMem(pSourceFileMem, Sourcelen, pDecFileMen, ref DecMemLen, ref nFailCode);
            if (nRet == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

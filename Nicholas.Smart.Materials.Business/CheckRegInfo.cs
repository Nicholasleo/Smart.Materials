using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace Nicholas.Smart.Materials.Business
{
    public class CheckRegInfo 
    {


        public CheckRegInfo()
        {
        }

        public static string LocalKey = GetSystemInfo.GetDiskID() + GetSystemInfo.GetCpuID() + GetSystemInfo.GetMotherBoardID();
       
        public static string AesLocalKey = AES.AesEncrypt(LocalKey, "NicholasLeo", "13158985896zhuzc");

        public static string RegPath = AppDomain.CurrentDomain.BaseDirectory + "SoftReg.leo";

        public static string VersionUrl = @"https://gitee.com/nicholasleo/Materials/raw/master/Version";

        public static string OAuthUrl = @"https://gitee.com/nicholasleo/Materials/raw/master/OAuth";

        public static string NowVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static string GetSoftRegFlg()
        {
            string fl = "U3OtiHLdjoM=";
            try
            {
                fl = RegisterClass.GetItemValue("Leo");
                if(fl == null || string.IsNullOrEmpty(fl))
                    fl = "U3OtiHLdjoM=";
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            
            return NicholasEncrypt.DecryptUTF8String(fl, GetSystemInfo.EncrytionKey);
        }

        public static int GetLoginTimes()
        {
            string times = "0";
            try
            {

                times = RegisterClass.GetItemValue("Nicholas");
                if(times != null)
                    times = NicholasEncrypt.DecryptUTF8String(times, GetSystemInfo.EncrytionKey);
            }
            catch (Exception ex)
            {
                return Convert.ToInt32(times);
            }
            return Convert.ToInt32(times);
        }

        public static bool IsNewVersion()
        {
            try
            {
                string[] n = GetNewVersionInfo().Split('.');

                string[] m = NowVersion.Split('.');

                for (int i = 0; i < n.Length-1; i++)
                {
                    if (Convert.ToInt32(m[i]) >= Convert.ToInt32(n[i]))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return true;
            }
            return true;
        }

        public static string GetNewVersionInfo()
        {
            try
            {
                string version = "0.0.0.0";
                WebRequest request = WebRequest.Create(VersionUrl);
                WebResponse response = request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(resStream, System.Text.Encoding.Default);
                version = sr.ReadToEnd();
                resStream.Close();
                sr.Close();
                return version;
            }
            catch (Exception)
            {
                return @"无法获取到最新版本信息，请检查网络是否连接正常！";
            }
            finally
            { 
            }
            
        }

        public static string GetOAuthInfo()
        {
            try
            {
                string version = "工业和信息化部备案号【粤ICP备11065058】";
                WebRequest request = WebRequest.Create(OAuthUrl);
                WebResponse response = request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(resStream, System.Text.Encoding.Default);
                version = sr.ReadToEnd();
                if (string.IsNullOrEmpty(version))
                {
                    version = "工业和信息化部备案号【粤ICP备11065058】";
                }
                resStream.Close();
                sr.Close();
                return version;
            }
            catch (Exception)
            {
                return @"工业和信息化部备案号【粤ICP备11065058】";
            }

        }

        public static string GetSoftDue()
        {   //HrejADlG4nA= NoDue
            //9TrZBvE7GbI= HasDue
            string dueFlg = "9TrZBvE7GbI";
            dueFlg = RegisterClass.GetItemValue("NicholasLeo");
            if (dueFlg != null)
            {
                dueFlg = NicholasEncrypt.DecryptUTF8String(dueFlg, GetSystemInfo.EncrytionKey);
            }
            return dueFlg;
        }

        /// <summary>
       /// 
       /// </summary>
       /// <param name="isReg"></param>
       /// <param name="errorInfo"></param>
       /// <param name="infoType">1:无法获取注册信息，2：无法在本机注册，3：未授权，4：已过期</param>
        public static void CheckReg(ref bool isReg, out string errorInfo, out int infoType, out bool isTrial)
        {
            infoType = 0;
            errorInfo = "";
            isTrial = false;
            try
            {
                int x = 0;
                //系统未注册
                if (GetSoftRegFlg() == "NO")
                {
                    if (GetLoginTimes() < 10)
                    {
                        isTrial = true;
                        int times = GetLoginTimes() + 1;
                        RegisterClass.UpdateSubKey("Nicholas", NicholasEncrypt.EncryptUTF8String(times.ToString(), GetSystemInfo.EncrytionKey));
                    }
                    else
                    {
                        errorInfo = "检测到系统试用次数已使用完！";
                        isReg = false;
                        infoType = 5;
                        RegisterClass.UpdateSubKey("NicholasLeo", NicholasEncrypt.EncryptUTF8String("NoDue", GetSystemInfo.EncrytionKey));
                        return;
                    }
                    isReg = true;
                    infoType = 10;
                    return;
                }

                if (GetSoftDue() != "Due")
                {
                    errorInfo = "检测到系统未授权！";
                    isReg = false;
                    infoType = 5;
                    return;
                }


                if (!File.Exists(RegPath))
                {
                    errorInfo = "无法检测到系统注册信息！";
                    isReg = false;
                    infoType = 1;
                    return;
                }

                if (!PiEncryptHelper.IsFileEnc(RegPath, ref x))
                {
                    errorInfo = "授权文件出错，请联系管理员！";
                    isReg = false;
                    infoType = 1;
                    return;
                }

                PiEncryptHelper.DecFile(RegPath);
                SystemRegInfo regInfo = XmlHelper.GetSystemRegInfo(RegPath, "Software");
                PiEncryptHelper.EncFile(RegPath);
                if (regInfo == null)
                {
                    errorInfo = "无法检测到系统注册信息！";
                    isReg = false;
                    infoType = 1;
                    return;
                }
                if (regInfo.RegKey != AesLocalKey)
                {
                    errorInfo = "检测到系统无法在改电脑上使用！";
                    isReg = false;
                    infoType = 2;
                    return;
                }

                DateTime endTime = Convert.ToDateTime(regInfo.EndDate);
                if (DateTime.Compare(endTime, DateTime.Now) < 0)
                {
                    errorInfo = "检测到系统注册已过期，请重新激活！";
                    isReg = false;
                    infoType = 3;
                    return;
                }

                DateTime startTime = Convert.ToDateTime(regInfo.StartDate);
                if (DateTime.Compare(startTime, DateTime.Now) > 0)
                {
                    errorInfo = "检测到电脑系统时间不是北京时间，请将电脑时间调整到当前北京时间！";
                    isReg = false;
                    infoType = 3;
                    return;
                }

                if (NicholasEncrypt.DecryptUTF8String(regInfo.IsAuthorized,GetSystemInfo.EncrytionKey) != "HasAuthorized")
                {
                    errorInfo = "检测到系统未进行授权！";
                    isReg = false;
                    infoType = 3;
                    return;
                }
            }
            catch (Exception)
            {
                errorInfo = "授权文件出错，请重试！";
                isReg = false;
            }
        }
    }
}

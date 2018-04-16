using Nicholas.Smart.Materials.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Nicholas.Smart.Materials.Main.Bussiness
{
    public partial class FrmUpdate : FrmBaseDev
    {
        public FrmUpdate()
        {
            InitializeComponent();
            //var version = Assembly.GetExecutingAssembly().GetName().Version;
            //lbVersion.Text = string.Format("当前系统版本为V{0}，目前系统最新版本为V{0}，目前没有最新的版本升级！", version);
        }

        protected override void DelayLoad()
        {
            base.DelayLoad();
            GetVersion();
        }

        private string url = @"https://gitee.com/nicholasleo/Materials/raw/master/Version";

        private void GetVersion()
        {
            try
            {
            //    WebRequest request = WebRequest.Create(url);
            //    WebResponse response = request.GetResponse();
            //    Stream resStream = response.GetResponseStream();
            //    StreamReader sr = new StreamReader(resStream, System.Text.Encoding.Default);
            //    //lbVersion.Text = sr.ReadToEnd();
            //    string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string versionInfo = "";
                if (CheckRegInfo.IsNewVersion())
                {
                    versionInfo = string.Format(@"当前系统版本为最新版本V{0}", CheckRegInfo.NowVersion);
                }
                else
                {
                    versionInfo = string.Format("当前系统版本为V{0}，目前系统最新版本为V{1}", CheckRegInfo.NowVersion, CheckRegInfo.GetNewVersionInfo());
                }
                lbVersion.Text = versionInfo;
            }
            catch (Exception)
            {
                lbVersion.Text = @"无法获取到最新版本信息，请检查网络是否连接正常！";
            }
        }
    }
}

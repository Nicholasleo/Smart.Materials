using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nicholas.Smart.Materials.Business;

namespace Nicholas.Smart.Materials.Main
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        //[MTAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();

            string skinname = "DevExpress Style";
            if (string.IsNullOrEmpty(skinname))
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "DevExpress Style";
            }
            else
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = skinname;
            }
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmMainDev());
            StartMain();
        }


        private static bool _isReg = true;


        private static string _errorInfo;

        private static int _infoType;
        

        private static void StartMain()
        {
            Application.EnableVisualStyles();
            Application.DoEvents();
            if (!CheckRegInfo.IsNewVersion())
            {
                MessageBox.Show(@"当前系统版本不是最新版本！");
            }
#if DEBUG
            StartFrmMain();
            return;
#endif
            RegisterClass.CreateSubKey();
            bool isTrial = true;
            CheckRegInfo.CheckReg(ref _isReg,out _errorInfo,out _infoType,out isTrial);
            if (isTrial)
            {
                MessageBox.Show(string.Format(@"当前版本为试用版，可免费试用{0}次！",11-CheckRegInfo.GetLoginTimes()), @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (!_isReg)
            {
                MessageBox.Show(_errorInfo,@"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var frm = new Bussiness.FrmRegister();
                DialogResult loginDiaSul = frm.ShowDialog();
                if (loginDiaSul == DialogResult.OK)
                {
                    _isReg = frm.RegSuccess;
                    frm.Dispose();
                    if (_isReg)
                    {
                        StartFrmMain();
                        return;
                    }
                }
            }
            if (_isReg)
            {
                StartFrmMain();
            }
            else
            {
                Application.Exit();   
            }
        }

        private static void StartFrmMain()
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.Run(new FrmMainDev());
            Application.Exit();
            string exefile = string.Format(@"{0}\Nicholas.Smart.Materials.Main.exe", AppDomain.CurrentDomain.BaseDirectory);
            if (File.Exists(exefile))
            {
                Process.Start(exefile);
            }
        }
    }
}

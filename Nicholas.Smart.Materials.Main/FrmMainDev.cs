using System.Reflection;
using DevExpress.XtraNavBar;
using DevExpress.XtraTabbedMdi;
using Nicholas.Smart.Materials.Business;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Nicholas.Smart.Materials.Main
{
    public partial class FrmMainDev : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public TabbedMdiManager XtraTabbedMdiManager1 = new TabbedMdiManager();

        private NavBarGroup focusedBarGroup; // 当前选中的bargroup

        /// <summary>
        /// 使用XtraTabbedMdiManager后，给Mdi窗体添加背景图片
        /// 重写DevExpress.XtraTabbedMdi.XtraTabbedMdiManager的DrawNC方法
        /// </summary>
        public class TabbedMdiManager : XtraTabbedMdiManager
        {
            private Image backgroundImage;

            public TabbedMdiManager()
            { }

            public TabbedMdiManager(IContainer container)
                : base(container) { }

            public Image BackgroundImage
            {
                set { backgroundImage = value; }
                get { return backgroundImage; }
            }

            protected override void DrawNC(DevExpress.Utils.Drawing.DXPaintEventArgs e)
            {
                if (Pages.Count > 0 || backgroundImage == null)
                {
                    base.DrawNC(e);
                }
                else
                {
                    //e.Graphics.DrawImage(_BackgroundImage, Bounds);
                    e.Graphics.DrawImage(backgroundImage, Bounds.X - 1, Bounds.Y - 1, Bounds.Width + 1, Bounds.Height + 2);
                }
            }

        }

        Timer initalTreeTimer;

        Timer delayLoadTimer;
        public FrmMainDev()
        {
            InitializeComponent();
#if DEBUG
            XtraTabbedMdiManager1.BackgroundImage = ControlFunction.GetFileImage(Application.StartupPath + "\\Resources", "主界面测试");
#else
            XtraTabbedMdiManager1.BackgroundImage = ControlFunction.GetFileImage(Application.StartupPath + "\\Resources", "主界面背景");
#endif

            delayLoadTimer = new Timer();
            delayLoadTimer.Tick += delayLoadTimer_Tick;
            delayLoadTimer.Enabled = false;
            XtraTabbedMdiManager1.MdiParent = this;
            //XtraTabbedMdiManager1.PageAdded += xtraTabbedMdiManager1_PageAdded;
            XtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            XtraTabbedMdiManager1.SelectedPageChanged += xtraTabbedMdiManager1_SelectedPageChanged;
            XtraTabbedMdiManager1.MouseDown += XtraTabbedMdiManager1_MouseDown;
            this.WindowState = FormWindowState.Maximized;
            
        }

        private void XtraTabbedMdiManager1_MouseDown(object sender, MouseEventArgs e)
        {
            if (XtraTabbedMdiManager1.Pages.Count >= 3)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (XtraTabbedMdiManager1.SelectedPage.MdiChild != null)
                    {
                        Point p = XtraTabbedMdiManager1.SelectedPage.MdiChild.PointToScreen(e.Location);
                        popupMenu2.ShowPopup(p);
                    }
                }
            }
        }
        

        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Application.DoEvents();
            try
            {
                BaseFunction.GetConfig();
                delayLoadTimer.Interval = 80;
                delayLoadTimer.Enabled = true;
                bsiSetting.Caption = @"当前系统计算的板宽为：【" + BaseFunction.Area + @"mm】";
                if (!File.Exists(imageConfig))
                {
                    XmlHelper.CreateImageXml(imageConfig);
                    PiEncryptHelper.EncFile(imageConfig);
                }
                if (!PiEncryptHelper.IsFileEnc(imageConfig, ref nKeyID))
                {
                    MessageBox.Show(@"系统文件错误！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception)
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void xtraTabbedMdiManager1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (((XtraTabbedMdiManager) sender).SelectedPage != null)
            {
                string pageName = ((XtraTabbedMdiManager) sender).SelectedPage.MdiChild.Name;
            }

        }

        #region 窗体打开

        ///<summary>
        ///打开子窗口
        ///</summary>
        ///<param name="type">子窗口实例</param>
        ///<param name="againOpen">允许重复打开</param>
        private void OpenSheet(Type type, bool againOpen)
        {
            try
            {
                foreach (XtraMdiTabPage page in XtraTabbedMdiManager1.Pages)
                {
                    if (!againOpen && page.MdiChild.GetType().Equals(type))
                    {
                        if (XtraTabbedMdiManager1.SelectedPage != page)
                            XtraTabbedMdiManager1.SelectedPage = page;
                        return;
                    }
                }
                Cursor.Current = Cursors.WaitCursor;

                FrmBaseDev fx = (FrmBaseDev)Activator.CreateInstance(type);
                //fx.frmModule = module;
                //fx.Text = module.FuncPic; //此处优先赋值FuncPic，为窗体寻找小图有效 kason 请勿修改
                Cursor.Current = Cursors.Default;
                if (type.Name.Contains("FrmRegister") || type.Name.Contains("FrmUpdate"))
                {
                    fx.ShowDialog();
                }
                else
                {
                    fx.MdiParent = this;
                    fx.Show();
                }
            }
            catch (Exception ex)
            {
                DialogMessagebox.ShowInfo(ex.Message);
            }
        }
        #endregion



        private void btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FuncWin = e.Item.Tag.ToString();
            Type type = Type.GetType(FuncWin);
            OpenSheet(type,false);
        }
        private string imageConfig = AppDomain.CurrentDomain.BaseDirectory + "ImageConfig.xml";

        int nKeyID = 0;

        private static bool _isReg = true;


        private static string _errorInfo;

        private static int _infoType;

        private void CheckReg()
        {
            bool _isReg = true;
            string _errorInfo;
            int _infoType;
            bool isTrial = false;
            CheckRegInfo.CheckReg(ref _isReg, out _errorInfo, out _infoType, out isTrial);
            if (isTrial)
            {
                MessageBox.Show(string.Format(@"当前版本为试用版，可免费试用{0}次！", 6 - CheckRegInfo.GetLoginTimes()), @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (!_isReg)
            {
                MessageBox.Show(_errorInfo, @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var frm = new Bussiness.FrmRegister();
                DialogResult loginDiaSul = frm.ShowDialog();
                if (loginDiaSul == DialogResult.OK)
                {
                    _isReg = frm.RegSuccess;
                    frm.Dispose();
                    if (_isReg)
                    {
                        return;
                    }
                }
            }
        }
        private void InitStatusBar()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;

#if !DEBUG
            //CheckReg();
#endif

            if (CheckRegInfo.GetSoftRegFlg() == "NO")
            {
                this.bsiVersion.Caption = string.Format(@"【软件未注册可免费使用10次，当前已使用（{0}）次】", CheckRegInfo.GetLoginTimes());
            }
            else
            {
                this.bsiVersion.Caption = string.Format(@"【软件已注册,当前版本为：V{0}】", version);
            }

            #if DEBUG
            this.bsiVersion.Caption = string.Format(@"【软件测试版本,当前版本为：测试V{0}】", version);
            #endif

            bsiSetting.Caption = @"当前系统计算的板宽为：【" + BaseFunction.Area + @"mm】";
        }

        private void delayLoadTimer_Tick(object sender, EventArgs e)
        {
            InitStatusBar();
        }
    }

}

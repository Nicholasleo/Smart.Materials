using System.ComponentModel;
using DevExpress.XtraEditors;

namespace Nicholas.Smart.Materials.Main
{
    public partial class FrmBasicDev : XtraForm
    {
        private FrmWaitDialog frmWait = new FrmWaitDialog();
        private BackgroundWorker bw;
        private AsyncStartHandler thisRun;
        private AsyncUpdateUIHandler thisUpdate;
        private string proccessmsg = "系统正在加载数据，请稍后……";
        private string defaultTitle = "数据加载";
        private bool isAutoClose = true;
        public FrmBasicDev()
        {
            InitializeComponent();
            Icon = Properties.Resources.load;

            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            //支持撤销
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            bw.ProgressChanged += Bw_ProgressChanged;
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            frmWait.SetContent(proccessmsg, e.ProgressPercentage);
            if (thisUpdate != null)
            {
                thisUpdate();
                thisUpdate = null;
            }

        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (isAutoClose) frmWait.Close();
            else
            {
                frmWait.SetOkVisiable(true);
            }
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (thisRun != null)
            {
                thisRun();
                thisRun = null;
            }
        }

        /// <summary>
        /// 开始执行异步操作
        /// </summary>
        /// <param name="doworkhandle"></param>
        protected void AsyncStartWork(AsyncStartHandler doworkhandle)
        {
            AsyncStartWork(doworkhandle, defaultTitle, "系统正在处理，请稍后……", true);
        }
        protected void AsyncStartWork(AsyncStartHandler doworkhandle, string title)
        {
            AsyncStartWork(doworkhandle, title, "系统正在处理，请稍后……", true);
        }

        /// <summary>
        /// 开始执行异步操作
        /// </summary>
        /// <param name="doworkHandle"></param>
        /// <param name="title"></param>
        /// <param name="proccessMsg"></param>
        protected void AsyncStartWork(AsyncStartHandler doworkHandle, string title, string proccessMsg)
        {
            AsyncStartWork(doworkHandle, title, proccessMsg, true);
        }

        /// <summary>
        /// 开始执行异步操作
        /// </summary>
        /// <param name="doworkHandle"></param>
        /// <param name="title"></param>
        /// <param name="proccessMsg"></param>
        /// <param name="autoClose"></param>
        protected void AsyncStartWork(AsyncStartHandler doworkHandle, string title, string proccessMsg, bool autoClose)
        {
            proccessmsg = proccessMsg;
            thisRun = doworkHandle;
            frmWait.Text = title;
            isAutoClose = autoClose;
            bw.RunWorkerAsync();
            frmWait.ShowDialog();
        }

        protected virtual void AsyncComplete()
        {

        }
        /// <summary>
        /// 更新进度条
        /// </summary>
        /// <param name="proccessIndex">进度条百分比1——100</param>
        protected void AsyncUpdateProcess(int proccessIndex)
        {
            bw.ReportProgress(proccessIndex);
        }

        /// <summary>
        /// 更新进度条，同时刷新主界面绑定
        /// </summary>
        /// <param name="msg">等待脚本</param>
        /// <param name="proccessIndex">进度条百分比1——100</param> 
        protected void AsyncUpdateProcess(string msg, int proccessIndex)
        {
            proccessmsg = msg;
            bw.ReportProgress(proccessIndex);
        }

        /// <summary>
        /// 更新进度条
        /// </summary>
        /// <param name="proccessIndex">进度条百分比1——100</param>
        /// <param name="updatehandle">主界面刷新UI委托</param>
        protected void AsyncUpdateProcess(int proccessIndex, AsyncUpdateUIHandler updatehandle)
        {
            thisUpdate = updatehandle;
            bw.ReportProgress(proccessIndex);
        }

        /// <summary>
        /// 更新进度条
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="proccessIndex">进度条百分比1——100</param>
        /// <param name="updatehandle">主界面刷新UI委托</param>
        protected void AsyncUpdateProcess(string msg, int proccessIndex, AsyncUpdateUIHandler updatehandle)
        {
            thisUpdate = updatehandle;
            proccessmsg = msg;
            bw.ReportProgress(proccessIndex);
        }
    }
}

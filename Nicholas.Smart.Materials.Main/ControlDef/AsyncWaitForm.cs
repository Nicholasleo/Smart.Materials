using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Nicholas.Smart.Materials.Main.ControlDef
{
    /// <summary>
    /// 此代理不能更新或访问任何UI控件
    /// </summary>
    /// <param name="frm"></param>
    public delegate void AsyncRunHandler(AsyncWaitForm frm);
    /// <summary>
    /// 此代理用来更新UI控件
    /// </summary>
    public delegate void CompletedHandler();

    public partial class AsyncWaitForm : XtraForm
    {
        private delegate void ChangeValueHandler(string msg, int progress);
        private delegate void ChangeMsgProgressHandler(string msg, int progess, bool close);

        private float closeTime = 0.6f;  //自动关闭时间 

        private volatile bool isRunning = false;  //是否正在运行
        private volatile bool autoClose = false; //是否完成后自动关闭
        private bool dialog;    //是否对话框
        private volatile bool actived = false;   //是否激活
        private string cruMessage = string.Empty;      //显示消息

        public string SuccessMsg = string.Empty; //执行任务成功后的消息 

        /// <summary>
        /// 是否正在运行
        /// </summary>
        public bool IsRunning
        {
            get { return isRunning; }
        }

        public AsyncWaitForm()
        {
            InitializeComponent();
        }


        #region 运行和释放
        void Run()
        {
            bool success = false;
            try
            {
                Invoke(new Action(() =>
                {
                    work(this);
                }));

                success = true;
            }
            catch (Exception ex)
            {
                Invoke(new ChangeMsgProgressHandler(Abort), ex.Message, 100, false);
            }
            if (success) Invoke(new CompletedHandler(ReleseForm));
        }

        private void ReleseForm()
        {
            bool success = false;
            try
            {
                Application.DoEvents();
                if (completed != null) completed();
                success = true;
            }
            catch (Exception ex)
            {
                timer.Enabled = false;
                Invoke(new ChangeMsgProgressHandler(Abort), ex.Message, 100, false);
            }
            if (success)
            {
                timer.Enabled = false;
                cruMessage = !string.IsNullOrEmpty(SuccessMsg) ? SuccessMsg : Text + " [完成]";
                Abort(cruMessage, 100, autoClose);
            }
        }

        void AutoCloseForm()
        {
            timer.Enabled = false;
            //Thread.Sleep(Convert.ToInt32(closeTime * 1000));
            if (actived)
            {
                Invoke(new CompletedHandler(
                    delegate
                    {
                        closeTime = 1f;

                        Close();
                    }));
            }
        }

        #endregion

        Thread t;
        int totalSencond = 1; //执行秒数
        private int totalCount = 0;//执行次数

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;

            TopMost = true;
            pgBar.Text = string.Format("2% (0秒)");
            cruMessage = string.Empty;
            SuccessMsg = string.Empty;
            Application.DoEvents();
            if (!dialog)
            {
                if (work != null)
                {
                    if (t != null) t.Abort();
                    t = null;
                    t = new Thread(Run) { IsBackground = true };
                    t.Start();
                }
                else
                {
                    ReleseForm();
                }
            }
            else if (autoClose)
            {
                if (t != null) t.Abort();
                t = null;
                t = new Thread(AutoCloseForm) { IsBackground = true };
                t.Start();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //instance.pgBar.Position = 0;
            isRunning = false;
            base.OnClosing(e);
        }
        protected override void OnClosed(EventArgs e)
        {
            actived = false;
            cruMessage = string.Empty;
            base.OnClosed(e);
        }

        #region 改变提示信息框的值与进度条
        private void Abort(string msg, int pvalue, bool close)
        {
            Instance.lblContent.Text = msg;
            //pgBar2.Position = pvalue;
            //pgBar2.Visible = close;

            pgBar.Text = string.Format("{0}%", pvalue);
            Application.DoEvents();
            pgBar.Visible = close;
            btnOK.Visible = !close;
            if (t != null)
            {
                t.Abort();
                t = null;
            }
            if (close)        //自动关闭
            {
                t = new Thread(AutoCloseForm) { IsBackground = true };
                t.Start();
            }
        }
        /// <summary>
        /// 设置显示消息
        /// </summary> 
        public static string ShowMessage
        {
            set
            {
                Instance.cruMessage = value;
            }
        }

        /// <summary>
        /// 更改提示消息与进度
        /// </summary> 
        /// <param name="progvalue"></param>
        public void SetMsgAndProgress(int progvalue)
        {
            SetMsgAndProgress(cruMessage, progvalue);
        }
        /// <summary>
        /// 更改提示消息与进度
        /// </summary>
        /// <param name="msg">显示的消息</param>
        /// <param name="progvalue"></param>
        public void SetMsgAndProgress(string msg, int progvalue)
        {
            cruMessage = msg;
            var chgMsg = new ChangeValueHandler(ChangeMsgAndProgress);
            Invoke(chgMsg, cruMessage, progvalue);
            Application.DoEvents();
        }

        void ChangeMsgAndProgress(string msg, int progress)
        {
            Application.DoEvents();
            lblContent.Text = msg;
            timerProgress = progress;
            Application.DoEvents();

        }

        #endregion

        private static object locObj = new object();
        private static AsyncRunHandler work;
        private static CompletedHandler completed;
        private readonly static AsyncWaitForm instance = new AsyncWaitForm();
        public static AsyncWaitForm Instance
        {
            get
            {
                lock (locObj)
                {
                    if (instance == null) return new AsyncWaitForm();
                    return instance;
                }
            }
        }

        #region 执行框口
        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="msg">消息</param>
        /// <param name="workMethod">执行方法，不能在此方法内改面Form控件值</param>
        /// <param name="completedMethod">完成方法，可以改变Form控件值</param> 
        public void AsyncShow(string title, string msg, AsyncRunHandler workMethod, CompletedHandler completedMethod)
        {
            AsyncShow(title, msg, workMethod, completedMethod, true);
        }
        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="msg">消息</param>
        /// <param name="workMethod">执行方法，不能在此方法内改面Form控件值</param>
        /// <param name="completedMethod">完成方法，可以改变Form控件值</param>
        /// <param name="enalbeCancel">是否允许停止</param>
        /// <param name="autoClose">是否自动关闭</param> 
        public void AsyncShow(string title, string msg, AsyncRunHandler workMethod, CompletedHandler completedMethod, bool autoClose)
        {
            AsyncShow(title, msg, workMethod, completedMethod, autoClose, 0);
        }
        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="msg">消息</param>
        /// <param name="workMethod">执行方法，不能在此方法内改面Form控件值</param>
        /// <param name="completedMethod">完成方法，可以改变Form控件值</param>
        /// <param name="enalbeCancel">是否允许停止</param>
        /// <param name="autoClose">是否自动关闭</param>
        /// <param name="time">停留多长时间</param> 
        public void AsyncShow(string title, string msg, AsyncRunHandler workMethod, CompletedHandler completedMethod, bool autoClose, float time)
        {
            try
            {
                if (Instance.actived) return;
                Instance.actived = true;
                work = null; completed = null;
                Instance.btnOK.Visible = false;
                instance.timerProgress = 2;
                Instance.timer.Enabled = true;
                Instance.timer.Interval = 200;
                //Instance.pgBar2.Visible = true; 
                Instance.pgBar.Visible = true;
                Instance.pgBar.Text = string.Format("2% (0秒)");
                Application.DoEvents();
                Instance.lblContent.Text = cruMessage = msg;

                Instance.totalSencond = 1;
                instance.totalCount = 0;

                Instance.dialog = false;
                Instance.closeTime = time;
                Instance.isRunning = true;
                Instance.Text = title;
                Instance.autoClose = autoClose;
                Application.DoEvents();
                work = workMethod;
                completed = completedMethod;

                Instance.ShowDialog();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (btnOK.Visible)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private int timerProgress = 2; //时间自动执行进度
        private void timer_Tick(object sender, EventArgs e)
        {
            Application.DoEvents();
            var time = string.Empty;
            if (totalCount % 5 == 0)
            {
                totalSencond++;
            }
            timerProgress += 1;

            if (timerProgress > 99)
            {
                timerProgress = 99;
            }
            if (totalSencond > 60)
            {
                var minute = totalSencond / 60;
                var second = totalSencond % 60;
                time = string.Format("({0}分{1}秒)", minute, second);
            }
            else if (totalSencond > 0)
            {
                time = string.Format("({0}秒)", totalSencond);
            }
            Application.DoEvents();
            pgBar.Text = string.Format("{0}% {1}", timerProgress, time);
            totalCount++;
            Application.DoEvents();
        }


    }
}

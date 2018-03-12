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

namespace Nicholas.Smart.Materials.Main
{
    public partial class FrmWaitDialog : XtraForm
    {
        private BackgroundWorker bw;
        public FrmWaitDialog()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            lblContent.Text = "系统正在加载数据，请稍后……";
            progressShow.Properties.Minimum = 0;
            progressShow.Properties.Maximum = 100;
            progressShow.Properties.Step = 10;
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            //支持撤销
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(Bw_DoWork);

            bw.ProgressChanged += Bw_ProgressChanged;
        }

        private bool autoIncrease = true;
        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (autoIncrease)
            {
                progressShow.PerformStep();
                this.Refresh();
                Application.DoEvents();
            }
        }
        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {

            while (autoIncrease)
            {
                if (progressShow.Position <= proccessIndexMax)
                {
                    var temp = progressShow.Position;
                    if (temp + 10 > proccessIndexMax) temp = proccessIndexMax;
                    bw.ReportProgress(temp + 10);
                    if (autoIncrease)
                        Thread.Sleep(200);
                }

            }
        }


        private int proccessIndexMax = 100;
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                //proccessIndexMax = 0;
                progressShow.Position = 0;
                autoIncrease = true;
                base.OnLoad(e);
                SetOkVisiable(false);
                bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                DialogMessagebox.ShowInfoError(ex.Message);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //if (progressShow.Position < proccessIndexMax) progressShow.Position = progressShow.Position;
            autoIncrease = false;
            Thread.Sleep(500);
            base.OnClosing(e);
        }

        #region Methods

        /// <summary>
        /// 设置描述
        /// </summary>
        /// <param name="newContent">提示内容</param>
        /// <param name="proccessIndex">1-100之间百分比</param>
        public void SetContent(string newContent, int proccessIndex)
        {
            //if (proccessIndexMax != 0 && proccessIndexMax <= proccessIndex)
            //{
            //    progressShow.Position = proccessIndexMax;
            //}
            proccessIndexMax = proccessIndex;
            if (proccessIndex > proccessIndexMax) proccessIndex = proccessIndexMax;
            progressShow.Position = proccessIndex;
            if (!string.IsNullOrEmpty(newContent))
                lblContent.Text = newContent;
            this.Refresh();
        }

        public void SetOkVisiable(bool visiable)
        {
            progressShow.Visible = !visiable;
            btnOK.Visible = visiable;
        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        } 
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nicholas.Smart.Materials.Enity;
using Timer = System.Windows.Forms.Timer;

namespace Nicholas.Smart.Materials.Main
{
    public partial class FrmBaseDev : FrmBasicDev
    {

        public FrmBaseDev()
        {
            InitializeComponent();

            this.KeyPreview = true;
            DoubleBuffered = true;
            Icon = Properties.Resources.load; 
        }

        private Timer _timer = new Timer();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitialForm();
            if (DesignMode) return;
            _timer.Interval = 200;
            _timer.Enabled = true;
            _timer.Tick += _timer_Tick;
        }

        private void _timer_Tick(object Sender, EventArgs e)
        {
            _timer.Enabled = false;
            Cursor.Current = Cursors.Default;
            DelayLoad();
        }

        protected virtual void DelayLoad()
        {

        }

        protected virtual void InitialForm()
        {
            this.KeyPreview = true;
            
        }



        #region

        protected override void OnClosed(EventArgs e)
        {
        }
        #endregion


        #region 图片加载

        

        #endregion
    }
}

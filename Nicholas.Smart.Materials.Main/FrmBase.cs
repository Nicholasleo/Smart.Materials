using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nicholas.Smart.Materials.Main
{
    public partial class FrmBase : Form
    {
        public FrmBase()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public virtual void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"确定关闭当前页面?", @"提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        public virtual void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public virtual void btnAdd_Click(object sender, EventArgs e)
        {

        }

        public virtual void btnEdit_Click(object sender, EventArgs e)
        {

        }

        public virtual void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void FrmBase_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }
        private Point mPoint = new Point();
        private void FrmBase_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            }
        }

        private void tsbMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void FrmBase_Load(object sender, EventArgs e)
        {

        }
    }
}

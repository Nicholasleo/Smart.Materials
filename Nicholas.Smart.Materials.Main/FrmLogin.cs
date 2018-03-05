using Nicholas.Smart.Materials.BLL;
using Nicholas.Smart.Materials.Enity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nicholas.Smart.Materials.Main
{
    public partial class FrmLogin : Form
    {
        private string pwstring = "输入密码";
        private string userstring = "输入用户名";

        public FrmLogin()
        {
            InitializeComponent();
            txtPwd.GotFocus += txtPwd_GotFocus;
            txtUserName.GotFocus += txtUserName_GotFocus;
            InitControl();
        }

        private void InitControl()
        {
            txtUserName.Text = userstring;
            txtUserName.ForeColor = Color.Gray;
            txtPwd.Text = pwstring;
            txtPwd.PasswordChar = '\0';
            txtPwd.ForeColor = Color.Gray;
        }

        private void txtPwd_GotFocus(object sender, EventArgs e)
        {
            txtPwd.PasswordChar = '*';
            if (txtPwd.Text.Trim() == pwstring)
            {
                txtPwd.Text = "";
                txtPwd.ForeColor = Color.Black;
            }
        }

        private void txtUserName_GotFocus(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == userstring)
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = Color.Black;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var result = new ResultMessage();
            string userName = txtUserName.Text.Trim();
            string password = txtPwd.Text.Trim();
            if (string.IsNullOrEmpty(userName) || userName == userstring)
            {
                MessageBox.Show(@"用户名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(password) || password == pwstring)
            {
                MessageBox.Show(@"密码不能为空！");
                return;
            }
            bool isRemember = cbRemember.Checked;
            if (isRemember)
            {
            }
#if DEBUG

            DialogResult = DialogResult.OK;
            return;
#endif

            LoginBLL _bll = new LoginBLL();
            result = _bll.CheckLogin(userName, password);
            Cursor.Current = Cursors.WaitCursor;
            if (result.ResultFlg)
            {
                MessageBox.Show(result.ResultMsg);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(result.ResultMsg);
                return;
            }
        }
    }
}

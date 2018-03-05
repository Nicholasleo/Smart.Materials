using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nicholas.Smart.Materials.Business;

namespace Nicholas.Smart.Materials.Reg
{
    public partial class FrmReg : Form
    {
        public FrmReg()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRegInfo.Text.Trim()))
            {
                MessageBox.Show(@"注册信息不能为空！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string filename = "";

            SystemRegInfo info = new SystemRegInfo();
            info.IsAuthorized = NicholasEncrypt.EncryptUTF8String("HasAuthorized", GetSystemInfo.EncrytionKey);
            info.RegKey = txtRegInfo.Text.Trim();
            info.StartDate = dtpStart.Value.ToString();
            info.EndDate = dtpEnd.Value.ToString();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = @"授权文件|*.leo";
            sfd.FileName = DateTime.Now.ToString("yyyyMMddhhmmss") + "系统授权";
            sfd.RestoreDirectory = true;
            sfd.CheckPathExists = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName;
                XmlHelper.CreateRegInfoXml(filename,info);
                //PiEncryptHelper.EncFile(filename);
                MessageBox.Show(@"生成成功！");
            }
        }

    }
}

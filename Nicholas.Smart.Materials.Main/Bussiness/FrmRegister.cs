using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nicholas.Smart.Materials.Business;

namespace Nicholas.Smart.Materials.Main.Bussiness
{
    public partial class FrmRegister : FrmBaseDev
    {
        public FrmRegister()
        {
            InitializeComponent();
        }
        private string _regPath = AppDomain.CurrentDomain.BaseDirectory + "SoftReg.leo";

        protected override void DelayLoad()
        {
            base.DelayLoad();
            InitRegInfo();
        }

        public bool RegSuccess = false;
        private void InitRegInfo()
        {
            txtRegInfo.Text = CheckRegInfo.AesLocalKey;
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = @"授权文件|*.leo";
                ofd.RestoreDirectory = true;
                ofd.FilterIndex = 1;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtRegFile.Text = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtRegFile.Text.Trim();
                PiEncryptHelper.DecFile(path);
                SystemRegInfo regInfo = XmlHelper.GetSystemRegInfo(path, "Software");
                PiEncryptHelper.EncFile(path);
                if (regInfo == null)
                {
                    MessageBox.Show(@"读取授权文件失败！", @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //DialogResult = DialogResult.OK;
                    RegSuccess = false;
                    return;
                }

                if (regInfo.RegKey != CheckRegInfo.AesLocalKey)
                {
                    MessageBox.Show(@"该授权文件无法在该电脑上激活！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //DialogResult = DialogResult.OK;
                    RegSuccess = false;
                    return;
                }

                DateTime endTime = Convert.ToDateTime(regInfo.EndDate);
                if (DateTime.Compare(endTime, DateTime.Now) < 0)
                {
                    MessageBox.Show(@"该授权文件已过期，请重新激活！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //DialogResult = DialogResult.OK;
                    RegSuccess = false;
                    return;
                }

                DateTime startTime = Convert.ToDateTime(regInfo.StartDate);
                if (DateTime.Compare(startTime, DateTime.Now) > 0)
                {
                    MessageBox.Show(@"检测到电脑系统时间不是北京时间，请将电脑时间调整到当前北京时间！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //DialogResult = DialogResult.OK;
                    RegSuccess = false;
                    return;
                }

                if (File.Exists(_regPath))
                {
                    PiEncryptHelper.DecFile(_regPath);
                    XmlHelper.Update(_regPath, regInfo);
                }
                else
                {
                    XmlHelper.CreateRegInfoXml(_regPath, regInfo);
                }

                RegisterClass.UpdateSubKey("Nicholas", NicholasEncrypt.EncryptUTF8String("0", GetSystemInfo.EncrytionKey));
                RegisterClass.UpdateSubKey("Leo", NicholasEncrypt.EncryptUTF8String("YES", GetSystemInfo.EncrytionKey));
                RegisterClass.UpdateSubKey("NicholasLeo", NicholasEncrypt.EncryptUTF8String("Due", GetSystemInfo.EncrytionKey));

                RegSuccess = true;
                PiEncryptHelper.EncFile(_regPath);

                MessageBox.Show(@"系统成功激活！");
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

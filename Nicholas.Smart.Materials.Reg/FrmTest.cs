using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Nicholas.Smart.Materials.Business;

namespace Nicholas.Smart.Materials.Reg
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.RestoreDirectory = true;
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }

            int x = 0;
            if (PiEncryptHelper.IsFileEnc(textBox1.Text, ref x))
            {
                label1.Text = string.Format(@"文件以加密，加密标识为：{0}", x);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PiEncryptHelper.EncFile(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PiEncryptHelper.DecFile(textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string t = textBox2.Text.Trim();
            string r = NicholasEncrypt.EncryptUTF8String(t, GetSystemInfo.EncrytionKey);
            textBox3.Text = r;
            label2.Text = NicholasEncrypt.DecryptUTF8String(r, GetSystemInfo.EncrytionKey);
            //label3.Text = NicholasEncrypt.EncryptString(CheckRegInfo.LocalKey, GetSystemInfo.EncrytionKey);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = "当前已使用了" + t++;
        }

        private long t = 1;

        private void FrmTest_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime nowTime = Convert.ToDateTime("2018-03-01 00:00:01");
            TimeSpan nowTs = new TimeSpan(nowTime.Ticks);
            DateTime endTime = Convert.ToDateTime("2018-03-02 23:59:59");
            TimeSpan endTs = new TimeSpan(endTime.Ticks);
            label4.Text = endTs.Subtract(nowTs).TotalSeconds.ToString();
        }
    }
}

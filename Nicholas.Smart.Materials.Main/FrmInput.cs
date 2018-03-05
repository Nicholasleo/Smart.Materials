using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nicholas.Smart.Materials.Main
{
    public partial class FrmInput : Form
    {
        public FrmInput()
        {
            InitializeComponent();
        }

        public string MyLen = "";


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show(@"请填写对应的长度");
                return;
            }
            MyLen = textBox1.Text.Trim();
            this.Close();
        }
    }
}

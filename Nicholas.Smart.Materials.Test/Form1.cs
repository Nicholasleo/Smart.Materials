using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nicholas.Smart.Materials.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = @"CAD文件|*.dwg";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtCadFile.Text = ofd.FileName;
                CadTest.FileName = ofd.FileName;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            CadTest.GetLayerPro();
        }
    }
}

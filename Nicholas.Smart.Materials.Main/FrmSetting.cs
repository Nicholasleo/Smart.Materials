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
using Nicholas.Smart.Materials.Enity;

namespace Nicholas.Smart.Materials.Main
{
    public partial class FrmSetting : FrmBase
    {
        private SystemConfigXml systemConfigXml = new SystemConfigXml();
        public FrmSetting()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            lbTitle.Text = @"系统参数设置";
            btnAdd.Text = @"保存";
            this.btnMin.Visible = this.btnMax.Visible = false;
            btnEdit.Visible = btnDel.Visible = false;
            GetConfig();
        }

        private void GetConfig()
        {
            string deviation = XmlHelper.Read(systemConfigXml.ConfigPath, "/SystemConfig/Deviation1", "");
            if (!string.IsNullOrEmpty(deviation))
            {
                txtWc1.Text = deviation.Trim();
            }
            deviation = XmlHelper.Read(systemConfigXml.ConfigPath, "/SystemConfig/Deviation2", "");
            if (!string.IsNullOrEmpty(deviation))
            {
                txtWc2.Text = deviation.Trim();
            }
            deviation = XmlHelper.Read(systemConfigXml.ConfigPath, "/SystemConfig/Deviation3", "");
            if (!string.IsNullOrEmpty(deviation))
            {
                txtWc3.Text = deviation.Trim();
            }
            string width = XmlHelper.Read(systemConfigXml.ConfigPath, "/SystemConfig/Width", "");
            if (!string.IsNullOrEmpty(width))
                txtArea.Text = width.Trim();
        }

        private void UpdateConfig()
        {
            XmlHelper.Update(systemConfigXml.ConfigPath, "/SystemConfig/Deviation1","",txtWc1.Text.Trim());
            XmlHelper.Update(systemConfigXml.ConfigPath, "/SystemConfig/Deviation2", "", txtWc2.Text.Trim());
            XmlHelper.Update(systemConfigXml.ConfigPath, "/SystemConfig/Deviation3", "", txtWc3.Text.Trim());

            XmlHelper.Update(systemConfigXml.ConfigPath, "/SystemConfig/Width", "", txtArea.Text.Trim());
        }

        public int Deviation1 = 0;
        public int Deviation2 = 0;
        public int Deviation3 = 0;

        public int Area = 1000;

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            string w = txtWc1.Text.Trim();
            if (string.IsNullOrEmpty(w))
                Deviation1 = 0;
            else
            {
                int.TryParse(w, out Deviation1);
            }
            w = txtWc2.Text.Trim();
            if (string.IsNullOrEmpty(w))
                Deviation2 = 0;
            else
            {
                int.TryParse(w, out Deviation2);
            }
            w = txtWc3.Text.Trim();
            if (string.IsNullOrEmpty(w))
                Deviation3 = 0;
            else
            {
                int.TryParse(w, out Deviation3);
            }
            
            string area = txtArea.Text.Trim();
            if (string.IsNullOrEmpty(area))
                Area = 1000;
            else
            {
                int.TryParse(area, out Area);
            }
            UpdateConfig();
            this.Close();
        }
    }
}

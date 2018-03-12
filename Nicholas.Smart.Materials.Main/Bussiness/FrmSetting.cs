using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Nicholas.Smart.Materials.Business;
using Nicholas.Smart.Materials.Enity;
using Nicholas.Smart.Materials.Main.ControlDef;

namespace Nicholas.Smart.Materials.Main.Bussiness
{
    public partial class FrmSetting : FrmBaseTool
    {
        public FrmSetting()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            btnAdd.Visibility = btnEdit.Visibility = btnImport.Visibility = BarItemVisibility.Never;
            btnRefresh.Caption = @"保存";
        }

        protected override void DelayLoad()
        {
            base.DelayLoad();
            BaseFunction.GetConfig();
            txtArea.Text = BaseFunction.Area.ToString();
        }

        private SystemConfigXml systemConfigXml = new SystemConfigXml();
        protected override void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            
            AsyncWaitForm.Instance.AsyncShow("设置系统", "正在保存结果",
            delegate(AsyncWaitForm exfrm)
            {
                exfrm.SetMsgAndProgress("正在保存", 10);
                string area = txtArea.Text.Trim();
                if (string.IsNullOrEmpty(area))
                    BaseFunction.Area = 1000;
                else
                {
                    int.TryParse(area, out BaseFunction.Area);
                }
                exfrm.SetMsgAndProgress("保存成功", 90);
            }, delegate
            {
                UpdateConfig();
                AsyncWaitForm.Instance.SetMsgAndProgress(100);
                DialogMessagebox.ShowInfo(@"保存成功");

            });
        }

        private void UpdateConfig()
        {
            //XmlHelper.Update(systemConfigXml.ConfigPath, "/SystemConfig/Deviation1", "", txtWc1.Text.Trim());
            //XmlHelper.Update(systemConfigXml.ConfigPath, "/SystemConfig/Deviation2", "", txtWc2.Text.Trim());
            //XmlHelper.Update(systemConfigXml.ConfigPath, "/SystemConfig/Deviation3", "", txtWc3.Text.Trim());

            XmlHelper.Update(systemConfigXml.ConfigPath, "/SystemConfig/Width", "", txtArea.Text.Trim());
        }

        //AsyncWaitForm.Instance.AsyncShow("开始计算", "正在进行排料计算",
        //        delegate(AsyncWaitForm exfrm)
        //        {
        //            exfrm.SetMsgAndProgress("正在进行排料计算", 10);
        //            exfrm.SetMsgAndProgress("计算完成", 90);
        //        }, delegate
        //        {
        //            AsyncWaitForm.Instance.SetMsgAndProgress(100);
                    
        //        });
    }
}

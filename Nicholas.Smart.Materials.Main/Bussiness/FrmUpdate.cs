using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Nicholas.Smart.Materials.Main.Bussiness
{
    public partial class FrmUpdate : FrmBaseDev
    {
        public FrmUpdate()
        {
            InitializeComponent();
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            lbVersion.Text = string.Format("当前系统版本为V{0}，目前系统最新版本为V{0}，目前没有最新的版本升级！", version);
        }
    }
}

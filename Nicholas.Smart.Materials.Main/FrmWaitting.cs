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
    public partial class FrmWaitting : Form
    {
        public FrmWaitting()
        {
            InitializeComponent();
        }
        public void SetNotifyInfo(int percent, string message)
        {
            this.lbMessage.Text = message;
            this.pbWait.Value = percent;
        } 
    }
}

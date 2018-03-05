using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Nicholas.Smart.Materials.Main
{
    public partial class FrmResult : FrmBase
    {
        private DataTable _dt = null;
        public FrmResult(DataTable dt)
        {
            InitializeComponent();
            
            this.WindowState = FormWindowState.Maximized;
            this.baseTool2.Visible = false;
            this._dt = dt;
        }

        private void FrmResult_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory + "Report/DataResult.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1",_dt));
            this.reportViewer1.RefreshReport();
        }
    }
}

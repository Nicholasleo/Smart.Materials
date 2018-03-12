using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Nicholas.Smart.Materials.Enity;
using Nicholas.Smart.Materials.Main.ControlDef;

namespace Nicholas.Smart.Materials.Main.Bussiness
{
    public partial class FrmEditPofile : FrmBaseTool
    {
        public FrmEditPofile()
        {
            InitializeComponent();
        }

        public FrmEditPofile(Ent2 ent, DataTable source, bool isEdit)
        {
            InitializeComponent();
            this._myEnt = ent;
            this._isEdit = isEdit;
            ResultTable = source.Copy();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private Ent2 _myEnt;

        private bool _isEdit;

        public DataTable ResultTable;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            btnAdd.Caption = @"保存";
            btnEdit.Visibility = btnImport.Visibility = btnRefresh.Visibility = BarItemVisibility.Never;
        }

        private void LoadData()
        {
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
        protected override void DelayLoad()
        {
            base.DelayLoad();
            this.Text = @"型材添加";
            this.txtDepth.Focus();
            if (_isEdit)
            {
                this.Text = @"型材编辑";
                this.txtkey.ReadOnly = this.txtDepth.ReadOnly = true;
                this.txtkey.Text = _myEnt.Key;
                this.txtArea.Text = _myEnt.MyEnt.Area.ToString();
                this.txtLength.Text = _myEnt.MyEnt.Length.ToString();
                this.txtQty.Text = _myEnt.MyEnt.Qty.ToString();
                this.txtDepth.Text = _myEnt.MyEnt.Depth;
                this.txtQty.Focus();
            }
        }

        protected override void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            base.btnAdd_ItemClick(sender, e);
            try
            {
                string key = txtkey.Text;
                int length = 0;
                int area = 0;
                int qty = 0;
                if (string.IsNullOrEmpty(txtkey.Text))
                {
                    MessageBox.Show(@"所属板材不能为空！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (string.IsNullOrEmpty(txtArea.Text))
                {
                    MessageBox.Show(@"型材面积不能为空！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (string.IsNullOrEmpty(txtLength.Text))
                {
                    MessageBox.Show(@"型材长度不能为空！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (string.IsNullOrEmpty(txtQty.Text))
                {
                    MessageBox.Show(@"型材数量不能为空！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                int.TryParse(txtArea.Text.Trim(), out area);
                int.TryParse(txtLength.Text.Trim(), out length);
                int.TryParse(txtQty.Text.Trim(), out qty);
                if (!_isEdit)
                {
                    _myEnt = new Ent2();
                    Ent1 ent1 = new Ent1();
                    ent1.Qty = qty;
                    ent1.Length = length;
                    ent1.Area = area;
                    ent1.Depth = txtDepth.Text.Trim();
                    _myEnt.Key = txtkey.Text.Trim().ToUpper();
                    _myEnt.MyEnt = ent1;
                    DataRow newRow = ResultTable.NewRow();
                    newRow["Key"] = _myEnt.Key;
                    newRow["Key1"] = _myEnt.Key;
                    if (_myEnt.Area == 0)
                        _myEnt.Area = _myEnt.MyEnt.Area * _myEnt.MyEnt.Qty;
                    newRow["AreaSum"] = _myEnt.Area;
                    newRow["Length"] = _myEnt.MyEnt.Length;
                    newRow["Qty"] = _myEnt.MyEnt.Qty;
                    newRow["Area"] = _myEnt.MyEnt.Area;
                    newRow["Depth"] = _myEnt.MyEnt.Depth;
                    ResultTable.Rows.Add(newRow);
                }
                else
                {
                    DataRow[] rows =
                        ResultTable.Select(string.Format("Depth = '{4}' AND Key='{0}' AND Length={1} AND Qty={2} AND Area={3}"
                            , _myEnt.Key, _myEnt.MyEnt.Length, _myEnt.MyEnt.Qty, _myEnt.MyEnt.Area,_myEnt.MyEnt.Depth));
                    foreach (var row in rows)
                    {
                        row["Key"] = _myEnt.Key.ToUpper();
                        row["AreaSum"] = area * qty;
                        row["Length"] = length;
                        row["Qty"] = qty;
                        row["Area"] = area;
                        row["Depth"] = txtDepth.Text.Trim();
                    }
                }
                DataView dv = ResultTable.DefaultView;
                dv.Sort = "Key Asc,Length Desc";
                ResultTable = dv.ToTable();
                DataRow[] tempRows = ResultTable.Select(string.Format("Key='{0}'", _myEnt.Key));
                int totalArea = 0;
                foreach (var row in tempRows)
                {
                    totalArea += Convert.ToInt32(row["Qty"]) * Convert.ToInt32(row["Area"]);
                    row["AreaSum"] = totalArea;
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            ////限制只能输入数字，Backspace键，小数点
            //if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            //{
            //    e.Handled = true;  //非以上键则禁止输入
            //}
            //限制只能输入数字
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  //非以上键则禁止输入
            }
        }
    }
}

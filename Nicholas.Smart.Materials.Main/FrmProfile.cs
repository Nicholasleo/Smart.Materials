using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nicholas.Smart.Materials.Enity;

namespace Nicholas.Smart.Materials.Main
{
    public partial class FrmProfile : FrmBase
    {
        public FrmProfile()
        {
            InitializeComponent();
        }

        private Ent2 _myEnt;

        private bool _isEdit;

        public DataTable ResultTable;

        public FrmProfile(Ent2 ent,DataTable source, bool isEdit)
        {
            InitializeComponent();
            btnAdd.Text = @"保存";
            btnEdit.Visible = btnDel.Visible = false;
            this.btnMin.Visible = this.btnMax.Visible = false;
            this.lbTitle.Text = @"型材添加";
            this._myEnt = ent;
            this._isEdit = isEdit;
            ResultTable = source.Copy();
            if (isEdit)
            {
                this.lbTitle.Text = @"型材编辑";
                this.txtkey.ReadOnly = true;
                this.txtkey.Text = ent.Key;
                this.txtArea.Text = ent.MyEnt.Area.ToString();
                this.txtLength.Text = ent.MyEnt.Length.ToString();
                this.txtQty.Text = ent.MyEnt.Qty.ToString();
            }
        }


        public override void btnAdd_Click(object sender, EventArgs e)
        {
            
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
                    ResultTable.Rows.Add(newRow);
                }
                else
                {
                    DataRow[] rows =
                        ResultTable.Select(string.Format("Key='{0}' AND Length={1} AND Qty={2} AND Area={3}"
                            , _myEnt.Key, _myEnt.MyEnt.Length, _myEnt.MyEnt.Qty, _myEnt.MyEnt.Area));
                    foreach (var row in rows)
                    {
                        row["Key"] = _myEnt.Key.ToUpper();
                        row["AreaSum"] = area *  qty;
                        row["Length"] = length;
                        row["Qty"] = qty;
                        row["Area"] = area;
                    }
                }
                DataView dv = ResultTable.DefaultView;
                dv.Sort = "Key Asc,Length Desc";
                ResultTable = dv.ToTable();
                DataRow[] tempRows = ResultTable.Select(string.Format("Key='{0}'", _myEnt.Key));
                int totalArea = 0;
                foreach (var row in tempRows)
                {
                    totalArea += Convert.ToInt32(row["Qty"])*Convert.ToInt32(row["Area"]);
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

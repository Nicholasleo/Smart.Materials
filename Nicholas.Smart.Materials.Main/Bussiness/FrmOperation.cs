using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraRichEdit.API.Word;
using Nicholas.Smart.Materials.Business;
using Nicholas.Smart.Materials.Enity;
using Nicholas.Smart.Materials.Main.ControlDef;
using Nicholas.Smart.Materials.Main.Properties;

namespace Nicholas.Smart.Materials.Main.Bussiness
{
    public partial class FrmOperation : FrmBaseTool
    {
        private DataTable dtSource = new DataTable("MyData");

        public FrmOperation()
        {
            InitializeComponent();
        }

        public DataTable ResultTable = new DataTable();
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            btnRefresh.Caption = @"清空数据";
            btnAdd.Caption = @"开始计算";
            btnEdit.Caption = @"打印结果";
            btnImport.Visibility = BarItemVisibility.Never;
            //btnImport.Caption = @"导入计算数据";
            dgvSource.KeyDown += dgvSource_KeyDown;

            //var batchImport = new BarButtonItem
            //{
            //    Caption = @"批量启用/禁用",
            //    CausesValidation = true,
            //    Glyph = Resources.,
            //    PaintStyle = BarItemPaintStyle.CaptionGlyph
            //};

        }

        private void InitSourceView()
        {
            DataColumn dc = new DataColumn();
            dc.Caption = "材料长度";
            dc.ColumnName = "Length";
            dc.DataType = Type.GetType("System.Int32");
            dtSource.Columns.Add(dc);
            dc = new DataColumn();
            dc.Caption = "材料数量";
            dc.ColumnName = "Qty";
            dc.DataType = Type.GetType("System.Int32");
            dtSource.Columns.Add(dc);
            dc = new DataColumn();
            dc.Caption = "材料展开面积";
            dc.ColumnName = "Area";
            dc.DataType = Type.GetType("System.Int32");
            dtSource.Columns.Add(dc);
            dc = new DataColumn();
            dc.Caption = "型材厚度";
            dc.ColumnName = "Depth";
            dc.DataType = Type.GetType("System.String");
            dtSource.Columns.Add(dc);
#if DEBUG
            DataRow newRow;
            newRow = dtSource.NewRow();
            newRow["Length"] = 2840;
            newRow["Area"] = 68;
            newRow["Qty"] = 3;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2740;
            newRow["Area"] = 130;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2420;
            newRow["Area"] = 85;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2420;
            newRow["Area"] = 56;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2420;
            newRow["Area"] = 119;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2420;
            newRow["Area"] = 181;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2370;
            newRow["Area"] = 120;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2370;
            newRow["Area"] = 180;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2420;
            newRow["Area"] = 197;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2370;
            newRow["Area"] = 172;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2370;
            newRow["Area"] = 218;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2370;
            newRow["Area"] = 389;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2390;
            newRow["Area"] = 180;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2390;
            newRow["Area"] = 216;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2390;
            newRow["Area"] = 395;
            newRow["Qty"] = 1;
            dtSource.Rows.Add(newRow);


            newRow = dtSource.NewRow();
            newRow["Length"] = 2390;
            newRow["Area"] = 395;
            newRow["Qty"] = 1;
            dtSource.Rows.Add(newRow);


            newRow = dtSource.NewRow();
            newRow["Length"] = 3400;
            newRow["Area"] = 169;
            newRow["Qty"] = 1;
            dtSource.Rows.Add(newRow);


            newRow = dtSource.NewRow();
            newRow["Length"] = 3400;
            newRow["Area"] = 225;
            newRow["Qty"] = 1;
            dtSource.Rows.Add(newRow);


            newRow = dtSource.NewRow();
            newRow["Length"] = 1800;
            newRow["Area"] = 250;
            newRow["Qty"] = 4;
            dtSource.Rows.Add(newRow);


            newRow = dtSource.NewRow();
            newRow["Length"] = 1860;
            newRow["Area"] = 258;
            newRow["Qty"] = 3;
            dtSource.Rows.Add(newRow);


            newRow = dtSource.NewRow();
            newRow["Length"] = 1860;
            newRow["Area"] = 78;
            newRow["Qty"] = 5;
            dtSource.Rows.Add(newRow);


            newRow = dtSource.NewRow();
            newRow["Length"] = 1800;
            newRow["Area"] = 128;
            newRow["Qty"] = 1;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 1620;
            newRow["Area"] = 34;
            newRow["Qty"] = 6;
            dtSource.Rows.Add(newRow);


            newRow = dtSource.NewRow();
            newRow["Length"] = 1620;
            newRow["Area"] = 63;
            newRow["Qty"] = 6;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 1620;
            newRow["Area"] = 46;
            newRow["Qty"] = 6;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 1800;
            newRow["Area"] = 197;
            newRow["Qty"] = 1;
            dtSource.Rows.Add(newRow);
#endif
            dgvSource.DataSource = dtSource;
            dgvSource.KeyDown += dgvSource_KeyDown;
            dgvSource.AutoGenerateColumns = true;
            NoSortable();
            dgvSource.SummaryColumns = new string[] { "Qty" };
            if (dgvSource.Columns.Contains("Length"))
            {
                dgvSource.Columns["Length"].HeaderText = @"型材长度";
            }
            if (dgvSource.Columns.Contains("Qty"))
            {
                dgvSource.Columns["Qty"].HeaderText = @"型材数量";
            }
            if (dgvSource.Columns.Contains("Area"))
            {
                dgvSource.Columns["Area"].HeaderText = @"型材面积";
            }
            if (dgvSource.Columns.Contains("Depth"))
            {
                dgvSource.Columns["Depth"].HeaderText = @"型材厚度";
            }
        }
        private void NoSortable()
        {
            for (int i = 0; i < this.dgvSource.Columns.Count; i++)
            {
                dgvSource.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void InitResultView()
        {
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Depth";
            dc.Caption = "厚薄度";
            dc.DataType = Type.GetType("System.String");
            ResultTable.Columns.Add(dc); 
            
            dc = new DataColumn();
            dc.ColumnName = "Key";
            dc.Caption = "板材标识";
            dc.DataType = Type.GetType("System.String");
            ResultTable.Columns.Add(dc);


            dc = new DataColumn();
            dc.ColumnName = "Length";
            dc.Caption = "型材长度";
            dc.DataType = Type.GetType("System.Int32");
            ResultTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Qty";
            dc.Caption = "型材标识";
            dc.DataType = Type.GetType("System.Int32");
            ResultTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Area";
            dc.Caption = "型材面积";
            dc.DataType = Type.GetType("System.Int32");
            ResultTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "AreaSum";
            dc.Caption = "面积合计";
            dc.DataType = Type.GetType("System.Int32");
            ResultTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Key1";
            dc.Caption = "Key1";
            dc.DataType = Type.GetType("System.String");
            ResultTable.Columns.Add(dc);

            gvResult.BeginInit();
            gvResult.Columns.Clear();
            gvResult.BeginUpdate();
            gvResult.BeginDataUpdate();
            this.gcResult.DataSource = ResultTable;

            gvResult.BeginInit();
            if (ResultTable.Columns.Contains("Key1"))
            {
                gvResult.Columns["Key1"].Visible = false;
            }
            if (ResultTable.Columns.Contains("Key"))
            {
                gvResult.Columns["Key"].OptionsColumn.ShowCaption = true;
            }
            if (ResultTable.Columns.Contains("Depth"))
            {
                gvResult.Columns["Depth"].OptionsColumn.ShowCaption = true;
            }
            if (ResultTable.Columns.Contains("Length"))
            {
                gvResult.Columns["Length"].OptionsColumn.ShowCaption = true;
            }
            if (ResultTable.Columns.Contains("Qty"))
            {
                gvResult.Columns["Qty"].OptionsColumn.ShowCaption = true;
            }
            if (ResultTable.Columns.Contains("AreaSum"))
            {
                gvResult.Columns["AreaSum"].OptionsColumn.ShowCaption = true;
            }
            if (ResultTable.Columns.Contains("Area"))
            {
                gvResult.Columns["Area"].OptionsColumn.ShowCaption = true;
            }

            gvResult.OptionsView.AllowCellMerge = true;
            foreach (DataColumn col in ResultTable.Columns)
            {
                if (col.ColumnName != "Key" && col.ColumnName != "Depth")
                    gvResult.Columns[col.ColumnName].OptionsColumn.AllowMerge = DefaultBoolean.False;

                gvResult.Columns[col.ColumnName].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
            gvResult.OptionsBehavior.Editable = false;

            gvResult.Appearance.OddRow.BackColor = Color.White;

            gvResult.BestFitColumns();
            gvResult.EndDataUpdate();
            gvResult.EndUpdate();
            gvResult.EndInit();
        }

        protected override void DelayLoad()
        {
            base.DelayLoad();
            InitSourceView();
            InitResultView();
        }

        #region 复制粘贴删除

        private void dgvSource_KeyDown(object sender, KeyEventArgs e)
        {

            //粘贴
            if (System.Windows.Forms.Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.V)
            {
                if (sender != null && sender.GetType() == typeof(DataGridViewSummary))
                {
                    DataGridViewCellPaste((DataGridViewSummary)sender);
                    //Total((DataGridViewSummary)sender);
                }
            }

            //复制
            if (System.Windows.Forms.Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.C)
            {
                if (sender != null && sender.GetType() == typeof(DataGridViewSummary))
                {
                    DataGridViewCellCopy((DataGridViewSummary)sender);
                }
            }

            //删除
            if (System.Windows.Forms.Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Delete)
            {
                if (sender != null && sender.GetType() == typeof(DataGridViewSummary))
                {
                    DataGridViewDelete((DataGridViewSummary)sender);
                }
            }
            //NoSortable();
        }

        //粘贴
        private void DataGridViewCellPaste(DataGridViewSummary dbView)
        {
            try
            {
                dtSource.Rows.Clear();
                // 获取剪切板的内容，并按行分割
                string pasteText = Clipboard.GetText();
                if (string.IsNullOrEmpty(pasteText))
                    return;
                string[] lines = pasteText.Split(new char[] { '\n' });
                foreach (string line in lines)
                {
                    if (string.IsNullOrEmpty(line.Trim()))
                        continue;
                    string[] vals = line.Split('\t');
                    if (string.IsNullOrEmpty(vals[1]))
                        continue;
                    DataRow ndr = dtSource.NewRow();
                    ndr.ItemArray = vals;
                    dtSource.Rows.Add(ndr);
                }
                dbView.DataSource = dtSource;

            }
            catch (Exception ex)
            {
            }
        }

        //复制
        private void DataGridViewCellCopy(DataGridViewSummary dbView)
        {
            try
            {
                if (dbView.GetCellCount(DataGridViewElementStates.Selected) > 0)
                {
                    try
                    {
                        Clipboard.SetDataObject(dbView.GetClipboardContent());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //删除
        private void DataGridViewDelete(DataGridViewSummary dbView)
        {
            try
            {
                int k = dbView.SelectedRows.Count;
                if (MessageBox.Show("确实要删除这" + Convert.ToString(k) + "项吗？", "系统提示") == DialogResult.No)
                {

                }
                else
                {
                    if (k != dbView.Rows.Count - 2)
                    {
                        for (int i = k; i >= 1; i--)
                        {
                            dbView.Rows.RemoveAt(dbView.SelectedRows[i - 1].Index);
                        }
                    }
                    else
                    {
                        dbView.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        private void CheckReg()
        {
            bool _isReg = true;
            string _errorInfo;
            int _infoType;
            bool isTrial = false;
            CheckRegInfo.CheckReg(ref _isReg, out _errorInfo, out _infoType, out isTrial);
            if (isTrial)
            {
                MessageBox.Show(string.Format(@"当前版本为试用版，可免费试用{0}次！", 11 - CheckRegInfo.GetLoginTimes()), @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (!_isReg)
            {
                MessageBox.Show(_errorInfo, @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var frm = new FrmRegister();
                DialogResult loginDiaSul = frm.ShowDialog();
                if (loginDiaSul == DialogResult.OK)
                {
                    _isReg = frm.RegSuccess;
                    frm.Dispose();
                    if (_isReg)
                    {
                        return;
                    }
                }
            }
        }
        private List<Ent1> entList = new List<Ent1>();
        private List<Ent2> result;

        /// <summary>
        /// 开始计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                #if !DEBUG
                CheckReg();
                #endif

                BaseFunction.GetConfig();
                entList = new List<Ent1>();
                dgvSource.EndEdit();
                int n = dgvSource.RowCount - 1;
                for (int i = 0; i < n; i++)
                {
                    Ent1 ent1 = new Ent1();
                    int length = 0;
                    int qty = 0;
                    int area = 0;
                    int.TryParse(dgvSource.Rows[i].Cells["Length"].Value == null ? "0" : dgvSource.Rows[i].Cells["Length"].Value.ToString(), out length);
                    int.TryParse(dgvSource.Rows[i].Cells["Qty"].Value == null ? "0" : dgvSource.Rows[i].Cells["Qty"].Value.ToString(), out qty);
                    int.TryParse(dgvSource.Rows[i].Cells["Area"].Value == null ? "0" : dgvSource.Rows[i].Cells["Area"].Value.ToString(), out area);
                    string depth = Convert.ToString(dgvSource.Rows[i].Cells["Depth"].Value);
                    ent1.Length = length;
                    ent1.Area = area;
                    ent1.Qty = qty;
                    ent1.Depth = depth;
                    if (length + area + qty == 0)
                        continue;
                    entList.Add(ent1);
                }
                if (entList == null || entList.Count <= 0)
                {
                    MessageBox.Show(@"数据有误！");
                    return;
                }

                LoadDataAysnc();
            }
            catch (Exception ex)
            {
                DialogMessagebox.ShowInfoError(ex.Message);
            }
        }

        /// <summary>
        /// 计算
        /// </summary>
        private void LoadDataAysnc()
        {
            AsyncWaitForm.Instance.AsyncShow("开始计算", "正在进行排料计算",
                delegate(AsyncWaitForm exfrm)
                {
                    exfrm.SetMsgAndProgress("正在进行排料计算", 10);
                    result = MaterialsBacktrack.CountList(entList);
                    if (result.Count < 0)
                        return;
                    ResultTable.Clear();
                    exfrm.SetMsgAndProgress("计算完成", 90);
                }, delegate
                {
                    AsyncWaitForm.Instance.SetMsgAndProgress(100);
                    foreach (var ent2 in result)
                    {
                        if (ent2.MyEnt.Qty <= 0)
                            continue;
                        DataRow newRow = ResultTable.NewRow();
                        newRow["Key"] = ent2.Key;
                        newRow["Key1"] = ent2.Key;
                        if (ent2.Area == 0)
                            ent2.Area = ent2.MyEnt.Area * ent2.MyEnt.Qty;
                        newRow["AreaSum"] = ent2.Area;
                        newRow["Length"] = ent2.MyEnt.Length;
                        newRow["Qty"] = ent2.MyEnt.Qty;
                        newRow["Area"] = ent2.MyEnt.Area;
                        newRow["Depth"] = ent2.MyEnt.Depth;
                        ResultTable.Rows.Add(newRow);
                        //lbView.Items.Add(ent2.MainKey + ":" + ent2.MyEnt.Length + "_" + ent2.MyEnt.Qty + "条" + "_" + ent2.MyEnt.Area);
                    }

                    gcResult.DataSource = ResultTable;
                    SetSumColumns();
                });
            //result = CountList(entList);
            //lbView.Items.Clear();
            
        }

        private void SetSumColumns()
        {
            gvResult.Columns["Qty"].SummaryItem.SummaryType = SummaryItemType.Sum;
            gvResult.Columns["Qty"].SummaryItem.DisplayFormat = @"合计：{0}";
            
        }

        /// <summary>
        /// 打印结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ResultTable.Rows.Count <= 0)
                return;
            foreach (DataRow row in ResultTable.Rows)
            {
                row["Key1"] = AppDomain.CurrentDomain.BaseDirectory + "MaterialsImg\\" + row["Area"] + ".png";
            }
            var frm = new FrmResult(ResultTable);
            frm.ShowDialog();
            frm.Dispose();
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dtSource.Rows.Count <= 0)
                return;
            dtSource.Rows.Clear();
        }

        protected override void btnImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            base.btnImport_ItemClick(sender, e);
        }

        private void dgvResult_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //Brush gridBrush = new SolidBrush(this.dgvResult.GridColor);
            //SolidBrush backBrush = new SolidBrush(e.CellStyle.BackColor);
            //SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
            //int cellheight;
            //int fontheight;
            //int cellwidth;
            //int fontwidth;
            //int countU = 0;
            //int countD = 0;
            //int count = 0;
            //if (e.Value == null)
            //    return;
            //// 对第1列相同单元格进行合并
            //if (e.ColumnIndex == 0 && e.RowIndex != -1)
            //{
            //    cellheight = e.CellBounds.Height;
            //    fontheight = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Height;
            //    cellwidth = e.CellBounds.Width;
            //    fontwidth = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
            //    Pen gridLinePen = new Pen(gridBrush, 5);
            //    string curValue = e.Value == null ? "" : e.Value.ToString().Trim();
            //    string curSelected = this.dgvResult.Rows[e.RowIndex].Cells[0].Value == null ? ""
            //        : this.dgvResult.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            //    if (!string.IsNullOrEmpty(curValue))
            //    {

            //        for (int i = e.RowIndex; i < this.dgvResult.Rows.Count; i++)
            //        {
            //            if (this.dgvResult.Rows[i].Cells[0].Value != null)
            //            {
            //                if (this.dgvResult.Rows[i].Cells[0].Value.ToString().Equals(curValue))
            //                {
            //                    this.dgvResult.Rows[i].Cells[0].Selected = this.dgvResult.Rows[e.RowIndex].Selected;
            //                    this.dgvResult.Rows[i].Selected = this.dgvResult.Rows[e.RowIndex].Selected;

            //                    countD++;

            //                }

            //                else
            //                {
            //                    break;
            //                }
            //            }
            //        }
            //        for (int i = e.RowIndex; i >= 0; i--)
            //        {
            //            if (this.dgvResult.Rows[i].Cells[0].Value.ToString().Equals(curValue))
            //            {
            //                this.dgvResult.Rows[i].Cells[0].Selected = this.dgvResult.Rows[e.RowIndex].Selected;

            //                this.dgvResult.Rows[i].Selected = this.dgvResult.Rows[e.RowIndex].Selected;

            //                countU++;
            //            }
            //            else
            //            {
            //                break;
            //            }
            //        }

            //        count = countD + countU - 1;
            //        if (count < 2) { return; }
            //    }

            //    if (this.dgvResult.Rows[e.RowIndex].Selected)
            //    {
            //        backBrush.Color = e.CellStyle.SelectionBackColor;
            //        fontBrush.Color = e.CellStyle.SelectionForeColor;
            //    }

            //    e.Graphics.FillRectangle(backBrush, e.CellBounds);
            //    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (countU - 1) + (cellheight * count - fontheight) / 2);

            //    if (countD == 1)
            //    {
            //        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
            //        count = 0;
            //    }

            //    // 画右边线
            //    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

            //    e.Handled = true;
            //}
        }

        private void btnAddProfile_Click(object sender, EventArgs e)
        {
            try
            {
                int index = gvResult.FocusedRowHandle;
                if (index < 0)
                {
                    MessageBox.Show(@"请选择需要添加的板材", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Ent2 ent = new Ent2();
                    ent.Key = gvResult.GetRowCellValue(index,"Key").ToString();
                    Ent1 ent1 = new Ent1();
                    ent1.Length = Convert.ToInt32(gvResult.GetRowCellValue(index,"Length").ToString());
                    ent1.Qty = Convert.ToInt32(gvResult.GetRowCellValue(index,"Qty").ToString());
                    ent1.Area = Convert.ToInt32(gvResult.GetRowCellValue(index, "Area").ToString());
                    ent1.Depth = gvResult.GetRowCellValue(index, "Depth").ToString();
                    ent.MyEnt = ent1;
                    var frm = new FrmEditPofile(ent, ResultTable, false);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (frm.ResultTable != null)
                            ResultTable = frm.ResultTable;
                        gcResult.DataSource = ResultTable;
                    }
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            try
            {
                int index = gvResult.FocusedRowHandle;
                if (index < 0)
                {
                    MessageBox.Show(@"请选择需要修改的板材", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Ent2 ent = new Ent2();
                    ent.Key = gvResult.GetRowCellValue(index, "Key").ToString();
                    Ent1 ent1 = new Ent1();
                    ent1.Length = Convert.ToInt32(gvResult.GetRowCellValue(index, "Length").ToString());
                    ent1.Qty = Convert.ToInt32(gvResult.GetRowCellValue(index, "Qty").ToString());
                    ent1.Area = Convert.ToInt32(gvResult.GetRowCellValue(index, "Area").ToString());
                    ent1.Depth = gvResult.GetRowCellValue(index, "Depth").ToString();
                    ent.MyEnt = ent1;
                    var frm = new FrmEditPofile(ent, ResultTable, true);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (frm.ResultTable != null)
                            ResultTable = frm.ResultTable;
                        gcResult.DataSource = ResultTable;
                    }
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string imageConfig = AppDomain.CurrentDomain.BaseDirectory + "ImageConfig.xml";
        private void btnDelProfile_Click (object sender, EventArgs e)
        {
            try
            {
                int index = gvResult.FocusedRowHandle;
                if (index < 0)
                {
                    MessageBox.Show(@"请选择需要删除的板材", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Ent2 ent = new Ent2();
                    ent.Key = gvResult.GetRowCellValue(index, "Key").ToString();
                    Ent1 ent1 = new Ent1();
                    ent1.Length = Convert.ToInt32(gvResult.GetRowCellValue(index, "Length").ToString());
                    ent1.Qty = Convert.ToInt32(gvResult.GetRowCellValue(index, "Qty").ToString());
                    ent1.Area = Convert.ToInt32(gvResult.GetRowCellValue(index, "Area").ToString());
                    ent1.Depth = gvResult.GetRowCellValue(index, "Depth").ToString();
                    ent.MyEnt = ent1;
                    string info = string.Format("确定要删除{0}中长度为【{1}】mm，面积为：【{2}】mm的【{3}】条型材？", ent.Key, ent.MyEnt.Length, ent.MyEnt.Area, ent.MyEnt.Qty);
                    if (MessageBox.Show(info, @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                        DialogResult.Yes)
                    {
                        for (int i = 0; i < ResultTable.Rows.Count; i++)
                        {
                            if (ResultTable.Rows[i]["Key"].ToString() == ent.Key && ResultTable.Rows[i]["Length"].ToString() == ent.MyEnt.Length.ToString()
                                    && ResultTable.Rows[i]["Area"].ToString() == ent.MyEnt.Area.ToString() && ResultTable.Rows[i]["Qty"].ToString() == ent.MyEnt.Qty.ToString())
                            {
                                ResultTable.Rows.RemoveAt(i);
                                ResultTable.AcceptChanges();
                                break;
                            }
                        }
                        DataRow[] tempRows = ResultTable.Select(string.Format("Key='{0}'", ent.Key));
                        int totalArea = 0;
                        foreach (var row in tempRows)
                        {
                            totalArea += Convert.ToInt32(row["Qty"]) * Convert.ToInt32(row["Area"]);
                            row["AreaSum"] = totalArea;
                        }
                        gcResult.DataSource = ResultTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvResult_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            //if (e.Column.FieldName != "Key")
            //{
            //    e.Merge = false;
            //    e.Handled = true;
            //}
            //if (e.Column.FieldName != "Depth")
            //{
            //    e.Merge = false;
            //    e.Handled = true;
            //}
        }

        private void gvResult_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView gv = sender as GridView;
            if (e.RowHandle >= 0)
            {
                int index = Convert.ToInt32(gv.GetRowCellDisplayText(e.RowHandle, "Key").Replace("BC", ""));
                if (index%2 == 0)
                {
                    e.Appearance.BackColor = Color.Gainsboro;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                }
            }
        }


    }
}

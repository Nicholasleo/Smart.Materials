using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Nicholas.Smart.Materials.Business;
using Nicholas.Smart.Materials.Enity;
using Nicholas.Smart.Materials.Main.Edit;
using System.Data;
using System.Drawing;

namespace Nicholas.Smart.Materials.Main
{
    public partial class FrmMain : Form
    {


        private DataTable dtSource = new DataTable("MyData");


        public FrmMain()
        {
            InitializeComponent();
            pageMaterial.Parent = null;
            pageHand.Parent = tclMain;
            GetConfig();
            this.Width = Screen.PrimaryScreen.Bounds.Width - 300;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 150;
            this.WindowState = FormWindowState.Maximized;

            //this.btnDelProfile.Visible = false;
            this.lbSettingInfo.Text = @"当前系统计算的板宽为：【" + _area + @"mm】";
        }


        protected override void OnShown(EventArgs e)
        {
            this.btnMain.Visible = false;

            ResultTable.Columns.Add("Key", Type.GetType("System.String"));
            ResultTable.Columns.Add("Length", Type.GetType("System.Int32"));
            ResultTable.Columns.Add("Qty", Type.GetType("System.Int32"));
            ResultTable.Columns.Add("Area", Type.GetType("System.Int32"));
            ResultTable.Columns.Add("AreaSum", Type.GetType("System.Int32"));
            ResultTable.Columns.Add("Key1", Type.GetType("System.String"));
            this.dgvResult.DataSource = ResultTable; 
            if (dgvResult.Columns.Contains("Key1"))
            {
                dgvResult.Columns["Key1"].Visible = false;
            }
            if (dgvResult.Columns.Contains("Key"))
            {
                dgvResult.Columns["Key"].HeaderText = @"板材标识";
            }
            if (dgvResult.Columns.Contains("Length"))
            {
                dgvResult.Columns["Length"].HeaderText = @"型材长度";
            }
            if (dgvResult.Columns.Contains("Qty"))
            {
                dgvResult.Columns["Qty"].HeaderText = @"型材数量";
            }
            if (dgvResult.Columns.Contains("AreaSum"))
            {
                dgvResult.Columns["AreaSum"].HeaderText = @"面积合计";
            }
            if (dgvResult.Columns.Contains("Area"))
            {
                dgvResult.Columns["Area"].HeaderText = @"型材面积";
            }
        }


        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (!File.Exists(imageConfig))
            {
                XmlHelper.CreateImageXml(imageConfig);
                PiEncryptHelper.EncFile(imageConfig);
            }
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            if (!PiEncryptHelper.IsFileEnc(imageConfig, ref nKeyID))
            {
                MessageBox.Show(@"系统文件错误！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (CheckRegInfo.GetSoftRegFlg() == "NO")
            {
                this.lbVersion.Text = string.Format(@"【软件未注册可免费使用10次，当前已使用（{0}）次】", CheckRegInfo.GetLoginTimes());
                this.lbVersion.ForeColor = Color.Red;
            }
            else
            {
                this.lbVersion.Text = string.Format(@"【软件已注册,当前版本为：V{0}】", version);
                this.lbVersion.ForeColor = Color.Blue;
            }

#if DEBUG
            this.lbVersion.Text = string.Format(@"【测试版本V{0}】", version);
            this.lbVersion.ForeColor = Color.Red;
#endif
            this.tsslSystemInfo.Text = @"工业和信息化部备案号【粤ICP备11065058】";

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

        private void tsbExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"确定退出系统?", @"提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            tsbExit_Click(null, null);
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            pageMaterial.Parent = null;
            pageHand.Parent = null;
        }


        int nKeyID = 0;

        private void btnMaterials_Click(object sender, EventArgs e)
        {
            if (!File.Exists(imageConfig))
            {
                XmlHelper.CreateImageXml(imageConfig);
                PiEncryptHelper.EncFile(imageConfig);
            }
            pageHand.Parent = null;
            pageMaterial.Parent = tclMain;
            tclMain.SelectTab(pageMaterial);
            if (PiEncryptHelper.IsFileEnc(imageConfig, ref nKeyID))
            {
                PiEncryptHelper.DecFile(imageConfig);
            }
            MaterialsNode mNode = new MaterialsNode();
            mNode.RNode = "Materials";
            List<MaterialsData> list = XmlHelper.GetXmlData(imageConfig,mNode);

            PiEncryptHelper.EncFile(imageConfig);
            BindDgvMain(list);
                
        }

        private void BindDgvMain(List<MaterialsData> list)
        {
            dgvMain.Rows.Clear();
            dgvMain.DataSource = null;
            if (list.Count > 0)
            {
                dgvMain.Rows.Add(list.Count);
                for (int i = 0; i < list.Count; i++)
                {
                    dgvMain.Rows[i].Cells[0].Value = list[i].Area;
                    dgvMain.Rows[i].Cells[1].Value = list[i].Path;
                    dgvMain.Rows[i].Cells[2].Value = GetImage(list[i].Path);
                }
            }
        }

        private System.Drawing.Image GetImage(string path)
        {
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);
            System.Drawing.Image result = System.Drawing.Image.FromStream(fs);

            fs.Close();

            return result;

        }


        private void btnMain_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(this.btnMain, "选料");
        }

        private void btnMaterials_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(this.btnMaterials, "材料管理");
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(this.btnExit, "退出系统");
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (dgvMain.CurrentRow == null)
                {
                    MessageBox.Show(@"请选择需要删除的型材！", @"错误", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);  
                    return;
                }
                int iCount = dgvMain.CurrentRow.Index;
                if (DialogResult.Yes ==
                    MessageBox.Show(@"是否删除选中的型材数据？", @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    string key = dgvMain.CurrentRow.Cells[0].Value.ToString();
                    MaterialsNode mNode = new MaterialsNode();
                    mNode.RNode = "Materials";
                    mNode.PNodeAttr = "key";
                    mNode.PNodeNewValue = key;
                    if (PiEncryptHelper.IsFileEnc(imageConfig, ref nKeyID))
                    {
                        PiEncryptHelper.DecFile(imageConfig);
                    }
                    XmlHelper.Delete(imageConfig,mNode);
                    PiEncryptHelper.EncFile(imageConfig);
                    //XmlHelper.Delete(AppDomain.CurrentDomain.BaseDirectory + "ImageConfig.xml","/Key_"+key,"");
                    string path = dgvMain.CurrentRow.Cells[1].Value.ToString();
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    dgvMain.Rows.RemoveAt(iCount);
                }

            }
            catch (Exception ex)       
            {
                MessageBox.Show(ex.Message, @"错误", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);  
            }
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new FrmMaterials();
                frm.ShowDialog();
                frm.IsAdd = false;
                frm.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new FrmMaterials();
                frm.ShowDialog();
                frm.IsAdd = true;
                frm.Dispose();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {

        }

        
        private void btnHand_Click(object sender, EventArgs e)
        {
            pageMaterial.Parent = null;
            pageHand.Parent = tclMain;
            tclMain.SelectTab(pageHand);
        }

        private void btnHand_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(this.btnHand, "手动下料");
        }

        private List<Ent1> entList = new List<Ent1>();

        private void tsbExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "1997-2003excel文件（*.xls）|*.xls|2007excel文件（*.xlsx）|*.xlsx";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                NPOI.RenderToExcel(dgvResult.DataSource as DataTable, localFilePath);
                ////fs输出带文字或图片的文件，就看需求了 
            }
        }

        private void NoSortable()
        {
            for (int i = 0; i < this.dgvSource.Columns.Count; i++)
            {
                dgvSource.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }




        private Point mPoint = new Point();
        private void tsbSetting_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }

        private void tsbSetting_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            }
        }

        private void tsbMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if(dtSource.Rows.Count <= 0)
                return;
            dtSource.Rows.Clear();
        }

        private void dgvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if(dgvMain.Rows.Count<1)
            //    return;   
            //if (dgvMain.Columns[e.ColumnIndex].Name.Equals("Image")) ;
            //{
            //    if (dgvMain.Rows[e.RowIndex].Cells["Path"].Value != null)
            //        e.Value = System.Drawing.Image.FromFile(dgvMain.Rows[e.RowIndex].Cells["Path"].Value.ToString());
            //}
        }


        private string imageConfig = AppDomain.CurrentDomain.BaseDirectory + "ImageConfig.xml";


        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(imageConfig))
                {
                    XmlHelper.CreateImageXml(imageConfig);
                    PiEncryptHelper.EncFile(imageConfig);
                }

                if (PiEncryptHelper.IsFileEnc(imageConfig, ref nKeyID)) ;
                {
                    PiEncryptHelper.DecFile(imageConfig);
                }
                OpenFileDialog ofd = new OpenFileDialog();
                //ofd.Filter = @"图像文件(*.jpg;*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png";
                ofd.Filter = @"图像文件(*.png)|*.png";
                ofd.Multiselect = true;
                ofd.Title = @"请选择文件";
                ofd.RestoreDirectory = true;

                MaterialsNode mNode = new MaterialsNode();
                mNode.CNode = new string[2];
                mNode.CNodeValue = new string[2];
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "MaterialsImg"))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "MaterialsImg");
                }
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (var item in ofd.SafeFileNames)
                    {
                        string filename = AppDomain.CurrentDomain.BaseDirectory + "MaterialsImg\\" +
                                          item;
                        if (File.Exists(filename))
                        {
                            MessageBox.Show(string.Format("【{0}】型材已经存在！",item.Replace(".png","")));
                            return;
                        }
                    }
                    for (int i=0;i<ofd.FileNames.Length;i++)
                    {
                        string filePath = AppDomain.CurrentDomain.BaseDirectory + "MaterialsImg\\" +
                                          ofd.SafeFileNames[i];
                        if (File.Exists(filePath))
                        {
                            MessageBox.Show(string.Format("【{0}】型材已经存在！", ofd.SafeFileNames[i].Replace(".png", "")));
                            return;
                        }
                        if (File.Exists(filePath))
                        {
                            XmlHelper.Update(imageConfig, "Image//Key_" + ofd.SafeFileNames[i].Replace(".png", ""), "Path", filePath);
                        }
                        else
                        {
                            mNode.RNode = "Materials";
                            mNode.PNode = "Image";
                            mNode.PNodeAttr = "key";
                            mNode.PNodeValue = ofd.SafeFileNames[i].Replace(".png", "");
                            mNode.CNode[0] = "Value";
                            mNode.CNodeValue[0] = ofd.SafeFileNames[i].Replace(".png", "");
                            mNode.CNode[1] = "Path";
                            mNode.CNodeValue[1] = filePath;
                            //XmlHelper.Insert(xmlPath, "Image", "Key_" + ofd.SafeFileNames[i].Replace(".png", ""), "Path",
                            //    filePath);
                            XmlHelper.Insert(imageConfig, mNode);
                        }
                        File.Copy(ofd.FileNames[i], filePath, true);
                    }
                    
                    //XmlHelper.Insert();
                }

                PiEncryptHelper.EncFile(imageConfig);
                MessageBox.Show(@"导入完成！");
                btnMaterials_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"错误",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void dgvResult_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Brush gridBrush = new SolidBrush(this.dgvResult.GridColor);
            SolidBrush backBrush = new SolidBrush(e.CellStyle.BackColor);
            SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
            int cellheight;
            int fontheight;
            int cellwidth;
            int fontwidth;
            int countU = 0;
            int countD = 0;
            int count = 0;
            if (e.Value == null)
                return;
            // 对第1列相同单元格进行合并
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                cellheight = e.CellBounds.Height;
                fontheight = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Height;
                cellwidth = e.CellBounds.Width;
                fontwidth = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
                Pen gridLinePen = new Pen(gridBrush, 5);
                string curValue = e.Value == null ? "" : e.Value.ToString().Trim();
                string curSelected = this.dgvResult.Rows[e.RowIndex].Cells[0].Value == null ? ""
                    : this.dgvResult.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                if (!string.IsNullOrEmpty(curValue))
                {

                    for (int i = e.RowIndex; i < this.dgvResult.Rows.Count; i++)
                    {
                        if (this.dgvResult.Rows[i].Cells[0].Value != null)
                        {
                            if (this.dgvResult.Rows[i].Cells[0].Value.ToString().Equals(curValue))
                            {
                                this.dgvResult.Rows[i].Cells[0].Selected = this.dgvResult.Rows[e.RowIndex].Selected;
                                this.dgvResult.Rows[i].Selected = this.dgvResult.Rows[e.RowIndex].Selected;

                                countD++;

                            }

                            else
                            {
                                break;
                            }
                        }
                    }
                    for (int i = e.RowIndex; i >= 0; i--)
                    {
                        if (this.dgvResult.Rows[i].Cells[0].Value.ToString().Equals(curValue))
                        {
                            this.dgvResult.Rows[i].Cells[0].Selected = this.dgvResult.Rows[e.RowIndex].Selected;

                            this.dgvResult.Rows[i].Selected = this.dgvResult.Rows[e.RowIndex].Selected;

                            countU++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    count = countD + countU - 1;
                    if (count < 2) { return; }
                }

                if (this.dgvResult.Rows[e.RowIndex].Selected)
                {
                    backBrush.Color = e.CellStyle.SelectionBackColor;
                    fontBrush.Color = e.CellStyle.SelectionForeColor;
                }

                e.Graphics.FillRectangle(backBrush, e.CellBounds);
                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (countU - 1) + (cellheight * count - fontheight) / 2);

                if (countD == 1)
                {
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                    count = 0;
                }

                // 画右边线
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

                e.Handled = true;
            }
        }


        //添加序列号
        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(this.dataGridView.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dataGridView.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            btnMaterials_Click(null, null);
        }

        private void timerCount_Tick(object sender, EventArgs e)
        {

        }

        private void btnDelProfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResult.CurrentRow == null)
                {
                    MessageBox.Show(@"请选择需要删除的板材", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Ent2 ent = new Ent2();
                    ent.Key = dgvResult.CurrentRow.Cells["Key"].Value.ToString();
                    Ent1 ent1 = new Ent1();
                    ent1.Length = Convert.ToInt32(dgvResult.CurrentRow.Cells["Length"].Value.ToString());
                    ent1.Qty = Convert.ToInt32(dgvResult.CurrentRow.Cells["Qty"].Value.ToString());
                    ent1.Area = Convert.ToInt32(dgvResult.CurrentRow.Cells["Area"].Value.ToString());
                    ent.MyEnt = ent1;
                    string info = string.Format("确定要删除{0}中长度为【{1}】mm，面积为：【{2}】mm的【{3}】条型材？",ent.Key,ent.MyEnt.Length,ent.MyEnt.Area,ent.MyEnt.Qty);
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
                        dgvResult.DataSource = ResultTable;
                        dgvResult.AutoGenerateColumns = true;
                        dgvResult.SummaryColumns = new string[] { "Qty" };
                        dgvResult.SummaryRowVisible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddProfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResult.CurrentRow == null)
                {
                    MessageBox.Show(@"请选择需要添加的板材", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Ent2 ent = new Ent2();
                    ent.Key = dgvResult.CurrentRow.Cells["Key"].Value.ToString();
                    Ent1 ent1 = new Ent1();
                    ent1.Length = Convert.ToInt32(dgvResult.CurrentRow.Cells["Length"].Value.ToString());
                    ent1.Qty = Convert.ToInt32(dgvResult.CurrentRow.Cells["Qty"].Value.ToString());
                    ent1.Area = Convert.ToInt32(dgvResult.CurrentRow.Cells["Area"].Value.ToString());
                    ent.MyEnt = ent1;
                    var frm = new FrmProfile(ent, ResultTable, false);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (frm.ResultTable != null)
                            ResultTable = frm.ResultTable;
                        dgvResult.DataSource = ResultTable;
                        dgvResult.AutoGenerateColumns = true;
                        dgvResult.SummaryColumns = new string[] { "Qty" };
                        dgvResult.SummaryRowVisible = true;
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
                if (dgvResult.CurrentRow == null)
                {
                    MessageBox.Show(@"请选择需要修改的板材", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Ent2 ent = new Ent2();
                    ent.Key = dgvResult.CurrentRow.Cells["Key"].Value.ToString();
                    Ent1 ent1 = new Ent1();
                    ent1.Length = Convert.ToInt32(dgvResult.CurrentRow.Cells["Length"].Value.ToString());
                    ent1.Qty = Convert.ToInt32(dgvResult.CurrentRow.Cells["Qty"].Value.ToString());
                    ent1.Area = Convert.ToInt32(dgvResult.CurrentRow.Cells["Area"].Value.ToString());
                    ent.MyEnt = ent1;
                    var frm = new FrmProfile(ent, ResultTable, true);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (frm.ResultTable != null)
                            ResultTable = frm.ResultTable;
                        dgvResult.DataSource = ResultTable;
                        dgvResult.AutoGenerateColumns = true;
                        dgvResult.SummaryColumns = new string[] { "Qty" };
                        dgvResult.SummaryRowVisible = true;
                    }
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbClearAll_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes ==
                MessageBox.Show(@"是否清空所以已存在的型材？", @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                if (File.Exists(imageConfig))
                {
                    File.Delete(imageConfig);
                }

                string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "MaterialsImg");
                foreach (var file in files)
                {
                    File.Delete(file);
                }
                MessageBox.Show(@"清除成功！"); 
                btnMaterials_Click(null, null);
            }
        }

    }


}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class FrmOperationNew : FrmBaseTool
    {
        private DataTable dtSource = new DataTable("MyData");

        public FrmOperationNew()
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
            //btnImport.Visibility = BarItemVisibility.Never;
            btnImport.Caption = @"刷新型材";
            //dgvSource.KeyDown += dgvSource_KeyDown;

            //var batchImport = new BarButtonItem
            //{
            //    Caption = @"批量启用/禁用",
            //    CausesValidation = true,
            //    Glyph = Resources.,
            //    PaintStyle = BarItemPaintStyle.CaptionGlyph
            //};
            gvMain.OptionsView.RowAutoHeight = true;
            gvMain.OptionsView.ColumnAutoWidth = true;
            gvSource.OptionsView.RowAutoHeight = true;
            gvSource.OptionsView.ColumnAutoWidth = true;
        }

        private void InitSourceView()
        {
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Length";
            dc.DataType = System.Type.GetType("System.Int32");
            dtSource.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "Qty";
            dc.DataType = System.Type.GetType("System.Int32");
            dtSource.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "Profile";
            dc.DataType = System.Type.GetType("System.Object");
            dtSource.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "SArea";
            dc.DataType = System.Type.GetType("System.Int32");
            dtSource.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "SDepth";
            dc.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "SPath";
            dc.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(dc);
#if DEBUG
            DataRow newRow;
            newRow = dtSource.NewRow();
            newRow["Length"] = 2840;
            newRow["SArea"] = 68;
            newRow["Qty"] = 3;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2740;
            newRow["SArea"] = 130;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2420;
            newRow["SArea"] = 85;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2420;
            newRow["SArea"] = 56;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2420;
            newRow["SArea"] = 119;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2420;
            newRow["SArea"] = 181;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2370;
            newRow["SArea"] = 120;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2370;
            newRow["SArea"] = 180;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2420;
            newRow["SArea"] = 197;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2370;
            newRow["SArea"] = 172;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2370;
            newRow["SArea"] = 218;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2370;
            newRow["SArea"] = 389;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2390;
            newRow["SArea"] = 180;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2390;
            newRow["SArea"] = 216;
            newRow["Qty"] = 2;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 2390;
            newRow["SArea"] = 395;
            newRow["Qty"] = 1;
            dtSource.Rows.Add(newRow);


            newRow = dtSource.NewRow();
            newRow["Length"] = 2390;
            newRow["SArea"] = 395;
            newRow["Qty"] = 1;
            dtSource.Rows.Add(newRow);


            newRow = dtSource.NewRow();
            newRow["Length"] = 3400;
            newRow["SArea"] = 169;
            newRow["Qty"] = 1;
            dtSource.Rows.Add(newRow);


            newRow = dtSource.NewRow();
            newRow["Length"] = 3400;
            newRow["SArea"] = 225;
            newRow["Qty"] = 1;
            dtSource.Rows.Add(newRow);


            newRow = dtSource.NewRow();
            newRow["Length"] = 1800;
            newRow["SArea"] = 250;
            newRow["Qty"] = 4;
            dtSource.Rows.Add(newRow);


            newRow = dtSource.NewRow();
            newRow["Length"] = 1860;
            newRow["SArea"] = 258;
            newRow["Qty"] = 3;
            dtSource.Rows.Add(newRow);


            newRow = dtSource.NewRow();
            newRow["Length"] = 1860;
            newRow["SArea"] = 78;
            newRow["Qty"] = 5;
            dtSource.Rows.Add(newRow);


            newRow = dtSource.NewRow();
            newRow["Length"] = 1800;
            newRow["SArea"] = 128;
            newRow["Qty"] = 1;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 1620;
            newRow["SArea"] = 34;
            newRow["Qty"] = 6;
            dtSource.Rows.Add(newRow);


            newRow = dtSource.NewRow();
            newRow["Length"] = 1620;
            newRow["SArea"] = 63;
            newRow["Qty"] = 6;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 1620;
            newRow["SArea"] = 46;
            newRow["Qty"] = 6;
            dtSource.Rows.Add(newRow);

            newRow = dtSource.NewRow();
            newRow["Length"] = 1800;
            newRow["SArea"] = 197;
            newRow["Qty"] = 1;
            dtSource.Rows.Add(newRow);
#endif
            gcSource.DataSource = dtSource;
            LoadProfileInfo();
        }
        private void InitResultView()
        {
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Depth";
            dc.Caption = "厚薄度";
            dc.DataType = System.Type.GetType("System.String");
            ResultTable.Columns.Add(dc); 
            
            dc = new DataColumn();
            dc.ColumnName = "Key";
            dc.Caption = "板材标识";
            dc.DataType = System.Type.GetType("System.String");
            ResultTable.Columns.Add(dc);


            dc = new DataColumn();
            dc.ColumnName = "Length";
            dc.Caption = "型材长度";
            dc.DataType = System.Type.GetType("System.Int32");
            ResultTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Qty";
            dc.Caption = "型材标识";
            dc.DataType = System.Type.GetType("System.Int32");
            ResultTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Area";
            dc.Caption = "型材面积";
            dc.DataType = System.Type.GetType("System.Int32");
            ResultTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "AreaSum";
            dc.Caption = "面积合计";
            dc.DataType = System.Type.GetType("System.Int32");
            ResultTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Key1";
            dc.Caption = "Key1";
            dc.DataType = System.Type.GetType("System.String");
            ResultTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Path";
            dc.Caption = "Path";
            dc.DataType = System.Type.GetType("System.String");
            ResultTable.Columns.Add(dc);

           
        }

        protected override void DelayLoad()
        {
            base.DelayLoad();
            InitSourceView();
            InitResultView();
        }


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
                //gvSource.EndEdit();

                int n = gvSource.RowCount - 1;
                for (int i = 0; i < n; i++)
                {
                    Ent1 ent1 = new Ent1();
                    int length = 0;
                    int qty = 0;
                    int area = 0;

                    int.TryParse(this.gvSource.GetRowCellValue(i, gvSource.Columns["Length"]) == null ? "0" : this.gvSource.GetRowCellValue(i, gvSource.Columns["Length"]).ToString(), out length);
                    int.TryParse(this.gvSource.GetRowCellValue(i, gvSource.Columns["Qty"]) == null ? "0" : this.gvSource.GetRowCellValue(i, gvSource.Columns["Qty"]).ToString(), out qty);
                    int.TryParse(this.gvSource.GetRowCellValue(i, gvSource.Columns["SArea"]) == null ? "0" : this.gvSource.GetRowCellValue(i, gvSource.Columns["SArea"]).ToString(), out area);
                    string depth = Convert.ToString(this.gvSource.GetRowCellValue(i,gvSource.Columns["SDepth"]));
                    string fPath = Convert.ToString(this.gvSource.GetRowCellValue(i, gvSource.Columns["SPath"]));
                    ent1.Length = length;
                    ent1.Area = area;
                    ent1.Qty = qty;
                    ent1.Depth = depth;
                    ent1.Path = fPath;
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

        private string imageConfig = AppDomain.CurrentDomain.BaseDirectory + "ImageConfig.xml";
        private int nKeyID = 0;
        List<MaterialsData> list = new List<MaterialsData>();
        private void LoadProfileInfo()
        {
            if (!File.Exists(imageConfig))
            {
                XmlHelper.CreateImageXml(imageConfig);
                PiEncryptHelper.EncFile(imageConfig);
            }
            if (PiEncryptHelper.IsFileEnc(imageConfig, ref nKeyID))
            {
                PiEncryptHelper.DecFile(imageConfig);
            }
            MaterialsNode mNode = new MaterialsNode();
            mNode.RNode = "Materials";
            list = XmlHelper.GetXmlData(imageConfig, mNode);

            PiEncryptHelper.EncFile(imageConfig);

            gcMain.DataSource = null;


            gcMain.DataSource = list;
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
                        newRow["Path"] = ent2.MyEnt.Path;
                        ResultTable.Rows.Add(newRow);
                    }

                });
            btnEdit_ItemClick(null, null);
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
            //foreach (DataRow row in ResultTable.Rows)
            //{
            //    row["Key1"] = AppDomain.CurrentDomain.BaseDirectory + "MaterialsImg\\" + row["Area"] + ".png";
            //}
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

       
        private void gvMain_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Image" && e.IsGetData)
            {
                //RefImage是存储图片路径的那一列  
                string filePath = ((MaterialsData) e.Row).Path;
                Image img = null;
                FileStream iStream = null;
                try
                {
                    //判断图片路径是否为网络路径  
                    if (UrlDiscern(filePath))
                    {
                        //文件是否存在  
                        if (RemoteFileExists(filePath))
                        {
                            //读取文件  
                            using (WebClient wc = new WebClient())
                            {
                                img = new Bitmap(wc.OpenRead(filePath));
                            }
                        }
                    }
                    // 判断本地文件是否存在  
                    else if (LocalFileExists(filePath))
                    {
                        iStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        //加载本地图片  
                        img = new Bitmap(iStream);
                    }
                    //pictureEdit列绑定图片  
                    e.Value = img;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    if (iStream != null)
                        iStream.Dispose();
                }
            }  
        }

        /// <summary>  
        /// 判断远程文件是否存在  
        /// </summary>  
        /// <param name="fileUrl"></param>  
        /// <returns></returns>  
        public bool RemoteFileExists(string fileUrl)
        {
            HttpWebRequest re = null;
            HttpWebResponse res = null;
            try
            {
                re = (HttpWebRequest)WebRequest.Create(fileUrl);
                res = (HttpWebResponse)re.GetResponse();
                if (res.ContentLength != 0)
                {
                    //MessageBox.Show("文件存在");  
                    return true;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("无此文件");  
                return false;
            }
            finally
            {
                if (re != null)
                {
                    re.Abort();//销毁关闭连接  
                }
                if (res != null)
                {
                    res.Close();//销毁关闭响应  
                }
            }
            return false;
        }
        /// <summary>  
        /// 判断本地文件是否存在  
        /// </summary>  
        /// <param name="path"></param>  
        /// <returns></returns>  
        public bool LocalFileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>  
        /// 识别urlStr是否是网络路径  
        /// </summary>  
        /// <param name="urlStr"></param>  
        /// <returns></returns>  
        public bool UrlDiscern(string urlStr)
        {
            if (Regex.IsMatch(urlStr, @"((http|ftp|https)://)(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,4})*(/[a-zA-Z0-9\&%_\./-~-]*)?"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = toolStripComboBox1.Text;
            List<MaterialsData> listTmp = list.FindAll(s => s.Type == value).ToList();
            gcMain.DataSource = listTmp;
        }

        private void gvMain_DoubleClick(object sender, EventArgs e)
        {
            if(gvMain.FocusedRowHandle < 0)
                return;
            try
            {
                if (hInfo.InRowCell)
                {
                    MaterialsData data = this.gvMain.GetRow(gvMain.FocusedRowHandle) as MaterialsData;
                    if (data != null)
                    {
                        SetSourceData(data);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        GridHitInfo hInfo =  new GridHitInfo();
        private void gvMain_MouseDown(object sender, MouseEventArgs e)
        {
            hInfo = gvMain.CalcHitInfo(e.Y, e.Y);
        }

        private void SetSourceData(MaterialsData data)
        {
            //int i = gcSource.\
            int index = this.gvSource.FocusedRowHandle;
            if (index <= -1)
            {
                MessageBox.Show(@"请选择需要添加型材的源！");
                return;
            }
            this.gvSource.SetRowCellValue(index, gvSource.Columns["Profile"], System.Drawing.Image.FromFile(data.Path));
            this.gvSource.SetRowCellValue(index, gvSource.Columns["SArea"], data.Area.Split('-')[0]);
            this.gvSource.SetRowCellValue(index, gvSource.Columns["SDepth"], data.Depth);
            this.gvSource.SetRowCellValue(index, gvSource.Columns["SPath"], data.Path);
        }

        private void FrmOperationNew_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void txtHoudu_TextChanged(object sender, EventArgs e)
        {
            string value = toolStripComboBox1.Text;
            List<MaterialsData> listTmp = list;
            if (!string.IsNullOrEmpty(txtHoudu.Text))
            {
                listTmp = listTmp.FindAll(s => s.Depth == txtHoudu.Text).ToList();
            }
            if (value != "请选择")
            {
                listTmp = listTmp.FindAll(s => s.Type == value).ToList();
            }
            gcMain.DataSource = listTmp;
        }

        protected override void btnImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadProfileInfo();
        }

    }
}

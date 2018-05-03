using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nicholas.Smart.Materials.Business;
using Nicholas.Smart.Materials.Main.ControlDef;
using System.Net;
using System.Text.RegularExpressions;

namespace Nicholas.Smart.Materials.Main.Bussiness
{
    public partial class FrmProfile : FrmBaseTool
    {
        public FrmProfile()
        {
            InitializeComponent();

            gvMain.OptionsView.RowAutoHeight = true;
            gvMain.OptionsView.ColumnAutoWidth = true;
        }

        protected override void OnShown(EventArgs e)
        {
            btnAdd.Caption = @"删除型材";
            btnEdit.Caption = @"导入型材";
            btnImport.Caption = @"清空所以型材";
        }
        protected override void DelayLoad()
        {
            btnRefresh_ItemClick(null, null);
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
        private string imageConfig = AppDomain.CurrentDomain.BaseDirectory + "ImageConfig.xml";
        private void LoadData()
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
            List<MaterialsData> list = XmlHelper.GetXmlData(imageConfig, mNode);

            PiEncryptHelper.EncFile(imageConfig);
            BindDgvMain(list);
        }

        private void BindDgvMain(List<MaterialsData> list)
        {
            gcMain.DataSource = list;
            //dgvMain.Rows.Clear();
            //dgvMain.DataSource = null;
            //if (list.Count > 0)
            //{
            //    dgvMain.Rows.Add(list.Count);
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        dgvMain.Rows[i].Cells[0].Value = list[i].Type;
            //        dgvMain.Rows[i].Cells[1].Value = list[i].Area;
            //        dgvMain.Rows[i].Cells[2].Value = list[i].Path;
            //        dgvMain.Rows[i].Cells[3].Value = ControlFunction.GetFileImage(list[i].Path);
            //        dgvMain.Rows[i].Cells[4].Value = list[i].Depth;
            //    }
            //}
        }

        protected override void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AsyncWaitForm.Instance.AsyncShow("加载数据", "正在加载数据",
                    delegate(AsyncWaitForm exfrm)
                    {
                        exfrm.SetMsgAndProgress("正在加载数据", 10);
                        LoadData();
                        exfrm.SetMsgAndProgress("加载数据完成", 90);
                    }, delegate
                    {
                        AsyncWaitForm.Instance.SetMsgAndProgress(100);

                    });
        }

        int nKeyID = 0;
        protected override void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int index = gvMain.FocusedRowHandle;
                if (index <= -1)
                {
                    MessageBox.Show(@"请选择需要删除的型材！", @"错误", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
                if (DialogResult.Yes ==
                    MessageBox.Show(@"是否删除选中的型材数据？", @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    MaterialsNode mNode = new MaterialsNode();
                    mNode.RNode = "Materials";
                    mNode.PNodeAttr = "key";
                    mNode.PNodeNewValue = this.gvMain.GetFocusedRowCellValue("Area").ToString();
                    string filename = this.gvMain.GetFocusedRowCellValue("Path").ToString();

                    this.gvMain.DeleteRow(index);
                    if (PiEncryptHelper.IsFileEnc(imageConfig, ref nKeyID))
                    {
                        PiEncryptHelper.DecFile(imageConfig);
                    }
                    XmlHelper.Delete(imageConfig, mNode);
                    PiEncryptHelper.EncFile(imageConfig);
                    if (File.Exists(filename))
                    {
                        File.SetAttributes(filename, FileAttributes.Normal);  

                        File.Delete(filename);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"错误", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void gvMain_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Image" && e.IsGetData)
            {
                //RefImage是存储图片路径的那一列  
                string filePath = AppDomain.CurrentDomain.BaseDirectory + ((MaterialsData)e.Row).Path;
                Image img = null;
                FileStream iStream = null;
                try
                {
                    if (LocalFileExists(filePath))
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
                    if(iStream != null)
                        iStream.Dispose();
                }
            }
        }

        protected override void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //AsyncWaitForm.Instance.AsyncShow("开始计算", "正在进行排料计算",
            //        delegate(AsyncWaitForm exfrm)
            //        {
            //            exfrm.SetMsgAndProgress("正在进行排料计算", 10);
            //            exfrm.SetMsgAndProgress("计算完成", 90);
            //        }, delegate
            //        {
            //            AsyncWaitForm.Instance.SetMsgAndProgress(100);

            //        });
            var frm = new FrmProfileType();
            if(frm.ShowDialog() == DialogResult.OK)
                LoadData();
            frm.Dispose();
        }

        protected override void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (DialogResult.Yes ==
                MessageBox.Show(@"是否清空所以已存在的型材？", @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    AsyncWaitForm.Instance.AsyncShow("开始清空型材", "正在清空型材",
                    delegate(AsyncWaitForm exfrm)
                    {
                        exfrm.SetMsgAndProgress("导入型材", 10);
                        if (File.Exists(imageConfig))
                        {
                            File.Delete(imageConfig);
                        }
                        DelectDir(AppDomain.CurrentDomain.BaseDirectory + "MaterialsImg");
                        exfrm.SetMsgAndProgress("清空型材完成", 90);
                    }, delegate
                    {
                        LoadData();
                        AsyncWaitForm.Instance.SetMsgAndProgress(100);
                    });
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"错误",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception e)
            {
                throw;
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
    }
}

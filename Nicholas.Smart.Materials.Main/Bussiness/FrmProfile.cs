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

namespace Nicholas.Smart.Materials.Main.Bussiness
{
    public partial class FrmProfile : FrmBaseTool
    {
        public FrmProfile()
        {
            InitializeComponent();
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
            dgvMain.Rows.Clear();
            dgvMain.DataSource = null;
            if (list.Count > 0)
            {
                dgvMain.Rows.Add(list.Count);
                for (int i = 0; i < list.Count; i++)
                {
                    dgvMain.Rows[i].Cells[0].Value = list[i].Area;
                    dgvMain.Rows[i].Cells[1].Value = list[i].Path;
                    dgvMain.Rows[i].Cells[2].Value = ControlFunction.GetFileImage(list[i].Path);
                }
            }
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
                    XmlHelper.Delete(imageConfig, mNode);
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
            AsyncWaitForm.Instance.AsyncShow("开始导入型材", "正在导入型材",
                    delegate(AsyncWaitForm exfrm)
                    {
                        exfrm.SetMsgAndProgress("导入型材", 10);
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
                                    MessageBox.Show(string.Format("【{0}】型材已经存在！", item.Replace(".png", "")));
                                    return;
                                }
                            }
                            for (int i = 0; i < ofd.FileNames.Length; i++)
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
                        exfrm.SetMsgAndProgress("导入完成", 90);
                        PiEncryptHelper.EncFile(imageConfig);
                    }, delegate
                    {
                        LoadData();
                        AsyncWaitForm.Instance.SetMsgAndProgress(100);
                    });
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

                        string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "MaterialsImg");
                        foreach (var file in files)
                        {
                            File.Delete(file);
                        }
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
    }
}

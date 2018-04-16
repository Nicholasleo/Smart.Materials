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
    public partial class FrmProfileType : FrmBaseTool
    {
        public FrmProfileType()
        {
            InitializeComponent();
            this.bar1.Visible = false;
        }
        private string imageConfig = AppDomain.CurrentDomain.BaseDirectory + "ImageConfig.xml";
        protected override void DelayLoad()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.Caption = "名称";
            dc.ColumnName = "Value";
            dc.DataType = Type.GetType("System.String");
            dt.Columns.Add(dc);

            DataRow row = dt.NewRow();
            row["Value"] = "门框";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Value"] = "实体门庭";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Value"] = "玻璃门庭";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Value"] = "纱门门庭";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Value"] = "门套";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Value"] = "墙体";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Value"] = "门头";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Value"] = "门槛";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Value"] = "帽头";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Value"] = "条子";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Value"] = "线条";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Value"] = "其他";
            dt.Rows.Add(row);

            lueType.EditValue = @"Value";
            lueType.Properties.ValueMember = "Value";
            lueType.Properties.DisplayMember = "Value";
            lueType.Properties.DataSource = dt;
            lueType.Properties.PopulateColumns();
            lueType.ItemIndex = 0;
        }

        private int nKeyID = 0;
        private void btnStart_Click(object sender, EventArgs e)
        {
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
                        mNode.CNode = new string[4];
                        mNode.CNodeValue = new string[4];
                        string path = AppDomain.CurrentDomain.BaseDirectory + "MaterialsImg\\" + lueType.Text + "\\";
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        

                            
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            foreach (var item in ofd.SafeFileNames)
                            {
                                string filename = path +  item.ToLower();
                                if (File.Exists(filename))
                                {
                                    MessageBox.Show(string.Format("【{0}】型材已经存在！", item.ToLower().Replace(".png", "")));
                                    return;
                                }
                            }


                            for (int i = 0; i < ofd.FileNames.Length; i++)
                            {
                                string filePath = path + ofd.SafeFileNames[i].ToLower();
                                if (File.Exists(filePath))
                                {
                                    MessageBox.Show(string.Format("【{0}】型材已经存在！", ofd.SafeFileNames[i].ToLower().Replace(".png", "")));
                                    return;
                                }
                                if (File.Exists(filePath))
                                {
                                    XmlHelper.Update(imageConfig, "Image//Key_" + ofd.SafeFileNames[i].ToLower().Replace(".png", ""), "Path", filePath);
                                }
                                else
                                {
                                    mNode.RNode = "Materials";
                                    mNode.PNode = "Image";
                                    mNode.PNodeAttr = "key";
                                    mNode.PNodeValue = ofd.SafeFileNames[i].ToLower().Replace(".png", "");
                                    mNode.CNode[0] = "Type";
                                    mNode.CNodeValue[0] = lueType.Text;
                                    mNode.CNode[1] = "Value";
                                    mNode.CNodeValue[1] = ofd.SafeFileNames[i].ToLower().Replace(".png", "");
                                    mNode.CNode[2] = "Path";
                                    mNode.CNodeValue[2] = filePath;
                                    mNode.CNode[3] = "Depth";
                                    mNode.CNodeValue[3] = txtDepth.Text;
                                    //XmlHelper.Insert(xmlPath, "Image", "Key_" + ofd.SafeFileNames[i].Replace(".png", ""), "Path",
                                    //    filePath);
                                    XmlHelper.Insert(imageConfig, mNode);
                                }
                                File.Copy(ofd.FileNames[i].ToLower(), filePath, true);
                            }

                            //XmlHelper.Insert();
                        }
                        exfrm.SetMsgAndProgress("导入完成", 90);
                        DialogResult = DialogResult.OK;
                        PiEncryptHelper.EncFile(imageConfig);
                    }, delegate
                    {
                        AsyncWaitForm.Instance.SetMsgAndProgress(100);
                    });
        }
    }
}

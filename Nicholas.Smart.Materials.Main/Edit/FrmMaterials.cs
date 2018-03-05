using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nicholas.Smart.Materials.Business;

namespace Nicholas.Smart.Materials.Main.Edit
{
    public partial class FrmMaterials : FrmBase
    {
        public bool IsAdd = false;

        private bool isDrawLine = false; //标志是否进入画线状态
        private Graphics g; //GDI+对象
        private Point pt;
        private Point ptLine;


        public FrmMaterials()
        {
            InitializeComponent();
            this.btnMin.Visible = this.btnMax.Visible = false;
            this.btnAdd.Text = @"保存";
            this.btnDel.Visible = btnEdit.Visible = false;
            InitControl();
        }

        protected override void OnLoad(EventArgs e)
        {
        }

        private void InitControl()
        {
            if (IsAdd)
            {
                this.lbTitle.Text = @"新增材料";
                g = Graphics.FromHwnd(this.Handle);//创建一个新的GDI+对象
                pt = new Point();
                ptLine = new Point();
            }
            else
            {
                this.lbTitle.Text = @"修改材料";
            }
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMId.Text.Trim()))
                {
                    MessageBox.Show(@"请输入材料的标识！");
                    return;
                }
                string path = AppDomain.CurrentDomain.BaseDirectory + "MaterialsImg";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filename = path + "\\" + txtMId.Text.Trim() + ".png";
                tools.OrginalImg.Save(filename);
                string xmlPath = AppDomain.CurrentDomain.BaseDirectory + "ImageConfig.xml";
                
                XmlHelper.Insert(xmlPath, "Image", "Key_" + txtMId.Text.Trim(), "Path", filename);
               }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private Materials GetEnt(Materials ent)
        {
            return ent;
        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            if (isDrawLine)
            {
                isDrawLine = false;
            }
            else
            {
                isDrawLine = true;
            }
        }

        private void plMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (isDrawLine)
            {
                if (pt.IsEmpty)
                {
                    pt = e.Location; //获取起始点坐标位置
                }
                else
                {
                    g.DrawLine(Pens.Red,pt,e.Location);
                    pt = ptLine;
                }
            }
        }

        private void plMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawLine && !pt.IsEmpty)
            {
                g.DrawLine(Pens.White,pt,ptLine);
                g.DrawLine(Pens.Red,pt,e.Location);
                ptLine = e.Location;
            }
        }

        private DrawTools tools;
        private string sType;//绘图样式
        private string sFileName;//打开的文件名
        private bool bReSize = false;//是否改变画布大小
        private Size DefaultPicSize;//储存原始画布大小，用来新建文件时使用

        private void pbImg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (tools != null)
                {
                    tools.startDraw = true;//相当于所选工具被激活，可以开始绘图
                    tools.startPointF = new PointF(e.X, e.Y);
                }
            }
        }

        private void DrawNumber(string num, PointF pt, Graphics gr)
        {
            Font font = new Font("宋体", 15f);
            Brush brush = Brushes.Red;
            //gr.TranslateTransform(pt.X, pt.Y);
            //gr.RotateTransform(-90);
            System.Drawing.StringFormat sf = new System.Drawing.StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionVertical;
            gr.DrawString(num, font, brush, new PointF(0,0), sf);  
        }

        private void pbImg_MouseMove(object sender, MouseEventArgs e)
        {
            Thread.Sleep(6);//减少cpu占用率
            mousePostion.Text = e.Location.ToString();
            if (tools.startDraw)
            {
                switch (sType)
                {
                    case "Dot": tools.DrawDot(e); break;
                    case "Eraser": tools.Eraser(e); break;
                    case "Word": tools.DrawWord(e); break;
                    default: tools.Draw(e, sType); break;

                }
            }
        }

        private string length = "";

        private void pbImg_MouseUp(object sender, MouseEventArgs e)
        {
            if (tools != null)
            {
                //if (sType != "Eraser")
                //{
                //    var frm = new FrmInput();
                //    frm.ShowDialog();
                //    length = frm.MyLen;
                //    frm.Dispose();
                //}
                //if (!string.IsNullOrEmpty(length))
                //{
                //    DrawNumber(length, e.Location, tools.DrawTools_Graphics);
                //}

                tools.EndDraw();
            }
        }

        private void pbImg_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(tools.OrginalImg, 0, 0);
        }

        private void FrmMaterials_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
            Bitmap bmp = new Bitmap(pbImg.Width, pbImg.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(pbImg.BackColor), new Rectangle(0, 0, pbImg.Width, pbImg.Height));
            g.Dispose();
            tools = new DrawTools(this.pbImg.CreateGraphics(), colorHatch1.HatchColor, bmp);//实例化工具类
            DefaultPicSize = pbImg.Size;


        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb != null)
            {
                sType = tsb.Name;
                currentDrawType.Text = tsb.Text;
                switch (sType)
                {
                    case "Eraser":
                        pbImg.Cursor = new Cursor(Application.StartupPath + @"\Resources\pb.cur");
                        break;
                    case "Dot":
                        pbImg.Cursor = new Cursor(Application.StartupPath + @"\Resources\pen.cur");
                        break;
                    default:
                        pbImg.Cursor = Cursors.Cross;
                        break;
                }
            }
        }

        private void colorHatch1_ColorChanged(object sender, ColorHatch.ColorChangedEventArgs e)
        {
            tools.DrawColor = e.GetColor;
        }
    }
}

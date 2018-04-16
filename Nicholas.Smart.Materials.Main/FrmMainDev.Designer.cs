namespace Nicholas.Smart.Materials.Main
{
    partial class FrmMainDev
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainDev));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bsiVersion = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.btnOperatorMaterials = new DevExpress.XtraBars.BarButtonItem();
            this.btnProfile = new DevExpress.XtraBars.BarButtonItem();
            this.btnSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.bsiSetting = new DevExpress.XtraBars.BarStaticItem();
            this.btnRegsiter = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnOperatorNew = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.popupMenu1;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bsiVersion,
            this.barStaticItem2,
            this.btnOperatorMaterials,
            this.btnProfile,
            this.btnSetting,
            this.btnUpdate,
            this.bsiSetting,
            this.btnRegsiter,
            this.btnOperatorNew});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 21;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageHeaderItemLinks.Add(this.bsiSetting);
            this.ribbon.PageHeaderItemLinks.Add(this.ribbon.ExpandCollapseItem);
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(813, 147);
            this.ribbon.StatusBar = this.ribbonStatusBar1;
            // 
            // popupMenu1
            // 
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.ribbon;
            // 
            // bsiVersion
            // 
            this.bsiVersion.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiVersion.Id = 1;
            this.bsiVersion.Name = "bsiVersion";
            this.bsiVersion.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "工业和信息化部备案号【粤ICP备11065058】";
            this.barStaticItem2.Id = 2;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnOperatorMaterials
            // 
            this.btnOperatorMaterials.Caption = "排料功能";
            this.btnOperatorMaterials.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOperatorMaterials.Glyph")));
            this.btnOperatorMaterials.Id = 8;
            this.btnOperatorMaterials.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOperatorMaterials.LargeGlyph")));
            this.btnOperatorMaterials.Name = "btnOperatorMaterials";
            this.btnOperatorMaterials.Tag = "Nicholas.Smart.Materials.Main.Bussiness.FrmOperation";
            this.btnOperatorMaterials.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_ItemClick);
            // 
            // btnProfile
            // 
            this.btnProfile.Caption = "型材管理";
            this.btnProfile.Id = 14;
            this.btnProfile.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnProfile.LargeGlyph")));
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Tag = "Nicholas.Smart.Materials.Main.Bussiness.FrmProfile";
            this.btnProfile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_ItemClick);
            // 
            // btnSetting
            // 
            this.btnSetting.Caption = "系统参数";
            this.btnSetting.Id = 15;
            this.btnSetting.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSetting.LargeGlyph")));
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Tag = "Nicholas.Smart.Materials.Main.Bussiness.FrmSetting";
            this.btnSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_ItemClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Caption = "系统升级";
            this.btnUpdate.Id = 16;
            this.btnUpdate.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnUpdate.LargeGlyph")));
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Tag = "Nicholas.Smart.Materials.Main.Bussiness.FrmUpdate";
            this.btnUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_ItemClick);
            // 
            // bsiSetting
            // 
            this.bsiSetting.Id = 17;
            this.bsiSetting.Name = "bsiSetting";
            this.bsiSetting.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnRegsiter
            // 
            this.btnRegsiter.AccessibleDescription = "";
            this.btnRegsiter.Caption = "软件注册";
            this.btnRegsiter.Id = 19;
            this.btnRegsiter.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRegsiter.LargeGlyph")));
            this.btnRegsiter.Name = "btnRegsiter";
            this.btnRegsiter.Tag = "Nicholas.Smart.Materials.Main.Bussiness.FrmRegister";
            this.btnRegsiter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup6});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "常用功能";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnOperatorMaterials);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnOperatorNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnProfile);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "排料功能";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnSetting);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnRegsiter);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnUpdate);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "系统设置";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiVersion);
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem2);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 494);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbon;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(813, 31);
            // 
            // popupMenu2
            // 
            this.popupMenu2.Name = "popupMenu2";
            this.popupMenu2.Ribbon = this.ribbon;
            // 
            // btnOperatorNew
            // 
            this.btnOperatorNew.Caption = "排料功能（新）";
            this.btnOperatorNew.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOperatorNew.Glyph")));
            this.btnOperatorNew.Id = 20;
            this.btnOperatorNew.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOperatorNew.LargeGlyph")));
            this.btnOperatorNew.Name = "btnOperatorNew";
            this.btnOperatorNew.Tag = "Nicholas.Smart.Materials.Main.Bussiness.FrmOperationNew";
            this.btnOperatorNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_ItemClick);
            // 
            // FrmMainDev
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 525);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmMainDev";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "自动排料系统";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarStaticItem bsiVersion;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.PopupMenu popupMenu2;
        private DevExpress.XtraBars.BarButtonItem btnOperatorMaterials;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnProfile;
        private DevExpress.XtraBars.BarButtonItem btnSetting;
        private DevExpress.XtraBars.BarButtonItem btnUpdate;
        private DevExpress.XtraBars.BarStaticItem bsiSetting;
        private DevExpress.XtraBars.BarButtonItem btnRegsiter;
        private DevExpress.XtraBars.BarButtonItem btnOperatorNew;


    }
}
namespace Nicholas.Smart.Materials.Main.Bussiness
{
    partial class FrmOperationNew
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gcSource = new DevExpress.XtraGrid.GridControl();
            this.gvSource = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Length = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Profile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.SArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SDepth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMain = new DevExpress.XtraGrid.GridControl();
            this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Area = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Path = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Image = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.Depth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtHoudu = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gcSource);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gcMain);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(824, 357);
            this.splitContainer1.SplitterDistance = 405;
            this.splitContainer1.TabIndex = 4;
            // 
            // gcSource
            // 
            this.gcSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSource.Location = new System.Drawing.Point(0, 0);
            this.gcSource.MainView = this.gvSource;
            this.gcSource.MenuManager = this.barManager1;
            this.gcSource.Name = "gcSource";
            this.gcSource.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit2});
            this.gcSource.Size = new System.Drawing.Size(405, 357);
            this.gcSource.TabIndex = 0;
            this.gcSource.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSource});
            // 
            // gvSource
            // 
            this.gvSource.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Length,
            this.Qty,
            this.SArea,
            this.SDepth,
            this.Profile,
            this.SPath});
            this.gvSource.GridControl = this.gcSource;
            this.gvSource.Name = "gvSource";
            this.gvSource.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvSource.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvSource.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvSource.OptionsView.ShowFooter = true;
            this.gvSource.OptionsView.ShowGroupPanel = false;
            // 
            // Length
            // 
            this.Length.Caption = "材料长度";
            this.Length.FieldName = "Length";
            this.Length.Name = "Length";
            this.Length.Visible = true;
            this.Length.VisibleIndex = 2;
            // 
            // Qty
            // 
            this.Qty.Caption = "型材数量";
            this.Qty.FieldName = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "合计={0:0.##}")});
            this.Qty.Visible = true;
            this.Qty.VisibleIndex = 0;
            // 
            // Profile
            // 
            this.Profile.Caption = "型材样式";
            this.Profile.ColumnEdit = this.repositoryItemPictureEdit2;
            this.Profile.FieldName = "Profile";
            this.Profile.Name = "Profile";
            this.Profile.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.Profile.Visible = true;
            this.Profile.VisibleIndex = 4;
            this.Profile.Width = 83;
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            this.repositoryItemPictureEdit2.ZoomPercent = 30D;
            // 
            // SArea
            // 
            this.SArea.Caption = "展开面积";
            this.SArea.FieldName = "SArea";
            this.SArea.Name = "SArea";
            this.SArea.Visible = true;
            this.SArea.VisibleIndex = 1;
            // 
            // SDepth
            // 
            this.SDepth.Caption = "型材厚度";
            this.SDepth.FieldName = "SDepth";
            this.SDepth.Name = "SDepth";
            this.SDepth.Visible = true;
            this.SDepth.VisibleIndex = 3;
            // 
            // SPath
            // 
            this.SPath.Caption = "路径";
            this.SPath.FieldName = "SPath";
            this.SPath.Name = "SPath";
            // 
            // gcMain
            // 
            this.gcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMain.Location = new System.Drawing.Point(0, 25);
            this.gcMain.MainView = this.gvMain;
            this.gcMain.MenuManager = this.barManager1;
            this.gcMain.Name = "gcMain";
            this.gcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1,
            this.repositoryItemPictureEdit1});
            this.gcMain.Size = new System.Drawing.Size(415, 332);
            this.gcMain.TabIndex = 1;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Type,
            this.Area,
            this.Path,
            this.Image,
            this.Depth});
            this.gvMain.GridControl = this.gcMain;
            this.gvMain.Name = "gvMain";
            this.gvMain.OptionsView.ShowGroupPanel = false;
            this.gvMain.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvMain_CustomUnboundColumnData);
            this.gvMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvMain_MouseDown);
            this.gvMain.DoubleClick += new System.EventHandler(this.gvMain_DoubleClick);
            // 
            // Type
            // 
            this.Type.Caption = "型材分类";
            this.Type.FieldName = "Type";
            this.Type.Name = "Type";
            this.Type.OptionsColumn.AllowEdit = false;
            this.Type.Visible = true;
            this.Type.VisibleIndex = 0;
            // 
            // Area
            // 
            this.Area.Caption = "型材编号";
            this.Area.FieldName = "Area";
            this.Area.Name = "Area";
            this.Area.OptionsColumn.AllowEdit = false;
            this.Area.Visible = true;
            this.Area.VisibleIndex = 1;
            // 
            // Path
            // 
            this.Path.Caption = "型材";
            this.Path.FieldName = "Path";
            this.Path.Name = "Path";
            this.Path.OptionsColumn.AllowEdit = false;
            // 
            // Image
            // 
            this.Image.Caption = "型材样式";
            this.Image.ColumnEdit = this.repositoryItemPictureEdit1;
            this.Image.FieldName = "Image";
            this.Image.Name = "Image";
            this.Image.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.Image.Visible = true;
            this.Image.VisibleIndex = 2;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.ZoomPercent = 30D;
            // 
            // Depth
            // 
            this.Depth.Caption = "型材厚度";
            this.Depth.FieldName = "Depth";
            this.Depth.Name = "Depth";
            this.Depth.Visible = true;
            this.Depth.VisibleIndex = 3;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBox1,
            this.toolStripLabel2,
            this.txtHoudu,
            this.toolStripLabel3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(415, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel1.Text = "型材类型";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "门框",
            "实体门庭",
            "玻璃门庭",
            "纱门门庭",
            "门套",
            "墙体",
            "门头",
            "门槛",
            "帽头",
            "条子",
            "线条",
            "其他"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.Text = "请选择";
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel2.Text = "门扇厚度：";
            // 
            // txtHoudu
            // 
            this.txtHoudu.Name = "txtHoudu";
            this.txtHoudu.Size = new System.Drawing.Size(100, 25);
            this.txtHoudu.TextChanged += new System.EventHandler(this.txtHoudu_TextChanged);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(54, 22);
            this.toolStripLabel3.Text = "单位mm";
            // 
            // FrmOperationNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 388);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmOperationNew";
            this.Text = "排料功能";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmOperationNew_FormClosed);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private DevExpress.XtraGrid.GridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMain;
        private DevExpress.XtraGrid.Columns.GridColumn Type;
        private DevExpress.XtraGrid.Columns.GridColumn Area;
        private DevExpress.XtraGrid.Columns.GridColumn Path;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn Image;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtHoudu;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private DevExpress.XtraGrid.Columns.GridColumn Depth;
        private DevExpress.XtraGrid.GridControl gcSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSource;
        private DevExpress.XtraGrid.Columns.GridColumn Length;
        private DevExpress.XtraGrid.Columns.GridColumn Qty;
        private DevExpress.XtraGrid.Columns.GridColumn Profile;
        private DevExpress.XtraGrid.Columns.GridColumn SArea;
        private DevExpress.XtraGrid.Columns.GridColumn SDepth;
        private DevExpress.XtraGrid.Columns.GridColumn SPath;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;

    }
}
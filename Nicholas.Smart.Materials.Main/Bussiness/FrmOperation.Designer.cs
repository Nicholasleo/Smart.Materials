namespace Nicholas.Smart.Materials.Main.Bussiness
{
    partial class FrmOperation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOperation));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvSource = new Nicholas.Smart.Materials.Main.DataGridViewSummary();
            this.gcResult = new DevExpress.XtraGrid.GridControl();
            this.gvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddProfile = new System.Windows.Forms.ToolStripButton();
            this.btnEditProfile = new System.Windows.Forms.ToolStripButton();
            this.btnDelProfile = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dgvSource);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gcResult);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(749, 357);
            this.splitContainer1.SplitterDistance = 370;
            this.splitContainer1.TabIndex = 4;
            // 
            // dgvSource
            // 
            this.dgvSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSource.DisplaySumRowHeader = true;
            this.dgvSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSource.FormatString = "";
            this.dgvSource.Location = new System.Drawing.Point(0, 0);
            this.dgvSource.Name = "dgvSource";
            this.dgvSource.RowTemplate.Height = 23;
            this.dgvSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSource.Size = new System.Drawing.Size(370, 357);
            this.dgvSource.SummaryColumns = new string[] {
        "Qty"};
            this.dgvSource.SummaryRowBackColor = System.Drawing.Color.Empty;
            this.dgvSource.SummaryRowSpace = 0;
            this.dgvSource.SummaryRowVisible = true;
            this.dgvSource.SumRowHeaderText = "合计：";
            this.dgvSource.SumRowHeaderTextBold = false;
            this.dgvSource.TabIndex = 2;
            // 
            // gcResult
            // 
            this.gcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcResult.Location = new System.Drawing.Point(0, 25);
            this.gcResult.MainView = this.gvResult;
            this.gcResult.MenuManager = this.barManager1;
            this.gcResult.Name = "gcResult";
            this.gcResult.Size = new System.Drawing.Size(375, 332);
            this.gcResult.TabIndex = 3;
            this.gcResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvResult});
            // 
            // gvResult
            // 
            this.gvResult.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gvResult.GridControl = this.gcResult;
            this.gvResult.Name = "gvResult";
            this.gvResult.OptionsView.AllowCellMerge = true;
            this.gvResult.OptionsView.ShowFooter = true;
            this.gvResult.OptionsView.ShowGroupPanel = false;
            this.gvResult.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvResult_RowStyle);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddProfile,
            this.btnEditProfile,
            this.btnDelProfile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(375, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddProfile
            // 
            this.btnAddProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnAddProfile.Image")));
            this.btnAddProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddProfile.Name = "btnAddProfile";
            this.btnAddProfile.Size = new System.Drawing.Size(76, 22);
            this.btnAddProfile.Text = "添加型材";
            this.btnAddProfile.Click += new System.EventHandler(this.btnAddProfile_Click);
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnEditProfile.Image")));
            this.btnEditProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Size = new System.Drawing.Size(76, 22);
            this.btnEditProfile.Text = "修改型材";
            this.btnEditProfile.Click += new System.EventHandler(this.btnEditProfile_Click);
            // 
            // btnDelProfile
            // 
            this.btnDelProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnDelProfile.Image")));
            this.btnDelProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelProfile.Name = "btnDelProfile";
            this.btnDelProfile.Size = new System.Drawing.Size(76, 22);
            this.btnDelProfile.Text = "删除型材";
            this.btnDelProfile.Click += new System.EventHandler(this.btnDelProfile_Click);
            // 
            // FrmOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 388);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmOperation";
            this.Text = "排料功能";
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DataGridViewSummary dgvSource;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddProfile;
        private System.Windows.Forms.ToolStripButton btnEditProfile;
        private System.Windows.Forms.ToolStripButton btnDelProfile;
        private DevExpress.XtraGrid.GridControl gcResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gvResult;

    }
}
using System.Windows.Forms.VisualStyles;

namespace Nicholas.Smart.Materials.Main
{
    partial class FrmBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBase));
            this.baseTool1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.btnMax = new System.Windows.Forms.ToolStripButton();
            this.btnMin = new System.Windows.Forms.ToolStripButton();
            this.lbTitle = new System.Windows.Forms.ToolStripLabel();
            this.baseTool2 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.baseTool1.SuspendLayout();
            this.baseTool2.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseTool1
            // 
            this.baseTool1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.baseTool1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.btnMax,
            this.btnMin,
            this.lbTitle});
            this.baseTool1.Location = new System.Drawing.Point(0, 0);
            this.baseTool1.Name = "baseTool1";
            this.baseTool1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.baseTool1.Size = new System.Drawing.Size(764, 25);
            this.baseTool1.TabIndex = 0;
            this.baseTool1.Text = "toolStrip1";
            this.baseTool1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmBase_MouseDown);
            this.baseTool1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmBase_MouseMove);
            // 
            // btnExit
            // 
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(23, 22);
            this.btnExit.ToolTipText = "关闭";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMax
            // 
            this.btnMax.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMax.Image = ((System.Drawing.Image)(resources.GetObject("btnMax.Image")));
            this.btnMax.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(23, 22);
            this.btnMax.ToolTipText = "最大化";
            this.btnMax.Click += new System.EventHandler(this.tsbMax_Click);
            // 
            // btnMin
            // 
            this.btnMin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMin.Image = ((System.Drawing.Image)(resources.GetObject("btnMin.Image")));
            this.btnMin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(23, 22);
            this.btnMin.ToolTipText = "最小化";
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lbTitle.Image = ((System.Drawing.Image)(resources.GetObject("lbTitle.Image")));
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(16, 22);
            this.lbTitle.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // baseTool2
            // 
            this.baseTool2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDel});
            this.baseTool2.Location = new System.Drawing.Point(0, 25);
            this.baseTool2.Name = "baseTool2";
            this.baseTool2.Size = new System.Drawing.Size(764, 25);
            this.baseTool2.TabIndex = 1;
            this.baseTool2.Text = "toolStrip2";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(52, 22);
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(52, 22);
            this.btnEdit.Text = "编辑";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(52, 22);
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // FrmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 469);
            this.Controls.Add(this.baseTool2);
            this.Controls.Add(this.baseTool1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBase";
            this.Text = "FrmBase";
            this.Load += new System.EventHandler(this.FrmBase_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmBase_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmBase_MouseMove);
            this.baseTool1.ResumeLayout(false);
            this.baseTool1.PerformLayout();
            this.baseTool2.ResumeLayout(false);
            this.baseTool2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip baseTool1;
        public System.Windows.Forms.ToolStripButton btnExit;
        public System.Windows.Forms.ToolStripButton btnMin;
        public System.Windows.Forms.ToolStripLabel lbTitle;
        public System.Windows.Forms.ToolStrip baseTool2;
        public System.Windows.Forms.ToolStripButton btnAdd;
        public System.Windows.Forms.ToolStripButton btnEdit;
        public System.Windows.Forms.ToolStripButton btnDel;
        public System.Windows.Forms.ToolStripButton btnMax;
    }
}
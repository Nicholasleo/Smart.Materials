namespace Nicholas.Smart.Materials.Main.Bussiness
{
    partial class FrmProfileType
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lueType = new DevExpress.XtraEditors.LookUpEdit();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDepth = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lueType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepth.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 54);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "型材类型：";
            // 
            // lueType
            // 
            this.lueType.Location = new System.Drawing.Point(89, 51);
            this.lueType.MenuManager = this.barManager1;
            this.lueType.Name = "lueType";
            this.lueType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueType.Size = new System.Drawing.Size(177, 20);
            this.lueType.TabIndex = 5;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(23, 132);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(243, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "选择文件开始导入";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "型材厚度：";
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(89, 90);
            this.txtDepth.MenuManager = this.barManager1;
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.Size = new System.Drawing.Size(58, 20);
            this.txtDepth.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(153, 93);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(20, 14);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "mm";
            // 
            // FrmProfileType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 201);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtDepth);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lueType);
            this.Controls.Add(this.labelControl1);
            this.Name = "FrmProfileType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "型材导入";
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.lueType, 0);
            this.Controls.SetChildIndex(this.btnStart, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.txtDepth, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lueType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepth.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lueType;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDepth;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}
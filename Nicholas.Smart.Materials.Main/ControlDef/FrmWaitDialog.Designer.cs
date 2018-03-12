namespace Nicholas.Smart.Materials.Main
{
    partial class FrmWaitDialog
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
            this.progressShow = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblContent = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.progressShow.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // progressShow
            // 
            this.progressShow.EditValue = 1;
            this.progressShow.Location = new System.Drawing.Point(3, 57);
            this.progressShow.Name = "progressShow";
            this.progressShow.Properties.ShowTitle = true;
            this.progressShow.Properties.Step = 5;
            this.progressShow.Size = new System.Drawing.Size(226, 18);
            this.progressShow.TabIndex = 0;
            // 
            // lblContent
            // 
            this.lblContent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblContent.Location = new System.Drawing.Point(3, 1);
            this.lblContent.MaximumSize = new System.Drawing.Size(230, 50);
            this.lblContent.MinimumSize = new System.Drawing.Size(230, 50);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(230, 50);
            this.lblContent.TabIndex = 1;
            this.lblContent.Text = "Content";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(74, 81);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            // 
            // FrmWaitDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 107);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.progressShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmWaitDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据加载";
            ((System.ComponentModel.ISupportInitialize)(this.progressShow.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl progressShow;
        private DevExpress.XtraEditors.LabelControl lblContent;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}
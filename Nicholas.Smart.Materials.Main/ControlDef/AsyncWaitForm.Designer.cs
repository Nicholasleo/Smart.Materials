namespace Nicholas.Smart.Materials.Main.ControlDef
{
    partial class AsyncWaitForm
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
            this.lblContent = new DevExpress.XtraEditors.MemoEdit();
            this.pgBar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgBar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblContent
            // 
            this.lblContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContent.EditValue = "数据加载中,请稍候...";
            this.lblContent.Location = new System.Drawing.Point(15, 14);
            this.lblContent.Name = "lblContent";
            this.lblContent.Properties.AllowFocused = false;
            this.lblContent.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblContent.Properties.Appearance.Options.UseBackColor = true;
            this.lblContent.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblContent.Properties.ReadOnly = true;
            this.lblContent.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.lblContent.Size = new System.Drawing.Size(297, 42);
            this.lblContent.TabIndex = 12;
            this.lblContent.TabStop = false;
            // 
            // pgBar
            // 
            this.pgBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgBar.EditValue = "";
            this.pgBar.Location = new System.Drawing.Point(14, 64);
            this.pgBar.Name = "pgBar";
            this.pgBar.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.pgBar.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.pgBar.Properties.EndColor = System.Drawing.Color.Lime;
            this.pgBar.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pgBar.Properties.ProgressAnimationMode = DevExpress.Utils.Drawing.ProgressAnimationMode.Cycle;
            this.pgBar.Properties.ShowTitle = true;
            this.pgBar.Size = new System.Drawing.Size(297, 21);
            this.pgBar.TabIndex = 11;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(117, 92);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 27);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确定";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // AsyncWaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 125);
            this.ControlBox = false;
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.pgBar);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AsyncWaitForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "加载数据";
            ((System.ComponentModel.ISupportInitialize)(this.lblContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgBar.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit lblContent;
        private DevExpress.XtraEditors.MarqueeProgressBarControl pgBar;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.Timer timer;

    }
}
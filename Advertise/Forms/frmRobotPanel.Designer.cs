namespace Advertise.Forms
{
    partial class frmRobotPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRobotPanel));
            this.lblSimcard = new System.Windows.Forms.Label();
            this.lblBaseInfo = new System.Windows.Forms.Label();
            this.lblMatchRegion = new System.Windows.Forms.Label();
            this.lblSetting = new System.Windows.Forms.Label();
            this.grp = new DevComponents.DotNetBar.PanelEx();
            this.picSimcard = new System.Windows.Forms.PictureBox();
            this.lblReport = new System.Windows.Forms.Label();
            this.picReport = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picBaseInfo = new System.Windows.Forms.PictureBox();
            this.picMatchRegion = new System.Windows.Forms.PictureBox();
            this.fPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSimcard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBaseInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMatchRegion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSimcard
            // 
            this.lblSimcard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSimcard.AutoSize = true;
            this.lblSimcard.BackColor = System.Drawing.Color.Transparent;
            this.lblSimcard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSimcard.ForeColor = System.Drawing.Color.Black;
            this.lblSimcard.Location = new System.Drawing.Point(24, 108);
            this.lblSimcard.Name = "lblSimcard";
            this.lblSimcard.Size = new System.Drawing.Size(107, 20);
            this.lblSimcard.TabIndex = 1;
            this.lblSimcard.Text = "مدیریت سیمکارت ها";
            this.lblSimcard.Click += new System.EventHandler(this.lblSimcard_Click);
            this.lblSimcard.MouseEnter += new System.EventHandler(this.lblSimcard_MouseEnter);
            this.lblSimcard.MouseLeave += new System.EventHandler(this.lblSimcard_MouseLeave);
            // 
            // lblBaseInfo
            // 
            this.lblBaseInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBaseInfo.AutoSize = true;
            this.lblBaseInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblBaseInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBaseInfo.ForeColor = System.Drawing.Color.Black;
            this.lblBaseInfo.Location = new System.Drawing.Point(4, 221);
            this.lblBaseInfo.Name = "lblBaseInfo";
            this.lblBaseInfo.Size = new System.Drawing.Size(147, 20);
            this.lblBaseInfo.TabIndex = 1;
            this.lblBaseInfo.Text = "دریافت اطلاعات پایه از دیوار";
            this.lblBaseInfo.Click += new System.EventHandler(this.lblBaseInfo_Click);
            this.lblBaseInfo.MouseEnter += new System.EventHandler(this.lblBaseInfo_MouseEnter);
            this.lblBaseInfo.MouseLeave += new System.EventHandler(this.lblBaseInfo_MouseLeave);
            // 
            // lblMatchRegion
            // 
            this.lblMatchRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMatchRegion.AutoSize = true;
            this.lblMatchRegion.BackColor = System.Drawing.Color.Transparent;
            this.lblMatchRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMatchRegion.ForeColor = System.Drawing.Color.Black;
            this.lblMatchRegion.Location = new System.Drawing.Point(7, 340);
            this.lblMatchRegion.Name = "lblMatchRegion";
            this.lblMatchRegion.Size = new System.Drawing.Size(144, 20);
            this.lblMatchRegion.TabIndex = 1;
            this.lblMatchRegion.Text = "تطابق مناطق دیوار با سیستم";
            this.lblMatchRegion.Click += new System.EventHandler(this.lblMatchRegion_Click);
            this.lblMatchRegion.MouseEnter += new System.EventHandler(this.lblMatchRegion_MouseEnter);
            this.lblMatchRegion.MouseLeave += new System.EventHandler(this.lblMatchRegion_MouseLeave);
            // 
            // lblSetting
            // 
            this.lblSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSetting.AutoSize = true;
            this.lblSetting.BackColor = System.Drawing.Color.Transparent;
            this.lblSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetting.ForeColor = System.Drawing.Color.Black;
            this.lblSetting.Location = new System.Drawing.Point(47, 588);
            this.lblSetting.Name = "lblSetting";
            this.lblSetting.Size = new System.Drawing.Size(47, 20);
            this.lblSetting.TabIndex = 1;
            this.lblSetting.Text = "تنظیمات";
            this.lblSetting.Click += new System.EventHandler(this.lblSetting_Click);
            this.lblSetting.MouseEnter += new System.EventHandler(this.lblSetting_MouseEnter);
            this.lblSetting.MouseLeave += new System.EventHandler(this.lblSetting_MouseLeave);
            // 
            // grp
            // 
            this.grp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grp.Controls.Add(this.picSimcard);
            this.grp.Controls.Add(this.lblReport);
            this.grp.Controls.Add(this.lblSetting);
            this.grp.Controls.Add(this.lblBaseInfo);
            this.grp.Controls.Add(this.picReport);
            this.grp.Controls.Add(this.pictureBox1);
            this.grp.Controls.Add(this.lblMatchRegion);
            this.grp.Controls.Add(this.lblSimcard);
            this.grp.Controls.Add(this.picBaseInfo);
            this.grp.Controls.Add(this.picMatchRegion);
            this.grp.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp.Location = new System.Drawing.Point(825, 31);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(152, 620);
            this.grp.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.grp.Style.BackColor1.Color = System.Drawing.Color.White;
            this.grp.Style.BackColor2.Color = System.Drawing.Color.White;
            this.grp.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.grp.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.grp.Style.BorderWidth = 2;
            this.grp.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grp.Style.GradientAngle = 90;
            this.grp.TabIndex = 10;
            // 
            // picSimcard
            // 
            this.picSimcard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSimcard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSimcard.Image = global::Advertise.Properties.Resources._53;
            this.picSimcard.Location = new System.Drawing.Point(34, 22);
            this.picSimcard.Name = "picSimcard";
            this.picSimcard.Size = new System.Drawing.Size(82, 81);
            this.picSimcard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSimcard.TabIndex = 0;
            this.picSimcard.TabStop = false;
            this.picSimcard.Click += new System.EventHandler(this.picSimcard_Click);
            // 
            // lblReport
            // 
            this.lblReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReport.AutoSize = true;
            this.lblReport.BackColor = System.Drawing.Color.Transparent;
            this.lblReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblReport.ForeColor = System.Drawing.Color.Black;
            this.lblReport.Location = new System.Drawing.Point(34, 468);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(82, 20);
            this.lblReport.TabIndex = 1;
            this.lblReport.Text = "گزارش آگهی ها";
            this.lblReport.Click += new System.EventHandler(this.lblReport_Click);
            this.lblReport.MouseEnter += new System.EventHandler(this.lblReport_MouseEnter);
            this.lblReport.MouseLeave += new System.EventHandler(this.lblReport_MouseLeave);
            // 
            // picReport
            // 
            this.picReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picReport.Image = global::Advertise.Properties.Resources._043;
            this.picReport.Location = new System.Drawing.Point(34, 380);
            this.picReport.Name = "picReport";
            this.picReport.Size = new System.Drawing.Size(82, 81);
            this.picReport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picReport.TabIndex = 0;
            this.picReport.TabStop = false;
            this.picReport.Click += new System.EventHandler(this.picReport_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Advertise.Properties.Resources._122;
            this.pictureBox1.Location = new System.Drawing.Point(34, 502);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // picBaseInfo
            // 
            this.picBaseInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBaseInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBaseInfo.Image = global::Advertise.Properties.Resources._10;
            this.picBaseInfo.Location = new System.Drawing.Point(34, 134);
            this.picBaseInfo.Name = "picBaseInfo";
            this.picBaseInfo.Size = new System.Drawing.Size(82, 81);
            this.picBaseInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBaseInfo.TabIndex = 0;
            this.picBaseInfo.TabStop = false;
            this.picBaseInfo.Click += new System.EventHandler(this.picBaseInfo_Click);
            // 
            // picMatchRegion
            // 
            this.picMatchRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMatchRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMatchRegion.Image = global::Advertise.Properties.Resources._34;
            this.picMatchRegion.Location = new System.Drawing.Point(34, 252);
            this.picMatchRegion.Name = "picMatchRegion";
            this.picMatchRegion.Size = new System.Drawing.Size(82, 81);
            this.picMatchRegion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMatchRegion.TabIndex = 0;
            this.picMatchRegion.TabStop = false;
            this.picMatchRegion.Click += new System.EventHandler(this.picMatchRegion_Click);
            // 
            // fPanel
            // 
            this.fPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.fPanel.Location = new System.Drawing.Point(5, 34);
            this.fPanel.Name = "fPanel";
            this.fPanel.Size = new System.Drawing.Size(814, 617);
            this.fPanel.TabIndex = 14;
            // 
            // frmRobotPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(989, 663);
            this.ControlBox = false;
            this.Controls.Add(this.fPanel);
            this.Controls.Add(this.grp);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(991, 600);
            this.Name = "frmRobotPanel";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRobotPanel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRobotPanel_KeyDown);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSimcard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBaseInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMatchRegion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picSimcard;
        private System.Windows.Forms.PictureBox picBaseInfo;
        private System.Windows.Forms.Label lblSimcard;
        private System.Windows.Forms.Label lblBaseInfo;
        private System.Windows.Forms.PictureBox picMatchRegion;
        private System.Windows.Forms.Label lblMatchRegion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSetting;
        private DevComponents.DotNetBar.PanelEx grp;
        private System.Windows.Forms.FlowLayoutPanel fPanel;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.PictureBox picReport;
    }
}
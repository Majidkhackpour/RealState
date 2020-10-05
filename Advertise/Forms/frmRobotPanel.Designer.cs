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
            this.picSimcard = new System.Windows.Forms.PictureBox();
            this.picBaseInfo = new System.Windows.Forms.PictureBox();
            this.lblSimcard = new System.Windows.Forms.Label();
            this.lblBaseInfo = new System.Windows.Forms.Label();
            this.picMatchRegion = new System.Windows.Forms.PictureBox();
            this.lblMatchRegion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picSimcard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBaseInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMatchRegion)).BeginInit();
            this.SuspendLayout();
            // 
            // picSimcard
            // 
            this.picSimcard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSimcard.Image = global::Advertise.Properties.Resources._53;
            this.picSimcard.Location = new System.Drawing.Point(819, 53);
            this.picSimcard.Name = "picSimcard";
            this.picSimcard.Size = new System.Drawing.Size(100, 95);
            this.picSimcard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSimcard.TabIndex = 0;
            this.picSimcard.TabStop = false;
            this.picSimcard.Click += new System.EventHandler(this.picSimcard_Click);
            // 
            // picBaseInfo
            // 
            this.picBaseInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBaseInfo.Image = global::Advertise.Properties.Resources._10;
            this.picBaseInfo.Location = new System.Drawing.Point(819, 218);
            this.picBaseInfo.Name = "picBaseInfo";
            this.picBaseInfo.Size = new System.Drawing.Size(100, 95);
            this.picBaseInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBaseInfo.TabIndex = 0;
            this.picBaseInfo.TabStop = false;
            this.picBaseInfo.Click += new System.EventHandler(this.picBaseInfo_Click);
            // 
            // lblSimcard
            // 
            this.lblSimcard.AutoSize = true;
            this.lblSimcard.BackColor = System.Drawing.Color.Transparent;
            this.lblSimcard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSimcard.ForeColor = System.Drawing.Color.Silver;
            this.lblSimcard.Location = new System.Drawing.Point(816, 163);
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
            this.lblBaseInfo.AutoSize = true;
            this.lblBaseInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblBaseInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBaseInfo.ForeColor = System.Drawing.Color.Silver;
            this.lblBaseInfo.Location = new System.Drawing.Point(796, 329);
            this.lblBaseInfo.Name = "lblBaseInfo";
            this.lblBaseInfo.Size = new System.Drawing.Size(147, 20);
            this.lblBaseInfo.TabIndex = 1;
            this.lblBaseInfo.Text = "دریافت اطلاعات پایه از دیوار";
            this.lblBaseInfo.Click += new System.EventHandler(this.lblBaseInfo_Click);
            this.lblBaseInfo.MouseEnter += new System.EventHandler(this.lblBaseInfo_MouseEnter);
            this.lblBaseInfo.MouseLeave += new System.EventHandler(this.lblBaseInfo_MouseLeave);
            // 
            // picMatchRegion
            // 
            this.picMatchRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMatchRegion.Image = global::Advertise.Properties.Resources._34;
            this.picMatchRegion.Location = new System.Drawing.Point(772, 391);
            this.picMatchRegion.Name = "picMatchRegion";
            this.picMatchRegion.Size = new System.Drawing.Size(100, 95);
            this.picMatchRegion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMatchRegion.TabIndex = 0;
            this.picMatchRegion.TabStop = false;
            this.picMatchRegion.Click += new System.EventHandler(this.picMatchRegion_Click);
            // 
            // lblMatchRegion
            // 
            this.lblMatchRegion.AutoSize = true;
            this.lblMatchRegion.BackColor = System.Drawing.Color.Transparent;
            this.lblMatchRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMatchRegion.ForeColor = System.Drawing.Color.Silver;
            this.lblMatchRegion.Location = new System.Drawing.Point(752, 502);
            this.lblMatchRegion.Name = "lblMatchRegion";
            this.lblMatchRegion.Size = new System.Drawing.Size(144, 20);
            this.lblMatchRegion.TabIndex = 1;
            this.lblMatchRegion.Text = "تطابق مناطق دیوار با سیستم";
            this.lblMatchRegion.Click += new System.EventHandler(this.lblMatchRegion_Click);
            this.lblMatchRegion.MouseEnter += new System.EventHandler(this.lblMatchRegion_MouseEnter);
            this.lblMatchRegion.MouseLeave += new System.EventHandler(this.lblMatchRegion_MouseLeave);
            // 
            // frmRobotPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Advertise.Properties.Resources.D1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(989, 598);
            this.ControlBox = false;
            this.Controls.Add(this.lblMatchRegion);
            this.Controls.Add(this.lblBaseInfo);
            this.Controls.Add(this.lblSimcard);
            this.Controls.Add(this.picMatchRegion);
            this.Controls.Add(this.picBaseInfo);
            this.Controls.Add(this.picSimcard);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRobotPanel_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picSimcard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBaseInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMatchRegion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picSimcard;
        private System.Windows.Forms.PictureBox picBaseInfo;
        private System.Windows.Forms.Label lblSimcard;
        private System.Windows.Forms.Label lblBaseInfo;
        private System.Windows.Forms.PictureBox picMatchRegion;
        private System.Windows.Forms.Label lblMatchRegion;
    }
}
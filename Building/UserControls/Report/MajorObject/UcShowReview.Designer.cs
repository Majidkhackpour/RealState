
namespace Building.UserControls.Report.MajorObject
{
    partial class UcShowReview
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupPanel58 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.fPanelMath = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMatchNone = new System.Windows.Forms.Label();
            this.groupPanel58.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel58
            // 
            this.groupPanel58.CanvasColor = System.Drawing.Color.Transparent;
            this.groupPanel58.Controls.Add(this.fPanelMath);
            this.groupPanel58.Controls.Add(this.label4);
            this.groupPanel58.Controls.Add(this.lblMatchNone);
            this.groupPanel58.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupPanel58.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel58.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel58.Location = new System.Drawing.Point(0, 0);
            this.groupPanel58.Name = "groupPanel58";
            this.groupPanel58.Size = new System.Drawing.Size(275, 188);
            // 
            // 
            // 
            this.groupPanel58.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(221)))), ((int)(((byte)(251)))));
            this.groupPanel58.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(221)))), ((int)(((byte)(251)))));
            this.groupPanel58.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel58.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(221)))), ((int)(((byte)(251)))));
            this.groupPanel58.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(221)))), ((int)(((byte)(251)))));
            this.groupPanel58.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel58.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel58.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel58.Style.CornerDiameter = 15;
            this.groupPanel58.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            // 
            // 
            // 
            this.groupPanel58.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel58.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel58.TabIndex = 55722;
            // 
            // fPanelMath
            // 
            this.fPanelMath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fPanelMath.AutoScroll = true;
            this.fPanelMath.Location = new System.Drawing.Point(1, 20);
            this.fPanelMath.Name = "fPanelMath";
            this.fPanelMath.Size = new System.Drawing.Size(269, 160);
            this.fPanelMath.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.label4.Location = new System.Drawing.Point(144, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "گزارش بازدیدهای ماه جاری";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMatchNone
            // 
            this.lblMatchNone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMatchNone.BackColor = System.Drawing.Color.Transparent;
            this.lblMatchNone.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMatchNone.ForeColor = System.Drawing.Color.Gray;
            this.lblMatchNone.Location = new System.Drawing.Point(-3, 83);
            this.lblMatchNone.Name = "lblMatchNone";
            this.lblMatchNone.Size = new System.Drawing.Size(278, 20);
            this.lblMatchNone.TabIndex = 8;
            this.lblMatchNone.Text = "داده ای برای نمایش وجود ندارد";
            this.lblMatchNone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UcShowReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel58);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcShowReview";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(275, 188);
            this.groupPanel58.ResumeLayout(false);
            this.groupPanel58.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel58;
        private System.Windows.Forms.FlowLayoutPanel fPanelMath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMatchNone;
    }
}

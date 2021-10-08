﻿
namespace Building.UserControls
{
    partial class UcBuildingImages
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnDelImage = new DevComponents.DotNetBar.ButtonX();
            this.btnInsImage = new DevComponents.DotNetBar.ButtonX();
            this.fPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnDelImage);
            this.groupPanel1.Controls.Add(this.btnInsImage);
            this.groupPanel1.Controls.Add(this.fPanel);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(465, 356);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 2;
            this.groupPanel1.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel1.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 2;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 2;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 2;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 10;
            this.groupPanel1.Text = "گالری تصاویر";
            // 
            // btnDelImage
            // 
            this.btnDelImage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelImage.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnDelImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelImage.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnDelImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelImage.Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDelImage.Location = new System.Drawing.Point(163, 298);
            this.btnDelImage.Name = "btnDelImage";
            this.btnDelImage.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnDelImage.Size = new System.Drawing.Size(150, 27);
            this.btnDelImage.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnDelImage.TabIndex = 5;
            this.btnDelImage.Text = "حذف تصویر(های) انتخاب شده";
            this.btnDelImage.TextColor = System.Drawing.Color.White;
            this.btnDelImage.Click += new System.EventHandler(this.btnDelImage_Click);
            // 
            // btnInsImage
            // 
            this.btnInsImage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInsImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsImage.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnInsImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnInsImage.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnInsImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsImage.Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnInsImage.Location = new System.Drawing.Point(319, 298);
            this.btnInsImage.Name = "btnInsImage";
            this.btnInsImage.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnInsImage.Size = new System.Drawing.Size(134, 27);
            this.btnInsImage.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnInsImage.TabIndex = 4;
            this.btnInsImage.Text = "افزودن تصویر(های) جدید";
            this.btnInsImage.TextColor = System.Drawing.Color.White;
            this.btnInsImage.Click += new System.EventHandler(this.btnInsImage_Click);
            // 
            // fPanel
            // 
            this.fPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fPanel.BackColor = System.Drawing.Color.Transparent;
            this.fPanel.Location = new System.Drawing.Point(3, 3);
            this.fPanel.Name = "fPanel";
            this.fPanel.Size = new System.Drawing.Size(453, 290);
            this.fPanel.TabIndex = 6;
            // 
            // UcBuildingImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPanel1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcBuildingImages";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(465, 356);
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnDelImage;
        private DevComponents.DotNetBar.ButtonX btnInsImage;
        private System.Windows.Forms.FlowLayoutPanel fPanel;
    }
}

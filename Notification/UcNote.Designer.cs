
namespace Notification
{
    partial class UcNote
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
            this.groupPanel67 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblTile = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.groupPanel67.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel67
            // 
            this.groupPanel67.CanvasColor = System.Drawing.Color.Transparent;
            this.groupPanel67.Controls.Add(this.lblContent);
            this.groupPanel67.Controls.Add(this.lblTile);
            this.groupPanel67.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupPanel67.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel67.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel67.Location = new System.Drawing.Point(0, 0);
            this.groupPanel67.Name = "groupPanel67";
            this.groupPanel67.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupPanel67.Size = new System.Drawing.Size(484, 72);
            // 
            // 
            // 
            this.groupPanel67.Style.BackColor = System.Drawing.Color.White;
            this.groupPanel67.Style.BackColor2 = System.Drawing.Color.White;
            this.groupPanel67.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel67.Style.BorderColor = System.Drawing.Color.White;
            this.groupPanel67.Style.BorderColor2 = System.Drawing.Color.White;
            this.groupPanel67.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel67.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel67.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel67.Style.CornerDiameter = 10;
            this.groupPanel67.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            // 
            // 
            // 
            this.groupPanel67.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel67.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel67.TabIndex = 55729;
            // 
            // lblTile
            // 
            this.lblTile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTile.BackColor = System.Drawing.Color.Transparent;
            this.lblTile.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTile.ForeColor = System.Drawing.Color.Black;
            this.lblTile.Location = new System.Drawing.Point(3, 0);
            this.lblTile.Name = "lblTile";
            this.lblTile.Size = new System.Drawing.Size(478, 26);
            this.lblTile.TabIndex = 0;
            this.lblTile.Text = "عنوان:";
            this.lblTile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblContent
            // 
            this.lblContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContent.BackColor = System.Drawing.Color.Transparent;
            this.lblContent.Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblContent.ForeColor = System.Drawing.Color.Black;
            this.lblContent.Location = new System.Drawing.Point(3, 26);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(478, 38);
            this.lblContent.TabIndex = 0;
            this.lblContent.Text = "شرح";
            // 
            // UcNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel67);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcNote";
            this.Size = new System.Drawing.Size(484, 72);
            this.groupPanel67.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel67;
        private System.Windows.Forms.Label lblTile;
        private System.Windows.Forms.Label lblContent;
    }
}
